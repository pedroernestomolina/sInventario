using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src
{
    
    public interface IFabrica
    {
        ModInventario.Producto.Precio.VerVisualizar.IVisual 
            CreateInstancia_VisualizarPrecio();
        ModInventario.Producto.Precio.EditarCambiar.IEditar 
            CreateInstancia_EditarCambiarPrecio();
        FiltrosGen.AdmProducto.IAdmProducto 
            CreateInstancia_FiltroPrdAdm();
        ModInventario.Producto.Precio.Historico.IHistorico 
            CreateInstancia_HistoricoPrecio();
        ModInventario.src.Producto.AgregarEditar.IBaseAgregarEditar 
            CreateInstancia_AgregarPrd();
        ModInventario.src.Producto.AgregarEditar.IBaseAgregarEditar 
            CreateInstancia_EditarPrd();
        ModInventario.Producto.VisualizarFicha.IVisualizar 
            CreateInstancia_VisualizarPrd();


        object BuscarPrd { get; }
        void CreateInstancia_BuscarPrd(ModInventario.Buscar.Gestion gestion);
        void ShowBuscarPrd();



        Filtro.IFiltro CreateInstancia_FiltrosReporte();
    }

}