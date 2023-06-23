using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.TomaInv.Analisis.Motivo
{
    public class ImpMotivo : IMotivo
    {
        private bool _abandonaIsOk;
        private bool _procesarIsOk;
        private string _motivo;


        public string GetMotivo { get { return _motivo; } }


        public ImpMotivo()
        {
            _abandonaIsOk = false;
            _procesarIsOk = false;
            _motivo = "";
        }


        public void Inicializa()
        {
            _abandonaIsOk = false;
            _procesarIsOk = false;
            _motivo = "";
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


        private bool CargarData()
        {
            return true;
        }


        public void setMotivo(string desc)
        {
            _motivo = desc;
        }


        public bool AbandonarIsOk { get { return _abandonaIsOk; } }
        public void AbandonarFicha()
        {
            _abandonaIsOk = Helpers.Msg.Abandonar();
        }

        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public void ProcesarFicha()
        {
            _procesarIsOk = false;
            if (_motivo.Trim() == "")
            {
                return;
            }
            _procesarIsOk = true;
        }
    }
}
