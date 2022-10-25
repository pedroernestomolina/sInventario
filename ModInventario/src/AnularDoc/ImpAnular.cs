using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.AnularDoc
{
    
    public class ImpAnular: IAnular
    {


        public bool AnularIsOK { get { return _procesarIsOk; } }


        public ImpAnular()
        {
            _motivo = "";
            _abandonarIsOk = false;
            _procesarIsOk = false;
        }


        public void Inicializa()
        {
            _motivo = "";
            _abandonarIsOk = false;
            _procesarIsOk = false;
        }
        AnularFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new AnularFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        private bool CargarData()
        {
            return true;
        }


        private string _motivo;
        public string GetMotivo_Desc { get { return _motivo; } }
        public void setMotivo(string desc)
        {
            _motivo = desc;
        }


        private bool _abandonarIsOk;
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = Helpers.Msg.Abandonar();
        }


        private bool _procesarIsOk;
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public void ProcesarFicha()
        {
            _procesarIsOk = false;
            if (_motivo.Trim() != "") 
            {
                var msg = MessageBox.Show("Seguir Con La Anulación ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                _procesarIsOk = msg == DialogResult.Yes ? true : false;
            }
        }

    }

}