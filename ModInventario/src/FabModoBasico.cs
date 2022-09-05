using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src
{
    
    public class FabModoBasico: IFabrica
    {

        public Producto.Precio.VerVisualizar.IVisual CreateInstancia_VisualizarPrecio()
        {
            return new Producto.Precio.VerVisualizar.ModoBasico.Visual();
        }
        public Producto.Precio.EditarCambiar.IEditar CreateInstancia_EditarCambiarPrecio()
        {
            return new Producto.Precio.EditarCambiar.ModoBasico.Editar();
        }

    }

}