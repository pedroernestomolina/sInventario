using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Producto.Imagen
{
    
    public class ImpImagen: IImagen
    {


        private string _autoPrd;
        private string _producto;
        private Image _imagen;


        public string GetProducto_Desc { get { return _producto; } }
        public Image GetProducto_Img { get { return _imagen; } }



        public ImpImagen()
        {
            _autoPrd = "";
            _producto = "";
            _imagen = null;
        }


        public void Inicializa()
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


        public void setFicha(string auto) 
        {
            _autoPrd = auto;
        }


        public bool AbandonarIsOk { get { return true; } }
        public void AbandonarFicha()
        {
        }


        private bool CargarData()
        {
            try
            {
                var r01 = Sistema.MyData.Producto_GetImagen(_autoPrd);
                _producto = r01.Entidad.codigo + Environment.NewLine + r01.Entidad.descripcion;
                if (r01.Entidad.imagen.Length > 0)
                {
                    using (var ms = new MemoryStream(r01.Entidad.imagen))
                    {
                        _imagen = Image.FromStream(ms);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }

    }

}