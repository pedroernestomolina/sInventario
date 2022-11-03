using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Producto.QR
{
    
    public interface IQR: IGestion, ModInventario.Gestion.IAbandonar
    {

        string GetProducto_Desc { get; }
        Image GetProducto_Img { get; }
        Image GetProducto_ImgQR { get; }
        void setFicha(string id);
        void ImprimirQR(System.Drawing.Printing.PrintPageEventArgs e);

    }

}