using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Movimiento.Cargo
{
    
    public class Gestion: IGestion
    {

        private List<OOB.LibInventario.Concepto.Ficha> lConcepto;
        private List<OOB.LibInventario.Sucursal.Ficha> lSucursal;
        private List<OOB.LibInventario.Deposito.Ficha> lDepOrigen;
        private List<OOB.LibInventario.Deposito.Ficha> lDepDestino;
        private BindingSource bsSucursal;
        private BindingSource bsConcepto;
        private BindingSource bsDepOrigen;
        private BindingSource bsDepDestino;
        private Movimiento.data miData;
        private GestionDetalle _gestionDetalle;
        private decimal tasaCambio;
        private bool isCerrarOk;
        private bool _procesarDocIsOk;


        public bool ProcesarDocIsOk { get { return _procesarDocIsOk; } }
        public bool IsCerrarOk { get { return isCerrarOk; } }
        public string TipoMovimiento { get {return "CARGO";} }
        public decimal MontoMovimiento { get { return _gestionDetalle.MontoMovimiento; } }
        public string ItemsMovimiento  { get { return _gestionDetalle.ItemsMovimiento; } }
        public bool Habilitar_DepDestino { get { return false; } }
        public bool VisualizarColumnaTipoMovimiento { get { return false; } }
        public BindingSource ConceptoSource { get { return bsConcepto; } }
        public BindingSource SucursalSource { get { return bsSucursal; } }
        public BindingSource DepOrigenSource { get { return bsDepOrigen; } }
        public BindingSource DepDestinoSource { get { return bsDepDestino; } }
        public BindingSource DetalleSouce { get { return _gestionDetalle.Souce; } }
        public string IdSucursal { get { return miData.IdSucursal; } set { miData.IdSucursal = value; } }
        public string IdConcepto { get { return miData.IdConcepto; } set { miData.IdConcepto = value; } }
        public string IdDepOrigen
        { 
            get { return miData.IdDepOrigen; } 
            set 
            {
                if (_gestionDetalle.TotalItems == 0) 
                {
                    miData.IdDepOrigen = value; 
                }
            }
        } 
        public string IdDepDestino 
        { 
            get { return miData.IdDepDestino; } 
            set 
            {
                if (_gestionDetalle.TotalItems == 0) 
                {
                    miData.IdDepDestino = value;
                }
            }
        }
        public string AutorizadoPor { get { return miData.AutorizadoPor; } set { miData.AutorizadoPor = value; } }
        public string Motivo { get { return miData.Motivo; } set { miData.Motivo = value; } }
        public DateTime FechaMov { get { return miData.Fecha; } set { miData.Fecha = value; } }
        public ficha Sucursal { get { return miData.GetSucursal; } }
        public ficha DepositoOrigen { get { return miData.GetDepositoOrigen; } }
        public ficha Concepto { get { return miData.GetConcepto; } }
        public bool HabilitarCambioSucursal { get { return _gestionDetalle.TotalItems == 0; } }
        public bool HabilitarCambioDepositoOrigen { get { return _gestionDetalle.TotalItems == 0; } }
        public string GetIdSucursal
        {
            get
            {
                var id = "";
                if (Sucursal != null)
                    id = Sucursal.id;
                return id;
            }
        }
        public string GetIdDepositoOrigen
        {
            get
            {
                var id = "";
                if (DepositoOrigen != null)
                    id = DepositoOrigen.id;
                return id;
            }
        }
        

        public Gestion()
        {
            _gestionDetalle = new GestionDetalle();
            miData = new Movimiento.data();

            lConcepto = new List<OOB.LibInventario.Concepto.Ficha>();
            lSucursal = new List<OOB.LibInventario.Sucursal.Ficha>();
            lDepOrigen = new List<OOB.LibInventario.Deposito.Ficha>();
            lDepDestino = new List<OOB.LibInventario.Deposito.Ficha>();
            bsConcepto = new BindingSource();
            bsSucursal = new BindingSource();
            bsDepOrigen = new BindingSource();
            bsDepDestino = new BindingSource();
            bsConcepto.DataSource = lConcepto;
            bsSucursal.DataSource = lSucursal;
            bsDepOrigen.DataSource = lDepOrigen;
            bsDepDestino.DataSource = lDepDestino;
        }

        //private void _glistaPrd_NotificarSeleccion(object sender, EventArgs e)
        //{
        //    if (_glistaPrd.ItemSeleccionado.isAnulado)
        //    {
        //        Helpers.Msg.Error("ITEM NO PUEDE SER SELECCIONADO: VERIFIQUE ESTATUS");
        //        return;
        //    }
        //    else
        //    {
        //        if (DepositoOrigen == null)
        //        {
        //            Helpers.Msg.Error("CAMPO [ DEPOSITO ORIGEN ] NO SELECCIONADO");
        //            return;
        //        }
        //        var filtro = new OOB.LibInventario.Producto.Filtro() { autoProducto = _glistaPrd.ItemSeleccionado.id };
        //        var r01 = Sistema.MyData.Producto_GetLista(filtro);
        //        if (r01.Result == OOB.Enumerados.EnumResult.isError)
        //        {
        //            Helpers.Msg.Error(r01.Mensaje);
        //            return;
        //        }
        //        _gestionDetalle.AgregarItem(r01.Lista[0], DepositoOrigen.id);
        //    }
        //}


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
            tasaCambio = rt4.Entidad;
            _gestionDetalle.setTasaCambio(tasaCambio);

            lConcepto.Clear();
            lConcepto.AddRange(rt2.Lista.OrderBy(o=>o.nombre).ToList());
            bsConcepto.CurrencyManager.Refresh();

            lSucursal.Clear();
            lSucursal.AddRange(rt1.Lista.OrderBy(o => o.nombre).ToList());
            bsSucursal.CurrencyManager.Refresh();

            return rt;
        }

        public void Limpiar()
        {
            _procesarDocIsOk = false;
            isCerrarOk = false;
            miData.Limpiar();
            lDepOrigen.Clear();
            bsDepOrigen.CurrencyManager.Refresh();
            _gestionDetalle.Limpiar();
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
            _gestionDetalle.EditarItem();
        }

        public void Procesar()
        {
            _procesarDocIsOk = false;
            miData.detalle = _gestionDetalle.Detalle;
            if (miData.Verificar())
            {
                if (Sucursal == null)
                {
                    Helpers.Msg.Error("Campo [ Sucursal ] No Seleccionada");
                    return;
                }
                if (Concepto == null)
                {
                    Helpers.Msg.Error("Campo [ Concepto Movimiento ] No Seleccionada");
                    return;
                }
                if (DepositoOrigen == null)
                {
                    Helpers.Msg.Error("Campo [ Deposito Origen ] No Seleccionada");
                    return;
                }

                var msg = MessageBox.Show("Procesar Documento ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.No) 
                {
                    return;
                }

                if (!RegistrarDocumento()) 
                {
                    return;
                }

                Helpers.Msg.AgregarOk();
                isCerrarOk = true;
                _procesarDocIsOk = true;
            }
        }

        private bool RegistrarDocumento()
        {
            var movOOB = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaMov()
            {
                autoConcepto = Concepto.id,
                autoDepositoDestino = DepositoOrigen.id ,
                autoDepositoOrigen = DepositoOrigen.id,
                autoRemision = "",
                autorizado = miData.AutorizadoPor,
                autoUsuario = Sistema.UsuarioP.autoUsu,
                cierreFtp = "",
                codConcepto = Concepto.codigo,
                codDepositoDestino = DepositoOrigen.codigo,
                codDepositoOrigen = DepositoOrigen.codigo,
                codigoSucursal = Sucursal.codigo,
                codUsuario = Sistema.UsuarioP.codigoUsu,
                desConcepto = Concepto.descripcion,
                desDepositoDestino = DepositoOrigen.descripcion,
                desDepositoOrigen = DepositoOrigen.descripcion,
                documentoNombre = "CARGOS",
                estacion = Environment.MachineName,
                estatusAnulado = "0",
                estatusCierreContable = "0",
                nota = miData.Motivo,
                renglones = _gestionDetalle.TotalItems,
                situacion = "Procesado",
                tipo = "01",
                total = MontoMovimiento,
                usuario = Sistema.UsuarioP.nombreUsu,
                factorCambio=tasaCambio,
                montoDivisa=Math.Round(MontoMovimiento/tasaCambio,2, MidpointRounding.AwayFromZero),
            };
            var detOOB = _gestionDetalle.Detalle.ListaItems.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaMovDetalle()
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
                    tipo = "01",
                    total = s.ImporteMonedaLocal,
                };
                return rg;
            }).ToList();
            var gr3 = _gestionDetalle.Detalle.ListaItems.GroupBy
                (g => new { g.FichaPrd.AutoId, g.DescripcionPrd }).
                Select(g2 => new { id = g2.Key.AutoId, desc = g2.Key.DescripcionPrd, cnt = g2.Sum(s => s.CantidadUnd * s.Signo) }).ToList();
            var depOOB = gr3.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaMovDeposito()
                {
                    autoDeposito = DepositoOrigen.id,
                    nombreProducto = s.desc,
                    autoProducto = s.id,
                    cantidadUnd = s.cnt,
                    nombreDeposito = DepositoOrigen.descripcion,
                };
                return rg;
            }).ToList();
            var lCosto = _gestionDetalle.Detalle.ListaItems.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrdCosto()
                {
                    autoProducto = s.FichaPrd.AutoId,
                    cantidadEntranteUnd = s.CantidadUnd,
                    costoDivisa = s.CostoDivisa,
                    costoFinal = s.CostoMonedaLocal,
                    costoFinalUnd = s.CostoUndMonedaLocal,
                };
                return rg;
            }).ToList();
            var lCostoHistorico = _gestionDetalle.Detalle.ListaItems.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrdCostoHistorico()
                {
                    autoProducto = s.FichaPrd.AutoId,
                    costo = s.CostoMonedaLocal,
                    divisa = s.CostoDivisa,
                    nota = "",
                    tasaCambio = s.TasaCambio,
                    serie="DOC",
                };
                return rg;
            }).ToList();
            var kardexOOB = _gestionDetalle.Detalle.ListaItems.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaMovKardex()
                {
                    autoConcepto = Concepto.id,
                    autoDeposito = DepositoOrigen.id,
                    autoProducto = s.FichaPrd.AutoId,
                    cantidad = s.Cantidad,
                    cantidadBono = 0.0m,
                    cantidadUnd = s.CantidadUnd,
                    codigoMov = "01",
                    codigoConcepto = Concepto.codigo,
                    codigoDeposito = DepositoOrigen.codigo,
                    codigoSucursal = Sucursal.codigo,
                    costoUnd = s.CostoUndMonedaLocal,
                    entidad = "",
                    estatusAnulado = "0",
                    modulo = "Inventario",
                    nombreConcepto = Concepto.descripcion,
                    nombreDeposito = DepositoOrigen.descripcion,
                    nota = "",
                    precioUnd = 0.0m,
                    siglasMov = "CAR",
                    signoMov = 1,
                    total = s.ImporteMonedaLocal,
                };
                return rg;
            }).ToList();

            var rt1 = Sistema.MyData.Configuracion_MetodoCalculoUtilidad();
            if (rt1.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return false;
            }
            var rt3 = Sistema.MyData.Configuracion_PreferenciaRegistroPrecio();
            if (rt3.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt3.Mensaje);
                return false;
            }
            var rt4 = Sistema.MyData.Configuracion_ForzarRedondeoPrecioVenta();
            if (rt4.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt4.Mensaje);
                return false;
            }
            var lMargen = new List<OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrdPrecioMargen>();
            var LPrecio = new List<OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrdPrecio>();
            var lPrecioHistorico = new List<OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrdPrecioHistorico>();
            foreach (var it in _gestionDetalle.Detalle.ListaItems)
            { 
                if (it.EsAdmDivisa)
                {
                    var rt2 = Sistema.MyData.Producto_GetPrecio(it.FichaPrd.AutoId);
                    if (rt2.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(rt2.Mensaje);
                        return false;
                    }
                    var rg = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrdPrecio();
                    rg.autoProducto = it.FichaPrd.AutoId;
                    rg.precio_1 = null;
                    rg.precio_2 = null;
                    rg.precio_3 = null;
                    rg.precio_4 = null;
                    rg.precio_5 = null;
                    if (rt2.Entidad.precioNeto1 > 0)
                    {
                        var p = Helpers.Utilitis.RecalcularPrecio(it.CostoUndMonedaLocal , rt2.Entidad.utilidad1, rt2.Entidad.tasaIva, rt3.Entidad, rt4.Entidad, rt1.Entidad, tasaCambio);
                        rg.precio_1 = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrecio() { precioNeto = p.neto, precio_divisa_full = p.fullDivisa };
                        var ph = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrdPrecioHistorico()
                        {
                            autoProducto = it.FichaPrd.AutoId,
                            nota = "",
                            precio = p.neto,
                            precio_id = "1",
                        };
                        lPrecioHistorico.Add(ph);
                    }
                    if (rt2.Entidad.precioNeto2 > 0)
                    {
                        var p = Helpers.Utilitis.RecalcularPrecio(it.CostoUndMonedaLocal, rt2.Entidad.utilidad2, rt2.Entidad.tasaIva, rt3.Entidad, rt4.Entidad, rt1.Entidad, tasaCambio);
                        rg.precio_2 = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrecio() { precioNeto = p.neto, precio_divisa_full = p.fullDivisa };
                        var ph = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrdPrecioHistorico()
                        {
                            autoProducto = it.FichaPrd.AutoId,
                            nota = "",
                            precio = p.neto,
                            precio_id = "2",
                        };
                        lPrecioHistorico.Add(ph);
                    }
                    if (rt2.Entidad.precioNeto3 > 0)
                    {
                        var p = Helpers.Utilitis.RecalcularPrecio(it.CostoUndMonedaLocal, rt2.Entidad.utilidad3, rt2.Entidad.tasaIva, rt3.Entidad, rt4.Entidad, rt1.Entidad, tasaCambio);
                        rg.precio_3 = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrecio() { precioNeto = p.neto, precio_divisa_full = p.fullDivisa };
                        var ph = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrdPrecioHistorico()
                        {
                            autoProducto = it.FichaPrd.AutoId,
                            nota = "",
                            precio = p.neto,
                            precio_id = "3",
                        };
                        lPrecioHistorico.Add(ph);
                    }
                    if (rt2.Entidad.precioNeto4 > 0)
                    {
                        var p = Helpers.Utilitis.RecalcularPrecio(it.CostoUndMonedaLocal, rt2.Entidad.utilidad4, rt2.Entidad.tasaIva, rt3.Entidad, rt4.Entidad, rt1.Entidad, tasaCambio);
                        rg.precio_4 = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrecio() { precioNeto = p.neto, precio_divisa_full = p.fullDivisa };
                        var ph = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrdPrecioHistorico()
                        {
                            autoProducto = it.FichaPrd.AutoId,
                            nota = "",
                            precio = p.neto,
                            precio_id = "4",
                        };
                        lPrecioHistorico.Add(ph);
                    }
                    if (rt2.Entidad.precioNeto5 > 0)
                    {
                        var p = Helpers.Utilitis.RecalcularPrecio(it.CostoUndMonedaLocal, rt2.Entidad.utilidad5, rt2.Entidad.tasaIva, rt3.Entidad, rt4.Entidad, rt1.Entidad, tasaCambio);
                        rg.precio_5 = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrecio() { precioNeto = p.neto, precio_divisa_full = p.fullDivisa };
                        var ph = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrdPrecioHistorico()
                        {
                            autoProducto = it.FichaPrd.AutoId,
                            nota = "",
                            precio = p.neto,
                            precio_id = "PTO",
                        };
                        lPrecioHistorico.Add(ph);
                    }
                    LPrecio.Add(rg);
                }
                else
                {
                    var rt2 = Sistema.MyData.Producto_GetPrecio(it.FichaPrd.AutoId);
                    if (rt2.Result == OOB.Enumerados.EnumResult.isError) 
                    {
                        Helpers.Msg.Error(rt2.Mensaje);
                        return false;
                    }
                    var rg = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrdPrecioMargen();
                    rg.autoProducto = it.FichaPrd.AutoId;
                    rg.precio_1=null;
                    rg.precio_2=null;
                    rg.precio_3=null;
                    rg.precio_4=null;
                    rg.precio_5=null;
                    if (rt2.Entidad.precioNeto1>0)
                    {
                        rg.precio_1 = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen() { utilidad = ReCalcularMargen(rt2.Entidad.precioNeto1, it.CostoUndMonedaLocal, rt1.Entidad), };
                    }
                    if (rt2.Entidad.precioNeto2 > 0)
                    {
                        rg.precio_2 = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen() { utilidad = ReCalcularMargen(rt2.Entidad.precioNeto2, it.CostoUndMonedaLocal, rt1.Entidad), };
                    }
                    if (rt2.Entidad.precioNeto3 > 0)
                    {
                        rg.precio_3 = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen() { utilidad = ReCalcularMargen(rt2.Entidad.precioNeto3, it.CostoUndMonedaLocal, rt1.Entidad), };
                    }
                    if (rt2.Entidad.precioNeto4 > 0)
                    {
                        rg.precio_4 = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen() { utilidad = ReCalcularMargen(rt2.Entidad.precioNeto4, it.CostoUndMonedaLocal, rt1.Entidad), };
                    }
                    if (rt2.Entidad.precioNeto5 > 0)
                    {
                        rg.precio_5 = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen() { utilidad = ReCalcularMargen(rt2.Entidad.precioNeto5, it.CostoUndMonedaLocal, rt1.Entidad), };
                    }
                    lMargen.Add(rg);
                }
            }

            var fichaOOB = new OOB.LibInventario.Movimiento.Cargo.Insertar.Ficha()
            {
                mov = movOOB,
                movDeposito = depOOB,
                movDetalles = detOOB,
                movKardex = kardexOOB,
                prdCosto = lCosto,
                prdCostoHistorico = lCostoHistorico,
                prdPrecioMargen = lMargen,
                prdPrecio = LPrecio,
                prdPrecioHistorico = lPrecioHistorico,
            };
            var r01 = Sistema.MyData.Producto_Movimiento_Cargo_Insertar(fichaOOB);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            Helpers.VisualizarDocumento.CargarVisualizarDocumento(r01.Auto);

            return true;
        }

        private decimal ReCalcularMargen(decimal pn, decimal costo, OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad metodo)
        {
            var rt = 0.0m;

            if (metodo == OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad.Financiero)
            {
                rt = (1 - (costo / pn)) * 100;
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            }
            else 
            {
                rt = ((pn / costo) - 1) * 100;
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            }

            return rt;
        }

        public bool AbandonarDocumento()
        {
            var msg = MessageBox.Show("Abandonar Documento ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            return (msg == DialogResult.Yes);
        }

        public enumerados.enumTipoMovimiento EnumTipoMovimiento
        {
            get { return  enumerados.enumTipoMovimiento.Cargo; }
        }

        public void ActualizarConceptos()
        {
            var rt1 = Sistema.MyData.Concepto_GetLista();
            if (rt1.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return ;
            }
            lConcepto.Clear();
            lConcepto.AddRange(rt1.Lista);
            bsConcepto.CurrencyManager.Refresh();
        }

        public void setHabilitarConcepto(bool p)
        {
        }

        public bool HabilitarConcepto
        {
            get { return true; }
        }

        public void setSucursal(string id)
        {
            var suc = lSucursal.FirstOrDefault(f => f.auto == id);
            if (suc != null)
            {
                var r01 = Sistema.MyData.Sucursal_GetFicha(id);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                var r02 = Sistema.MyData.Deposito_GetListaBySucursal(r01.Entidad.codigo);
                if (r02.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r02.Mensaje);
                    return;
                }
                lDepOrigen.Clear();
                lDepOrigen.AddRange(r02.Lista.OrderBy(o => o.nombre).ToList());
                bsDepOrigen.CurrencyManager.Refresh();
                miData.setSucursal(new ficha(suc.auto, suc.nombre, suc.codigo));
                miData.setDepositoOrigen(null);
            }
            else
            {
                miData.setSucursal(null);
                miData.setDepositoOrigen(null);
            }
        }

        public void setDepositoOrigen(string id)
        {
            miData.setDepositoOrigen(null);
            var dep = lDepOrigen.FirstOrDefault(f => f.auto == id);
            if (dep != null)
            {
                miData.setDepositoOrigen(new ficha(dep.auto, dep.nombre, dep.codigo));
            }
        }

        public void setConcepto(string id)
        {
            miData.setConcepto(null);
            var ent = lConcepto.FirstOrDefault(f => f.auto == id);
            if (ent != null)
            {
                miData.setConcepto(new ficha(ent.auto, ent.nombre, ent.codigo));
            }
        }


        // NO IMPLEMENTAR
        public bool HabilitarCambioDepositoDestino { get { return false; } }
        public string GetIdDepositoDestino { get { return ""; } }
        public void setDepositoDestino(string id)
        {
        }

        public void Inicia()
        {
        }

        public void Inicializa()
        {
            _procesarDocIsOk = false;
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
            if (DepositoOrigen == null)
            {
                Helpers.Msg.Error("CAMPO [ DEPOSITO ORIGEN ] NO SELECCIONADO");
                return;
            }
            _gestionDetalle.AgregarItem(ficha, DepositoOrigen.id);
        }

        public OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda MetodoBusqueda { get; set; }
        public string CadenaBusqueda { get; set; }
        public void BuscarProducto()
        {
        }

    }

}