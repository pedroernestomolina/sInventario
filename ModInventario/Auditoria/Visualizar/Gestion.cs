using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Auditoria.Visualizar
{
    
    public class Gestion
    {

        private OOB.LibInventario.Auditoria.Entidad.Ficha _ficha;


        public string Motivo 
        {
            get 
            {
                var rt = "";
                if (_ficha != null) { rt = _ficha.motivo; }
                return rt;
            }
        }
        public string Fecha
        {
            get
            {
                var rt = "";
                if (_ficha != null) { rt = _ficha.fecha.ToShortDateString(); }
                return rt;
            }
        }





        public Gestion()
        {
            _ficha = null;
        }


        VisualizarFrm frm;
        public void Inicia() 
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new VisualizarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return true;
        }

        public void Inicializa()
        {
            _ficha = null;
        }

        public void setData(OOB.LibInventario.Auditoria.Entidad.Ficha ficha)
        {
            _ficha = ficha;
        }

    }

}