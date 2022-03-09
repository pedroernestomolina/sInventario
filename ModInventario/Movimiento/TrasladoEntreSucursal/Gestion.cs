using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Movimiento.TrasladoEntreSucursal
{
    
    public class Gestion: IGestion
    {

        public enum enumMetBusq { SinDefinir = -1, PorCodgo = 1, PorNombre, PorReferencia };


        private bool _procesarIsOk;
        private Producto.Deposito.Listar.Gestion _gestionExistencia;
        private Analisis.General.Gestion _gestionAnalisisGeneral;
        private Analisis.Detallado.Gestion _gestionAnalisisDetallado;
        private Analisis.Existencia.Gestion _gestionAnalisisExistencia;
        private List<OOB.LibInventario.Concepto.Ficha> lConcepto;
        private List<OOB.LibInventario.Sucursal.Ficha> lSucOrigen;
        private List<OOB.LibInventario.Sucursal.Ficha> lSucDestino;
        private List<OOB.LibInventario.Departamento.Ficha> lDepartamento;
        private BindingSource bsConcepto;
        private BindingSource bsSucOrigen;
        private BindingSource bsSucDestino;
        private BindingSource bsDepartamento;
        private Movimiento.data miData;
        private GestionDetalle _gestionDetalle;
        private decimal tasaCambio;
        private bool isCerrarOk;
        private OOB.LibInventario.Sucursal.Ficha sucOrigen;
        private OOB.LibInventario.Sucursal.Ficha sucDestino;
        private OOB.LibInventario.Departamento.Ficha _departamento;
        private FiltrosGen.IAdmSelecciona _gAdmSelPrd;


        public bool ProcesarDocIsOk { get { return _procesarIsOk; } }
        public bool IsCerrarOk { get { return isCerrarOk; } }
        public string TipoMovimiento { get {return "TRASLADO";} }
        public decimal MontoMovimiento { get { return _gestionDetalle.MontoMovimiento; } }
        public string ItemsMovimiento  { get { return _gestionDetalle.ItemsMovimiento; } }
        public bool Habilitar_DepDestino { get { return true; } }
        public bool VisualizarColumnaTipoMovimiento { get { return false; } }
        public BindingSource ConceptoSource { get { return bsConcepto; } }
        public BindingSource SucursalSource { get { return null; } }
        public BindingSource DepOrigenSource { get { return bsSucOrigen; } }
        public BindingSource DepDestinoSource { get { return bsSucDestino; } }
        public BindingSource DepartamentoSource { get { return bsDepartamento; } }
        public string IdSucursal { get { return miData.IdSucursal; } set { miData.IdSucursal = value; } }
        public string IdConcepto { get { return miData.IdConcepto; } set { miData.IdConcepto = value; } }
        public string IdDepOrigen
        { 
            get { return miData.IdDepOrigen; } 
            set { miData.IdDepOrigen = value;  }
        } 
        public string IdDepDestino 
        { 
            get { return miData.IdDepDestino; }
            set { miData.IdDepDestino = value; }
        }
        public string AutorizadoPor { get { return miData.AutorizadoPor; } set { miData.AutorizadoPor = value; } }
        public string Motivo { get { return miData.Motivo; } set { miData.Motivo = value; } }
        public DateTime FechaMov { get { return miData.Fecha; } set { miData.Fecha = value; } }
        public bool CargarDetallesIsOk { get; set; }
        

        public Gestion(FiltrosGen.IAdmSelecciona admSelPrd)
        {
            _gAdmSelPrd = admSelPrd;
            _gestionDetalle = new GestionDetalle();
            _gestionExistencia = new Producto.Deposito.Listar.Gestion();
            _gestionAnalisisGeneral = new Analisis.General.Gestion();
            _gestionAnalisisGeneral.ItemSeleccionado+=_gestionAnalisisGeneral_ItemSeleccionado;
            _gestionAnalisisDetallado = new Analisis.Detallado.Gestion();
            _gestionAnalisisExistencia = new Analisis.Existencia.Gestion();
            miData = new Movimiento.data();

            lConcepto = new List<OOB.LibInventario.Concepto.Ficha>();
            lSucOrigen = new List<OOB.LibInventario.Sucursal.Ficha>();
            lSucDestino = new List<OOB.LibInventario.Sucursal.Ficha>();
            lDepartamento = new List<OOB.LibInventario.Departamento.Ficha>();
            bsConcepto = new BindingSource();
            bsSucOrigen = new BindingSource();
            bsSucDestino = new BindingSource();
            bsDepartamento = new BindingSource();
            bsConcepto.DataSource = lConcepto;
            bsSucOrigen.DataSource = lSucOrigen;
            bsSucDestino.DataSource = lSucDestino;
            bsDepartamento.DataSource = lDepartamento;
        }


        private void _gestionAnalisisGeneral_ItemSeleccionado(object sender, EventArgs e)
        {
            var item = _gestionAnalisisGeneral.Item;
            _gestionDetalle.AgregarItem(item, sucOrigen.autoDepositoPrincipal);
        }

        MovimientoFrm frm;
        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                if (frm == null) 
                {
                    frm = new MovimientoFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        public bool CargarData()
        {
            var rt = true;

            var rt1 = Sistema.MyData.Sucursal_GetLista();
            if (rt1.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return false;
            }
            var rt2 = Sistema.MyData.Concepto_GetLista() ;
            if (rt2.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt2.Mensaje);
                return false;
            }
            var rt4 = Sistema.MyData.Configuracion_TasaCambioActual();
            if (rt4.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt4.Mensaje);
                return false;
            }
            var rt5 = Sistema.MyData.Departamento_GetLista();
            if (rt5.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt5.Mensaje);
                return false;
            }
            var rt6 = Sistema.MyData.Configuracion_PreferenciaBusqueda();
            if (rt6.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt6.Mensaje);
                return false;
            }
            switch (rt6.Entidad)
            {
                case OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda.PorCodigo:
                    setMetBusqByCodigo();
                    break;
                case OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda.PorNombre:
                    setMetBusqByNombre();
                    break;
                case OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda.PorReferencia:
                    setMetBusqByReferencia();
                    break;
            }


            tasaCambio = rt4.Entidad;
            _gestionDetalle.setTasaCambio(tasaCambio);

            lConcepto.Clear();
            lConcepto.AddRange(rt2.Lista.OrderBy(o=>o.nombre).ToList());
            bsConcepto.CurrencyManager.Refresh();

            lSucOrigen.Clear();
            lSucOrigen.AddRange(rt1.Lista.OrderBy(o=>o.nombre).ToList());
            bsSucOrigen.CurrencyManager.Refresh();

            lSucDestino.Clear();
            lSucDestino.AddRange(rt1.Lista.OrderBy(o=>o.nombre).ToList());
            bsSucDestino.CurrencyManager.Refresh();

            lDepartamento.Clear();
            lDepartamento.AddRange(rt5.Lista.OrderBy(o => o.nombre).ToList());
            bsDepartamento.CurrencyManager.Refresh();

            return rt;
        }

        public void Limpiar()
        {
            _procesarIsOk = false;
            CargarDetallesIsOk = false;
            isCerrarOk = false;
            miData.Limpiar();
            _gestionDetalle.Limpiar();
            _departamento = null;
        }

        public bool LimpiarVistaIsOk()
        {
            var rt = true;

            var msg = MessageBox.Show("Limpiar Cambios Realizados ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.No) { return false; }

            Limpiar();

            return rt;
        }

        public void EliminarItem()
        {
            _gestionDetalle.EliminarItem();
        }

        public void EditarItem()
        {
            _gestionDetalle.EditarItem(IdDepOrigen);
        }

        public void Procesar()
        {
            _procesarIsOk = false;
            miData.detalle = _gestionDetalle.Detalle;
            IdConcepto = "0000000008";
            if (miData.Verificar())
            {
                if (IdDepOrigen == "")
                {
                    Helpers.Msg.Error("[ Sucursal Origen ] No Seleccionada");
                    return;
                }
                if (IdDepDestino== "")
                {
                    Helpers.Msg.Error("[ Sucursal Destino ] No Seleccionada");
                    return;
                }

                var msg = MessageBox.Show("Procesar Documento ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.No)
                    return;

                if (!RegistrarDocumento()) 
                {
                    return;
                }

                Helpers.Msg.AgregarOk();
                isCerrarOk = true;
                _procesarIsOk = true;
            }
        }

        private bool RegistrarDocumento()
        {
            var concepto = lConcepto.FirstOrDefault(m => m.auto == miData.IdConcepto);
            var movOOB = new OOB.LibInventario.Movimiento.Traslado.Insertar.FichaMov()
            {
                autoConcepto = miData.IdConcepto,
                autoDepositoDestino = sucDestino.autoDepositoPrincipal,
                autoDepositoOrigen = sucOrigen.autoDepositoPrincipal,
                autoRemision = "",
                autorizado = miData.AutorizadoPor,
                autoUsuario = Sistema.UsuarioP.autoUsu,
                cierreFtp = "",
                codConcepto = concepto.codigo,
                codDepositoDestino = sucDestino.codigoDepositoPrincipal,
                codDepositoOrigen = sucOrigen.codigoDepositoPrincipal,
                codigoSucursal = sucOrigen.codigo,
                codUsuario = Sistema.UsuarioP.codigoUsu,
                desConcepto = concepto.nombre,
                desDepositoDestino = sucDestino.nombreDepositoPrincipal,
                desDepositoOrigen = sucOrigen.nombreDepositoPrincipal,
                documentoNombre = "TRANSFERENCIA",
                estacion = Environment.MachineName,
                estatusAnulado = "0",
                estatusCierreContable = "0",
                nota = miData.Motivo,
                renglones = _gestionDetalle.TotalItems,
                situacion = "Procesado",
                tipo = "03",
                total = MontoMovimiento,
                usuario = Sistema.UsuarioP.nombreUsu,
                factorCambio = tasaCambio,
                montoDivisa = Math.Round(MontoMovimiento / tasaCambio, 2, MidpointRounding.AwayFromZero),
            };
            var detOOB= _gestionDetalle.Detalle.ListaItems.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.Traslado.Insertar.FichaMovDetalle()
                {
                    autoDepartamento = s.FichaPrd.identidad.autoDepartamento,
                    autoGrupo = s.FichaPrd.identidad.autoGrupo,
                    autoProducto = s.FichaPrd.AutoId,
                    cantidad = s.Cantidad,
                    cantidadBono = 0,
                    cantidadUnd = s.CantidadUnd,
                    categoria = s.FichaPrd.Categoria,
                    codigoProducto = s.FichaPrd.CodigoPrd,
                    contEmpaque = s.FichaPrd.identidad.contenidoCompra,
                    costoCompra = s.CostoMonedaLocal,
                    costoUnd = s.CostoUndMonedaLocal,
                    decimales = s.FichaPrd.Decimales,
                    empaque = s.FichaPrd.identidad.empaqueCompra,
                    estatusAnulado = "0",
                    estatusUnidad = s.TipoEmpaqueSeleccionado == enumerados.enumTipoEmpaque.PorUnidad ? "1" : "0",
                    nombreProducto = s.DescripcionPrd,
                    signo = 1,
                    tipo = "03",
                    total = s.ImporteMonedaLocal,
                };
                return rg;
            }).ToList();
            var depOOB = _gestionDetalle.Detalle.ListaItems.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.Traslado.Insertar.FichaMovDeposito()
                {
                    autoDeposito = sucOrigen.autoDepositoPrincipal,
                    nombreProducto = s.DescripcionPrd,
                    autoDepositoDestino = sucDestino.autoDepositoPrincipal,
                    autoProducto = s.FichaPrd.AutoId,
                    cantidadUnd = s.CantidadUnd,
                    nombreDeposito = sucOrigen.nombreDepositoPrincipal,
                    depositoDestino = sucDestino.nombreDepositoPrincipal,
                };
                return rg;
            }).ToList();
            var kardexS = _gestionDetalle.Detalle.ListaItems.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.Traslado.Insertar.FichaMovKardex()
                {
                    autoConcepto = concepto.auto,
                    autoDeposito = sucOrigen.autoDepositoPrincipal ,
                    autoProducto = s.FichaPrd.AutoId,
                    cantidad = s.Cantidad,
                    cantidadBono = 0.0m,
                    cantidadUnd = s.CantidadUnd,
                    codigoMov = "03",
                    codigoConcepto = concepto.codigo,
                    codigoDeposito = sucOrigen.codigoDepositoPrincipal,
                    codigoSucursal = sucOrigen.codigo,
                    costoUnd = s.CostoUndMonedaLocal,
                    entidad = "",
                    estatusAnulado = "0",
                    modulo = "Inventario",
                    nombreConcepto = concepto.nombre,
                    nombreDeposito = sucOrigen.nombreDepositoPrincipal ,
                    nota = "",
                    precioUnd = 0.0m,
                    siglasMov = "TRA",
                    signoMov = -1,
                    total = s.ImporteMonedaLocal,
                };
                return rg;
            }).ToList();
            var kardexE = _gestionDetalle.Detalle.ListaItems.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.Traslado.Insertar.FichaMovKardex()
                {
                    autoConcepto = concepto.auto,
                    autoDeposito = sucDestino.autoDepositoPrincipal ,
                    autoProducto = s.FichaPrd.AutoId,
                    cantidad = s.Cantidad,
                    cantidadBono = 0.0m,
                    cantidadUnd = s.CantidadUnd,
                    codigoMov = "03",
                    codigoConcepto = concepto.codigo,
                    codigoDeposito = sucDestino.codigoDepositoPrincipal ,
                    codigoSucursal = sucOrigen.codigo,
                    costoUnd = s.CostoUndMonedaLocal,
                    entidad = "",
                    estatusAnulado = "0",
                    modulo = "Inventario",
                    nombreConcepto = concepto.nombre,
                    nombreDeposito = sucDestino.nombreDepositoPrincipal ,
                    nota = "",
                    precioUnd = 0.0m,
                    siglasMov = "TRA",
                    signoMov = 1,
                    total = s.ImporteMonedaLocal,
                };
                return rg;
            }).ToList();
            var kardexOOB = kardexS.Union(kardexE).ToList();

            var fichaOOB = new OOB.LibInventario.Movimiento.Traslado.Insertar.Ficha()
            {
                mov = movOOB,
                movDetalles = detOOB,
                movKardex = kardexOOB,
                movDeposito = depOOB,
            };
            var r01 = Sistema.MyData.Producto_Movimiento_Traslado_Insertar(fichaOOB);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            Helpers.VisualizarDocumento.CargarVisualizarDocumento(r01.Auto);

            return true;
        }

        public bool AbandonarDocumento()
        {
            var msg = MessageBox.Show("Abandonar Documento ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            return (msg == DialogResult.Yes);
        }

        public enumerados.enumTipoMovimiento EnumTipoMovimiento
        {
            get { return  enumerados.enumTipoMovimiento.Traslado; }
        }

        public void BuscarData()
        {
            CargarDetallesIsOk = false;
            if (_gestionDetalle.TotalItems > 0)
                return;
            if (sucOrigen == null)
            {
                Helpers.Msg.Error("FALTA POR SELECCIONAR [ Sucursal Origen ]");
                return;
            }
            if (sucDestino== null)
            {
                Helpers.Msg.Error("FALTA POR SELECCIONAR [ Sucursal Destino ]");
                return;
            }
            if (IdDepOrigen=="")
            {
                return;
            }
            if (IdDepDestino== "")
            {
                return;
            }
            if (sucOrigen.autoDepositoPrincipal == "")
            {
                Helpers.Msg.Error("SUCURSAL ORIGEN NO POSEE DEPOSITO PRINCIPAL ASIGNADO");
                return;
            }
            if (sucDestino.autoDepositoPrincipal == "")
            {
                Helpers.Msg.Error("SUCURSAL DESTINO NO POSEE DEPOSITO PRINCIPAL ASIGNADO");
                return;
            }
            if (sucDestino.auto == sucOrigen.auto)
            {
                Helpers.Msg.Error("SUCURSAL DESTINO NO PUEDE SER IGUAL A LA SUCURSAL ORIGEN");
                return;
            }

            //var filtro = new OOB.LibInventario.Movimiento.Traslado.Consultar.Filtro();
            //filtro.autoDeposito = sucDestino.autoDepositoPrincipal;
            //if (_departamento != null)
            //{
            //    filtro.autoDepartamento = _departamento.auto;
            //}
            //var rt3 = Sistema.MyData.Producto_Movimiento_Traslado_Consultar_ProductosPorDebajoNivelMinimo(filtro);
            //if (rt3.Result == OOB.Enumerados.EnumResult.isError)
            //{
            //    Helpers.Msg.Error(rt3.Mensaje);
            //    return;
            //}
            //_gestionDetalle.AgregarItem(rt3.Lista, sucOrigen.autoDepositoPrincipal);

            var filtro = new OOB.LibInventario.Movimiento.Traslado.Capturar.ProductoPorDebajoNivelMinimo.Filtro();
            filtro.autoDepositoVerificarNivel= sucDestino.autoDepositoPrincipal;
            filtro.autoDepositoOrigen = sucOrigen.autoDepositoPrincipal;
            if (_departamento != null)
            {
                filtro.autoDepartamento = _departamento.auto;
            }
            var rt3 = Sistema.MyData.Capturar_ProductosPorDebajoNivelMinimo(filtro);
            if (rt3.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt3.Mensaje);
                return;
            }
            _gestionDetalle.AgregarItem(rt3.Lista, sucOrigen.autoDepositoPrincipal);

            CargarDetallesIsOk = true;
        }


        public BindingSource DetalleSouce
        {
            get { return _gestionDetalle.Souce; } 
        }

        public void EliminarItemsNoDisponible()
        {
            _gestionDetalle.EliminarItemsNoDisponible(); 
        }

        public void ActualizarConceptos()
        {
            var rt1 = Sistema.MyData.Concepto_GetLista();
            if (rt1.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return;
            }
            lConcepto.Clear();
            lConcepto.AddRange(rt1.Lista);
            bsConcepto.CurrencyManager.Refresh();
        }

        public void setSucursalOrigen(string idSuc)
        {
            sucOrigen = null;
            IdDepOrigen = "";
            if (idSuc != "")
            {
                var r01 = Sistema.MyData.Sucursal_GetFicha(idSuc);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                sucOrigen = r01.Entidad;
                IdDepOrigen = sucOrigen.autoDepositoPrincipal;
            }
        }

        public void setSucursalDestino(string idSuc)
        {
            sucDestino= null;
            IdDepDestino= "";
            if (idSuc != "")
            {
                var r01 = Sistema.MyData.Sucursal_GetFicha(idSuc);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                sucDestino= r01.Entidad;
                IdDepDestino= sucDestino.autoDepositoPrincipal;
            }
        }

        public void setDepartamento(string idDepart)
        {
            _departamento = lDepartamento.FirstOrDefault(s => s.auto == idDepart);
        }


        public void VerExistencia()
        {
            if (_gestionDetalle.ItemActual != null)
            {
                _gestionExistencia.setFicha(_gestionDetalle.ItemActual.FichaPrd.AutoId);
                _gestionExistencia.Inicia();
            }
        }

        public void EliminarItemsExistenciaDepositoCero()
        {
            _gestionDetalle.EliminarItemsExistenciaDepositoCero(); 
        }

        public void AnalisisProductos()
        {
            if (sucDestino == null)
                return;

            _gestionAnalisisGeneral.Inicializar();
            _gestionAnalisisGeneral.setDeposito(sucDestino.autoDepositoPrincipal);
            _gestionAnalisisGeneral.setUltimosXDias(15);
            _gestionAnalisisGeneral.setModulo(Analisis.General.EnumModulo.Ventas);
            _gestionAnalisisGeneral.Inicia();
        }

        public void AnalisisDetallado()
        {
            if (_gestionDetalle.ItemActual == null)
                return;

            _gestionAnalisisDetallado.Inicializar();
            _gestionAnalisisDetallado.setDeposito(sucDestino.autoDepositoPrincipal);
            _gestionAnalisisDetallado.setProducto(_gestionDetalle.ItemActual.FichaPrd.AutoId);
            _gestionAnalisisDetallado.setUltimosXDias(15);
            _gestionAnalisisDetallado.setModulo(Analisis.Detallado.EnumModulo.Ventas);
            _gestionAnalisisDetallado.Inicia();
        }

        public void VerExistenciaDeposito()
        {
            if (sucDestino != null)
            {
                _gestionAnalisisExistencia.Inicializa();
                _gestionAnalisisExistencia.setDeposito(sucDestino.autoDepositoPrincipal);
                _gestionAnalisisExistencia.Inicia();
            }
        }

        public void setHabilitarConcepto(bool p)
        {
        }

        public bool HabilitarConcepto
        {
            get { return false; }
        }

        public void setSucursal(string id)
        {
        }

        public void setDepositoOrigen(string id)
        {
        }

        public void setConcepto(string id)
        {
        }

        public bool HabilitarCambioSucursal
        {
            get { return false; }
        }

        public string GetIdSucursal
        {
            get { return ""; }
        }

        public bool HabilitarCambioDepositoOrigen
        {
            get { return false; }
        }

        public string GetIdDepositoOrigen
        {
            get { return ""; }
        }

        public bool HabilitarCambioDepositoDestino
        {
            get { return false; }
        }

        public string GetIdDepositoDestino
        {
            get { return ""; }
        }

        public void setDepositoDestino(string id)
        {
        }

        public void Inicializa()
        {
            _procesarIsOk = false;
            _departamento = null;
            _gAdmSelPrd.Inicializa();
        }

        public void Finaliza()
        {
        }

        public void BuscarProducto(string id)
        {
            var filtro = new OOB.LibInventario.Producto.Filtro() { autoProducto = id };
            var r01 = Sistema.MyData.Producto_GetLista(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var ficha = r01.Lista[0];
            if (ficha.IsInactivo)
            {
                Helpers.Msg.Error("ITEM NO PUEDE SER SELECCIONADO: VERIFIQUE ESTATUS");
                return;
            }
            if (sucOrigen == null)
            {
                Helpers.Msg.Error("DEPOSITO [ ORIGEN ] NO DEFINIDO");
                return;
            }
            _gestionDetalle.AgregarItem(ficha, sucOrigen.autoDepositoPrincipal);
        }


        public enumMetBusq MetodoBusqueda { get { return (enumMetBusq)_gAdmSelPrd.MetBusqueda; } }
        public string CadenaBusqueda { get { return _gAdmSelPrd.CadenaBusqueda; } }


        public void setMetBusqByCodigo()
        {
            _gAdmSelPrd.setMetBusqByCodigo();
        }
        public void setMetBusqByNombre()
        {
            _gAdmSelPrd.setMetBusqByNombre();
        }
        public void setMetBusqByReferencia()
        {
            _gAdmSelPrd.setMetBusqByReferencia();
        }
        public void setCadenaBuscar(string cadena)
        {
            _gAdmSelPrd.setCadenaBusq(cadena);
        }
        public void Filtrar()
        {
            _gAdmSelPrd.Inicia();
        }
        public void BuscarProducto()
        {
            _gAdmSelPrd.NotificarSeleccion +=_gAdmSelPrd_NotificarSeleccion;
            _gAdmSelPrd.BuscarSeleccionar();
            _gAdmSelPrd.NotificarSeleccion -= _gAdmSelPrd_NotificarSeleccion;
        }

        private void _gAdmSelPrd_NotificarSeleccion(object sender, EventArgs e)
        {
            if (_gAdmSelPrd.ItemSeleccionadoIsOk)
            {
                BuscarProducto(_gAdmSelPrd.ItemSeleccionado.id);
            }
        }

        OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda IGestion.MetodoBusqueda {get;set;}
        string IGestion.CadenaBusqueda {get;set;}

    }

}