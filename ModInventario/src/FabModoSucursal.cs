using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src
{
    
    public class FabModoSucursal: IFabrica
    {

        public ModInventario.Producto.Precio.VerVisualizar.IVisual CreateInstancia_VisualizarPrecio()
        {
            return new ModInventario.Producto.Precio.VerVisualizar.ModoSucursal.Visual();
        }
        public ModInventario.Producto.Precio.EditarCambiar.IEditar CreateInstancia_EditarCambiarPrecio()
        {
            return new ModInventario.Producto.Precio.EditarCambiar.ModoSucursal.Editar();
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
        public ModInventario.Producto.Precio.Historico.IHistorico CreateInstancia_HistoricoPrecio()
        {
            return new ModInventario.Producto.Precio.Historico.ModoSucursal.ImpSucursal();
        }
        public Producto.AgregarEditar.IBaseAgregarEditar CreateInstancia_AgregarPrd()
        {
            return null;
        }
        public Producto.AgregarEditar.IBaseAgregarEditar CreateInstancia_EditarPrd()
        {
            return null;
        }
        public ModInventario.Producto.VisualizarFicha.IVisualizar CreateInstancia_VisualizarPrd()
        {
            return new ModInventario.Producto.VisualizarFicha.Gestion();
        }


        ModInventario.Buscar.BusquedaFrm _frm;
        public object BuscarPrd
        {
            get { return _frm; }
        }
        public void CreateInstancia_BuscarPrd(ModInventario.Buscar.Gestion ctr)
        {
            _frm = new ModInventario.Buscar.BusquedaFrm();
            _frm.setControlador(ctr);
        }
        public void ShowBuscarPrd()
        {
            _frm.ShowDialog();
        }

    }

}