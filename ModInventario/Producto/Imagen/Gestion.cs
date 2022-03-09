using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Imagen
{
    
    public class Gestion
    {


        private string autoPrd;
        private string producto;
        private byte[] imagen;


        public byte[] Imagen { get { return imagen; } }
        public string Producto { get { return producto; } }


        public Gestion()
        {
            autoPrd = "";
            producto = "";
            imagen = new byte[] { };
        }


        ImgFrm frm;
        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new ImgFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Producto_GetImagen(autoPrd);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            imagen = r01.Entidad.imagen;
            producto = r01.Entidad.codigo+Environment.NewLine+r01.Entidad.descripcion;

            return rt;
        }

        private void Limpiar()
        {
            producto = "";
            imagen = new byte[] { };
        }

        public void setFicha(string auto) 
        {
            autoPrd = auto;
        }

    }

}