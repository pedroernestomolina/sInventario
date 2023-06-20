using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModInventario.Utils.Tools;
using System.Windows.Forms;


namespace ModInventario.TomaInv.Generar
{
    public class ImpGenerar : IGenerar
    {
        private int _cntPrdTomar;
        private enum enumeradoOrdenLista { PorDefecto, PorMayorCosto, PorMayorMargen, PorMayorDemanda };
        private bool _abandonarIsOk;
        private bool _procesarIsOk;
        private ICtrl _sucOrigen;
        private ICtrlLink _depOrigen;
        private string _motivo;
        private string _autorizadoPor;
        private DateTime _fechaSist;
        private decimal _cntDias;
        private ILista _lista;
        private Tools.ExcluirDepart.IExcluir _excluir;
        private enumeradoOrdenLista _tipoOrdenLista;


        public string GetEnt_Motivo { get { return _motivo; } }
        public string GetEnt_AutorizadoPor { get { return _autorizadoPor; } }
        public DateTime GetFechaSistema { get { return _fechaSist; } }
        public ICtrl SucOrigen { get { return _sucOrigen; } }
        public ICtrlLink DepOrigen { get { return _depOrigen; } }
        public decimal GetCntDias { get { return _cntDias; } }
        public BindingSource GetSource { get { return _lista.GetDataSource; } }
        public decimal DiasMov { get { return 45m; } }
        public int CntItems { get { return _lista.CntItem; } }


        public ImpGenerar()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _autorizadoPor = "";
            _fechaSist = DateTime.Now.Date;
            _motivo = "";
            _sucOrigen = new Utils.Tools.Sucursal.Imp();
            _depOrigen = new Utils.Tools.Deposito.Imp();
            _cntDias = DiasMov;
            _lista = new ImpLista();
            _excluir = new Tools.ExcluirDepart.ImpExcluir();
            _tipoOrdenLista = enumeradoOrdenLista.PorDefecto;
            _cntPrdTomar = 0;
        }


        public void Inicializa()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _autorizadoPor = "";
            _fechaSist = DateTime.Now.Date;
            _motivo = "";
            _sucOrigen.Inicializa();
            _depOrigen.Inicializa();
            _cntDias = 45m;
            _lista.Inicializa();
            _excluir.Inicializa();
            _tipoOrdenLista = enumeradoOrdenLista.PorDefecto;
            _cntPrdTomar = 0;
        }
        Frm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = Helpers.Msg.Abandonar();
        }

        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public void ProcesarFicha()
        {
            if (_autorizadoPor.Trim() == "")
            {
                Helpers.Msg.Alerta("CAMPO AUTORIZADO NO PUEDE ESTAR VACIO");
                return;
            }
            if (_motivo.Trim() == "")
            {
                Helpers.Msg.Alerta("CAMPO MOTIVO NO PUEDE ESTAR VACIO");
                return;
            }
            if (_lista.GetLista.Count <= 0)
            {
                Helpers.Msg.Alerta("NO HAY ITEMS PARA LA SOLICITUD");
                return;
            }
            var resp = Helpers.Msg.ProcesarGuardar();
            if (resp)
            {
                Procesar();
            }
        }


        public void setAutorizadoPor(string desc)
        {
            _autorizadoPor = desc;
        }
        public void setMotivo(string desc)
        {
            _motivo = desc;
        }
        public void SucOrigenSetId(string id)
        {
            _sucOrigen.setId(id);
            if (id != "")
            {
                _depOrigen.CargarDataByIdLink(id);
            }
            else
            {
                _depOrigen.Inicializa();
            }
        }
        public void setCntDias(decimal cnt)
        {
            _cntDias = cnt;
        }


        public void GenerarToma()
        {
            if (_sucOrigen.GetItem == null)
            {
                Helpers.Msg.Alerta("SUCURSAL NO PUEDE ESTAR VACIA");
                return;
            }
            if (_depOrigen.GetItem == null)
            {
                Helpers.Msg.Alerta("DEPOSITO NO PUEDE ESTAR VACIO");
                return;
            }
            if (_cntDias <= 0m)
            {
                Helpers.Msg.Alerta("CANTIDAD DIAS MOVIMIENTOS NO PUEDE SER CERO(0)");
                return;
            }
            var _lstId = _excluir.GetLista.Where(w => w.IsSeleccionado).Select(s => s.Departamento.auto).ToList();
            var filtro = new OOB.LibInventario.TomaInv.ObtenerToma.Filtro()
            {
                idDeposito = _depOrigen.GetId,
                periodoDias = (int)_cntDias,
                idDepartExcluir = _lstId,
            };
            var r01 = Sistema.MyData.TomaInv_GetListaPrd(filtro);
            if (r01.Result != OOB.Enumerados.EnumResult.isError)
            {
                var _lst = new List<TomaInv.data>();
                if (_cntPrdTomar == 0) 
                {
                    _cntPrdTomar = r01.cntRegistro;
                }
                switch (_tipoOrdenLista)
                {
                    case enumeradoOrdenLista.PorDefecto:
                        foreach (var r in r01.Lista.Where(w => w.cntMov > 0).ToList())
                        {
                            var rg = new TomaInv.data() { cnt = r.cnt, codigoPrd = r.codigoPrd, costoPrd = r.costoPrd, descPrd = r.descPrd, idPrd = r.idPrd, margen = r.margen, fechaUltToma=r.fechaUltConteo, ultConteo=r.ultConteo };
                            _lst.Add(rg);
                        }
                        _lst.Sort();
                        _lst.Reverse();
                        _lista.setDataListar(_lst.Take(_cntPrdTomar).ToList());
                        break;
                    case enumeradoOrdenLista.PorMayorCosto:
                        foreach (var r in r01.Lista.Where(w => w.cntMov > 0).OrderByDescending(o=>o.costoPrd).ToList())
                        {
                            var rg = new TomaInv.data() { cnt = r.cnt, codigoPrd = r.codigoPrd, costoPrd = r.costoPrd, descPrd = r.descPrd, idPrd = r.idPrd, margen = r.margen, fechaUltToma=r.fechaUltConteo, ultConteo=r.ultConteo };
                            _lst.Add(rg);
                        }
                        _lista.setDataListar(_lst.Take(_cntPrdTomar).ToList());
                        break;
                    case enumeradoOrdenLista.PorMayorMargen:
                        foreach (var r in r01.Lista.Where(w => w.cntMov > 0).OrderByDescending(o=>o.margen).ToList())
                        {
                            var rg = new TomaInv.data() { cnt = r.cnt, codigoPrd = r.codigoPrd, costoPrd = r.costoPrd, descPrd = r.descPrd, idPrd = r.idPrd, margen = r.margen, fechaUltToma = r.fechaUltConteo, ultConteo = r.ultConteo };
                            _lst.Add(rg);
                        }
                        _lista.setDataListar(_lst.Take(_cntPrdTomar).ToList());
                        break;
                    case enumeradoOrdenLista.PorMayorDemanda:
                        foreach (var r in r01.Lista.Where(w => w.cntMov > 0).OrderByDescending(o=>o.cnt).ToList())
                        {
                            var rg = new TomaInv.data() { cnt = r.cnt, codigoPrd = r.codigoPrd, costoPrd = r.costoPrd, descPrd = r.descPrd, idPrd = r.idPrd, margen = r.margen, fechaUltToma = r.fechaUltConteo, ultConteo = r.ultConteo };
                            _lst.Add(rg);
                        }
                        _lista.setDataListar(_lst.Take(_cntPrdTomar).ToList());
                        break;
                }
            }
        }


        private bool CargarData()
        {
            try
            {
                _sucOrigen.CargarData();
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        public void Limpiar()
        {
            var xmsg = "Desechar Cambios Al Documento Actual ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _abandonarIsOk = false;
                _procesarIsOk = false;
                _autorizadoPor = "";
                _fechaSist = DateTime.Now.Date;
                _motivo = "";
                _sucOrigen.LimpiarItemSeleccion();
                _depOrigen.LimpiarItemSeleccion();
                _cntDias = DiasMov;
                _lista.Inicializa();
            }
        }
        public void DepartamentosExcluir()
        {
            _excluir.Inicia();
        }
        private void Procesar()
        {
            _procesarIsOk = false;
            try
            {
                var rt1 = Sistema.MyData.Sucursal_GetFicha(_sucOrigen.GetId);
                var rt2 = Sistema.MyData.Deposito_GetFicha(_depOrigen.GetId);
                if (rt2.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rt2.Mensaje);
                }
                var _lstPrd = _lista.GetLista.ToList().Select(s =>
                {
                    var nr = new OOB.LibInventario.TomaInv.Solicitud.Generar.PrdToma()
                    {
                        IdPrd = s.PrdToma.idPrd,
                    };
                    return nr;
                }).ToList();
                var ficha = new OOB.LibInventario.TomaInv.Solicitud.Generar.Ficha()
                {
                    idDeposito = _depOrigen.GetId,
                    autorizadoPor = _autorizadoPor,
                    cantItems = _lstPrd.Count,
                    codigoDeposito = rt2.Entidad.codigo,
                    codigoSucursal = rt1.Entidad.codigo,
                    descDeposito = rt2.Entidad.nombre,
                    descSucursal = rt1.Entidad.nombre,
                    idSucursal = _sucOrigen.GetId,
                    motivo = _motivo,
                    ProductosTomaInv = _lstPrd,
                };
                var r01 = Sistema.MyData.TomaInv_GenerarSolcitud(ficha);
                _procesarIsOk = true;
                Helpers.Msg.AgregarOk();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
        public void EliminarItem()
        {
            _lista.EiminarItem();
        }

        public void Lista_PorDefecto()
        {
            _tipoOrdenLista = enumeradoOrdenLista.PorDefecto;
        }
        public void Lista_PorMayorCosto()
        {
            _tipoOrdenLista = enumeradoOrdenLista.PorMayorCosto;
        }
        public void Lista_PorMayorMargen()
        {
            _tipoOrdenLista = enumeradoOrdenLista.PorMayorMargen;
        }
        public void Lista_PorMayorDemanda()
        {
            _tipoOrdenLista = enumeradoOrdenLista.PorMayorDemanda;
        }
        public void setCantidadPrdTomar(decimal cnt)
        {
            _cntPrdTomar = (int)cnt;
        }
    }
}