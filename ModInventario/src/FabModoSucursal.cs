using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src
{
    
    public class FabModoSucursal: IFabrica
    {

        public Producto.Precio.VerVisualizar.IVisual CreateInstancia_VisualizarPrecio()
        {
            return new Producto.Precio.VerVisualizar.ModoSucursal.Visual();
        }
        public Producto.Precio.EditarCambiar.IEditar CreateInstancia_EditarCambiarPrecio()
        {
            return new Producto.Precio.EditarCambiar.ModoSucursal.Editar();
        }

        public FiltrosGen.AdmProducto.IAdmProducto CreateInstancia_FiltroPrdAdm()
        {
            var BuscarProv = CreateInstancia_BusquedaProveedor();
            return new src.FiltroBusqAdm.ModoSucursal.ImpSucursal(BuscarProv);
        }
        private FiltrosGen.IBuscar CreateInstancia_BusquedaProveedor()
        {
            return new FiltrosGen.BuscarProveedor.Gestion(new Proveedor.ListaSel.Gestion());
        }

        public Producto.Precio.Historico.IHistorico CreateInstancia_HistoricoPrecio()
        {
            return new Producto.Precio.Historico.ModoSucursal.ImpSucursal();
        }

    }

}
