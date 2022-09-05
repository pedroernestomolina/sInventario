using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MovimientoInvTipo.Traslado
{
    
    public class Gestion: ITipoxDev
    {

        private bool _isOk;
        private string _autorizado;
        private string _motivo;
        private dataItem _itemAgregar;
        private bool _procesarDocIsOk;
        private string _idDocumentoGenerado;
        private decimal _tasaCambio;
        private bool _activarPorDevolucion;
        private string _tipoMovimiento;
        private bool _dejarEnPendienteIsOk;
        private int _cntDocPend;
        private string _tipoMovTransito;


        private ModInventario.FiltrosGen.IOpcion _gConcepto;
        private ModInventario.FiltrosGen.IOpcion _gSucursal;
        private ModInventario.FiltrosGen.IOpcion _gDepOrigen;
        private ModInventario.FiltrosGen.IOpcion _gDepDestino;
        private Helpers.Maestros.ICallMaestros _gMaestro;
        private ICaptura _gCapturaMov;
        private MovimientoInvTipo.Transito.ITransito _gDocPend;
        private ISeguridadAccesoSistema _seguridad;


        public string TipoMovimiento { get { return _tipoMovimiento; } }
        public bool IsOk { get { return _isOk; } }
        public BindingSource ConceptoSource { get { return _gConcepto.Source; } }
        public BindingSource SucursalSource { get { return _gSucursal.Source; } }
        public BindingSource DepOrigenSource { get { return _gDepOrigen.Source; } }
        public BindingSource DepDestinoSource { get { return _gDepDestino.Source; } }
        public string AutorizadoPor { get { return _autorizado; } }
        public string Motivo{ get { return _motivo; } }
        public string ConceptoGetId { get { return _gConcepto.GetId; } }
        public string SucursalGetId { get { return _gSucursal.GetId; } }
        public string DepOrigenGetID { get { return _gDepOrigen.GetId; } }
        public string DepDestinoGetID { get { return _gDepDestino.GetId; } }
        public dataItem ItemAgregar { get { return _itemAgregar; } }
        public bool ProcesarDocIsOk { get { return _procesarDocIsOk; } }
        public string IdDocumentoGenerado { get { return _idDocumentoGenerado; } }


        public Gestion(
            ICaptura ctrCapturaMov,
            Helpers.Maestros.ICallMaestros ctrMaestro,
            MovimientoInvTipo.Transito.ITransito ctrTransito,
            ISeguridadAccesoSistema  ctrSeguridad)
        {
            _seguridad = ctrSeguridad;
            _gDocPend = ctrTransito;
            _gCapturaMov = ctrCapturaMov;
            _gMaestro = ctrMaestro;
            _gConcepto = new ModInventario.FiltrosGen.Opcion.Gestion();
            _gSucursal = new ModInventario.FiltrosGen.Opcion.Gestion();
            _gDepOrigen = new ModInventario.FiltrosGen.Opcion.Gestion();
            _gDepDestino= new ModInventario.FiltrosGen.Opcion.Gestion();
            _isOk = false;
            _itemAgregar = null;
            _procesarDocIsOk=false;
            _autorizado = "";
            _motivo = "";
            _idDocumentoGenerado = "";
            _tasaCambio = 0m;
            _activarPorDevolucion = false;
            _tipoMovimiento = "TRASLADO / DEPÓSITOS";
            _dejarEnPendienteIsOk=false;
            _cntDocPend = 0;
            _tipoMovTransito = "1";
        }


        public void Inicializa()
        {
            _gConcepto.Inicializa();
            _gSucursal.Inicializa();
            _gDepOrigen.Inicializa();
            _gDepDestino.Inicializa();
            _gDocPend.Inicializa();


            _isOk = false;
            _itemAgregar = null;
            _procesarDocIsOk = false;
            _autorizado = "";
            _motivo = "";
            _idDocumentoGenerado = "";
            _tasaCambio = 0m;
            _dejarEnPendienteIsOk = false;
            _cntDocPend = 0;
            _tipoMovTransito = "1";
        }

        MovFrm frm;
        public void Inicia(IGestionTipo ctr)
        {
            if (frm == null)
            {
                frm = new MovFrm();
                frm.setControlador(ctr);
            }
            frm.ShowDialog();
        }

        public bool CargarData()
        {
            var Id_Deposito_Devolucion = "";
            var Id_Concepto_Devolucion = "";

            if (_activarPorDevolucion)
            {
                var r11 = Sistema.MyData.Configuracion_DepositoConceptoPreDeterminadoDevolucionMercancia();
                if (r11.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r11.Mensaje);
                    return false;
                }
                Id_Concepto_Devolucion = r11.Entidad.IdConcepto;
                Id_Deposito_Devolucion = r11.Entidad.IdDeposito;

                var r22 = Sistema.MyData.Concepto_GetFicha(Id_Concepto_Devolucion);
                if (r22.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r22.Mensaje);
                    return false;
                }
                var rg = r22.Entidad;
                var _lConcepto = new List<ficha>();
                _lConcepto.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
                _gConcepto.setData(_lConcepto);

                var r33 = Sistema.MyData.Deposito_GetFicha(Id_Deposito_Devolucion);
                if (r33.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r33.Mensaje);
                    return false;
                }
                var rg2 = r33.Entidad;
                var lst = new List<ficha>();
                lst.Add(new ficha(rg2.auto, rg2.codigo, rg2.nombre));
                _gDepDestino.setData(lst);
            }
            else
            {
                var r11 = Sistema.MyData.Concepto_GetLista();
                if (r11.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r11.Mensaje);
                    return false;
                }
                var _lConcepto = new List<ficha>();
                foreach (var rg in r11.Lista.OrderBy(o => o.nombre).ToList())
                {
                    _lConcepto.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
                }
                _gConcepto.setData(_lConcepto);

                var r22 = Sistema.MyData.Deposito_GetLista();
                if (r22.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r22.Mensaje);
                    return false;
                }
                var lst = new List<ficha>();
                foreach (var rg in r22.Lista.OrderBy(o => o.nombre).ToList())
                {
                    lst.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
                }
                _gDepDestino.setData(lst);
            }

            var filtroOOb = new OOB.LibInventario.Sucursal.Filtro();
            var r02 = Sistema.MyData.Sucursal_GetLista(filtroOOb);
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            var _lSucursal = new List<ficha>();
            foreach (var rg in r02.Lista.OrderBy(o => o.nombre).ToList())
            {
                _lSucursal.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
            }
            _gSucursal.setData(_lSucursal);
            _gDepOrigen.setData(null);

            var r03 = Sistema.MyData.Configuracion_TasaCambioActual();
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            _tasaCambio = r03.Entidad;

            var r05 = Sistema.MyData.Sistema_TipoDocumento_GetFichaByTipo(OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.TRASLADO);
            if (r05.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r05.Mensaje);
                return false;
            }
            var _docTipo = r05.Entidad;

            var filtroOOB = new OOB.LibInventario.Transito.Movimiento.Lista.Filtro() { codigoMov = _docTipo.codigo, tipoMov = _tipoMovTransito };
            var r06 = Sistema.MyData.Transito_Movimiento_GetCnt(filtroOOB);
            if (r06.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r06.Mensaje);
                return false;
            }
            _cntDocPend = r06.Entidad;

            return true;
        }


        public void setAutorizadoPor(string p)
        {
            _autorizado = p;
        }
        public void setMotivo(string p)
        {
            _motivo = p;
        }
        public void setSucursal(string id)
        {
            _gSucursal.setFicha(id);
            if (id.Trim() != "")
            {
                var r01 = Sistema.MyData.Deposito_GetListaBySucursal(_gSucursal.Item.codigo);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                var lst = new List<ficha>();
                foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
                {
                    lst.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
                }
                _gDepOrigen.setData(lst);
            }
        }
        public void setConcepto(string id)
        {
            _gConcepto.setFicha(id);
        }
        public void setDepOrigen(string id)
        {
            _gDepOrigen.setFicha(id);
        }
        public void setDepDestino(string id)
        {
            _gDepDestino.setFicha(id);
        }


        public void BuscarIdPrd(string id)
        {
            _isOk = false;
            _itemAgregar = null;
            if (_gSucursal.Item == null)
            {
                Helpers.Msg.Alerta("CAMPO [ SUCURSAL ] NO SELECCIONADA");
                return;
            }
            if (_gDepOrigen.Item == null) 
            {
                Helpers.Msg.Alerta("CAMPO [ DEPOSITO ORIGEN ] NO SELECCIONADA");
                return;
            }
            if (_gDepDestino.Item == null)
            {
                Helpers.Msg.Alerta("CAMPO [ DEPOSITO DESTINO ] NO SELECCIONADA");
                return;
            }

            var filtroOOB = new OOB.LibInventario.Movimiento.Traslado.CapturaMov.Filtro()
            {
                idDeposito = _gDepOrigen.GetId,
                IdDepDestino = _gDepDestino.GetId,
                idProducto = id,
            };
            var r01 = Sistema.MyData.Producto_Movimiento_Traslado_CaptureMov(filtroOOB);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            if (r01.Entidad.data.exFisica<=0.0m)
            {
                Helpers.Msg.Error("Producto No Posee Existencia Disponible Para [ TRASLADO ]");
                return;
            }

            var r = r01.Entidad.data;
            var dat = new data()
            {
                autoDepart = r.autoDepart,
                autoGrupo = r.autoGrupo,
                autoPrd = r.autoPrd,
                autoTasa = r.autoTasa,
                catPrd = r.catPrd,
                codigoPrd = r.codigoPrd,
                contEmp = r.contEmp,
                costo = r.costo,
                costoDivisa = r.costoDivisa,
                costoDivisaUnd = r.costoDivisaUnd,
                costoUnd = r.costoUnd,
                decimales = r.decimales,
                descTasa = r.descTasa,
                esAdmDivisa = r.esAdmDivisa,
                exFisica = r.exFisica,
                nombreEmp = r.nombreEmp,
                nombrePrd = r.nombrePrd,
                valorTasa = r.valorTasa,
                fechaUltimaActCosto = r.fechaUltActualizacionCosto,
            };
            _gCapturaMov.Inicializa();
            _gCapturaMov.setData(dat);
            _gCapturaMov.setTasaCambio(_tasaCambio);
            _gCapturaMov.Inicia();
            if (_gCapturaMov.IsOk) 
            {
                _itemAgregar = _gCapturaMov.DataItem;
                _isOk = true;
            }
        }

        public void Limpiar()
        {
            _itemAgregar = null;
            _autorizado = "";
            _motivo = "";
            _gConcepto.Limpiar();
            _gSucursal.Limpiar();
            _gDepOrigen.Limpiar();
            _gDepOrigen.setData(null);
            _gDepDestino.Limpiar();
            _gDocPend.Limpiar();
        }


        public void EditarItem(dataItem ItemActual)
        {
            _isOk = false;
            _gCapturaMov.Inicializa();
            _gCapturaMov.setItemEditar(ItemActual);
            _gCapturaMov.Inicia();
            if (_gCapturaMov.IsOk)
            {
                _itemAgregar = _gCapturaMov.DataItem;
                _isOk = true;
            }
        }


        public void ConceptoMaestro()
        {
            _gMaestro.MtConcepto();

            var r01 = Sistema.MyData.Concepto_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            var _lConcepto= new List<ficha>();
            foreach(var rg in r01.Lista.OrderBy(o=>o.nombre).ToList())
            {
                _lConcepto.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
            }
            _gConcepto.setData(_lConcepto);
        }


        public void ProcesarDoc(List<dataItem> list, decimal totalImporte)
        {
            _procesarDocIsOk = false;
            _idDocumentoGenerado = "";

            var r00 = Sistema.MyData.Permiso_Movimiento_Traslado_Procesar(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (_seguridad.Verificar(r00.Entidad))
            {
                if (ValidarDoc())
                {
                    var xmsg = "Procesar / Generar Movimiento ?";
                    var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msg == DialogResult.Yes)
                    {
                        RegistrarDoc(list, totalImporte);
                    }
                }
            }
        }

        private void RegistrarDoc(List<dataItem> list, decimal totalImporte)
        {
            var r00 = Sistema.MyData.Sistema_TipoDocumento_GetFichaByTipo(OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.TRASLADO);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            var _docTipo = r00.Entidad;
            var _mDivisa = Math.Round(totalImporte / _tasaCambio, 2, MidpointRounding.AwayFromZero);
            var movOOB = new OOB.LibInventario.Movimiento.Traslado.Insertar.FichaMov()
            {
                autoConcepto = _gConcepto.Item.id,
                autoDepositoDestino = _gDepDestino.Item.id,
                autoDepositoOrigen = _gDepOrigen.Item.id,
                autoRemision = "",
                autorizado = _autorizado,
                autoUsuario = Sistema.UsuarioP.autoUsu,
                cierreFtp = "",
                codConcepto = _gConcepto.Item.codigo,
                codDepositoDestino = _gDepDestino.Item.codigo,
                codDepositoOrigen = _gDepOrigen.Item.codigo,
                codigoSucursal = _gSucursal.Item.codigo,
                codUsuario = Sistema.UsuarioP.codigoUsu,
                desConcepto = _gConcepto.Item.desc,
                desDepositoDestino = _gDepDestino.Item.desc,
                desDepositoOrigen = _gDepOrigen.Item.desc,
                documentoNombre = _docTipo.nombre,
                estacion = Environment.MachineName,
                estatusAnulado = "0",
                estatusCierreContable = "0",
                nota = _motivo,
                renglones = list.Count,
                situacion = "Procesado",
                tipo = _docTipo.codigo,
                total = totalImporte,
                usuario = Sistema.UsuarioP.nombreUsu,
                factorCambio = _tasaCambio,
                montoDivisa = _mDivisa,
            };

            var detOOB = list.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.Traslado.Insertar.FichaMovDetalle()
                {
                    autoDepartamento = s.Data.autoDepart,
                    autoGrupo = s.Data.autoGrupo,
                    autoProducto = s.Data.autoPrd,
                    cantidad = s.Cantidad,
                    cantidadBono = 0,
                    cantidadUnd = s.CntUnd,
                    categoria = s.Data.catPrd,
                    codigoProducto = s.Data.codigoPrd,
                    contEmpaque = s.Data.contEmp,
                    costoCompra = s.CostoNacional,
                    costoUnd = s.CostoUndNacional,
                    decimales = s.Data.decimales,
                    empaque = s.Data.nombreEmp,
                    estatusAnulado = "0",
                    estatusUnidad = s.MovPorUnidad ? "1" : "0",
                    nombreProducto = s.Data.nombrePrd,
                    signo = _docTipo.signo,
                    tipo = _docTipo.codigo,
                    total = s.ImporteNacional,
                };
                return rg;
            }).ToList();

            var gr3 = list.GroupBy
                (g => new { g.Data.autoPrd, g.Data.nombrePrd }).
                Select(g2 => new { id = g2.Key.autoPrd, desc = g2.Key.nombrePrd, cnt = g2.Sum(s => s.CntUnd) }).
                ToList();
            var depOOB = gr3.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.Traslado.Insertar.FichaMovDeposito()
                {
                    autoDeposito = _gDepOrigen.Item.id,
                    autoDepositoDestino = _gDepDestino.Item.id,
                    autoProducto = s.id,
                    nombreProducto = s.desc,
                    nombreDeposito = _gDepOrigen.Item.desc,
                    depositoDestino = _gDepDestino.Item.desc,
                    cantidadUnd = s.cnt,
                };
                return rg;
            }).ToList();

            var lSalida= list.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.Traslado.Insertar.FichaMovKardex()
                {
                    autoConcepto = _gConcepto.Item.id,
                    autoDeposito = _gDepOrigen.Item.id,
                    autoProducto = s.Data.autoPrd,
                    cantidad = s.Cantidad,
                    cantidadBono = 0.0m,
                    cantidadUnd = s.CntUnd,
                    codigoMov = _docTipo.codigo,
                    codigoConcepto = _gConcepto.Item.codigo,
                    codigoDeposito = _gDepOrigen.Item.codigo,
                    codigoSucursal = _gSucursal.Item.codigo,
                    costoUnd = s.CostoUndNacional,
                    entidad = "",
                    estatusAnulado = "0",
                    modulo = _docTipo.tipo,
                    nombreConcepto = _gConcepto.Item.desc,
                    nombreDeposito = _gDepOrigen.Item.desc,
                    nota = "",
                    precioUnd = 0.0m,
                    siglasMov = _docTipo.siglas,
                    signoMov = -1,
                    total = s.ImporteNacional,
                    factorCambio = _tasaCambio,
                };
                return rg;
            }).ToList();

            var lEntrada= list.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.Traslado.Insertar.FichaMovKardex()
                {
                    autoConcepto = _gConcepto.Item.id,
                    autoDeposito = _gDepDestino.Item.id,
                    autoProducto = s.Data.autoPrd,
                    cantidad = s.Cantidad,
                    cantidadBono = 0.0m,
                    cantidadUnd = s.CntUnd,
                    codigoMov = _docTipo.codigo,
                    codigoConcepto = _gConcepto.Item.codigo,
                    codigoDeposito = _gDepDestino.Item.codigo,
                    codigoSucursal = _gSucursal.Item.codigo,
                    costoUnd = s.CostoUndNacional,
                    entidad = "",
                    estatusAnulado = "0",
                    modulo = _docTipo.tipo,
                    nombreConcepto = _gConcepto.Item.desc,
                    nombreDeposito = _gDepDestino.Item.desc,
                    nota = "",
                    precioUnd = 0.0m,
                    siglasMov = _docTipo.siglas,
                    signoMov = 1,
                    total = s.ImporteNacional,
                    factorCambio = _tasaCambio,
                };
                return rg;
            }).ToList();
            var KardexOOB = lSalida.Union(lEntrada).ToList();

            var ficha = new OOB.LibInventario.Movimiento.Traslado.Insertar.Ficha()
            {
                mov = movOOB,
                movDeposito = depOOB,
                movDetalles = detOOB,
                movKardex = KardexOOB,
            };
            var r01 = Sistema.MyData.Producto_Movimiento_Traslado_Insertar(ficha);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _procesarDocIsOk = true;
            _idDocumentoGenerado = r01.Auto;
        }


        private bool ValidarDoc()
        {
            if (_autorizado.Trim() == "") 
            {
                Helpers.Msg.Alerta("CAMPO [ AUTORIZADO POR ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_motivo.Trim() == "")
            {
                Helpers.Msg.Alerta("CAMPO [ MOTIVO ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_gSucursal.Item == null) 
            {
                Helpers.Msg.Alerta("CAMPO [ SUCURSAL ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_gConcepto.Item == null)
            {
                Helpers.Msg.Alerta("CAMPO [ CONCEPTO ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_gDepOrigen.Item == null)
            {
                Helpers.Msg.Alerta("CAMPO [ DEPOSITO ORIGEN ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_gDepDestino.Item == null)
            {
                Helpers.Msg.Alerta("CAMPO [ DEPOSITO DESTINO ] NO PUEDE ESTAR VACIO");
                return false;
            }

            return true;
        }

        public void setActivarPorDevolucion(bool p)
        {
            _tipoMovimiento = "TRASLADO / DEPÓSITOS";
            _tipoMovTransito = "1";
            _activarPorDevolucion = p;
            if (_activarPorDevolucion)
            {
                _tipoMovimiento = "TRASLADO x DEVOLUCIÓN";
                _tipoMovTransito = "2";
            }
        }


        public bool CapturarDataAplicarAjusteInvCeroIsOk { get { return false; } }
        public List<dataItem> ListaItemAplicarAjusteInvCero { get { return null; } }
        public void CapturarDataAplicarAjusteInvCero()
        {
        }


        public BindingSource DepatamentoSource { get { return null; } }
        public string DepartamentoGetId { get { return ""; } }
        public void setDepartamento(string id)
        {
        }


        public bool CapturarProductosConNivelMinimoIsOk { get { return false; } }
        public List<dataItem> ListaItemNivelMinimo { get { return null; } }
        public void CapturarProductosConNivelMinimo()
        {
        }


        public void NuevoDocumento()
        {
            _isOk = false;
            _itemAgregar = null;
            _procesarDocIsOk = false;
            _autorizado = "";
            _motivo = "";
            _idDocumentoGenerado = "";
            _dejarEnPendienteIsOk = false;
            _cntDocPend = 0;

            var r01 = Sistema.MyData.Sistema_TipoDocumento_GetFichaByTipo(OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.TRASLADO);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            var _docTipo = r01.Entidad;

            var filtroOOB = new OOB.LibInventario.Transito.Movimiento.Lista.Filtro() { codigoMov = _docTipo.codigo, tipoMov = _tipoMovTransito };
            var r02 = Sistema.MyData.Transito_Movimiento_GetCnt(filtroOOB);
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return;
            }
            _cntDocPend = r02.Entidad;
        }


        public bool ItemTransitoIsOk { get { return _gDocPend.ItemSeleccionadoIsOk; } }
        public int ItemTransitoId { get { return _gDocPend.ItemSeleccionado.id; } }
        public int DocPendientes { get { return _cntDocPend; } }
        public bool DejarEnPendienteIsOk { get { return _dejarEnPendienteIsOk; } }
        public void DejarEnPendiente(List<dataItem> list, decimal totalImporte)
        {
            _dejarEnPendienteIsOk = false;
            if (ValidarDoc())
            {
                var xmsg = "Dejar Cambios En Pendiente ?";
                var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    RegistrarPendiente(list, totalImporte);
                }
            }
        }
        private void RegistrarPendiente(List<dataItem> list, decimal totalImporte)
        {
            var r00 = Sistema.MyData.Sistema_TipoDocumento_GetFichaByTipo(OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.TRASLADO);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            var _docTipo = r00.Entidad;
            var _mDivisa = Math.Round(totalImporte / _tasaCambio, 2, MidpointRounding.AwayFromZero);
            var movOOB = new OOB.LibInventario.Transito.Movimiento.Agregar.Mov()
            {
                autoriza = _autorizado,
                cntRenglones = list.Count,
                codigoMov = _docTipo.codigo,
                descConcepto = _gConcepto.Item.desc,
                descDepDestino = _gDepDestino.Item.desc,
                descDepOrigen = _gDepOrigen.Item.desc,
                descMov = _docTipo.nombre,
                descSucDestino = "",
                descSucOrigen = _gSucursal.Item.desc,
                descUsuario = Sistema.UsuarioP.nombreUsu,
                estacionEquipo = "",
                factorCambio = _tasaCambio,
                idConcepto = _gConcepto.Item.id,
                idDeOrigen = _gDepOrigen.Item.id,
                idDepDestino = _gDepDestino.Item.id,
                idSucDestino = "",
                idSucOrigen = _gSucursal.Item.id,
                monto = totalImporte,
                montoDivisa = _mDivisa,
                motivo = _motivo,
                tipoMov = _tipoMovTransito,
            };
            var detallesOOB = new List<OOB.LibInventario.Transito.Movimiento.Agregar.Detalle>();
            foreach (var det in list)
            {
                var idTipoMovFicha = "";
                if (det.TipoMovFicha != null) { idTipoMovFicha = det.TipoMovFicha.id; }

                var rg = new OOB.LibInventario.Transito.Movimiento.Agregar.Detalle()
                {
                    autoDepart = det.Data.autoDepart,
                    autoGrupo = det.Data.autoGrupo,
                    autoPrd = det.Data.autoPrd,
                    autoTasa = det.Data.autoTasa,
                    catPrd = det.Data.catPrd,
                    codigoPrd = det.Data.codigoPrd,
                    contEmp = det.Data.contEmp,
                    costo = det.Data.costo,
                    costoDivisa = det.Data.costoDivisa,
                    costoDivisaUnd = det.Data.costoDivisaUnd,
                    costoUnd = det.Data.costoUnd,
                    decimales = det.Data.decimales,
                    nombreEmp = det.Data.nombreEmp,
                    descTasa = det.Data.descTasa,
                    estatusDivisa = det.Data.esAdmDivisa ? "1" : "0",
                    exFisica = det.Data.exFisica,
                    fechaUltActCosto = det.Data.fechaUltimaActCosto,
                    nombrePrd = det.Data.nombrePrd,
                    valorTasa = det.Data.valorTasa,
                    nivelMinimo = det.Data.nivelMinimoDepDestino,
                    nivelOptimo = det.Data.nivelOptimoDepDestino,
                    exFisicaDestino = det.Data.exFisicaDepDestino,
                    //
                    cantidadSolicitada = det.Cantidad,
                    costoSolicitada = det.Costo,
                    ajusteIdSolicitada = idTipoMovFicha,
                    empaqueIdSolicitada = det.EmpaqueFicha.id,
                };
                detallesOOB.Add(rg);
            }

            var ficha = new OOB.LibInventario.Transito.Movimiento.Agregar.Ficha()
            {
                mov = movOOB,
                detalles = detallesOOB,
            };
            var r01 = Sistema.MyData.Transito_Movimiento_Agregar(ficha);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _dejarEnPendienteIsOk = true;
        }
        public void ListaDocPendientes()
        {
            if (_cntDocPend <= 0)
            {
                Helpers.Msg.Alerta("NO HAY MOVIMIENTOS EN PENDIENTES");
                return;
            }

            var r01 = Sistema.MyData.Sistema_TipoDocumento_GetFichaByTipo(OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.TRASLADO);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            var _docTipo = r01.Entidad;

            var filtroOOB = new OOB.LibInventario.Transito.Movimiento.Lista.Filtro() { codigoMov = _docTipo.codigo, tipoMov = _tipoMovTransito };
            var r02 = Sistema.MyData.Transito_Movimiento_GetLista(filtroOOB);
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return;
            }
            var lst = new List<Transito.data>();
            foreach (var rg in r02.Lista.OrderBy(o => o.id).ToList())
            {
                var nr = new Transito.data()
                {
                    id = rg.id,
                    fecha = rg.fecha,
                    renglones = rg.cntRenglones,
                    monto = rg.monto,
                    montoDivisa = rg.montoDivisa,
                    Origen = rg.descSucOrigen + ", " + rg.descDepOrigen,
                    Destino = rg.descSucDestino + ", " + rg.descDepDestino,
                };
                lst.Add(nr);
            }
            _gDocPend.Inicializa();
            _gDocPend.setActivarNotificacion(false);
            _gDocPend.setPermitirSeleccionarInactivos(false);
            _gDocPend.setCerrarVentanaAlSeleccionarItem(true);
            _gDocPend.setLista(lst);
            _gDocPend.Inicia();
        }
        public List<dataItem> LoadTransito()
        {
            return LoadTransito(_gDocPend.ItemSeleccionado.id);
            //var _lst = new List<dataItem>();

            //var r01 = Sistema.MyData.Transito_Movimiento_GetById(_gDocPend.ItemSeleccionado.id);
            //if (r01.Result == OOB.Enumerados.EnumResult.isError)
            //{
            //    Helpers.Msg.Error(r01.Mensaje);
            //    return _lst;
            //}

            //var mov = r01.Entidad.mov;
            //setAutorizadoPor(mov.autoriza);
            //setMotivo(mov.motivo);
            //setConcepto(mov.idConcepto);
            //setSucursal(mov.idSucOrigen);
            //setDepOrigen(mov.idDeOrigen);
            //setDepDestino(mov.idDepDestino);
            //foreach (var r in r01.Entidad.detalles.OrderBy(o => o.nombreProd).ToList())
            //{
            //    var dat = new data()
            //    {
            //        autoDepart = r.autoDepart,
            //        autoGrupo = r.autoGrupo,
            //        autoPrd = r.autoProd,
            //        autoTasa = r.autoTasa,
            //        catPrd = r.categoriaProd,
            //        codigoPrd = r.codigoProd,
            //        contEmp = r.contEmpaque,
            //        costo = r.costo,
            //        costoDivisa = r.costoDivisa,
            //        costoDivisaUnd = r.costoDivisaUnd,
            //        costoUnd = r.costoUnd,
            //        decimales = r.decimales,
            //        descTasa = r.descTasa,
            //        esAdmDivisa = r.esAdmDivisa == "1" ? true : false,
            //        exFisica = r.exFisica,
            //        nombreEmp = r.descEmpaque,
            //        nombrePrd = r.nombreProd,
            //        valorTasa = r.valorTasa,
            //        fechaUltimaActCosto = r.fechaUltActCosto,
            //        exFisicaDepDestino = r.exFisicaDestino,
            //        nivelMinimoDepDestino = r.nivelMinimo,
            //        nivelOptimoDepDestino = r.nivelOptimo,
            //    };
            //    var _item = new dataItem();
            //    _item.setFicha(dat);
            //    _item.setCantidad(r.cantSolicitada);
            //    if (r.empaqueIdSolicitado == "2")
            //    {
            //        _item.setEmpaque(new ficha("2", "", "POR UNIDAD"));
            //    }
            //    else
            //    {
            //        _item.setEmpaque(new ficha("1", "", "POR EMPQ/COMPRA"));
            //    }
            //    _item.setTasaCambio(_tasaCambio);
            //    _lst.Add(_item);
            //}
            //return _lst;
        }
        public void AnularTransito()
        {
            AnularTransito(_gDocPend.ItemSeleccionado.id);
        }
        public List<dataItem> LoadTransito(int idMovPend)
        {
            var _lst = new List<dataItem>();

            var r01 = Sistema.MyData.Transito_Movimiento_GetById(idMovPend);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return _lst;
            }

            var mov = r01.Entidad.mov;
            setAutorizadoPor(mov.autoriza);
            setMotivo(mov.motivo);
            setConcepto(mov.idConcepto);
            setSucursal(mov.idSucOrigen);
            setDepOrigen(mov.idDeOrigen);
            setDepDestino(mov.idDepDestino);
            foreach (var r in r01.Entidad.detalles.OrderBy(o => o.nombreProd).ToList())
            {
                var dat = new data()
                {
                    autoDepart = r.autoDepart,
                    autoGrupo = r.autoGrupo,
                    autoPrd = r.autoProd,
                    autoTasa = r.autoTasa,
                    catPrd = r.categoriaProd,
                    codigoPrd = r.codigoProd,
                    contEmp = r.contEmpaque,
                    costo = r.costo,
                    costoDivisa = r.costoDivisa,
                    costoDivisaUnd = r.costoDivisaUnd,
                    costoUnd = r.costoUnd,
                    decimales = r.decimales,
                    descTasa = r.descTasa,
                    esAdmDivisa = r.esAdmDivisa == "1" ? true : false,
                    exFisica = r.exFisica,
                    nombreEmp = r.descEmpaque,
                    nombrePrd = r.nombreProd,
                    valorTasa = r.valorTasa,
                    fechaUltimaActCosto = r.fechaUltActCosto,
                    exFisicaDepDestino = r.exFisicaDestino,
                    nivelMinimoDepDestino = r.nivelMinimo,
                    nivelOptimoDepDestino = r.nivelOptimo,
                };
                var _item = new dataItem();
                _item.setFicha(dat);
                _item.setCantidad(r.cantSolicitada);
                if (r.empaqueIdSolicitado == "2")
                {
                    _item.setEmpaque(new ficha("2", "", "POR UNIDAD"));
                }
                else
                {
                    _item.setEmpaque(new ficha("1", "", "POR EMPQ/COMPRA"));
                }
                _item.setTasaCambio(_tasaCambio);
                _lst.Add(_item);
            }
            return _lst;
        }
        public void CargarDocPendiente(int idMovPend)
        {
            _gDocPend.CargarDoc(idMovPend);
        }
        public void AnularTransito(int idMov)
        {
            var r01 = Sistema.MyData.Transito_Movimiento_AnularById(idMov);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var r02 = Sistema.MyData.Sistema_TipoDocumento_GetFichaByTipo(OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.TRASLADO);
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return;
            }
            var _docTipo = r02.Entidad;

            var filtroOOB = new OOB.LibInventario.Transito.Movimiento.Lista.Filtro() { codigoMov = _docTipo.codigo, tipoMov = _tipoMovTransito };
            var r03 = Sistema.MyData.Transito_Movimiento_GetCnt(filtroOOB);
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return;
            }
            _cntDocPend = r03.Entidad;
        }

        public string GetIdDepOrigen { get { return _gDepOrigen.GetId; } }
        public string GetIdDepDestino { get { return _gDepDestino.GetId; } }

    }

}