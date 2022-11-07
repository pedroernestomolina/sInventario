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
        private Visor.Traslado.Gestion _gestionVisorTraslado;
        private Visor.Ajuste.Gestion _gestionVisorAjuste;
        private Visor.CostoExistencia.Gestion _gestionVisorCostoExistencia;
        private Configuracion.CostoEdad.Gestion _gestionConfCostoEdad;
        private Configuracion.RedondeoPrecio.Gestion _gestionConfRedondeoPrecio;
        private Configuracion.RegistroPrecio.Gestion _gestionConfRegistroPrecio;
        private Configuracion.BusquedaPredeterminada.Gestion _gestionConfBusquedaPred;
        private Configuracion.MetodoCalculoUtilidad.Gestion _gestionConfMetodoCalUtilidad;
        private Auditoria.Visualizar.Gestion _gestionAuditoria;
        private Configuracion.DepositoPreDeterminado.Gestion _gConfDepPredeterminado;

        //
        private Buscar.INotificarSeleccion _gListaSelPrd;
        private FiltrosGen.IAdmSelecciona _gAdmSelPrd;
        private Administrador.IGestion _gAdmDoc;

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
        private ModInventario.MovimientoInvTipo.IGestionTipo _gMovTipo;
        private ModInventario.MovimientoInvTipo.ILista _gMovTipoLista;
        //
        private ModInventario.MovimientoInvTipo.ITipo _gMovTipoDescargo;
        private ModInventario.MovimientoInvTipo.ICaptura _gCapturaMovDescargo;
        //
        private ModInventario.MovimientoInvTipo.ITipo _gMovTipoCargo;
        private ModInventario.MovimientoInvTipo.ICaptura _gCapturaMovCargo;
        //
        private ModInventario.MovimientoInvTipo.ITipoxDev _gMovTipoTraslado;
        private ModInventario.MovimientoInvTipo.ICaptura _gCapturaMovTraslado;
        //
        private ModInventario.MovimientoInvTipo.ITipo _gMovTipoAjuste;
        private ModInventario.MovimientoInvTipo.ICapturaMovAjuste _gCapturaMovAjuste;
        //
        private ModInventario.MovimientoInvTipo.ITipo _gMovTipoTraslPorNIvelMinimo;
        //
        private ModInventario.MovimientoInvTipo.ITipoSeguridad _gMovTipoAjusteInvCero;
        //
        private Configuracion.DepositoConceptoDevMercancia.IConfiguracion _gCnfDepositoConceptoDev;
        // 
        private MovimientoInvTipo.Transito.ITransito _gTransitoMov;
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
        public string Host { get { return Sistema._Instancia + "/" + Sistema._BaseDatos; } }
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
        ModInventario.src.Filtro.FiltroRep.IFiltroRep _gestionReporteFiltros;
        ModInventario.src.AdmDocumentos.IAdmDoc _hndAdmDoc;
        private Buscar.Gestion _gHndProducto;
        public GestionInv(src.IFabrica fabrica)
        {
            _fabrica = fabrica;
            Producto.Precio.EditarCambiar.IEditar _hndEditarPrecio = _fabrica.CreateInstancia_EditarCambiarPrecio();
            FiltrosGen.AdmProducto.IAdmProducto _hndFiltroAdmProducto = _fabrica.CreateInstancia_FiltroPrdAdm();
            _gestionReporteFiltros = _fabrica.CreateInstancia_FiltrosReporte();
            _hndAdmDoc = _fabrica.CreateInstancia_AdmDocumentos();


            _gSecurity= new SeguridadSist.Gestion();
            _gSecurityModoUsuario = new SeguridadSist.Usuario.Gestion();
            _gSecurityNivelAcceso= new SeguridadSist.NivelAcceso.Gestion();
            _seguridad = new Helpers.Seguridad(_gSecurityNivelAcceso, _gSecurity);


            _gListaSelPrd = new Producto.ListaSel.Gestion();
            _gAdmSelPrd = new FiltrosGen.AdmSelecciona.Gestion(
                _hndFiltroAdmProducto,
                _gListaSelPrd);


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
            // MOV TRANSITO
            _gTransitoMov = new MovimientoInvTipo.Transito.Gestion();
            // MOV INVENTARIO
            _gMovTipoLista = new ModInventario.MovimientoInvTipo.Lista();
            _gMovTipo = new ModInventario.MovimientoInvTipo.Gestion(
                _gMovTipoLista,
                _gAdmSelPrd);
            //MOV DESCARGO INVENTARIO
            _gCapturaMovDescargo = new ModInventario.MovimientoInvTipo.Descargo.Captura.Gestion();
            _gMovTipoDescargo = new ModInventario.MovimientoInvTipo.Descargo.Gestion(
                _gCapturaMovDescargo,
                _callMaestro);
            //MOV CARGO INVENTARIO
            _gCapturaMovCargo = new ModInventario.MovimientoInvTipo.Cargo.Captura.Gestion();
            _gMovTipoCargo = new ModInventario.MovimientoInvTipo.Cargo.Gestion(
                _gCapturaMovCargo,
                _callMaestro);
            //MOV TRASLADO INVENTARIO
            _gCapturaMovTraslado= new ModInventario.MovimientoInvTipo.Traslado.Captura.Gestion();
            _gMovTipoTraslado = new ModInventario.MovimientoInvTipo.Traslado.Gestion(
                _gCapturaMovTraslado,
                _callMaestro, 
                _gTransitoMov,
                _seguridad);
            //
            _gMovTipoTraslPorNIvelMinimo = new ModInventario.MovimientoInvTipo.TrasladoPorNivelMinimo.Gestion(
                _gCapturaMovTraslado,
                _callMaestro, 
                _gTransitoMov, 
                _seguridad);
            //MOV AJUSTE INVENTARIO
            _gCapturaMovAjuste= new ModInventario.MovimientoInvTipo.Ajuste.Captura.Gestion();
            _gMovTipoAjuste = new ModInventario.MovimientoInvTipo.Ajuste.Gestion(
                _gCapturaMovAjuste,
                _callMaestro,
                _gTransitoMov, 
                _seguridad);
            //MOV AJUSTE INVENTARIO CERO
            _gMovTipoAjusteInvCero = new ModInventario.MovimientoInvTipo.AjusteInvCero.Gestion(
                _callMaestro,
                _gSecurity);
            //
            _gCnfDepositoConceptoDev = new ModInventario.Configuracion.DepositoConceptoDevMercancia.Gestion();
            //
            _gListaAdmMovPend = new AdmMovPend.Lista();
            _gAdmMovPend = new AdmMovPend.AdmMovPend(
                _gListaAdmMovPend, 
                _gMovTipo, 
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
            _gestionVisorTraslado = new Visor.Traslado.Gestion();
            _gestionVisorAjuste = new Visor.Ajuste.Gestion();
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
                _gMovTipoDescargo.Inicializa();
                _gMovTipo.Inicializa();
                _gMovTipo.setTipoMov(_gMovTipoDescargo);
                _gMovTipo.Inicia();
                _gMovTipo.Finaliza();
            }
        }

        public void MovimientoCargo()
        {
            if (Helpers.VerificarPermiso.PermitirAcceso(Sistema.MyData.Permiso_MovimientoCargoInventario, Sistema.UsuarioP.autoGru, _seguridad))
            {
                _gMovTipoCargo.Inicializa();
                _gMovTipo.Inicializa();
                _gMovTipo.setTipoMov(_gMovTipoCargo);
                _gMovTipo.Inicia();
                _gMovTipo.Finaliza();
            }
        }

        public void MovimientoTraslado()
        {
            if (Helpers.VerificarPermiso.PermitirAcceso(Sistema.MyData.Permiso_MovimientoTrasladoInventario, Sistema.UsuarioP.autoGru, _seguridad))
            {
                _gMovTipoTraslado.Inicializa();
                _gMovTipoTraslado.setActivarPorDevolucion(false);
                _gMovTipo.Inicializa();
                _gMovTipo.setTipoMov(_gMovTipoTraslado);
                _gMovTipo.Inicia();
                _gMovTipo.Finaliza();
            }
        }

        public void TrasladoPorDevolucion()
        {
            if (Helpers.VerificarPermiso.PermitirAcceso(Sistema.MyData.Permiso_MovimientoTrasladoPorDevolucion, Sistema.UsuarioP.autoGru, _seguridad))
            {
                _gMovTipoTraslado.Inicializa();
                _gMovTipoTraslado.setActivarPorDevolucion(true);
                _gMovTipo.Inicializa();
                _gMovTipo.setTipoMov(_gMovTipoTraslado);
                _gMovTipo.Inicia();
                _gMovTipo.Finaliza();
            }
        }

        public void MovimientoAjuste()
        {
            if (Helpers.VerificarPermiso.PermitirAcceso(Sistema.MyData.Permiso_MovimientoAjusteInventario, Sistema.UsuarioP.autoGru, _seguridad))
            {
                _gMovTipoAjuste.Inicializa();
                _gMovTipo.Inicializa();
                _gMovTipo.setTipoMov(_gMovTipoAjuste);
                _gMovTipo.Inicia();
                _gMovTipo.Finaliza();
            }
        }

        public void AjusteInvCero()
        {
            if (Helpers.VerificarPermiso.PermitirAcceso(Sistema.MyData.Permiso_MovimientoAjusteInventarioCero, Sistema.UsuarioP.autoGru, _seguridad))
            {
                // POR USUARIO
                _gSecurityModoUsuario.Inicializa();
                _gSecurityModoUsuario.setUsuarioValidar(SeguridadSist.Usuario.enumerados.enumTipo.Administrador);

                _gMovTipoAjusteInvCero.Inicializa();
                _gMovTipoAjusteInvCero.setModoSeguridad(_gSecurityModoUsuario);

                _gMovTipo.Inicializa();
                _gMovTipo.setTipoMov(_gMovTipoAjusteInvCero);
                _gMovTipo.Inicia();
                _gMovTipo.Finaliza();
            }
        }

        public void TrasladoMercanciaEntreSucursalPorNivelMinimo()
        {
            if (Helpers.VerificarPermiso.PermitirAcceso(Sistema.MyData.Permiso_MovimientoTrasladoEntreSucursales_PorExistenciaDebajoDelMinimo, Sistema.UsuarioP.autoGru, _seguridad))
            {
                _gMovTipoTraslPorNIvelMinimo.Inicializa();
                _gMovTipo.Inicializa();
                _gMovTipo.setTipoMov(_gMovTipoTraslPorNIvelMinimo);
                _gMovTipo.Inicia();
                _gMovTipo.Finaliza();
            }
        }

        public void AdministradorMovPendiente()
        {
            _gAdmMovPend.Inicializa();
            _gAdmMovPend.setMovTrasladoxNivel(_gMovTipoTraslPorNIvelMinimo);
            _gAdmMovPend.setMovTraslado(_gMovTipoTraslado);
            _gAdmMovPend.setMovAjuste(_gMovTipoAjuste);
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
                _gestionVisorTraslado = new Visor.Traslado.Gestion();
                _gestionVisorTraslado.Inicia();
            }
        }
        public void VisorAjuste()
        {
            if (VerificarPermisoVisor())
            {
                _gestionVisorAjuste = new Visor.Ajuste.Gestion();
                _gestionVisorAjuste.Inicia();
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
        public bool VerificarPermisoVisor()
        {
            return Helpers.VerificarPermiso.PermitirAcceso(Sistema.MyData.Permiso_Visor, Sistema.UsuarioP.autoGru, _seguridad);
        }


        public void ReporteMaestroDepositoResumen()
        {
            if (VerificarPermisoReportes())
            {
                var rp = new Reportes.Filtros.DepositoResumen.GestionRep();
                rp.Generar();
            }
        }
        public void ReporteMaestroExistencia()
        {
            if (VerificarPermisoReportes())
            {
                _gestionReporteFiltros.Inicializa();
                _gestionReporteFiltros.setValidarData(false);
                _gestionReporteFiltros.setGestion(new Reportes.Filtros.MaestroExistencia.Filtros());
                _gestionReporteFiltros.Inicia();
                if (_gestionReporteFiltros.FiltrosIsOK)
                {
                    var rp = new Reportes.Filtros.MaestroExistencia.GestionRep();
                    rp.setFiltros(_gestionReporteFiltros.dataFiltrar);
                    rp.Generar();
                }
            }
        }
        public void ReporteMaestroPrecio()
        {
            if (VerificarPermisoReportes())
            {
                _gestionReporteFiltros.Inicializa();
                _gestionReporteFiltros.setValidarData(false);
                _gestionReporteFiltros.setGestion(new Reportes.Filtros.MaestroPrecio.Filtros());
                _gestionReporteFiltros.Inicia();
                if (_gestionReporteFiltros.FiltrosIsOK)
                {
                    if (_gestionReporteFiltros.dataFiltrar.Precio == null) 
                    {
                        Helpers.Msg.Alerta("Debes Indicar El Tipo De Precio A Listar");
                        return;
                    }
                    var rp = new Reportes.Filtros.MaestroPrecio.GestionRep();
                    rp.setFiltros(_gestionReporteFiltros.dataFiltrar);
                    rp.Generar();
                }
            }
        }
        public void ReporteMaestroExistenciaInventario()
        {
            if (VerificarPermisoReportes())
            {
                _gestionReporteFiltros.Inicializa();
                _gestionReporteFiltros.setValidarData(false);
                _gestionReporteFiltros.setGestion(new Reportes.Filtros.MaestroExistencia.Filtros());
                _gestionReporteFiltros.Inicia();
                if (_gestionReporteFiltros.FiltrosIsOK)
                {
                    var rp = new Reportes.Filtros.MaestroExistenciaInventario.GestionRep();
                    rp.setFiltros(_gestionReporteFiltros.dataFiltrar);
                    rp.Generar();
                }
            }
        }
        public void ReporteResumenCostoInventario()
        {
            if (VerificarPermisoReportes())
            {
                _gestionReporteFiltros.Inicializa();
                _gestionReporteFiltros.setValidarData(false);
                _gestionReporteFiltros.setDesde(DateTime.Now.Date);
                _gestionReporteFiltros.setHasta(DateTime.Now.Date);
                _gestionReporteFiltros.setGestion(new Reportes.Filtros.ResumenCostoInventario.Filtros());
                _gestionReporteFiltros.Inicia();
                if (_gestionReporteFiltros.FiltrosIsOK)
                {
                    if (_gestionReporteFiltros.dataFiltrar.Deposito == null)
                    {
                        Helpers.Msg.Error("Parametro [ DEPOSITO ] Incorrectos, Verifique Por Favor");
                        return;
                    }
                    var rp = new Reportes.Filtros.ResumenCostoInventario.GestionRep();
                    rp.setFiltros(_gestionReporteFiltros.dataFiltrar);
                    rp.Generar();
                }
            }
        }
        public void ReporteMaestroProductos()
        {
            if (VerificarPermisoReportes())
            {
                _gestionReporteFiltros.Inicializa();
                _gestionReporteFiltros.setValidarData(false);
                _gestionReporteFiltros.setGestion(new Reportes.Filtros.MaestroProducto.Filtros());
                _gestionReporteFiltros.Inicia();
                if (_gestionReporteFiltros.FiltrosIsOK)
                {
                    var rp = new Reportes.Filtros.MaestroProducto.GestionRep();
                    rp.setFiltros(_gestionReporteFiltros.dataFiltrar);
                    rp.Generar();
                }
            }
        }
        public void ReporteMaestroInventario()
        {
            if (VerificarPermisoReportes())
            {
                _gestionReporteFiltros.Inicializa();
                _gestionReporteFiltros.setValidarData(false);
                _gestionReporteFiltros.setGestion(new Reportes.Filtros.MaestroInventario.Filtros());
                _gestionReporteFiltros.Inicia();
                if (_gestionReporteFiltros.FiltrosIsOK)
                {
                    var rp = new Reportes.Filtros.MaestroInventario.GestionRep();
                    rp.setFiltros(_gestionReporteFiltros.dataFiltrar);
                    rp.Generar();
                }
            }
        }
        public void ReporteRelacionCompraVenta()
        {
            if (VerificarPermisoReportes())
            {
                _gestionReporteFiltros.Inicializa();
                _gestionReporteFiltros.setValidarData(false);
                _gestionReporteFiltros.setGestion(new Reportes.Filtros.RelacionCompraVenta.Filtros());
                _gestionReporteFiltros.Inicia();
                if (_gestionReporteFiltros.FiltrosIsOK)
                {
                    if (_gestionReporteFiltros.dataFiltrar.Producto == null)
                    {
                        Helpers.Msg.Error("Parametros Incorrectos, Verifique Por Favor");
                        return;
                    }
                    var rp = new Reportes.Filtros.RelacionCompraVenta.GestionRep();
                    rp.setFiltros(_gestionReporteFiltros.dataFiltrar);
                    rp.Generar();
                }
            }
        }
        public void ReporteValorizacionInventario()
        {
            if (VerificarPermisoReportes())
            {
                _gestionReporteFiltros.Inicializa();
                _gestionReporteFiltros.setValidarData(true);
                _gestionReporteFiltros.setGestion(new Reportes.Filtros.Valorizacion.Filtros());
                _gestionReporteFiltros.setHasta(DateTime.Now.Date);
                _gestionReporteFiltros.Inicia();
                if (_gestionReporteFiltros.FiltrosIsOK)
                {
                    if (_gestionReporteFiltros.dataFiltrar.Deposito == null)
                    {
                        Helpers.Msg.Error("Parametro [ DEPOSITO ] Incorrectos, Verifique Por Favor");
                        return;
                    }
                    var rp = new Reportes.Filtros.Valorizacion.GestionRep();
                    rp.setFiltros(_gestionReporteFiltros.dataFiltrar);
                    rp.Generar();
                }
            }
        }
        public void Kardex_Resumen_Mov()
        {
            if (VerificarPermisoReportes())
            {
                _gestionReporteFiltros.Inicializa();
                _gestionReporteFiltros.setValidarData(true);
                _gestionReporteFiltros.setDesde(DateTime.Now.Date);
                _gestionReporteFiltros.setHasta(DateTime.Now.Date);
                _gestionReporteFiltros.setGestion(new Reportes.Filtros.Kardex.Filtros());
                _gestionReporteFiltros.Inicia();
                if (_gestionReporteFiltros.FiltrosIsOK)
                {
                    if (_gestionReporteFiltros.dataFiltrar.Producto == null)
                    {
                        Helpers.Msg.Error("Parametro [ PRODUCTO ] Incorrectos, Verifique Por Favor");
                        return;
                    }
                    var rp = new Reportes.Filtros.KardexResumen.GestionRep();
                    rp.setFiltros(_gestionReporteFiltros.dataFiltrar);
                    rp.Generar();
                }
            }
        }
        public void Kardex()
        {
            if (VerificarPermisoReportes())
            {
                _gestionReporteFiltros.Inicializa();
                _gestionReporteFiltros.setValidarData(true);
                _gestionReporteFiltros.setDesde(DateTime.Now.Date);
                _gestionReporteFiltros.setHasta(DateTime.Now.Date);
                _gestionReporteFiltros.setGestion(new Reportes.Filtros.Kardex.Filtros());
                _gestionReporteFiltros.Inicia();
                if (_gestionReporteFiltros.FiltrosIsOK)
                {
                    var rp = new Reportes.Filtros.Kardex.GestionRep();
                    rp.setFiltros(_gestionReporteFiltros.dataFiltrar);
                    rp.Generar();
                }
            }
        }
        public void MaestroNivelMinimo()
        {
            if (VerificarPermisoReportes())
            {
                _gestionReporteFiltros.Inicializa();
                _gestionReporteFiltros.setValidarData(false);
                _gestionReporteFiltros.setGestion(new Reportes.Filtros.NivelMInimo.Filtro());
                _gestionReporteFiltros.Inicia();
                if (_gestionReporteFiltros.FiltrosIsOK)
                {
                    var rp = new Reportes.Filtros.NivelMInimo.GestionRep();
                    rp.setFiltros(_gestionReporteFiltros.dataFiltrar);
                    rp.Generar();
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

        public void ReporteMaestroInventarioBasico()
        {
            if (VerificarPermisoReportes())
            {
                _gestionReporteFiltros.Inicializa();
                _gestionReporteFiltros.setValidarData(false);
                _gestionReporteFiltros.setGestion(new Reportes.Filtros.MaestroInventario.Filtros());
                _gestionReporteFiltros.Inicia();
                if (_gestionReporteFiltros.FiltrosIsOK)
                {
                    var rp = new Reportes.Filtros.MaestroInventarioBasico.GestionRep();
                    rp.setFiltros(_gestionReporteFiltros.dataFiltrar);
                    rp.Generar();
                }
            }
        }
        public void ReporteMaestroPrecioBasico()
        {
            if (VerificarPermisoReportes())
            {
                _gestionReporteFiltros.Inicializa();
                _gestionReporteFiltros.setValidarData(false);
                _gestionReporteFiltros.setGestion(new Reportes.Filtros.MaestroPrecioBasico.Filtros());
                _gestionReporteFiltros.Inicia();
                if (_gestionReporteFiltros.FiltrosIsOK)
                {
                    var rp = new Reportes.Filtros.MaestroPrecioBasico.GestionRep();
                    rp.setFiltros(_gestionReporteFiltros.dataFiltrar);
                    rp.Generar();
                }
            }
        }

    }

}