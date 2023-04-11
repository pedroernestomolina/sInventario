using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Producto.ActualizarOfertaMasiva.ModoAdm
{
    public class ImpMasiva: IMasiva
    {


        public ImpMasiva()
        {
        }


        public void Inicializa()
        {
        }
        private Frm frm;
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
    }
}