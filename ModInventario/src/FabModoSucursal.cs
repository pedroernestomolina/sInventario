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
            return new src.Producto.AgregarEditar.ModoSucursal.Agregar.ImpAgregar(CrearInstancia_Seguridad_Modo_NivelAcceso_Usuario(SeguridadSist.Usuario.enumerados.enumTipo.GrupoAdministrador));
        }
        public Producto.AgregarEditar.IBaseAgregarEditar CreateInstancia_EditarPrd()
        {
            return new src.Producto.AgregarEditar.ModoSucursal.Editar.ImpEditar(CrearInstancia_Seguridad_Modo_NivelAcceso_Usuario(SeguridadSist.Usuario.enumerados.enumTipo.GrupoAdministrador));
        }
        public ModInventario.Producto.VisualizarFicha.IVisualizar CreateInstancia_VisualizarPrd()
        {
            return new ModInventario.Producto.VisualizarFicha.Gestion();
        }
        public Filtro.IFiltro CreateInstancia_FiltrosReporte()
        {
            var filtroBusPrd = CreateInstancia_FiltroBusqProducto();
            return new ModInventario.src.Filtro.FiltroRep.ModoSucursal.ImpModoSucursal(filtroBusPrd);
        }

        private FiltrosGen.IBuscar CreateInstancia_FiltroBusqProducto()
        {
            var listaPrdSel = CreateInstancia_ListaSeleccionableProducto();
            return new FiltrosGen.BuscarProducto.Gestion(listaPrdSel);
        }

        private ModInventario.Buscar.INotificarSeleccion CreateInstancia_ListaSeleccionableProducto()
        {
            return new ModInventario.Producto.ListaSel.Gestion();
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


        private SeguridadSist.ISeguridad CrearInstancia_Seguridad_Modo_NivelAcceso_Usuario(SeguridadSist.Usuario.enumerados.enumTipo modo) 
        {
            SeguridadSist.Usuario.IModoUsuario _gModoNivelAcceso = new SeguridadSist.Usuario.Gestion(); 
            _gModoNivelAcceso.setUsuarioValidar(modo);
            SeguridadSist.ISeguridad _gSecurity = new SeguridadSist.Gestion();
            _gSecurity.setGestionTipo(_gModoNivelAcceso);
            return _gSecurity;
        }

    }

}