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
        private bool _abandonarIsOk;
        private bool _procesarIsOk;
        private ICtrl _sucOrigen;
        private ICtrlLink _depOrigen;
        private string _motivo;
        private string _autorizadoPor;
        private DateTime _fechaSist;
        private decimal _cntDias;
        private ILista _lista;


        public string GetEnt_Motivo { get { return _motivo; } }
        public string GetEnt_AutorizadoPor { get { return _autorizadoPor; } }
        public DateTime GetFechaSistema { get { return _fechaSist; } }
        public ICtrl SucOrigen { get { return _sucOrigen; } }
        public ICtrlLink DepOrigen { get { return _depOrigen; } }
        public decimal GetCntDias { get { return _cntDias; } }
        public BindingSource GetSource { get { return _lista.GetDataSource; } }


        public ImpGenerar()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _autorizadoPor = "";
            _fechaSist = DateTime.Now.Date;
            _motivo = "";
            _sucOrigen = new Utils.Tools.Sucursal.Imp();
            _depOrigen = new Utils.Tools.Deposito.Imp();
            _cntDias = 45m;
            _lista = new ImpLista();
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
                return;
            }
            if (_motivo.Trim() == "")
            {
                return;
            }
            if (_lista.GetLista.Count<=0)
            {
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
                return;
            }
            if (_depOrigen.GetItem == null)
            {
                return;
            }
            if (_cntDias <= 0m)
            {
                return;
            }
            var filtro = new OOB.LibInventario.TomaInv.ObtenerToma.Filtro()
            {
                idDeposito = _depOrigen.GetId,
                periodoDias = (int)_cntDias,
                idDepartExcluir = new List<string>() { "0000000004" },
            };
            var r01 = Sistema.MyData.TomaInv_GetListaPrd(filtro);
            if (r01.Result != OOB.Enumerados.EnumResult.isError)
            {
                var _lst = new List<TomaInv.data>();
                foreach (var r in r01.Lista)
                {
                    var rg = new TomaInv.data() { cnt = r.cnt, codigoPrd = r.codigoPrd, costoPrd = r.costoPrd, descPrd = r.descPrd, idPrd = r.idPrd, margen = r.margen };
                    _lst.Add(rg);
                }
                _lst.Sort();
                _lst.Reverse();
                _lista.setDataListar(_lst);
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
                _cntDias = 45m;
                _lista.Inicializa();
            }
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
                    var nr = new OOB.LibInventario.TomaInv.GenerarToma.PrdToma()
                    {
                        IdPrd = s.PrdToma.idPrd,
                    };
                    return nr;
                }).ToList();
                var ficha = new OOB.LibInventario.TomaInv.GenerarToma.Ficha()
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
                var r01 = Sistema.MyData.TomaInv_GenerarToma(ficha);
                _procesarIsOk = true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
    }
}