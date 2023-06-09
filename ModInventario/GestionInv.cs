using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario
{

    public class GestionInv
    {

        private Visor.Existencia.Gestion _gestionVisorExistencia;
        private Visor.CostoEdad.Gestion _gestionVisorCostoEdad;
        private Visor.CostoExistencia.Gestion _gestionVisorCostoExistencia;
        private Configuracion.CostoEdad.Gestion _gestionConfCostoEdad;
        private Configuracion.RedondeoPrecio.Gestion _gestionConfRedondeoPrecio;
        private Configuracion.RegistroPrecio.Gestion _gestionConfRegistroPrecio;
        private Configuracion.BusquedaPredeterminada.Gestion _gestionConfBusquedaPred;
        private Configuracion.MetodoCalculoUtilidad.Gestion _gestionConfMetodoCalUtilidad;
        private Auditoria.Visualizar.Gestion _gestionAuditoria;
        private Configuracion.DepositoPreDeterminado.Gestion _gConfDepPredeterminado;
        //
        private ISeguridadAccesoSistema _seguridad;
        private SeguridadSist.ISeguridad _gSecurity;
        private SeguridadSist.Usuario.IModoUsuario _gSecurityModoUsuario;
        private SeguridadSist.NivelAcceso.IModoNivelAcceso _gSecurityNivelAcceso;
        //
        private MaestrosInv.Departamento.IAgregarEditar _gAgregarDepart;
        private MaestrosInv.Departamento.IAgregarEditar _gEditarDepart;
        private MaestrosInv.IMaestroTipo _gMtDepart;
        //
        private MaestrosInv.Grupo.IAgregarEditar _gAgregarGrupo;
        private MaestrosInv.Grupo.IAgregarEditar _gEditarGrupo;
        private MaestrosInv.IMaestroTipo _gMtGrupo;
        //
        private MaestrosInv.Concepto.IAgregarEditar _gAgregarConcepto;
        private MaestrosInv.Concepto.IAgregarEditar _gEditarConcepto;
        private MaestrosInv.IMaestroTipo _gMtConcepto;
        //
        private MaestrosInv.Marca.IAgregarEditar _gAgregarMarca;
        private MaestrosInv.Marca.IAgregarEditar _gEditarMarca;
        private MaestrosInv.IMaestroTipo _gMtMarca;
        //
        private MaestrosInv.UnidadEmpaque.IAgregarEditar _gAgregarUnidadEmpq;
        private MaestrosInv.UnidadEmpaque.IAgregarEditar _gEditarUnidadEmpq;
        private MaestrosInv.IMaestroTipo _gMtUnidadEmpq;
        //
        private MaestrosInv.ILista _gMtLista;
        private MaestrosInv.IMaestro _gMaestro;
        private Helpers.Maestros.ICallMaestros _callMaestro;
        //
        private Configuracion.DepositoConceptoDevMercancia.IConfiguracion _gCnfDepositoConceptoDev;
        // 
        private AdmMovPend.IAdmMovPend _gAdmMovPend;
        private AdmMovPend.IListaAdmMovPend _gListaAdmMovPend;
        //
        private Producto.Deposito.AsignacionMasiva.IAsignacion _gAsignacionMasiva;
        //
        private Visor.PrecioAjuste.IAjuste _gVisorPrecioAjuste;
        //
        private Configuracion.CambiarPreciosAlModificarCosto.IConf _gConfEditarPrecioAlCambiarCosto;
        //
        private Tool.CambioMasivoPrecio.ICambio _gCambioMasivoPrecio;


        public string Version { get { return "Ver. 2 - " + Application.ProductVersion; } }
        public string Host { get { return Sistema.MotorDatos.GetHost; } }
        public string Usuario
        {
            get 
            { 
                var rt = ""; 
                rt = Sistema.UsuarioP.codigoUsu + Environment.NewLine + Sistema.UsuarioP.nombreUsu + Environment.NewLine + Sistema.UsuarioP.NombreGru; 
                return rt; 
            }
        }


        private src.IFabrica _fabrica;
        ModInventario.src.AdmDocumentos.IAdmDoc _hndAdmDoc;
        private Buscar.Gestion _gHndProducto;
        ModInventario.src.Visor.Traslado.IVisorTraslado _gVisorTraslado;
        ModInventario.src.Visor.GananciaPerdida.IVisorGanPerd _gVisorGanPerd;
        ModInventario.src.Visor.Precios.IPrecio _gVisorPrecio;
        ModInventario.src.Visor.EntradaxCompra.IEntradaxCompra _gVisorEntradaxCompra;
        public GestionInv(src.IFabrica fabrica)
        {
            _fabrica = fabrica;
            Producto.Precio.EditarCambiar.IEditar _hndEditarPrecio = _fabrica.CreateInstancia_EditarCambiarPrecio();

            _hndAdmDoc = _fabrica.CreateInstancia_AdmDocumentos();

            //VISOR
            _gVisorTraslado = _fabrica.CreateInstancia_VisorTraslado();
            _gVisorGanPerd = _fabrica.CreateInstancia_VisorGananciaPerdida();
            _gVisorPrecio = _fabrica.CreateInstancia_VisorPrecio();
            _gVisorEntradaxCompra = _fabrica.CreateInstancia_VisorEntradaxCompra();

            _gSecurity= new SeguridadSist.Gestion();
            _gSecurityModoUsuario = new SeguridadSist.Usuario.Gestion();
            _gSecurityNivelAcceso= new SeguridadSist.NivelAcceso.Gestion();
            _seguridad = new Helpers.Seguridad(_gSecurityNivelAcceso, _gSecurity);

            //
            _gAgregarDepart = new MaestrosInv.Departamento.Agregar.Gestion();
            _gEditarDepart = new MaestrosInv.Departamento.Editar.Gestion();
            _gMtDepart = new MaestrosInv.Departamento.Gestion(_seguridad, _gAgregarDepart, _gEditarDepart);
            //
            _gAgregarGrupo= new MaestrosInv.Grupo.Agregar.Gestion();
            _gEditarGrupo= new MaestrosInv.Grupo.Editar.Gestion();
            _gMtGrupo = new MaestrosInv.Grupo.Gestion(_seguridad, _gAgregarGrupo, _gEditarGrupo);
            //
            _gAgregarConcepto = new MaestrosInv.Concepto.Agregar.Gestion();
            _gEditarConcepto = new MaestrosInv.Concepto.Editar.Gestion();
            _gMtConcepto = new MaestrosInv.Concepto.Gestion(_seguridad, _gAgregarConcepto, _gEditarConcepto);
            //
            _gAgregarMarca = new MaestrosInv.Marca.Agregar.Gestion();
            _gEditarMarca = new MaestrosInv.Marca.Editar.Gestion();
            _gMtMarca = new MaestrosInv.Marca.Gestion(_seguridad, _gAgregarMarca, _gEditarMarca);
            //
            _gAgregarUnidadEmpq = new MaestrosInv.UnidadEmpaque.Agregar.Gestion();
            _gEditarUnidadEmpq = new MaestrosInv.UnidadEmpaque.Editar.Gestion();
            _gMtUnidadEmpq = new MaestrosInv.UnidadEmpaque.Gestion(_seguridad, _gAgregarUnidadEmpq, _gEditarUnidadEmpq);
            //
            _gMtLista = new MaestrosInv.Lista();
            _gMaestro = new MaestrosInv.Gestion(_gMtLista);
            //
            _callMaestro = new Helpers.Maestros.Maestros(_gMaestro,
                _gMtDepart,
                _gMtGrupo,
                _gMtConcepto,
                _gMtMarca,
                _gMtUnidadEmpq,
                _seguridad);
            //
            _gCnfDepositoConceptoDev = new ModInventario.Configuracion.DepositoConceptoDevMercancia.Gestion();
            //
            _gListaAdmMovPend = new AdmMovPend.Lista();
            _gAdmMovPend = new AdmMovPend.AdmMovPend(
                _gListaAdmMovPend, 
                _seguridad);
            //
            _gAsignacionMasiva = new Producto.Deposito.AsignacionMasiva.Asignacion();
            //
            _gConfEditarPrecioAlCambiarCosto = new Configuracion.CambiarPreciosAlModificarCosto.Conf();
            //
            _gCambioMasivoPrecio = new Tool.CambioMasivoPrecio.Cambio();


            _gVisorPrecioAjuste = new Visor.PrecioAjuste.Ajuste(_seguridad, _hndEditarPrecio);
            _gestionVisorExistencia = new Visor.Existencia.Gestion();
            _gestionVisorCostoEdad = new Visor.CostoEdad.Gestion();
            //_gestionVisorTraslado = new Visor.Traslado.Gestion();
            //_gestionVisorAjuste = new Visor.Ajuste.Gestion();
            _gestionVisorCostoExistencia = new Visor.CostoExistencia.Gestion();

            _gestionConfCostoEdad = new Configuracion.CostoEdad.Gestion();
            _gestionConfRedondeoPrecio = new Configuracion.RedondeoPrecio.Gestion();
            _gestionConfRegistroPrecio = new Configuracion.RegistroPrecio.Gestion();
            _gestionConfBusquedaPred = new Configuracion.BusquedaPredeterminada.Gestion();
            _gestionConfMetodoCalUtilidad = new Configuracion.MetodoCalculoUtilidad.Gestion();
            _gestionAuditoria = new Auditoria.Visualizar.Gestion();
            _gConfDepPredeterminado = new Configuracion.DepositoPreDeterminado.Gestion();

            //
            _gHndProducto = _fabrica.CreateInstancia_HndProducto(_seguridad, _fabrica);
        }


        public void Inicia() 
        {
            _fabrica.Iniciar_FrmPrincipal(this);
        }

        public void Ajuste_DefinirNivelMinimoMaximo()
        {
            var r00 = Sistema.MyData.Permiso_DefinirNivelMinimoMaximoInventario(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (_seguridad.Verificar(r00.Entidad))
            {
                var _ajusteNivel = new Tool.AjusteNivelMinimoMaximoProducto.Gestion();
                _ajusteNivel.Inicia();
            }
        }

        public void MaestroDepartamentos()
        {
            _callMaestro.MtDepartamento();
        }
        public void MaestroGrupo()
        {
            _callMaestro.MtGrupo();
        }
        public void MaestroMarca()
        {
            _callMaestro.MtMarca();
        }
        public void MaestroEmpaquesMedida()
        {
            _callMaestro.MtUnidadEmpaque();
        }
        public void MaestroConcepto()
        {
            _callMaestro.MtConcepto();
        }


        public void BuscarProducto()
        {
            _gHndProducto.Inicializa();
            _gHndProducto.Inicia();
        }

        public void AdministradorMovimiento()
        {
            if (Helpers.VerificarPermiso.PermitirAcceso(
                Sistema.MyData.Permiso_AdministradorMovimientoInventario, 
                Sistema.UsuarioP.autoGru, _seguridad)
                )
            {
                _hndAdmDoc.Inicializa();
                _hndAdmDoc.Inicia();
            }
        }

        public void GraficaTop30()
        {
            var gestion = new Graficas.Gestion();
            gestion.Inicia();
        }


        public void MovimientoDesCargo()
        {
            if (Helpers.VerificarPermiso.PermitirAcceso(Sistema.MyData.Permiso_MovimientoDescargoInventario, Sistema.UsuarioP.autoGru, _seguridad))
            {
                Helpers.GenerarMov.Cargo(_seguridad);
            }
        }
        public void MovimientoCargo()
        {
            if (Helpers.VerificarPermiso.PermitirAcceso(Sistema.MyData.Permiso_MovimientoCargoInventario, Sistema.UsuarioP.autoGru, _seguridad))
            {
                Helpers.GenerarMov.DesCargo(_seguridad);
            }
        }
        public void MovimientoTraslado()
        {
            if (Helpers.VerificarPermiso.PermitirAcceso(Sistema.MyData.Permiso_MovimientoTrasladoInventario, Sistema.UsuarioP.autoGru, _seguridad))
            {
                Helpers.GenerarMov.Traslado(_seguridad);
            }
        }
        public void TrasladoPorDevolucion()
        {
            if (Helpers.VerificarPermiso.PermitirAcceso(Sistema.MyData.Permiso_MovimientoTrasladoInventario, Sistema.UsuarioP.autoGru, _seguridad))
            {
                Helpers.GenerarMov.TrasladoPorDevolucion(_seguridad);
            }
        }
        public void TrasladoMercanciaEntreSucursalPorNivelMinimo()
        {
            if (Helpers.VerificarPermiso.PermitirAcceso(Sistema.MyData.Permiso_MovimientoTrasladoInventario, Sistema.UsuarioP.autoGru, _seguridad))
            {
                Helpers.GenerarMov.TrasladoPorNivelMinimo(_seguridad);
            }
        }
        public void MovimientoAjuste()
        {
            if (Helpers.VerificarPermiso.PermitirAcceso(Sistema.MyData.Permiso_MovimientoAjusteInventario, Sistema.UsuarioP.autoGru, _seguridad))
            {
                Helpers.GenerarMov.AjusteInv(_seguridad);
            }
        }
        public void AjusteInvCero()
        {
            if (Helpers.VerificarPermiso.PermitirAcceso(Sistema.MyData.Permiso_MovimientoAjusteInventarioCero, Sistema.UsuarioP.autoGru, _seguridad))
            {
                Helpers.GenerarMov.AjustarInvCero(_seguridad);
            }
        }
        public void AdministradorMovPendiente()
        {
            _gAdmMovPend.Inicializa();
            _gAdmMovPend.Inicia();
        }


        public void AsignacionMasivaProductoDeposito()
        {
            if (Helpers.VerificarPermiso.PermitirAcceso(Sistema.MyData.Permiso_AsignacionMasivaProductosDeposito, Sistema.UsuarioP.autoGru, _seguridad))
            {
                _gAsignacionMasiva.Inicializa();
                _gAsignacionMasiva.Inicia();
            }
        }

        public void VisorCostoExistencia()
        {
            if (VerificarPermisoVisor())
            {
                _gestionVisorCostoExistencia = new Visor.CostoExistencia.Gestion();
                _gestionVisorCostoExistencia.Inicia();
            }
        }
        public void VisorExistencia()
        {
            if (VerificarPermisoVisor())
            {
                _gestionVisorExistencia = new Visor.Existencia.Gestion();
                _gestionVisorExistencia.Inicia();
            }
        }
        public void VisorCostoEdad()
        {
            if (VerificarPermisoVisor())
            {
                _gestionVisorCostoEdad = new Visor.CostoEdad.Gestion();
                _gestionVisorCostoEdad.Inicia();
            }
        }
        public void VisorTraslados()
        {
            if (VerificarPermisoVisor())
            {
                _gVisorTraslado.Inicializa();
                _gVisorTraslado.Inicia();
            }
        }
        public void VisorAjuste()
        {
            if (VerificarPermisoVisor())
            {
                _gVisorGanPerd.Inicializa();
                _gVisorGanPerd.Inicia();
            }
        }
        public void VisorPrecio_AjustarProductosConExistenciaPrecioCero()
        {
            if (VerificarPermisoVisor())
            {
                _gVisorPrecioAjuste.Inicializa();
                _gVisorPrecioAjuste.Inicia();
            }
        }
        public void VisorPrecio_Precios()
        {
            if (VerificarPermisoVisor())
            {
                _gVisorPrecio.Inicializa();
                _gVisorPrecio.Inicia();
            }
        }
        public void VisorEntradasPorCompra()
        {
            if (VerificarPermisoVisor())
            {
                _gVisorEntradaxCompra.Inicializa();
                _gVisorEntradaxCompra.Inicia();
            }
        }
        public bool VerificarPermisoVisor()
        {
            return Helpers.VerificarPermiso.PermitirAcceso(Sistema.MyData.Permiso_Visor, Sistema.UsuarioP.autoGru, _seguridad);
        }


        public void ReporteMaestroPrecio()
        {
            if (VerificarPermisoReportes())
            {
                Reporte(_fabrica.CreateInstancia_RepMasterPrecio(), _fabrica.CreateInstancia_RepMasterPrecio_Filtros());
            }
        }
        public void ReporteMaestroProductos()
        {
            if (VerificarPermisoReportes())
            {
                Reporte(_fabrica.CreateInstancia_RepMasterProductos(), _fabrica.CreateInstancia_RepMasterProductos_Filtros());
            }
        }
        public void ReporteMaestroInventario()
        {
            if (VerificarPermisoReportes())
            {
                Reporte(_fabrica.CreateInstancia_RepMaestroInventario(), _fabrica.CreateInstancia_RepMaestroInventario_Filtros());
            }
        }
        public void ReporteMaestroExistenciaDetalle()
        {
            if (VerificarPermisoReportes())
            {
                Reporte(_fabrica.CreateInstancia_RepMaestroExistenciaDetalle(), _fabrica.CreateInstancia_RepMaestroExistenciaDetalle_Filtros());
            }
        }
        public void ReporteMaestroExistenciaInventario()
        {
            if (VerificarPermisoReportes())
            {
                Reporte(_fabrica.CreateInstancia_RepMaestroExistenciaInventario(), _fabrica.CreateInstancia_RepMaestroExistenciaInventario_Filtros());
            }
        }
        public void ReporteMaestroDepositoResumen()
        {
            if (VerificarPermisoReportes())
            {
                var rp = _fabrica.CreateInstancia_RepMaestroDepositoResumen();
                rp.Generar();
            }
        }
        public void MaestroNivelMinimo()
        {
            if (VerificarPermisoReportes())
            {
                Reporte(_fabrica.CreateInstancia_RepNivelMinimo(), _fabrica.CreateInstancia_RepNivelMinimo_Filtros());
            }
        }
        public void Kardex()
        {
            if (VerificarPermisoReportes())
            {
                Reporte(_fabrica.CreateInstancia_RepKardex(), _fabrica.CreateInstancia_RepKardex_Filtros());
            }
        }
        public void Kardex_Resumen_Mov()
        {
            if (VerificarPermisoReportes())
            {
                Reporte(_fabrica.CreateInstancia_RepKardexResumenMov(), _fabrica.CreateInstancia_RepKardexResumenMov_Filtros());
            }
        }
        public void ReporteValorizacionInventario()
        {
            if (VerificarPermisoReportes())
            {
                Reporte(_fabrica.CreateInstancia_RepValorizacionInventario(), _fabrica.CreateInstancia_RepValorizacionInventario_Filtros());
            }
        }
        public void ReporteRelacionCompraVenta()
        {
            if (VerificarPermisoReportes())
            {
                Reporte(_fabrica.CreateInstancia_RepRelacionCompraVenta(), _fabrica.CreateInstancia_RepRelacionCompraVenta_Filtros());
            }
        }
        public void ReporteResumenCostoInventario()
        {
            if (VerificarPermisoReportes())
            {
                Reporte(_fabrica.CreateInstancia_RepResumenCostoInventario(), _fabrica.CreateInstancia_RepResumenCostoInventario_Filtros());
            }
        }
        private void Reporte(src.Reporte.IReporte reporte, Reportes.Filtros.IFiltros filtros)
        {
            var _filtrRep = _fabrica.CreateInstancia_FiltrosParaReportes();
            if (_filtrRep != null)
            {
                _filtrRep.Inicializa();
                _filtrRep.setFiltrosHab(filtros);
                _filtrRep.Inicia();
                if (_filtrRep.ProcesarIsOk)
                {
                    reporte.setFiltros(_filtrRep.DataExportar);
                    reporte.Generar();
                }
            }
        }

        public bool VerificarPermisoReportes()
        {
            return Helpers.VerificarPermiso.PermitirAcceso(Sistema.MyData.Permiso_Reportes, Sistema.UsuarioP.autoGru, _seguridad);
        }


        public void CambioMovimientoPrecios()
        {
            if (Helpers.VerificarPermiso.PermitirAcceso(Sistema.MyData.Permiso_CambioMovimientoMasivoPrecio, Sistema.UsuarioP.autoGru, _seguridad))
            {
                _gCambioMasivoPrecio.Inicializa();
                _gCambioMasivoPrecio.Inicia();
            }
        }


        public void Conf_CostoEdadProducto()
        {
            if (VerificarPermisoConfiguracionSistema()) 
            {
                _gestionConfCostoEdad.Inicializa();
                _gestionConfCostoEdad.Inicia();
            }
        }
        public void Conf_RedondeoPreciosVenta()
        {
            if (VerificarPermisoConfiguracionSistema()) 
            {
                _gestionConfRedondeoPrecio.Inicializa();
                _gestionConfRedondeoPrecio.Inicia();
            }
        }
        public void Conf_RegistroPrecio()
        {
            if (VerificarPermisoConfiguracionSistema()) 
            {
                _gestionConfRegistroPrecio.Inicializa();
                _gestionConfRegistroPrecio.Inicia();
            }
        }
        public void Conf_BusquedaPredeterminada()
        {
            if (VerificarPermisoConfiguracionSistema()) 
            {
                _gestionConfBusquedaPred.Inicializa();
                _gestionConfBusquedaPred.Inicia();
            }
        }
        public void Conf_MetodoCalcUtilidad()
        {
            if (VerificarPermisoConfiguracionSistema()) 
            {
                _gestionConfMetodoCalUtilidad.Inicializa();
                _gestionConfMetodoCalUtilidad.Inicia();
            }
        }
        public void Conf_DepositosPreDeterminadosRegistrar()
        {
            if (VerificarPermisoConfiguracionSistema()) 
            {
                _gConfDepPredeterminado.Inicializa();
                _gConfDepPredeterminado.Inicia();
            }
        }
        public void PermitirCambiarPrecioAlModificarCosto()
        {
            if (VerificarPermisoConfiguracionSistema()) 
            {
                _gConfEditarPrecioAlCambiarCosto.Inicializa();
                _gConfEditarPrecioAlCambiarCosto.Inicia();
            }
        }
        public void Conf_DepositoConceptoDevMercancia()
        {
            if (VerificarPermisoConfiguracionSistema()) 
            {
                _gCnfDepositoConceptoDev.Inicializa();
                _gCnfDepositoConceptoDev.Inicia();
            }
        }
        public bool VerificarPermisoConfiguracionSistema()
        {
            return Helpers.VerificarPermiso.PermitirAcceso(Sistema.MyData.Permiso_ConfiguracionSistema, Sistema.UsuarioP.autoGru, _seguridad);
        }

        private src.Producto.ActualizarOfertaMasiva.IOferta _asignacionMasivaOferta;
        public void AsignacionMasivaOfertas()
        {
            if (Helpers.VerificarPermiso.PermitirAcceso(Sistema.MyData.Permiso_AsignacionMasivaProductosDeposito, Sistema.UsuarioP.autoGru, _seguridad))
            {
                if (_asignacionMasivaOferta == null)
                {
                    _asignacionMasivaOferta = _fabrica.CreateInstancia_AsginacionMasivaOferta();
                }
                _asignacionMasivaOferta.Inicializa();
                _asignacionMasivaOferta.Inicia(); 
            }
        }

        public void TomaInv_GenerarSolicitud()
        {
            TomaInv.Generar.IGenerar _generarToma = new TomaInv.Generar.ImpGenerar();
            _generarToma.Inicializa();
            _generarToma.Inicia();
        }
        public void TomaInv_AdmDocumentos()
        {
            TomaInv.Analisis.IAnalisis _analsisTomaInv = new TomaInv.Analisis.ImpAnalisis();
            _analsisTomaInv.Inicializa();
            _analsisTomaInv.Inicia();
        }
        public void TomaInv_ConvertirSolicitudEnToma()
        {
            var imp = new TomaInv.ConvertirSolicitud.Imp();
            imp.Convertir();
        }
    }
}