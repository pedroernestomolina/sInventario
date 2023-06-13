using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.TomaInv.Analisis.RecopilarData
{
    public class ImpRecopilar: IRecopilar
    {
        private bool _abandonaIsOk;
        private bool _procesarIsOk;
        private string _autorizadoPor;
        private string _motivo;


        public string Autorizado_GetData { get { return _autorizadoPor; } }
        public string Motivo_GetData { get { return _motivo; } }


        public void Inicializa()
        {
            _abandonaIsOk = false;
            _procesarIsOk = false;
            _autorizadoPor = "";
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


        public void setAutorizadoPor(string desc)
        {
            _autorizadoPor = desc;
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
            if (_autorizadoPor.Trim() == "") 
            {
                Helpers.Msg.Alerta("CAMPO [ AUTORIZADO POR ] NO PUEDE ESTAR VACIO");
                return;
            }
            if (_motivo.Trim() == "")
            {
                Helpers.Msg.Alerta("CAMPO [ MOTIVO / OBSERVACIONES ] NO PUEDE ESTAR VACIO");
                return;
            }
            var msg = "Estas De Acuerdo Con Los Datos Suministrados ?";
            var resp = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (resp == DialogResult.Yes)
            {
                _procesarIsOk = true;
            }
        }


        private bool CargarData()
        {
            return true;
        }
    }
}