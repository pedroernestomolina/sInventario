using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Configuracion.CambiarPreciosAlModificarCosto
{
    
    public class Conf: IConf
    {

        private bool _opcion;
        private bool _abandonarIsOk;
        private bool _procesarIsOk;


        public Conf() 
        {
            _opcion = false;
            _abandonarIsOk = false;
            _procesarIsOk = false;
        }


        public void Inicializa()
        {
            _opcion = false;
            _abandonarIsOk = false;
            _procesarIsOk = false;
        }
        private ConfigurarFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new ConfigurarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var r01 = Sistema.MyData.Configuracion_PermitirCambiarPrecioAlModificarCosto();
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _opcion = r01.Entidad;
            return true;
        }


        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = false;
            var xmsg = "Abandonar Cambios Ficha ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _abandonarIsOk = true;
            }
        }

        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public void ProcesarFicha()
        {
            _procesarIsOk = false;
            var xmsg = "Procesar Cambios ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                var r01 = Sistema.MyData.Configuracion_SetPermitirCambiarPrecioAlModificarCosto(_opcion);
                if (r01.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _procesarIsOk = true;
                Helpers.Msg.EditarOk();
            }
        }


        public bool GetOpcion { get { return _opcion; } }
        public void setOpcion()
        {
            _opcion = !_opcion;
        }

    }

}