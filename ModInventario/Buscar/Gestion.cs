using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Buscar
{
    public class Gestion
    {
        private GestionLista _gestionLista;
        private Producto.Precio.Historico.IHistorico _gHistPrecio;
        private Producto.Costo.Historico.Gestion _gestionHistoricoCosto;
        private Producto.Costo.Ver.Gestion _gestionPrdCosto;
        private Producto.Costo.Editar.Gestion _gestionEditarCosto;
        private Producto.Deposito.Asignar.Gestion _gestionDeposito;
        private ModInventario.src.Producto.AgregarEditar.IBaseAgregarEditar _gestionAgregarFicha;
        private ModInventario.src.Producto.AgregarEditar.IBaseAgregarEditar _gestionEditarFicha;
        private Producto.VisualizarFicha.IVisualizar _gVisualizarFicha;
        private Producto.Estatus.Gestion _gestionEstatus;
        private Producto.Proveedor.Gestion _gestionProveedor;
        private ISeguridadAccesoSistema _gAccesoSistema;
        private ModInventario.src.Producto.QR.IQR _gQR;
        private Kardex.Movimiento.IMov _gKardex;
        private FiltrosGen.IOpcion _gTipoBusq;
        private src.TallaColorSabor.Visualizar.IVer _gTallaColorSabor;
        private src.Producto.Deposito.VerLista.IVerLista _gVerDepositos;
        private src.Producto.Imagen.IImagen _gImagen;


        public BindingSource Source { get { return _gestionLista.Source; } }
        public int Items { get { return _gestionLista.Items; } }
        public OOB.LibInventario.Producto.Data.Ficha Item { get { return _gestionLista.Item; } }
        public bool HayItemSeleccionado { get; set; }


        //
        private Utils.FiltrosPara.BusqProducto.Busqueda.IComp _compBusqProducto;
        public Utils.FiltrosPara.BusqProducto.Busqueda.IComp CompBusqProducto { get { return _compBusqProducto; } }


        private src.IFabrica _fabrica;
        public Gestion(
            //FiltrosGen.AdmProducto.IAdmProducto hndFiltrarProducto, 
            ISeguridadAccesoSistema ctrSeguridad,
            ModInventario.src.Producto.QR.IQR hndQR,
            ModInventario.src.Producto.Imagen.IImagen hndImagen,
            ModInventario.src.Producto.AgregarEditar.IBaseAgregarEditar hndAgregarFicha,
            ModInventario.src.Producto.AgregarEditar.IBaseAgregarEditar hndEditarFicha,
            Producto.VisualizarFicha.IVisualizar hndVisualizarFicha,
            Producto.Precio.EditarCambiar.IEditar hndEditarCambiarPrecio,
            Producto.Precio.VerVisualizar.IVisual hndVerVisualizarPrecio, 
            Producto.Precio.Historico.IHistorico hndHistPrecio,
            ModInventario.src.TallaColorSabor.Visualizar.IVer hndTallaColorSabor,
            ModInventario.src.Producto.Deposito.VerLista.IVerLista hndListaVisDepositos,
            ModInventario.src.IFabrica hndFabrica)
        {
            _gHistPrecio = hndHistPrecio;
            _gEditarCambiarPrecio = hndEditarCambiarPrecio;
            _gVerPrecio = hndVerVisualizarPrecio;
            _gAccesoSistema = ctrSeguridad;
            _gQR = hndQR;
            _gImagen = hndImagen;
            _gTipoBusq= new FiltrosGen.Opcion.Gestion();
            _fabrica = hndFabrica;
            _gestionLista = new GestionLista();
            _gestionHistoricoCosto= new Producto.Costo.Historico.Gestion();
            _gestionPrdCosto = new Producto.Costo.Ver.Gestion();
            _gestionEditarCosto = new Producto.Costo.Editar.Gestion();
            _gestionDeposito = new Producto.Deposito.Asignar.Gestion();
            _gestionAgregarFicha = hndAgregarFicha;
            _gestionEditarFicha = hndEditarFicha;
            _gVisualizarFicha = hndVisualizarFicha;
            _gKardex = new Kardex.Movimiento.Gestion();
            _gestionEstatus = new Producto.Estatus.Gestion();
            _gestionProveedor = new Producto.Proveedor.Gestion();
            _gTallaColorSabor = hndTallaColorSabor;
            _gVerDepositos = hndListaVisDepositos;

            //
            _compBusqProducto = new Utils.FiltrosPara.BusqProducto.Busqueda.ImpComp();
            _compBusqProducto.setFiltros(new FiltrosActivar());
        }


        public void Inicializa() 
        {
            _gTipoBusq.Inicializa();
            _compBusqProducto.Inicializa();
        }

        public void Inicia() 
        {
            if (CargarData()) 
            {
                HayItemSeleccionado = false;
                _gestionLista.Limpiar();

                if (_fabrica.BuscarPrd == null)
                    _fabrica.CreateInstancia_BuscarPrd(this);
                _fabrica.ShowBuscarPrd();
            }
        }

        private bool CargarData()
        {
            try
            {
                _compBusqProducto.CargarData(true);
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }

        public void FiltrarBusqueda()
        {
            _compBusqProducto.MostrarFiltros();
        }

        private string _filtroIdDeposito;
        private void RealizarBusqueda(OOB.LibInventario.Producto.Filtro _filtros)
        {
            _filtroIdDeposito = "";
            if (_filtros == null) { return; }

            try
            {
                var r01 = Sistema.MyData.Producto_GetLista(_filtros);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                _filtroIdDeposito = _filtros.autoDeposito;
                _gestionLista.setLista(r01.Lista);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return;
            }
        }

        public void Limpiar()
        {
            _compBusqProducto.Limpiar();
            _gestionLista.Limpiar();
        }

        public void HistoricoPrecio()
        {
            if (Item != null)
            {
                _gHistPrecio.Inicializa();
                _gHistPrecio.setFicha(Item.identidad.auto);
                _gHistPrecio.Inicia();
            }
        }

        internal void HistoricoCosto()
        {
            if (Item != null)
            {
                _gestionHistoricoCosto.setFicha(Item.identidad.auto);
                _gestionHistoricoCosto.Inicia();
            }
        }

        public void VerCosto()
        {
            if (Item != null)
            {
                _gestionPrdCosto.setFicha(Item.identidad.auto);
                _gestionPrdCosto.Inicia();
            }
        }

        public void EditarCosto()
        {
            if (Item != null)
            {
                if (!Item.IsInactivo)
                {
                    var idAuto = Item.AutoId;
                    var r00 = Sistema.MyData.Permiso_CambiarCostos(Sistema.UsuarioP.autoGru);
                    if (r00.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r00.Mensaje);
                        return;
                    }
                    if (_gAccesoSistema.Verificar(r00.Entidad))
                    {
                        _gestionEditarCosto.setFicha(Item.identidad.auto);
                        _gestionEditarCosto.Inicia();
                        if (_gestionEditarCosto.EditarCostoIsOk) 
                        {
                            var r01 = Sistema.MyData.Configuracion_PermitirCambiarPrecioAlModificarCosto();
                            if (r01.Entidad)
                            {
                                EditarPrecio();
                            }

                            var filtros = new OOB.LibInventario.Producto.Filtro();
                            filtros.autoProducto = Item.identidad.auto;
                            ActualizarItemLista(filtros);
                        }
                    }
                    _gestionLista.ListaPosicion(idAuto);
                }
                else
                    Helpers.Msg.Error("Producto En Estado Inactivo, Verifique Por Favor !!!");
            }
        }

        private void ActualizarItemLista(OOB.LibInventario.Producto.Filtro filtros)
        {
            var r01 = Sistema.MyData.Producto_GetLista(filtros);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    _gestionLista.Reemplazar(r01.Lista);
                }
            }
        }

        public void AsignarDeposito()
        {
            if (Item != null)
            {
                AsignarDepositosA(Item.identidad.auto);
            }
        }
        private void AsignarDepositosA(string autoPrd)
        {
            var r00 = Sistema.MyData.Permiso_AsignarDepositos(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (_gAccesoSistema.Verificar(r00.Entidad))
            {
                _gestionDeposito.setFicha(autoPrd);
                _gestionDeposito.Inicia();
            }
        }

        public void EditarFicha()
        {
            if (Item != null)
            {
                if (Item.identidad.estatus == OOB.LibInventario.Producto.Enumerados.EnumEstatus.Inactivo)
                {
                    Helpers.Msg.Error("Producto En Estado Inactivo, Verifique Por Favor !!!");
                    return;
                }

                var r00 = Sistema.MyData.Permiso_ModificarProducto(Sistema.UsuarioP.autoGru);
                if (r00.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    Helpers.Msg.Error(r00.Mensaje);
                    return;
                }
                if (_gAccesoSistema.Verificar(r00.Entidad))
                {
                    _gestionEditarFicha.Inicializa();
                    _gestionEditarFicha.setFicha(Item.identidad.auto);
                    _gestionEditarFicha.Inicia();
                    if (_gestionEditarFicha.IsAgregarEditarOk)
                    {
                        var auto = Item.identidad.auto;
                        var filtros = new OOB.LibInventario.Producto.Filtro();
                        filtros.autoProducto = Item.identidad.auto;
                        ActualizarItemLista(filtros);
                        ListaPosicion(auto);
                    }
                }
            }
        }

        private void ListaPosicion(string auto)
        {
            _gestionLista.ListaPosicion(auto);
        }

        public void AgregarFicha()
        {
            var r00 = Sistema.MyData.Permiso_CrearProducto(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (_gAccesoSistema.Verificar(r00.Entidad))
            {
                _gestionAgregarFicha.Inicializa();
                _gestionAgregarFicha.Inicia();
                if (_gestionAgregarFicha.IsAgregarEditarOk)
                {
                    AsignarDepositosA(_gestionAgregarFicha.AutoProductoAgregado);


                    var filtros = new OOB.LibInventario.Producto.Filtro();
                    var auto=_gestionAgregarFicha.AutoProductoAgregado;
                    filtros.autoProducto = _gestionAgregarFicha.AutoProductoAgregado;
                    var r01 = Sistema.MyData.Producto_GetLista(filtros);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    if (r01.Lista != null)
                    {
                        if (r01.Lista.Count > 0)
                        {
                            _gestionLista.Agregar(r01.Lista);
                            ListaPosicion(auto);
                        }
                    }
                }
            }
        }

        public void CambioEstatus()
        {
            if (Item != null)
            {
                var idAuto = Item.AutoId;
                var r00 = Sistema.MyData.Permiso_ActualizarEstatusDelProducto(Sistema.UsuarioP.autoGru);
                if (r00.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    Helpers.Msg.Error(r00.Mensaje);
                    return;
                }
                if (_gAccesoSistema.Verificar(r00.Entidad))
                {
                    _gestionEstatus.setFicha(Item.identidad.auto);
                    _gestionEstatus.Inicia();

                    if (_gestionEstatus.IsCambioOk)
                    {
                        var filtros = new OOB.LibInventario.Producto.Filtro();
                        filtros.autoProducto = Item.identidad.auto;
                        var r01 = Sistema.MyData.Producto_GetLista(filtros);
                        if (r01.Result == OOB.Enumerados.EnumResult.isError)
                        {
                            Helpers.Msg.Error(r01.Mensaje);
                            return;
                        }
                        if (r01.Lista != null)
                        {
                            if (r01.Lista.Count > 0)
                            {
                                _gestionLista.Reemplazar(r01.Lista);
                            }
                        }
                    }
                }
                _gestionLista.ListaPosicion(idAuto);
            }
        }

        public void Buscar()
        {
            if (!_compBusqProducto.HayParametrosBusqueda)
            {
                Helpers.Msg.Alerta("NO HAY PARAMETROS SELECCIONADOS PARA REALIZAR LA BUSQUEDA");
                return;
            }
            RealizarBusqueda(_compBusqProducto.DataExportar());
        }

        public void Proveedores()
        {
            if (Item != null)
            {
                _gestionProveedor.setFicha(Item.identidad.auto);
                _gestionProveedor.Inicia();
            }
        }

        public void VisualizarItem()
        {
            if (Item != null)
            {
                _gVisualizarFicha.Inicializa();
                _gVisualizarFicha.setFicha(Item.identidad.auto);
                _gVisualizarFicha.Inicia();
            }
        }

        public void SeleccionarItem()
        {
            HayItemSeleccionado = _gestionLista.SeleccionarItem() != null ? true : false;
        }

        private Producto.Precio.EditarCambiar.IEditar _gEditarCambiarPrecio;
        public void EditarPrecio()
        {
            if (Item != null)
            {
                if (!Item.IsInactivo)
                {
                    var r00 = Sistema.MyData.Permiso_CambiarPrecios(Sistema.UsuarioP.autoGru);
                    if (r00.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r00.Mensaje);
                        return;
                    }
                    if (_gAccesoSistema.Verificar(r00.Entidad))
                    {
                        var idAuto = Item.AutoId;
                        _gEditarCambiarPrecio.Inicializa();
                        _gEditarCambiarPrecio.setIdItemEditar(idAuto);
                        _gEditarCambiarPrecio.Inicia();
                        if (_gEditarCambiarPrecio.EditarPrecioIsOk)
                        {
                            var filtros = new OOB.LibInventario.Producto.Filtro();
                            filtros.autoProducto = idAuto;
                            ActualizarItemLista(filtros);
                        }
                        _gestionLista.ListaPosicion(idAuto);
                    }
                }
                else
                    Helpers.Msg.Error("Producto En Estado Inactivo, Verifique Por Favor !!!");
            }
        }


        public string ET_INV_EMP_COMPRA { get { return Item.GetEtiqueta_InvEmpCompra; } }
        public string ET_INV_EMP_INV { get { return Item.GetEtiqueta_InvEmpInv; } }
        public string ET_INV_EMP_UND { get { return Item.GetEtiqueta_InvEmpUnd; } }
        public int INV_EMP_COMPRA { get { return Item.GetEx_InvEmpCompra; } }
        public int INV_EMP_INV { get { return Item.GetEx_InvEmpInv; } }
        public int INV_EMP_UND { get { return Item.GetEx_InvEmpUnd; } }


        public void MovKardex()
        {
            if (Item != null)
            {
                _gKardex.Inicializa();
                _gKardex.setFicha(Item.identidad.auto);
                _gKardex.Inicia();
            }
        }

        private Producto.Precio.VerVisualizar.IVisual _gVerPrecio;
        public void VerPrecios()
        {
            if (Item != null)
            {
                _gVerPrecio.Inicializa();
                _gVerPrecio.setFichaVisualizar(Item.identidad.auto);
                _gVerPrecio.Inicia();
            }
        }


        public BindingSource GeTipoBusqueda_Source { get { return _gTipoBusq.Source; } }
        public string GetTipoBusqueda_Id { get { return _gTipoBusq.GetId; } }
        public void setCadenaBusc(string cadena)
        {
            _compBusqProducto.setCadenaBuscar(cadena);
        }
        public void setTipoBusqueda(string id)
        {
            _compBusqProducto.setMetodo(id);
        }

        public void GenerarQR()
        {
            if (Item != null)
            {
                _gQR.Inicializa();
                _gQR.setFicha(Item.identidad.auto);
                _gQR.Inicia();
            }
        }
        public void VerImagen()
        {
            if (Item != null)
            {
                try
                {
                    var r00 = Sistema.MyData.Permiso_CambiarImagenDelProducto(Sistema.UsuarioP.autoGru);
                    if (_gAccesoSistema.Verificar(r00.Entidad))
                    {
                        _gImagen.Inicializa();
                        _gImagen.setFicha(Item.identidad.auto);
                        _gImagen.Inicia();
                    }
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                }
            }
        }
        public void VerTallaColorSabor()
        {
            if (Item != null)
            {
                _gTallaColorSabor.Inicializa();
                _gTallaColorSabor.setIdPrd(Item.identidad.auto);
                _gTallaColorSabor.setIdDeposito(_filtroIdDeposito);
                _gTallaColorSabor.HabilitaBtDetalle(_filtroIdDeposito=="");
                _gTallaColorSabor.Inicia();
            }
        }
        public void VerExistencia()
        {
            if (Item != null)
            {
                _gVerDepositos.Inicializa();
                _gVerDepositos.setIdPrd(Item.identidad.auto);
                _gVerDepositos.setIdDeposito(_filtroIdDeposito);
                _gVerDepositos.Inicia();
            }
        }


        src.Producto.ActualizarOferta.IActOferta _ofertaDscto;
        public void DsctoOferta()
        {
            try
            {
                var r01 = Sistema.MyData.Permiso_AsignarOfertaProducto(Sistema.UsuarioP.autoGru);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                if (_gAccesoSistema.Verificar(r01.Entidad))
                {
                    if (Item != null)
                    {
                        if (_ofertaDscto == null)
                        {
                            _ofertaDscto = _fabrica.CreateInstancia_OfertaDscto();
                            if (_ofertaDscto == null)
                            {
                                Helpers.Msg.Alerta("OPCION NO IMPLEMENTADA PARA ESTE MODULO");
                                return;
                            }
                        }
                        _ofertaDscto.Inicializa();
                        _ofertaDscto.setFichaByIdPrd(Item.AutoId);
                        _ofertaDscto.Inicia();
                    }
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
    }
}