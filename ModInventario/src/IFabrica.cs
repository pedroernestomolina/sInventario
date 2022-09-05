using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src
{
    
    public interface IFabrica
    {

        Producto.Precio.VerVisualizar.IVisual CreateInstancia_VisualizarPrecio();
        Producto.Precio.EditarCambiar.IEditar CreateInstancia_EditarCambiarPrecio();

    }

}