using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Configuracion.CostoEdad
{
    
    public class Gestion
    {

        private int _costoEdad;
        private bool _isOk;


        public int CostoEdad { get { return _costoEdad; } }
        public bool IsOk { get { return _isOk; } }

        
        public Gestion()
        {
            _costoEdad = 0;
            _isOk = false;
        }


        public void Inicializa()
        {
            _costoEdad = 0;
            _isOk = false;
        }

        CostoEdad.ConfigurarFrm frm;
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
            var rt = true;

            var r01 = Sistema.MyData.Configuracion_CostoEdadProducto();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _costoEdad = r01.Entidad;

            return rt;
        }

        public void setCostoEdad(int p)
        {
            _costoEdad = p;
        }

        public void Proesar()
        {
            _isOk=false;
            var msg = MessageBox.Show("Guardar Cambios ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg== DialogResult.Yes)
            {
                var fichaOOB= new OOB.LibInventario.Configuracion.CostoEdad.Editar.Ficha()
                {
                     Edad=_costoEdad,
                };
                var r01= Sistema.MyData.Configuracion_SetCostoEdadProducto(fichaOOB);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _isOk=true;
                Helpers.Msg.EditarOk();
            }

        }

    }

}