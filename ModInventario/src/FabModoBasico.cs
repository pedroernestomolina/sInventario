using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src
{
    
    public class FabModoBasico: IFabrica
    {

        public ModInventario.Producto.Precio.VerVisualizar.IVisual CreateInstancia_VisualizarPrecio()
        {
            return new ModInventario.Producto.Precio.VerVisualizar.ModoBasico.Visual();
        }
        public ModInventario.Producto.Precio.EditarCambiar.IEditar CreateInstancia_EditarCambiarPrecio()
        {
            return new ModInventario.Producto.Precio.EditarCambiar.ModoBasico.Editar();
        }
        public FiltrosGen.AdmProducto.IAdmProducto CreateInstancia_FiltroPrdAdm()
        {
            return new src.FiltroBusqAdm.ModoBasico.ImpBasico();
        }
        public ModInventario.Producto.Precio.Historico.IHistorico CreateInstancia_HistoricoPrecio()
        {
            return new ModInventario.Producto.Precio.Historico.ModoSucursal.ImpSucursal();
        }
        public Producto.AgregarEditar.IBaseAgregarEditar CreateInstancia_AgregarPrd()
        {
            return new Producto.AgregarEditar.ModoBasico.Agregar.ImpAgregar();
        }
        public Producto.AgregarEditar.IBaseAgregarEditar CreateInstancia_EditarPrd()
        {
            return new Producto.AgregarEditar.ModoBasico.Editar.ImpEditar();
        }
        public ModInventario.Producto.VisualizarFicha.IVisualizar CreateInstancia_VisualizarPrd()
        {
            return new Producto.Visualizar.ModoBasico.Gestion();
        }
        public Filtro.IFiltro CreateInstancia_FiltrosReporte()
        {
            return new ModInventario.src.Filtro.FiltroRep.ModoBasico.ImpModoBasico();
        }


        ModInventario.src.Buscar.ModoBasico.BusquedaFrm _frm;
        public object BuscarPrd
        {
            get { return _frm; }
        }
        public void CreateInstancia_BuscarPrd(ModInventario.Buscar.Gestion ctr)
        {
            _frm = new ModInventario.src.Buscar.ModoBasico.BusquedaFrm();
            _frm.setControlador(ctr);
        }
        public void ShowBuscarPrd()
        {
            _frm.ShowDialog();
        }

    }

}