using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Producto.Imagen
{
    
    public interface IImagen: IGestion, ModInventario.Gestion.IAbandonar
    {

        void setFicha(string auto);
        string GetProducto_Desc { get; }
        Image GetProducto_Img { get; }

    }

}