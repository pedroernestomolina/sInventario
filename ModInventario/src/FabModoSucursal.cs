using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src
{
    public class FabModoSucursal: IFabrica
    {
        public void Iniciar_FrmPrincipal(GestionInv ctr)
        {
            var frm = new ModInventario.src.Inicio.ModoSucursal.Principal();
            frm.setControlador(ctr);
            frm.ShowDialog();
        }
        public ModInventario.Producto.Precio.VerVisualizar.IVisual 
            CreateInstancia_VisualizarPrecio()
        {
            return new ModInventario.Producto.Precio.VerVisualizar.ModoSucursal.Visual();
        }
        public ModInventario.Producto.Precio.EditarCambiar.IEditar 
            CreateInstancia_EditarCambiarPrecio()
        {
            return new ModInventario.Producto.Precio.EditarCambiar.ModoSucursal.Editar();
        }
        public FiltrosGen.AdmProducto.IAdmProducto 
            CreateInstancia_FiltroPrdAdm()
        {
            var BuscarProv = CreateInstancia_BusquedaProveedor();
            return new src.FiltroBusqAdm.ModoSucursal.ImpSucursal(BuscarProv);
        }
        private FiltrosGen.IBuscar 
            CreateInstancia_BusquedaProveedor()
        {
            return new FiltrosGen.BuscarProveedor.Gestion(new Proveedor.ListaSel.Gestion());
        }
        public ModInventario.Producto.Precio.Historico.IHistorico 
            CreateInstancia_HistoricoPrecio()
        {
            return new ModInventario.Producto.Precio.Historico.ModoSucursal.ImpSucursal();
        }
        public Producto.AgregarEditar.IBaseAgregarEditar 
            CreateInstancia_AgregarPrd()
        {
            return new src.Producto.AgregarEditar.ModoSucursal.Agregar.ImpAgregar(CrearInstancia_Seguridad_Modo_NivelAcceso_Usuario(SeguridadSist.Usuario.enumerados.enumTipo.GrupoAdministrador));
        }
        public Producto.AgregarEditar.IBaseAgregarEditar 
            CreateInstancia_EditarPrd()
        {
            return new src.Producto.AgregarEditar.ModoSucursal.Editar.ImpEditar(CrearInstancia_Seguridad_Modo_NivelAcceso_Usuario(SeguridadSist.Usuario.enumerados.enumTipo.GrupoAdministrador));
        }
        public ModInventario.Producto.VisualizarFicha.IVisualizar 
            CreateInstancia_VisualizarPrd()
        {
            return new ModInventario.Producto.VisualizarFicha.Gestion();
        }
        public Filtro.FiltroRep.IFiltroRep 
            CreateInstancia_FiltrosReporte()
        {
            var filtroBusPrd = CreateInstancia_FiltroBusqProducto();
            return new ModInventario.src.Filtro.FiltroRep.ModoSucursal.ImpModoSucursal(filtroBusPrd);
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
        public AdmDocumentos.IAdmDoc 
            CreateInstancia_AdmDocumentos()
        {
            return new ModInventario.src.AdmDocumentos.ModoSucursal.ImpModoSucursal(
                CreateInstancia_FiltrosAdmDoc(),
                CreateInstancia_ListaAdmDoc(),
                CreateInstancia_AuditoriaDoc(),
                CreateInstancia_AnularDoc());
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

        private SeguridadSist.ISeguridad 
            CrearInstancia_Seguridad_Modo_NivelAcceso_Usuario(SeguridadSist.Usuario.enumerados.enumTipo modo) 
        {
            SeguridadSist.Usuario.IModoUsuario _gModoNivelAcceso = new SeguridadSist.Usuario.Gestion(); 
            _gModoNivelAcceso.setUsuarioValidar(modo);
            SeguridadSist.ISeguridad _gSecurity = new SeguridadSist.Gestion();
            _gSecurity.setGestionTipo(_gModoNivelAcceso);
            return _gSecurity;
        }
        private Filtro.FiltroAdmDoc.IAdmDoc
            CreateInstancia_FiltrosAdmDoc()
        {
            var filtroBusPrd = CreateInstancia_FiltroBusqProducto();
            return new ModInventario.src.Filtro.FiltroAdmDoc.ModoSucursal.ImpModoSucursal(filtroBusPrd);
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
        public ModInventario.src.Producto.Imagen.IImagen
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

        public Visor.Traslado.IVisorTraslado 
            CreateInstancia_VisorTraslado()
        {
            return new src.Visor.Traslado.ModoSucursal.ImpModo();
        }
        public Visor.GananciaPerdida.IVisorGanPerd 
            CreateInstancia_VisorGananciaPerdida()
        {
            return new src.Visor.GananciaPerdida.ModoSucursal.ImpModo();
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
            return new Reportes.Filtros.MaestroPrecioSucursal.GestionRep();
        }
        public Reportes.Filtros.IFiltros 
            CreateInstancia_RepMasterPrecio_Filtros()
        {
            return new Reportes.Filtros.MaestroPrecioSucursal.Filtros();
        }
        private TallaColorSabor.Visualizar.IVer 
            CreateInstancia_TallaColorSabor()
        {
            return new src.TallaColorSabor.Visualizar.ImpVer();
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

        public bool ReporteMaestroPrecio_Validar_SeleccionarPrecio { get { return true; } }
        public Producto.ActualizarOferta.IActOferta
            CreateInstancia_OfertaDscto()
        {
            return null;
        }
    }
}