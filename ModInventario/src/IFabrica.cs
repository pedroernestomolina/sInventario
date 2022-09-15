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
        FiltrosGen.AdmProducto.IAdmProducto CreateInstancia_FiltroPrdAdm();
        Producto.Precio.Historico.IHistorico CreateInstancia_HistoricoPrecio();

    }

}