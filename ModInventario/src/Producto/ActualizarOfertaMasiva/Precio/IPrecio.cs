using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Producto.ActualizarOfertaMasiva.Precio
{
    public interface IPrecio
    {
        BindingSource GetSource { get; }
        string GetId { get; }

        void setId(string id);

        void Inicializa();
        void CargarData();
    }
}