using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MovimientoInvTipo.AjusteInvCero
{
    
    public class Gestion: ITipoSeguridad
    {

        private bool _isOk;
        private string _autorizado;
        private string _motivo;
        private dataItem _itemAgregar;
        private bool _procesarDocIsOk;
        private string _idDocumentoGenerado;
        private decimal _tasaCambio;
        private bool _capturarDataAplicarAjusteInvCeroIsOk;
        private List<dataItem> _lItems;


        private ModInventario.FiltrosGen.IOpcion _gConcepto;
        private ModInventario.FiltrosGen.IOpcion _gSucursal;
        private ModInventario.FiltrosGen.IOpcion _gDepOrigen;
        private Helpers.Maestros.ICallMaestros _gMaestro;
        private ICapturaMovAjuste _gCapturaMov;
        private SeguridadSist.ISeguridad _gSecurity;
        private SeguridadSist.IModo _gModoSecurity;


        public string TipoMovimiento { get { return "AJUSTE INVENTARIO A CERO"; } }
        public bool IsOk { get { return _isOk; } }
        public BindingSource ConceptoSource { get { return _gConcepto.Source; } }
        public BindingSource SucursalSource { get { return _gSucursal.Source; } }
        public BindingSource DepOrigenSource { get { return _gDepOrigen.Source; } }
        public BindingSource DepDestinoSource { get { return null; } }
        public string AutorizadoPor { get { return _autorizado; } }
        public string Motivo{ get { return _motivo; } }
        public string ConceptoGetId { get { return _gConcepto.GetId; } }
        public string SucursalGetId { get { return _gSucursal.GetId; } }
        public string DepOrigenGetID { get { return _gDepOrigen.GetId; } }
        public string DepDestinoGetID { get { return ""; } }
        public dataItem ItemAgregar { get { return _itemAgregar; } }
        public bool ProcesarDocIsOk { get { return _procesarDocIsOk; } }
        public string IdDocumentoGenerado { get { return _idDocumentoGenerado; } }
        public bool CapturarDataAplicarAjusteInvCeroIsOk { get { return _capturarDataAplicarAjusteInvCeroIsOk; } }
        public List<dataItem> ListaItemAplicarAjusteInvCero { get { return _lItems; } }


        public Gestion(
            Helpers.Maestros.ICallMaestros ctrMaestro,
            SeguridadSist.ISeguridad seguridad)
        {
            _gCapturaMov = null;
            _gMaestro = ctrMaestro;
            _gSecurity = seguridad;
            _gConcepto = new ModInventario.FiltrosGen.Opcion.Gestion();
            _gSucursal = new ModInventario.FiltrosGen.Opcion.Gestion();
            _gDepOrigen = new ModInventario.FiltrosGen.Opcion.Gestion();
            _isOk = false;
            _itemAgregar = null;
            _procesarDocIsOk=false;
            _autorizado = "";
            _motivo = "";
            _idDocumentoGenerado = "";
            _tasaCambio = 0m;
            _capturarDataAplicarAjusteInvCeroIsOk = false;
            _lItems = new List<dataItem>();
        }


        public void Inicializa()
        {
            _gConcepto.Inicializa();
            _gSucursal.Inicializa();
            _gDepOrigen.Inicializa();
            _isOk = false;
            _itemAgregar = null;
            _procesarDocIsOk = false;
            _autorizado = "";
            _motivo = "";
            _idDocumentoGenerado = "";
            _tasaCambio = 0m;
            _capturarDataAplicarAjusteInvCeroIsOk = false; ;
            _lItems.Clear();
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
            try
            {
                var _lConcepto = new List<ficha>();
                var r01 = Sistema.MyData.Concepto_GetLista();
                foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
                {
                    _lConcepto.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
                }
                _gConcepto.setData(_lConcepto);

                var _lSucursal = new List<ficha>();
                var filtroOOb = new OOB.LibInventario.Sucursal.Filtro();
                var r02 = Sistema.MyData.Sucursal_GetLista(filtroOOb);
                foreach (var rg in r02.Lista.OrderBy(o => o.nombre).ToList())
                {
                    _lSucursal.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
                }
                _gSucursal.setData(_lSucursal);
                _gDepOrigen.setData(null);

                var r03 = Sistema.MyData.Configuracion_TasaCambioActual();
                if (r02.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r03.Mensaje);
                    return false;
                }
                _tasaCambio = r03.Entidad;

                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
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
        }


        public void BuscarIdPrd(string id)
        {
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
        }


        public void EditarItem(dataItem ItemActual)
        {
        }


        public void ConceptoMaestro()
        {
            _gMaestro.MtConcepto();

            var _lConcepto = new List<ficha>();
            try
            {
                var r01 = Sistema.MyData.Concepto_GetLista();
                foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
                {
                    _lConcepto.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
            _gConcepto.setData(_lConcepto);
        }


        public void ProcesarDoc(List<dataItem> list, decimal totalImporte)
        {
            _procesarDocIsOk = false;
            _idDocumentoGenerado = "";
            if (ValidarDoc())
            {
                var xmsg = "Procesar / Generar Movimiento ?";
                var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    if (VerificarUsuario())
                    {
                        xmsg = "Seguro de Ajustar el Déposito a Cero(0) ?";
                        msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (msg == DialogResult.Yes)
                        {
                            RegistrarDoc(list, totalImporte);
                        }
                    }
                }
            }
        }

        private bool VerificarUsuario()
        {
            _gSecurity.setGestionTipo(_gModoSecurity);
            _gSecurity.Inicializa();
            _gSecurity.Inicia();
            return _gSecurity.IsOk;
        }

        private void RegistrarDoc(List<dataItem> list, decimal totalImporte)
        {
            var r00 = Sistema.MyData.Sistema_TipoDocumento_GetFichaByTipo(OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.AJUSTE);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            var _docTipo = r00.Entidad;
            var _mDivisa = Math.Round(totalImporte / _tasaCambio, 2, MidpointRounding.AwayFromZero);
            var movOOB = new OOB.LibInventario.Movimiento.AjusteInvCero.Insertar.FichaMov()
            {
                autoConcepto = _gConcepto.Item.id,
                autoDepositoDestino = _gDepOrigen.Item.id,
                autoDepositoOrigen = _gDepOrigen.Item.id,
                autoRemision = "",
                autorizado = _autorizado,
                autoUsuario = Sistema.UsuarioP.autoUsu,
                cierreFtp = "",
                codConcepto = _gConcepto.Item.codigo,
                codDepositoDestino = _gDepOrigen.Item.codigo,
                codDepositoOrigen = _gDepOrigen.Item.codigo,
                codigoSucursal = _gSucursal.Item.codigo,
                codUsuario = Sistema.UsuarioP.codigoUsu,
                desConcepto = _gConcepto.Item.desc,
                desDepositoDestino = _gDepOrigen.Item.desc,
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
                var rg = new OOB.LibInventario.Movimiento.AjusteInvCero.Insertar.FichaMovDetalle()
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
                    signo = s.Signo,
                    tipo = _docTipo.codigo,
                    total = Math.Abs(s.ImporteNacional),
                };
                return rg;
            }).ToList();

            var gr3 = list.GroupBy
                (g => new { g.Data.autoPrd, g.Data.nombrePrd }).
                Select(g2 => new { id = g2.Key.autoPrd, desc = g2.Key.nombrePrd, cnt = g2.Sum(s => s.CntUnd*s.Signo) }).
                ToList();
            var depOOB = gr3.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.AjusteInvCero.Insertar.FichaMovDeposito()
                {
                    autoDeposito = _gDepOrigen.Item.id,
                    autoProducto = s.id,
                    nombreProducto = s.desc,
                    cantidadUnd = s.cnt,
                    nombreDeposito = _gDepOrigen.Item.desc, 
                };
                return rg;
            }).ToList();

            var KardexOOB = list.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.AjusteInvCero.Insertar.FichaMovKardex()
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
                    signoMov = s.Signo,
                    total = Math.Abs(s.ImporteNacional),
                    factorCambio = _tasaCambio,
                };
                return rg;
            }).ToList();

            var ficha = new OOB.LibInventario.Movimiento.AjusteInvCero.Insertar.Ficha()
            {
                mov = movOOB,
                movDeposito = depOOB,
                movDetalles = detOOB,
                movKardex = KardexOOB,
            };
            var r01 = Sistema.MyData.Producto_Movimiento_AjusteInventarioCero_Insertar(ficha);
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
                Helpers.Msg.Alerta("CAMPO [ DEPOSITO ] NO PUEDE ESTAR VACIO");
                return false;
            }

            return true;
        }
        

        public void CapturarDataAplicarAjusteInvCero()
        {
            _capturarDataAplicarAjusteInvCeroIsOk = false;
            if (_gSucursal.Item == null)
            {
                Helpers.Msg.Alerta("CAMPO [ SUCURSAL ] NO SELECCIONADA");
                return;
            }
            if (_gDepOrigen.Item == null)
            {
                Helpers.Msg.Alerta("CAMPO [ DEPOSITO ] NO SELECCIONADO");
                return;
            }
            CapturarInv();
        }

        private void CapturarInv()
        {
            _lItems.Clear();
            var filtroOOB = new OOB.LibInventario.Movimiento.AjusteInvCero.Capture.Filtro()
            {
                idDeposito = _gDepOrigen.GetId,
            };
            var r01 = Sistema.MyData.Producto_Movimiento_AjusteInventarioCero_Capture(filtroOOB);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            foreach (var r in r01.Entidad.data.OrderBy(o=>o.nombrePrd).ToList())
            {
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
                    fechaUltimaActCosto = "",
                };
                var _item = new dataItem();
                _item.setFicha(dat);
                if (r.exFisica > 0)
                {
                    _item.setTipoMov(new ficha("2", "", "DESCARGO"));
                }
                else 
                {
                    _item.setTipoMov(new ficha("1", "", "CARGO"));
                }
                _item.setEmpaque(new ficha("2", "", "POR UNIDAD"));
                _item.setCantidad(Math.Abs(r.exFisica));
                _item.setTasaCambio(_tasaCambio);
                _lItems.Add(_item);
            }
            _capturarDataAplicarAjusteInvCeroIsOk = true;
        }

        public void setModoSeguridad(SeguridadSist.IModo securityModo)
        {
            _gModoSecurity = securityModo;
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
        }



        public bool ItemTransitoIsOk { get { return false; } }
        public int ItemTransitoId { get { return -1; } }
        public int DocPendientes { get { return 0; } }
        public bool DejarEnPendienteIsOk { get { return false; } }
        public void DejarEnPendiente(List<dataItem> list, decimal TotalImporte)
        {
        }
        public void ListaDocPendientes()
        {
        }
        public List<dataItem> LoadTransito()
        {
            return null;
        }
        public void AnularTransito()
        {
        }
        public List<dataItem> LoadTransito(int idMovPend)
        {
            return null;
        }
        public void CargarDocPendiente(int idMovPend)
        {
        }
        public void AnularTransito(int idMov)
        {
        }


        public string GetIdDepOrigen { get { return _gDepOrigen.GetId; } }
        public string GetIdDepDestino { get { return _gDepOrigen.GetId; } }

    }

}