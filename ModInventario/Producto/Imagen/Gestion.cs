using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Imagen
{
    
    public class Gestion: IImagen
    {


        private string _autoPrd;
        private string _producto;
        private Image _imagen;


        public string Producto { get { return _producto; } }
        public Image Imagen { get { return _imagen; } }


        public Gestion()
        {
            _autoPrd = "";
            _producto = "";
            _imagen = null;
        }


        ImgFrm frm;
        public void Inicia()
        {
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

            var r01 = Sistema.MyData.Producto_GetImagen(_autoPrd);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _producto = r01.Entidad.codigo+Environment.NewLine+r01.Entidad.descripcion;
            if (r01.Entidad.imagen.Length > 0)
            {
                using (var ms = new MemoryStream(r01.Entidad.imagen))
                {
                    _imagen = Image.FromStream(ms);
                }
            }

            return rt;
        }

        public void setFicha(string auto) 
        {
            _autoPrd = auto;
        }

        public void Inicializa()
        {
            _autoPrd = "";
            _producto = "";
            _imagen = null;
        }

    }

}