using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src
{
    
    public class FabModoSoloReporte: IFabrica
    {
        public void Iniciar_FrmPrincipal(GestionInv ctr)
        {
            var frm = new ModInventario.src.Inicio.ModoSoloReporte.Principal();
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
        public ModInventario.Buscar.Gestion 
            CreateInstancia_HndProducto(ISeguridadAccesoSistema _seguridad, IFabrica _fabrica)
        {
            return null;
        }

        public object BuscarPrd
        {
            get { throw new NotImplementedException(); }
        }
        public void CreateInstancia_BuscarPrd(ModInventario.Buscar.Gestion gestion)
        {
        }
        public void ShowBuscarPrd()
        {
        }

        public Visor.Traslado.IVisorTraslado 
            CreateInstancia_VisorTraslado()
        {
            return new src.Visor.Traslado.ModoSoloReporte.ImpVisorTraslado();
        }
        public Visor.GananciaPerdida.IVisorGanPerd 
            CreateInstancia_VisorGananciaPerdida()
        {
            return new src.Visor.GananciaPerdida.ModoSoloReporte.ImpVisorGanPerd();
        }
        public Visor.Precios.IPrecio
            CreateInstancia_VisorPrecio()
        {
            return new src.Visor.Precios.ModoSoloReporte.ImpVisor();
        }
        public Visor.EntradaxCompra.IEntradaxCompra 
            CreateInstancia_VisorEntradaxCompra()
        {
            return new src.Visor.EntradaxCompra.ModoSoloReporte.ImpSoloReporte();
        }

        //public Filtro.FiltroRep.IFiltroRep 
        //    CreateInstancia_FiltrosReporte()
        //{
        //    var filtroBusPrd = CreateInstancia_FiltroBusqProducto();
        //    return new src.Filtro.FiltroRep.ModoSoloReporte.ImpModo(filtroBusPrd);
        //}

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


        public AdmDocumentos.IAdmDoc
            CreateInstancia_AdmDocumentos()
        {
            return new ModInventario.src.AdmDocumentos.ModoSoloReporte.ImpModoReporte(
                CreateInstancia_FiltrosAdmDoc(),
                CreateInstancia_ListaAdmDoc(),
                CreateInstancia_AuditoriaDoc(),
                CreateInstancia_AnularDoc());
        }
        Utils.FiltrosPara.AdmDocumentos.IAdmDoc _filtrosParaAdmDoc;
        private Utils.FiltrosPara.AdmDocumentos.IAdmDoc
            CreateInstancia_FiltrosAdmDoc()
        {
            if (_filtrosParaAdmDoc == null)
            {
                _filtrosParaAdmDoc = new Utils.FiltrosPara.AdmDocumentos.ModoSucursal.ImpModoSucursal();
            }
            return _filtrosParaAdmDoc;
        }


        private ModInventario.src.AdmDocumentos.IListaAdmDoc
            CreateInstancia_ListaAdmDoc()
        {
            return new ModInventario.src.AdmDocumentos.ImpListaAdmDoc();
        }
        private ModInventario.src.Auditoria.Visualizar.IVisualizar
            CreateInstancia_AuditoriaDoc()
        {
            return new ModInventario.src.Auditoria.Visualizar.ImpVisualizar();
        }
        private ModInventario.src.AnularDoc.IAnular
            CreateInstancia_AnularDoc()
        {
            return new ModInventario.src.AnularDoc.ImpAnular();
        }
        public bool ReporteMaestroPrecio_Validar_SeleccionarPrecio { get { return true; } }
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
            if (_filtrosParaReportes == null)
            {
                _filtrosParaReportes = new Utils.FiltrosPara.Reportes.ModoSucursal.ImpModo();
            }
            return _filtrosParaReportes;
        }

        public Reportes.Filtros.IFiltros CreateInstancia_RepMasterProductos_Filtros()
        {
            return new Reportes.Filtros.MaestroProducto.Filtros();
        }
        public Reporte.IReporte CreateInstancia_RepMasterProductos()
        {
            return new Reportes.Filtros.MaestroProducto.GestionRep();
        }

        public Reportes.Filtros.IFiltros CreateInstancia_RepMasterPrecio_Filtros()
        {
            return new Reportes.Filtros.MaestroPrecioSoloReporte.Filtros();
        }
        public Reporte.IReporte CreateInstancia_RepMasterPrecio()
        {
            return new Reportes.Filtros.MaestroPrecioSoloReporte.GestionRep();
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
            return new Reportes.Filtros.MaestroExistenciaInventario.FiltrosModoSoloReporte();
        }
        public Reporte.IReporte CreateInstancia_RepMaestroExistenciaInventario()
        {
            return new Reportes.Filtros.MaestroExistenciaInventario.GestionRep();
        }

        public Reporte.IReporte CreateInstancia_RepMaestroDepositoResumen()
        {
            return null;
        }

        public Reportes.Filtros.IFiltros CreateInstancia_RepNivelMinimo_Filtros()
        {
            return new Reportes.Filtros.NivelMInimo.FiltrosModoSoloReporte();
        }
        public Reporte.IReporte CreateInstancia_RepNivelMinimo()
        {
            return new Reportes.Filtros.NivelMInimo.GestionRep();
        }

        public Reportes.Filtros.IFiltros CreateInstancia_RepKardex_Filtros()
        {
            return new Reportes.Filtros.Kardex.FiltrosModoSoloReporte();
        }
        public Reporte.IReporte CreateInstancia_RepKardex()
        {
            return new Reportes.Filtros.Kardex.GestionRep();
        }

        public Reportes.Filtros.IFiltros CreateInstancia_RepKardexResumenMov_Filtros()
        {
            return new Reportes.Filtros.KardexResumen.FiltrosModoSoloReporte();
        }
        public Reporte.IReporte CreateInstancia_RepKardexResumenMov()
        {
            return new Reportes.Filtros.KardexResumen.GestionRep();
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