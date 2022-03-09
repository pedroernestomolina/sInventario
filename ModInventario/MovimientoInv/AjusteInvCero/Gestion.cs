using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MovimientoInv.AjusteInvCero
{

    public class Gestion : IMov
    {

        private FiltrosGen.IOpcion _gSucursal;
        private FiltrosGen.IOpcion _gConcepto;
        private FiltrosGen.IOpcion _gDepOrigen;
        private IItem _gItem;
        private string _autorizadoPor;
        private string _motivo;
        private DateTime _fechaSistema;
        private decimal _tasaDivisa;
        private bool _procesarIsOk;
        private OOB.LibInventario.Sistema.TipoDocumento.Entidad.Ficha _tipoDoc;
        private SeguridadSist.ISeguridad _gSecurity;
        private SeguridadSist.IModo _gModoSecurity;


        public BindingSource SucursalSource { get { return _gSucursal.Source; } }
        public string SucursalGetID { get { return _gSucursal.GetId; } }
        public BindingSource ConceptoSource { get { return _gConcepto.Source; } }
        public string ConceptoGetID { get { return _gConcepto.GetId; } }
        public BindingSource DepOrigenSource { get { return _gDepOrigen.Source; } }
        public string DepOrigenGetID { get { return _gDepOrigen.GetId; } }
        public string AutoriazadoPor { get { return _autorizadoPor; } }
        public string Motivo { get { return _motivo; } }
        public DateTime FechaSistema { get { return _fechaSistema; } }
        public BindingSource ItemsSource { get { return _gItem.Source; } }
        public int CntItem { get { return _gItem.CntItem; } }
        public bool HablitarCambio { get { return CntItem == 0; } }
        public decimal Monto { get { return _gItem.TotalImporteMonedaLocal; } }
        public bool ProcesarIsOk { get { return _procesarIsOk; } }


        public Gestion(FiltrosGen.IOpcion sucursal,
            FiltrosGen.IOpcion concepto,
            FiltrosGen.IOpcion depOrigen,
            IItem item,
            SeguridadSist.ISeguridad seguridad)
        {
            _tipoDoc = null;
            _procesarIsOk = false;
            _tasaDivisa = 0m;
            _autorizadoPor = "";
            _motivo = "";
            _gSucursal = sucursal;
            _gConcepto = concepto;
            _gDepOrigen = depOrigen;
            _gItem = item;
            _gSecurity = seguridad;
        }


        public void Inicializa()
        {
            _tipoDoc = null;
            _procesarIsOk = false;
            _tasaDivisa = 0m;
            _autorizadoPor = "";
            _motivo = "";
            _gSucursal.Inicializa();
            _gConcepto.Inicializa();
            _gDepOrigen.Inicializa();
            _gItem.Inicializa();
        }

        private MvFrm frm;
        public void Inicia(GestionMov ctr)
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new MvFrm();
                    frm.setControlador(ctr);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var r01 = Sistema.MyData.Sucursal_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            var lst = new List<ficha>();
            foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
            {
                lst.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
            }
            _gSucursal.setData(lst);

            var r02 = Sistema.MyData.Concepto_GetLista();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            var lst2 = new List<ficha>();
            foreach (var rg in r02.Lista.OrderBy(o => o.nombre).ToList())
            {
                lst2.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
            }
            _gConcepto.setData(lst2);

            var r03 = Sistema.MyData.FechaServidor();
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            _fechaSistema = r03.Entidad.Date;

            var r04 = Sistema.MyData.Configuracion_TasaCambioActual();
            if (r04.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r04.Mensaje);
                return false;
            }
            _tasaDivisa = r04.Entidad;

            var r05 = Sistema.MyData.Sistema_TipoDocumento_GetFichaByTipo(OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.AJUSTE);
            if (r05.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r05.Mensaje);
                return false;
            }
            _tipoDoc = r05.Entidad;

            return true;
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
        public void setAutorizado(string p)
        {
            _autorizadoPor = p;
        }
        public void setMotivo(string p)
        {
            _motivo = p;
        }

        public void Limpiar()
        {
            _autorizadoPor = "";
            _motivo = "";
            _procesarIsOk = false;
            _gSucursal.Inicializa();
            _gConcepto.Inicializa();
            _gDepOrigen.Inicializa();
            _gItem.Limpiar();
        }

        public void CapturarAplicarAjuste()
        {
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
            _gItem.setData(r01.Entidad.data.OrderBy(o => o.nombrePrd).ToList());
        }

        public void Procesar()
        {
            _procesarIsOk = false;
            if (AutoriazadoPor.Trim() == "")
            {
                Helpers.Msg.Alerta("CAMPO [ AUTORIZADO ] PENDIENTE POR COMPLETAR");
                return;
            }
            if (Motivo.Trim() == "")
            {
                Helpers.Msg.Alerta("CAMPO [ MOTIVO ] PENDIENTE POR COMPLETAR");
                return;
            }
            if (_gConcepto.Item == null)
            {
                Helpers.Msg.Alerta("CAMPO [ CONCEPTO ] PENDIENTE POR COMPLETAR");
                return;
            }
            if (CntItem == 0)
            {
                Helpers.Msg.Alerta("NO HAY ITEMS PARA REALIZAR EL AJUSTE");
                return;
            }

            var xmsg = "Procesar y Guardar Documento ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                if (VerificarUsuario())
                {
                    xmsg = "Seguro de Ajustar el Déposito a Cero(0) ?";
                    msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msg == DialogResult.Yes)
                    {
                        ProcesarAjuste();
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

        private void ProcesarAjuste()
        {
            var movOOB = new OOB.LibInventario.Movimiento.AjusteInvCero.Insertar.FichaMov()
            {
                autoConcepto = _gConcepto.Item.id,
                autoDepositoDestino = _gDepOrigen.Item.id,
                autoDepositoOrigen = _gDepOrigen.Item.id,
                autoRemision = "",
                autorizado = AutoriazadoPor,
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
                documentoNombre = _tipoDoc.nombre,
                estacion = Environment.MachineName,
                estatusAnulado = "0",
                estatusCierreContable = "0",
                nota = Motivo,
                renglones = CntItem,
                situacion = "Procesado",
                tipo = _tipoDoc.codigo,
                total = Monto,
                usuario = Sistema.UsuarioP.nombreUsu,
                factorCambio = _tasaDivisa,
                montoDivisa = Math.Round(Monto / _tasaDivisa, 2, MidpointRounding.AwayFromZero),
            };
            var detOOB = _gItem.Items.Select(s =>
            {
                var costoAjuste = s.EsDivisa ? (s.Costo * _tasaDivisa) : s.CostoMonedaLocal;
                var costoAjusteEmp = costoAjuste * s.Ficha.contEmp;
                costoAjusteEmp = Math.Round(costoAjusteEmp, 2, MidpointRounding.AwayFromZero);
                var cnt = Math.Abs(s.Cantidad);
                var totalAjuste = costoAjuste * cnt;
                totalAjuste = Math.Round(totalAjuste, 2, MidpointRounding.AwayFromZero);
                costoAjuste = Math.Round(costoAjuste, 2, MidpointRounding.AwayFromZero);

                var rg = new OOB.LibInventario.Movimiento.AjusteInvCero.Insertar.FichaMovDetalle()
                {
                    autoDepartamento = s.Ficha.autoDepart,
                    autoGrupo = s.Ficha.autoGrupo,
                    autoProducto = s.AutoPrd,
                    cantidad = cnt,
                    cantidadBono = 0,
                    cantidadUnd = cnt,
                    categoria = s.Ficha.catPrd,
                    codigoProducto = s.Ficha.codigoPrd,
                    contEmpaque = s.Ficha.contEmp,
                    costoCompra = costoAjusteEmp,
                    costoUnd = costoAjuste,
                    decimales = s.Ficha.decimales,
                    empaque = s.Ficha.nombreEmp,
                    estatusAnulado = "0",
                    estatusUnidad = "1",
                    nombreProducto = s.Ficha.nombrePrd,
                    signo = s.Signo,
                    tipo = _tipoDoc.codigo,
                    total = totalAjuste,
                };
                return rg;
            }).ToList();
            var depOOB = _gItem.Items.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.AjusteInvCero.Insertar.FichaMovDeposito()
                {
                    autoDeposito = _gDepOrigen.Item.id,
                    autoProducto = s.AutoPrd,
                    cantidadUnd = s.Ajuste,
                    nombreProducto = s.NombrePrd,
                    nombreDeposito = _gDepOrigen.Item.desc,
                };
                return rg;
            }).ToList();
            var KardexOOB = _gItem.Items.Select(s =>
            {
                var costoAjuste = s.EsDivisa ? (s.Costo * _tasaDivisa) : s.CostoMonedaLocal;
                var cnt = Math.Abs(s.Cantidad);
                var totalAjuste = costoAjuste * cnt;
                totalAjuste = Math.Round(totalAjuste, 2, MidpointRounding.AwayFromZero);
                costoAjuste = Math.Round(costoAjuste, 2, MidpointRounding.AwayFromZero);

                var rg = new OOB.LibInventario.Movimiento.AjusteInvCero.Insertar.FichaMovKardex()
                {
                    autoConcepto = _gConcepto.Item.id,
                    autoDeposito = _gDepOrigen.Item.id,
                    autoProducto = s.AutoPrd,
                    cantidad = cnt,
                    cantidadBono = 0.0m,
                    cantidadUnd = cnt,
                    codigoMov = _tipoDoc.codigo,
                    codigoConcepto = _gConcepto.Item.codigo,
                    codigoDeposito = _gDepOrigen.Item.codigo,
                    codigoSucursal = _gSucursal.Item.codigo,
                    costoUnd = costoAjuste,
                    entidad = "",
                    estatusAnulado = "0",
                    modulo = _tipoDoc.tipo,
                    nombreConcepto = _gConcepto.Item.desc,
                    nombreDeposito = _gDepOrigen.Item.desc,
                    nota = "",
                    precioUnd = 0.0m,
                    siglasMov = _tipoDoc.siglas,
                    signoMov = s.Signo,
                    total = totalAjuste,
                };
                return rg;
            }).ToList();
            var fichaOOB = new OOB.LibInventario.Movimiento.AjusteInvCero.Insertar.Ficha()
            {
                mov = movOOB,
                movDeposito = depOOB,
                movDetalles = detOOB,
                movKardex = KardexOOB,
            };
            var r01 = Sistema.MyData.Producto_Movimiento_AjusteInventarioCero_Insertar(fichaOOB);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            Helpers.VisualizarDocumento.CargarVisualizarDocumento(r01.Auto);
            _procesarIsOk = true;
        }

        public void setModoSeguridad(SeguridadSist.IModo securityModo)
        {
            _gModoSecurity = securityModo;
        }

    }

}