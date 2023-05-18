using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src
{
    
    public interface IFabrica
    {
        void Iniciar_FrmPrincipal(ModInventario.GestionInv ctr);
        ModInventario.Producto.Precio.VerVisualizar.IVisual 
            CreateInstancia_VisualizarPrecio();
        ModInventario.Producto.Precio.EditarCambiar.IEditar 
            CreateInstancia_EditarCambiarPrecio();

        //FiltrosGen.AdmProducto.IAdmProducto 
        //    CreateInstancia_FiltroPrdAdm();

        ModInventario.Producto.Precio.Historico.IHistorico 
            CreateInstancia_HistoricoPrecio();
        ModInventario.src.Producto.AgregarEditar.IBaseAgregarEditar 
            CreateInstancia_AgregarPrd();
        ModInventario.src.Producto.AgregarEditar.IBaseAgregarEditar 
            CreateInstancia_EditarPrd();
        ModInventario.Producto.VisualizarFicha.IVisualizar 
            CreateInstancia_VisualizarPrd();
        AdmDocumentos.IAdmDoc 
            CreateInstancia_AdmDocumentos();
        ModInventario.src.Producto.Imagen.IImagen
            CreateInstancia_ImagenProducto();
        ModInventario.src.Producto.QR.IQR
            CreateInstancia_ImagenQRProducto();
        //Filtro.FiltroRep.IFiltroRep 
        //    CreateInstancia_FiltrosReporte();
        ModInventario.Buscar.Gestion 
            CreateInstancia_HndProducto(ISeguridadAccesoSistema _seguridad, IFabrica _fabrica);
        ModInventario.src.Visor.Traslado.IVisorTraslado 
            CreateInstancia_VisorTraslado();
        ModInventario.src.Visor.GananciaPerdida.IVisorGanPerd 
            CreateInstancia_VisorGananciaPerdida();
        ModInventario.src.Visor.Precios.IPrecio 
            CreateInstancia_VisorPrecio();
        ModInventario.src.Visor.EntradaxCompra.IEntradaxCompra 
            CreateInstancia_VisorEntradaxCompra();

        object BuscarPrd { get; }
        void CreateInstancia_BuscarPrd(ModInventario.Buscar.Gestion gestion);
        void ShowBuscarPrd();

        bool ReporteMaestroPrecio_Validar_SeleccionarPrecio { get;  }

        ModInventario.src.Producto.ActualizarOferta.IActOferta 
            CreateInstancia_OfertaDscto();

        ModInventario.src.Producto.ActualizarOfertaMasiva.IOferta 
            CreateInstancia_AsginacionMasivaOferta();

        //
        Utils.FiltrosPara.Reportes.IFiltroRep
            CreateInstancia_FiltrosParaReportes();
        //
        Reportes.Filtros.IFiltros 
            CreateInstancia_RepMasterProductos_Filtros();
        Reporte.IReporte
            CreateInstancia_RepMasterProductos();

        Reportes.Filtros.IFiltros 
            CreateInstancia_RepMasterPrecio_Filtros();
        Reporte.IReporte 
            CreateInstancia_RepMasterPrecio();

        Reportes.Filtros.IFiltros 
            CreateInstancia_RepMaestroInventario_Filtros();
        Reporte.IReporte 
            CreateInstancia_RepMaestroInventario();

        Reportes.Filtros.IFiltros 
            CreateInstancia_RepMaestroExistenciaDetalle_Filtros();
        Reporte.IReporte 
            CreateInstancia_RepMaestroExistenciaDetalle();

        Reportes.Filtros.IFiltros 
            CreateInstancia_RepMaestroExistenciaInventario_Filtros();
        Reporte.IReporte 
            CreateInstancia_RepMaestroExistenciaInventario();

        Reporte.IReporte 
            CreateInstancia_RepMaestroDepositoResumen();

        Reportes.Filtros.IFiltros 
            CreateInstancia_RepNivelMinimo_Filtros();
        Reporte.IReporte 
            CreateInstancia_RepNivelMinimo();

        Reportes.Filtros.IFiltros 
            CreateInstancia_RepKardex_Filtros();
        Reporte.IReporte 
            CreateInstancia_RepKardex();

        Reportes.Filtros.IFiltros
            CreateInstancia_RepKardexResumenMov_Filtros();
        Reporte.IReporte 
            CreateInstancia_RepKardexResumenMov();

        Reportes.Filtros.IFiltros 
            CreateInstancia_RepValorizacionInventario_Filtros();
        Reporte.IReporte 
            CreateInstancia_RepValorizacionInventario();

        Reportes.Filtros.IFiltros 
            CreateInstancia_RepRelacionCompraVenta_Filtros();
        Reporte.IReporte 
            CreateInstancia_RepRelacionCompraVenta();

        Reportes.Filtros.IFiltros 
            CreateInstancia_RepResumenCostoInventario_Filtros();
        Reporte.IReporte 
            CreateInstancia_RepResumenCostoInventario();
    }
}