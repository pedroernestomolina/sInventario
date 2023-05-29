using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Traslado.CapturaMov
{
    
    public class ImpCapturaMovTraslado: ICapturaMovTraslado
    {
        public event EventHandler ItemCapturado;


        private bool _modoEditar;
        private Tools.CapturaMov.IDataCaptura _itEditar;
        private decimal _tasaCambio;
        private bool _procesarIsOk;
        private bool _abandonarIsOk;
        private Tools.CapturaMov.IDataCaptura _dataMov;
        private Tools.InfPrd.IPrdInf _infPrd;
        private string _idDepOrigen;
        private string _idDepDestino;


        public Tools.CapturaMov.IDataCaptura Captura { get { return _dataMov; } }


        public ImpCapturaMovTraslado() 
        {
            _modoEditar = false;
            _tasaCambio = 0m;
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _itEditar = null;
            _infPrd = new Tools.InfPrd.ImpPrdInf();
            _idDepDestino = "";
            _idDepOrigen = "";
        }


        public void Inicializa()
        {
            _modoEditar = false;
            _tasaCambio = 0m;
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _dataMov = new Tools.CapturaMov.ImpDataCaptura();
            _itEditar = null;
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


        public void setData(data dat)
        {
            _idDepOrigen = dat.autoDepOrigen;
            _idDepDestino = dat.autoDepDestino;
            _dataMov.setFicha(dat);
        }
        public void setDataEditar(Tools.CapturaMov.IDataCaptura it)
        {
            _modoEditar = true;
            _itEditar = it;
        }
        public void setTasaCambio(decimal tasaCambio)
        {
            _dataMov.setTasaCambio(tasaCambio);
        }


        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = Helpers.Msg.Abandonar();
        }
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public void ProcesarFicha()
        {
            _procesarIsOk = false;
            if (_dataMov.ValidarParaProcesarIsOk()) 
            {
                _procesarIsOk = false;
                var xmsg = "Guardar Cambios ?";
                var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    _procesarIsOk = true;
                    EventHandler hnd = ItemCapturado;
                    if (hnd != null) 
                    {
                        hnd.Invoke(this, null);
                    }
                }
            }
        }


        private bool CargarData()
        {
            _dataMov.Empaque.CargarData();

            if (_modoEditar)
            {
                _dataMov.setFicha(_itEditar.Ficha.GetFicha);
                _dataMov.setCantidad(_itEditar.Cantidad);
                _dataMov.setCosto(_itEditar.CostoNeto);
                _dataMov.setEmpaque(_itEditar.Empaque.GetId);
                _dataMov.setTasaCambio(_itEditar.TasaCambio);
            }
            return true;
        }


        public void InfDepDestino()
        {
            _infPrd.Inicializa();
            _infPrd.setIdPrd(_dataMov.AutoPrd);
            _infPrd.setIdDeposito(_idDepDestino);
            _infPrd.Inicia();
        }
    }
}