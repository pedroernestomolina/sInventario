using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src
{

    public class FabModoBasicoFoxSystem: IFabrica
    {
        public void Iniciar_FrmPrincipal(GestionInv ctr)
        {
            var frm = new ModInventario.src.Inicio.ModoBasicoFox.Principal();
            frm.setControlador(ctr);
            frm.ShowDialog();
        }
        public ModInventario.Producto.Precio.VerVisualizar.IVisual 
            CreateInstancia_VisualizarPrecio()
        {
            return null;
        }
        public ModInventario.Producto.Precio.EditarCambiar.IEditar 
            CreateInstancia_EditarCambiarPrecio()
        {
            return null;
        }
        public FiltrosGen.AdmProducto.IAdmProducto 
            CreateInstancia_FiltroPrdAdm()
        {
            return null;
        }
        public ModInventario.Producto.Precio.Historico.IHistorico 
            CreateInstancia_HistoricoPrecio()
        {
            return null;
        }
        public Producto.AgregarEditar.IBaseAgregarEditar 
            CreateInstancia_AgregarPrd()
        {
            return null;
        }
        public Producto.AgregarEditar.IBaseAgregarEditar 
            CreateInstancia_EditarPrd()
        {
            return null;
        }
        public ModInventario.Producto.VisualizarFicha.IVisualizar 
            CreateInstancia_VisualizarPrd()
        {
            return null;
        }
        public AdmDocumentos.IAdmDoc 
            CreateInstancia_AdmDocumentos()
        {
            return null;
        }
        public Producto.Imagen.IImagen 
            CreateInstancia_ImagenProducto()
        {
            return null;
        }
        public Producto.QR.IQR 
            CreateInstancia_ImagenQRProducto()
        {
            return null;
        }
        public Filtro.FiltroRep.IFiltroRep 
            CreateInstancia_FiltrosReporte()
        {
            var filtroBusPrd = CreateInstancia_FiltroBusqProducto();
            return new src.Filtro.FiltroRep.ModoBasicoFox.ImpModo(filtroBusPrd);
        }
        private FiltrosGen.IBuscar
            CreateInstancia_FiltroBusqProducto()
        {
            var listaPrdSel = CreateInstancia_ListaSeleccionableProducto();
            return new FiltrosGen.BuscarProducto.Gestion(listaPrdSel);
        }
        private ModInventario.Buscar.INotificarSeleccion
            CreateInstancia_ListaSeleccionableProducto()
        {
            return new ModInventario.Producto.ListaSel.Gestion();
        }
        public ModInventario.Buscar.Gestion 
            CreateInstancia_HndProducto(ISeguridadAccesoSistema _seguridad, IFabrica _fabrica)
        {
            return null;
        }
        public Visor.Traslado.IVisorTraslado 
            CreateInstancia_VisorTraslado()
        {
            return null;
        }
        public Visor.GananciaPerdida.IVisorGanPerd 
            CreateInstancia_VisorGananciaPerdida()
        {
            return null;
        }
        public Visor.Precios.IPrecio 
            CreateInstancia_VisorPrecio()
        {
            return null;
        }
        public Visor.EntradaxCompra.IEntradaxCompra 
            CreateInstancia_VisorEntradaxCompra()
        {
            return null;
        }

        public object BuscarPrd
        {
            get { return null; }
        }
        public void CreateInstancia_BuscarPrd(ModInventario.Buscar.Gestion gestion)
        {
        }
        public void ShowBuscarPrd()
        {
        }
        
        public bool ReporteMaestroPrecio_Validar_SeleccionarPrecio { get { return false; } }
        public Producto.ActualizarOferta.IActOferta 
            CreateInstancia_OfertaDscto()
        {
            return null;
        }
        public Producto.ActualizarOfertaMasiva.IOferta
            CreateInstancia_AsginacionMasivaOferta()
        {
            return null;
        }


        //
        private Utils.FiltrosPara.Reportes.IFiltroRep _filtrosParaReportes;
        public Utils.FiltrosPara.Reportes.IFiltroRep
            CreateInstancia_FiltrosParaReportes()
        {
            return null;
        }

        public Reportes.Filtros.IFiltros CreateInstancia_RepMasterProductos_Filtros()
        {
            return null;
        }
        public Reporte.IReporte CreateInstancia_RepMasterProductos()
        {
            return null;
        }

        public Reporte.IReporte CreateInstancia_RepMasterPrecio()
        {
            return new Reportes.Filtros.MaestroPrecioFox.GestionRep();
        }
        public Reportes.Filtros.IFiltros CreateInstancia_RepMasterPrecio_Filtros()
        {
            return new Reportes.Filtros.MaestroPrecioFox.Filtros();
        }

        public Reportes.Filtros.IFiltros CreateInstancia_RepMaestroInventario_Filtros()
        {
            return null;
        }
        public Reporte.IReporte CreateInstancia_RepMaestroInventario()
        {
            return null;
        }

        public Reportes.Filtros.IFiltros CreateInstancia_RepMaestroExistenciaDetalle_Filtros()
        {
            return null;
        }
        public Reporte.IReporte CreateInstancia_RepMaestroExistenciaDetalle()
        {
            return null;
        }

        public Reportes.Filtros.IFiltros CreateInstancia_RepMaestroExistenciaInventario_Filtros()
        {
            return null;
        }
        public Reporte.IReporte CreateInstancia_RepMaestroExistenciaInventario()
        {
            return null;
        }

        public Reporte.IReporte CreateInstancia_RepMaestroDepositoResumen()
        {
            return null;
        }

        public Reportes.Filtros.IFiltros CreateInstancia_RepNivelMinimo_Filtros()
        {
            return null;
        }
        public Reporte.IReporte CreateInstancia_RepNivelMinimo()
        {
            return null;
        }

        public Reportes.Filtros.IFiltros CreateInstancia_RepKardex_Filtros()
        {
            return null;
        }
        public Reporte.IReporte CreateInstancia_RepKardex()
        {
            return null;
        }

        public Reportes.Filtros.IFiltros CreateInstancia_RepKardexResumenMov_Filtros()
        {
            return null;
        }
        public Reporte.IReporte CreateInstancia_RepKardexResumenMov()
        {
            return null;
        }

        public Reportes.Filtros.IFiltros CreateInstancia_RepValorizacionInventario_Filtros()
        {
            return null;
        }
        public Reporte.IReporte CreateInstancia_RepValorizacionInventario()
        {
            return null;
        }

        public Reportes.Filtros.IFiltros CreateInstancia_RepRelacionCompraVenta_Filtros()
        {
            return null;
        }
        public Reporte.IReporte CreateInstancia_RepRelacionCompraVenta()
        {
            return null;
        }

        public Reportes.Filtros.IFiltros CreateInstancia_RepResumenCostoInventario_Filtros()
        {
            return null;
        }
        public Reporte.IReporte CreateInstancia_RepResumenCostoInventario()
        {
            return null;
        }
    }
}