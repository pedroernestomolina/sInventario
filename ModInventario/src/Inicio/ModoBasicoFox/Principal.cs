using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Inicio.ModoBasicoFox
{

    public partial class Principal : Form
    {


        private GestionInv _controlador;
        private Timer timer;


        public Principal()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick +=timer_Tick;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var s = DateTime.Now;
            L_FECHA.Text = s.ToLongDateString();
            L_HORA.Text = s.ToLongTimeString();
        }

        private void BT_TRASLADO_MERC_SUCURSAL_NIVEL_MINIMO_Click(object sender, EventArgs e)
        {
            TrasladoMercanciaEntreSucursalPorNivelMinimo();
        }

        private void TrasladoMercanciaEntreSucursalPorNivelMinimo()
        {
            _controlador.TrasladoMercanciaEntreSucursalPorNivelMinimo();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            timer.Start();
            L_VERSION.Text = _controlador.Version;
            L_HOST.Text = _controlador.Host;
            L_USUARIO.Text = _controlador.Usuario;
            L_FECHA.Text = "";
            L_HORA.Text = "";
        }

        public void setControlador(GestionInv ctr) 
        {
            _controlador = ctr;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void TSM_MOVIMIENTO_TRASLADOMERCANCIAPOREXISTENCIADEBAJOMINIMO_Click(object sender, EventArgs e)
        {
            Movimientos_TrasladoEntreSucursal_PorExistenca_DebajoMinimo();
        }
        private void Movimientos_TrasladoEntreSucursal_PorExistenca_DebajoMinimo()
        {
            _controlador.TrasladoMercanciaEntreSucursalPorNivelMinimo();
        }

        private void TSM_ARCHIVO_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void TSM_AJUSTE_DefinirNivelMinimoMaximo_Click(object sender, EventArgs e)
        {
            Ajuste_DefinirNivelMinimoMaximo();
        }

        private void Ajuste_DefinirNivelMinimoMaximo()
        {
            VisibilidadOff();
            _controlador.Ajuste_DefinirNivelMinimoMaximo();
            VisibilidadOn();
        }

        private void VisibilidadOn()
        {
            this.Visible = true;
        }

        private void VisibilidadOff()
        {
            this.Visible = false;
        }

        private void TSM_MAESTROS_Departamentos_Click(object sender, EventArgs e)
        {
            MaestroDepartamentos();
        }
        private void MaestroDepartamentos()
        {
            _controlador.MaestroDepartamentos();
        }

        private void TSM_MAESTRO_Grupo_Click(object sender, EventArgs e)
        {
            MaestroGrupo();
        }
        private void MaestroGrupo()
        {
            _controlador.MaestroGrupo();
        }

        private void TSM_MAESTRO_Marcas_Click(object sender, EventArgs e)
        {
            MaestroMarca();
        }
        private void MaestroMarca()
        {
            _controlador.MaestroMarca();
        }

        private void TSM_MAESTRO_EmpaquesMedida_Click(object sender, EventArgs e)
        {
            MaestroEmpaquesMedida();
        }

        private void MaestroEmpaquesMedida()
        {
            _controlador.MaestroEmpaquesMedida();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controlador.BuscarProducto();
        }

        private void TSM_MAESTROS_Conceptos_Click(object sender, EventArgs e)
        {
            MaestroConcepto();
        }
        private void MaestroConcepto()
        {
            _controlador.MaestroConcepto();
        }

        private void TSM_Movimiento_Control_Cargo_Click(object sender, EventArgs e)
        {
            MovimientoCargo();
        }
        private void MovimientoCargo()
        {
            _controlador.MovimientoCargo();
        }

        private void TSM_Movimiento_Control_DesCargo_Click(object sender, EventArgs e)
        {
            MovimientoDesCargo();
        }
        private void MovimientoDesCargo()
        {
            _controlador.MovimientoDesCargo();
        }

        private void TSM_Movimiento_Control_Traslado_Click(object sender, EventArgs e)
        {
            MovimientoTraslado();
        }
        private void MovimientoTraslado()
        {
            _controlador.MovimientoTraslado();
        }

        private void TSM_VISOR_EXISTENCIA_Click(object sender, EventArgs e)
        {
            VisorExistencia();
        }

        private void VisorExistencia()
        {
            _controlador.VisorExistencia();
        }

        private void TSM_VISOR_COSTOEDAD_Click(object sender, EventArgs e)
        {
            VisorCostoEdad();
        }

        private void VisorCostoEdad()
        {
            _controlador.VisorCostoEdad(); 
        }

        private void TSM_VISOR_TRASLADO_Click(object sender, EventArgs e)
        {
            VisorTraslados();
        }
        private void VisorTraslados()
        {
            _controlador.VisorTraslados();
        }

        private void TSM_VISOR_AJUSTE_Click(object sender, EventArgs e)
        {
            VisorAjuste();
        }

        private void VisorAjuste()
        {
            _controlador.VisorAjuste();
        }

        private void TSM_AJUSTE_MOVIMIENTO_Click(object sender, EventArgs e)
        {
            MovimientoAjuste();
        }
        private void MovimientoAjuste()
        {
            _controlador.MovimientoAjuste();
        }

        private void TSM_MOVIMIENTO_ADMINISTRADOR_Click(object sender, EventArgs e)
        {
            AdministradorMovimiento();
        }
        private void AdministradorMovimiento()
        {
            _controlador.AdministradorMovimiento();
        }

        private void TSM_VISOR_COSTO_EXISTENCIA_Click(object sender, EventArgs e)
        {
            VisorCostoExistencia();
        }
        private void VisorCostoExistencia()
        {
            _controlador.VisorCostoExistencia();
        }

        private void TSM_REPORTE_MAESTRO_PRODUCTO_Click(object sender, EventArgs e)
        {
            ReporteMaestroProductos();
        }

        private void ReporteMaestroProductos()
        {
            _controlador.ReporteMaestroProductos();
        }

        private void TSM_REPORTE_MAESTRO_INVENTARIO_Click(object sender, EventArgs e)
        {
            ReporteMaestroInventario();
        }

        private void ReporteMaestroInventario()
        {
            _controlador.ReporteMaestroInventario();
        }

        private void TSM_GRAFICA_TOP_30_Click(object sender, EventArgs e)
        {
            GraficaTop30();
        }

        private void GraficaTop30()
        {
            _controlador.GraficaTop30();
        }

        private void TSM_REPORTE_MAESTRO_PRECIO_Click(object sender, EventArgs e)
        {
            ReporteMaestroPrecio();
        }
        private void ReporteMaestroPrecio()
        {
            _controlador.ReporteMaestroPrecio();
        }

        private void TSM_REPORTE_KARDEX_Click(object sender, EventArgs e)
        {
            Kardex();
        }

        private void Kardex()
        {
            _controlador.Kardex();
        }

        private void TSM_REPORTE_RELACION_COMPRAVENTA_Click(object sender, EventArgs e)
        {
            ReporteRelacionCompraVenta();
        }

        private void ReporteRelacionCompraVenta()
        {
            _controlador.ReporteRelacionCompraVenta(); 
        }

        private void TSM_REPORTE_MAESTRO_DEPOSITO_RESUMEN_Click(object sender, EventArgs e)
        {
            ReporteMaestroDepositoResumen();
        }

        private void ReporteMaestroDepositoResumen()
        {
            _controlador.ReporteMaestroDepositoResumen();
        }

        private void TSM_REPORTE_MAESTRO_NIVEL_MINIMO_Click(object sender, EventArgs e)
        {
            MaestroNivelMinimo();
        }

        private void MaestroNivelMinimo()
        {
            _controlador.MaestroNivelMinimo();
        }

        private void TSM_CONFIGURACION_COSTO_EDAD_Click(object sender, EventArgs e)
        {
            Conf_CostoEdadProducto();
        }

        private void Conf_CostoEdadProducto()
        {
            _controlador.Conf_CostoEdadProducto();
        }

        private void TSM_CONFIGURACION_REDONDEO_PRECIOS_Click(object sender, EventArgs e)
        {
            Conf_RedondeoPreciosVenta();
        }

        private void Conf_RedondeoPreciosVenta()
        {
            _controlador.Conf_RedondeoPreciosVenta();
        }

        private void TSM_CONFIGURACION_REGISTRO_PRECIOS_Click(object sender, EventArgs e)
        {
            Conf_RegistroPrecio();
        }

        private void Conf_RegistroPrecio()
        {
            _controlador.Conf_RegistroPrecio();
        }

        private void TSM_CONFIGURACION_BUSQUEDA_PREDETERMINADA_Click(object sender, EventArgs e)
        {
            Conf_BusquedaPredeterminada();
        }

        private void Conf_BusquedaPredeterminada()
        {
            _controlador.Conf_BusquedaPredeterminada();
        }

        private void TSM_CONFIGURACION_METODO_CALC_UTILIDAD_Click(object sender, EventArgs e)
        {
            Conf_MetodoCalcUtilidad();
        }

        private void Conf_MetodoCalcUtilidad()
        {
            _controlador.Conf_MetodoCalcUtilidad();
        }

        private void TSM_REPORTE_VALORIZACION_Click(object sender, EventArgs e)
        {
            ReporteValorizacionInventario();
        }

        private void ReporteValorizacionInventario()
        {
            _controlador.ReporteValorizacionInventario();
        }

        private void TSM_Movimiento_Control_Traslado_Devolucion_Click(object sender, EventArgs e)
        {
            TrasladoPorDevolucion();
        }
        private void TrasladoPorDevolucion()
        {
            _controlador.TrasladoPorDevolucion();
        }


        private void TSM_REPORTE_KARDEX_RESUMEN_MOV_Click(object sender, EventArgs e)
        {
            Kardex_Resumen_Mov();
        }
        private void Kardex_Resumen_Mov()
        {
            _controlador.Kardex_Resumen_Mov();
        }

        private void TSM_CONFIGURACION_DEPOSITOS_PRE_DETERMINADOS_Click(object sender, EventArgs e)
        {
            Conf_DepositosPreDeterminadosRegistrar();
        }
        private void Conf_DepositosPreDeterminadosRegistrar()
        {
            _controlador.Conf_DepositosPreDeterminadosRegistrar();
        }

        private void TSM_AJUSTE_CERO_Click(object sender, EventArgs e)
        {
            AjusteInvCero();
        }
        private void AjusteInvCero()
        {
            _controlador.AjusteInvCero();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            DepositoConceptoDevMercancia();
        }
        private void DepositoConceptoDevMercancia()
        {
            _controlador.Conf_DepositoConceptoDevMercancia();
        }

        private void TSM_MOVIMIENTO_ADMINISTRADOR_PENDIENTE_Click(object sender, EventArgs e)
        {
            AdministradorMovPendiente();
        }
        private void AdministradorMovPendiente()
        {
            _controlador.AdministradorMovPendiente();
        }

        private void TSM_REPORTE_MAESTRO_EXISTENCIA_Click(object sender, EventArgs e)
        {
            ReporteMaestroExistencia();
        }
        private void ReporteMaestroExistencia()
        {
            _controlador.ReporteMaestroExistenciaDetalle();
        }

        private void TSM_REPORTE_MAESTRO_EXISTENCIA_INVENTARIO_Click(object sender, EventArgs e)
        {
            ReporteMaestroExistenciaInventario();
        }
        private void ReporteMaestroExistenciaInventario()
        {
            _controlador.ReporteMaestroExistenciaInventario();
        }
        private void TSM_REPORTE_RESUMEN_COSTO_INVENTARIO_Click(object sender, EventArgs e)
        {
            _controlador.ReporteResumenCostoInventario();
        }

        private void rotaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void TSM_VISOR_PRECIOS_AJUSTAR_PRODUCTOS_CON_EXISTENCIA_PRECIO_CERO_Click(object sender, EventArgs e)
        {
            VisorPrecio_AjustarProductosConExistenciaPrecioCero();
        }
        private void VisorPrecio_AjustarProductosConExistenciaPrecioCero()
        {
            _controlador.VisorPrecio_AjustarProductosConExistenciaPrecioCero();
        }
        private void TSM_VISOR_PRECIO_Click(object sender, EventArgs e)
        {
            _controlador.VisorPrecio_Precios();
        }
        private void TSM_VISOR_ENTRADAS_POR_COMPRA_Click(object sender, EventArgs e)
        {
            _controlador.VisorEntradasPorCompra();
        }


        private void TSM_AJSUTES_ASIGNACION_MASIVA_PRODUCTOS_DEPOSITO_Click(object sender, EventArgs e)
        {
            AsignacionMasivaProductoDeposito();
        }
        private void AsignacionMasivaProductoDeposito()
        {
            _controlador.AsignacionMasivaProductoDeposito();
        }

        private void TSM_AJUSTES_CAMBIO_MOVIMIENTOS_PRECIOS_Click(object sender, EventArgs e)
        {
            CambioMovimientoPrecios();
        }
        private void CambioMovimientoPrecios()
        {
            _controlador.CambioMovimientoPrecios();
        }

        private void TSM_CONFIGURACION_PERMITIR_CAMBIAR_PRECIO_AL_MODIFICAR_COSTO_Click(object sender, EventArgs e)
        {
            PermitirCambiarPrecioAlModificarCosto();
        }
        private void PermitirCambiarPrecioAlModificarCosto()
        {
            _controlador.PermitirCambiarPrecioAlModificarCosto();
        }

    }

}