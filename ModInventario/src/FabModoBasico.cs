using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src
{
    
    public class FabModoBasico: IFabrica
    {
        public void Iniciar_FrmPrincipal(GestionInv ctr)
        {
            var frm = new ModInventario.src.Inicio.ModoBasico.Form2();
            frm.setControlador(ctr);
            frm.ShowDialog();
        }
        public ModInventario.Producto.Precio.VerVisualizar.IVisual 
            CreateInstancia_VisualizarPrecio()
        {
            return new ModInventario.Producto.Precio.VerVisualizar.ModoBasico.Visual();
        }
        public ModInventario.Producto.Precio.EditarCambiar.IEditar 
            CreateInstancia_EditarCambiarPrecio()
        {
            return new ModInventario.Producto.Precio.EditarCambiar.ModoBasico.Editar();
        }
        public FiltrosGen.AdmProducto.IAdmProducto 
            CreateInstancia_FiltroPrdAdm()
        {
            return new src.FiltroBusqAdm.ModoBasico.ImpBasico();
        }
        public ModInventario.Producto.Precio.Historico.IHistorico 
            CreateInstancia_HistoricoPrecio()
        {
            return new ModInventario.Producto.Precio.Historico.ModoSucursal.ImpSucursal();
        }
        public Producto.AgregarEditar.IBaseAgregarEditar 
            CreateInstancia_AgregarPrd()
        {
            return new Producto.AgregarEditar.ModoBasico.Agregar.ImpAgregar();
        }
        public Producto.AgregarEditar.IBaseAgregarEditar 
            CreateInstancia_EditarPrd()
        {
            return new Producto.AgregarEditar.ModoBasico.Editar.ImpEditar();
        }
        public ModInventario.Producto.VisualizarFicha.IVisualizar 
            CreateInstancia_VisualizarPrd()
        {
            return new Producto.Visualizar.ModoBasico.Gestion();
        }
        public Filtro.FiltroRep.IFiltroRep 
            CreateInstancia_FiltrosReporte()
        {
            return new ModInventario.src.Filtro.FiltroRep.ModoBasico.ImpModoBasico();
        }
        public AdmDocumentos.IAdmDoc 
            CreateInstancia_AdmDocumentos()
        {
            return new ModInventario.src.AdmDocumentos.ModoBasico.ImpModoBasico(
                CreateInstancia_FiltrosAdmDoc(), 
                CreateInstancia_ListaAdmDoc(),
                CreateInstancia_AuditoriaDoc(),
                CreateInstancia_AnularDoc());
        }

        ModInventario.src.Buscar.ModoBasico.BusquedaFrm _frm;
        public object BuscarPrd
        {
            get { return _frm; }
        }

        public void
            CreateInstancia_BuscarPrd(ModInventario.Buscar.Gestion ctr)
        {
            _frm = new ModInventario.src.Buscar.ModoBasico.BusquedaFrm();
            _frm.setControlador(ctr);
        }
        public void 
            ShowBuscarPrd()
        {
            _frm.ShowDialog();
        }

        private Filtro.FiltroAdmDoc.IAdmDoc
            CreateInstancia_FiltrosAdmDoc()
        {
            var filtroBusPrd = CreateInstancia_FiltroBusqProducto();
            return new ModInventario.src.Filtro.FiltroAdmDoc.ModoBasico.ImpModoBasico(filtroBusPrd);
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
        public Producto.Imagen.IImagen 
            CreateInstancia_ImagenProducto()
        {
            return new ModInventario.src.Producto.Imagen.ImpImagen();
        }
        public Producto.QR.IQR
            CreateInstancia_ImagenQRProducto()
        {
            return new ModInventario.src.Producto.QR.ImpQR();
        }
        public ModInventario.Buscar.Gestion
            CreateInstancia_HndProducto(ISeguridadAccesoSistema _seguridad, IFabrica _fabrica)
        {
            var hndTCS = CreateInstancia_TallaColorSabor();
            return new ModInventario.Buscar.Gestion(
                CreateInstancia_FiltroPrdAdm(),
                _seguridad,
                CreateInstancia_ImagenQRProducto(),
                CreateInstancia_ImagenProducto(),
                CreateInstancia_AgregarPrd(),
                CreateInstancia_EditarPrd(),
                CreateInstancia_VisualizarPrd(),
                CreateInstancia_EditarCambiarPrecio(),
                CreateInstancia_VisualizarPrecio(),
                CreateInstancia_HistoricoPrecio(),
                hndTCS,
                CreateInstancia_ListarVisDepositos(hndTCS),
                _fabrica);
        }

        private TallaColorSabor.Visualizar.IVer 
            CreateInstancia_TallaColorSabor()
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
        public Reporte.IReporte
            CreateInstancia_RepMasterPrecio()
        {
            return new Reportes.Filtros.MaestroPrecioBasico.GestionRep();
        }
        public Reportes.Filtros.IFiltros 
            CreateInstancia_RepMasterPrecio_Filtros()
        {
            return new Reportes.Filtros.MaestroPrecioBasico.Filtros();
        }
        private Producto.Deposito.VerLista.IVerLista
            CreateInstancia_ListarVisDepositos(src.TallaColorSabor.Visualizar.IVer hndTCS)
        {
            var hndVisualizarDeposito = CreateInstancia_VisualizarDeposito();
            var hndEditarDeposito = CreateInstancia_EditarDeposito();
            return new src.Producto.Deposito.VerLista.ImpVerLista(hndTCS,
                                                                    hndVisualizarDeposito,
                                                                    hndEditarDeposito);
        }
        private src.Producto.Deposito.Editar.IEditar 
            CreateInstancia_EditarDeposito()
        {
            return new src.Producto.Deposito.Editar.ImpEditar();        }
        private src.Producto.Deposito.Visualizar.IVisualizar
            CreateInstancia_VisualizarDeposito()
        {
            return new src.Producto.Deposito.Visualizar.ImpVisualizar();
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
    }
}