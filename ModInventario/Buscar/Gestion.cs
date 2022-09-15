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

        public enum enumMetodoBusqueda { SinDefinir = -1, PorCodigo = 1, PorNombre, PorReferencia };


        private GestionLista _gestionLista;
        private Producto.Deposito.Listar.Gestion _gestionPrdExistencia;
        private Producto.Precio.Historico.IHistorico _gHistPrecio;

        private Producto.Costo.Historico.Gestion _gestionHistoricoCosto;
        private Producto.Costo.Ver.Gestion _gestionPrdCosto;
        private Producto.Costo.Editar.Gestion _gestionEditarCosto;
        private Producto.Deposito.Asignar.Gestion _gestionDeposito;
        private Producto.AgregarEditar.Gestion _gestionEditarFicha;
        private Producto.AgregarEditar.Gestion _gestionAgregarFicha;
        private Producto.Estatus.Gestion _gestionEstatus;
        private Producto.Imagen.Gestion _gestionImagen;
        private Producto.Proveedor.Gestion _gestionProveedor;
        private Producto.VisualizarFicha.Gestion _gestionVisualizarFicha;
        //
        private FiltrosGen.AdmProducto.IAdmProducto _gFiltrarProducto;
        private ISeguridadAccesoSistema _gAccesoSistema;
        //
        private SeguridadSist.ISeguridad _gSeguridadUsu;
        private SeguridadSist.Usuario.IModoUsuario _gSeguridadModoUsu;
        private Producto.QR.IQR _gQR;
        private Producto.Imagen.IImagen _gImagen;
        private Kardex.Movimiento.IMov _gKardex;
        //
        private FiltrosGen.IOpcion _gTipoBusq;


        public BindingSource Source { get { return _gestionLista.Source; } }
        public int Items { get { return _gestionLista.Items; } }
        public OOB.LibInventario.Producto.Data.Ficha Item { get { return _gestionLista.Item; } }
        public bool HayItemSeleccionado { get; set; }
        public string CadenaBusqProducto { get { return _gFiltrarProducto.CadenaBusq; } }
        public enumMetodoBusqueda MetodoBusqueda { get { return (enumMetodoBusqueda)_gFiltrarProducto.MetBusqueda; } }


        public Gestion(FiltrosGen.AdmProducto.IAdmProducto hndFiltrarProducto, 
            ISeguridadAccesoSistema ctrSeguridad,
            Helpers.Maestros.ICallMaestros ctrMaestros,
            SeguridadSist.ISeguridad _seguridadUsu,
            SeguridadSist.Usuario.IModoUsuario seguridadModo,
            Producto.QR.IQR _qr,
            Producto.Imagen.IImagen _imagen,
            Producto.Precio.EditarCambiar.IEditar hndEditarCambiarPrecio,
            Producto.Precio.VerVisualizar.IVisual hndVerVisualizarPrecio, 
            Producto.Precio.Historico.IHistorico hndHistPrecio)
        {
            _gHistPrecio = hndHistPrecio;
            _gEditarCambiarPrecio = hndEditarCambiarPrecio;
            _gVerPrecio = hndVerVisualizarPrecio;
            _gFiltrarProducto = hndFiltrarProducto;
            _gAccesoSistema = ctrSeguridad;
            _gSeguridadUsu = _seguridadUsu;
            _gSeguridadModoUsu= seguridadModo;
            _gQR = _qr;
            _gImagen = _imagen;
            _gTipoBusq= new FiltrosGen.Opcion.Gestion();

            //
            _gestionLista = new GestionLista();
            _gestionPrdExistencia = new Producto.Deposito.Listar.Gestion();
            _gestionHistoricoCosto= new Producto.Costo.Historico.Gestion();
            _gestionPrdCosto = new Producto.Costo.Ver.Gestion();
            _gestionEditarCosto = new Producto.Costo.Editar.Gestion();
            _gestionDeposito = new Producto.Deposito.Asignar.Gestion();

            //
            var _editarFicha = new Producto.AgregarEditar.Editar.Gestion();
            _editarFicha.setSeguridad(_gSeguridadUsu);
            _editarFicha.setModoSeguridad(_gSeguridadModoUsu);
            _gestionEditarFicha = new Producto.AgregarEditar.Gestion(
                _editarFicha, 
                ctrMaestros);
            _gestionAgregarFicha = new Producto.AgregarEditar.Gestion(
                new Producto.AgregarEditar.Agregar.Gestion(), 
                ctrMaestros);
            //
            _gKardex = new Kardex.Movimiento.Gestion();
            //
            _gestionEstatus = new Producto.Estatus.Gestion();
            _gestionImagen = new Producto.Imagen.Gestion();
            _gestionProveedor = new Producto.Proveedor.Gestion();
            _gestionVisualizarFicha = new Producto.VisualizarFicha.Gestion();
        }

        public void Inicializa() 
        {
            _gTipoBusq.Inicializa();
            _gFiltrarProducto.Inicializa();
        }

        BusquedaFrm frm;
        public void Inicia() 
        {
            if (CargarData()) 
            {
                HayItemSeleccionado = false;
                _gestionLista.Limpiar();
                if (frm == null) 
                {
                    frm = new BusquedaFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var lst = new List<ficha>();
            lst.Add(new ficha("01", "", "Código"));
            lst.Add(new ficha("02", "", "Descripción"));
            lst.Add(new ficha("03", "", "Referencia"));
            lst.Add(new ficha("04", "", "Cod/Barra"));
            _gTipoBusq.setData(lst);

            var r01 = Sistema.MyData.Configuracion_PreferenciaBusqueda();
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            switch (r01.Entidad) 
            {
                case OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda.PorCodigo:
                    setTipoBusqueda("01");
                    break;
                case OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda.PorNombre:
                    setTipoBusqueda("02");
                    break;
                case OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda.PorReferencia:
                    setTipoBusqueda("03");
                    break;
            }

            return rt;
        }

        private void RealizarBusqueda(FiltrosGen.AdmProducto.data data)
        {
            CargarFiltros(data);
        }

        public void FiltrarBusqueda()
        {
            _gFiltrarProducto.Inicia();
        }

        private void CargarFiltros(FiltrosGen.AdmProducto.data data)
        {
            if (data.MetBusqueda != FiltrosGen.AdmProducto.data.enumMetBusqueda.PorCodigoBarra)
            {
                var r00 = Sistema.MyData.Configuracion_VisualizarProductosInactivos();
                if (r00.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r00.Mensaje);
                    return;
                }
                var _activarProductosInactivos = r00.Entidad;

                var _filtros = new OOB.LibInventario.Producto.Filtro();
                _filtros.cadena = data.CadenaBusq;
                _filtros.MetodoBusqueda = (OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda)data.MetBusqueda;
                if (data.Proveedor != null) _filtros.autoProveedor = data.Proveedor.id;
                if (data.Departamento != null) _filtros.autoDepartamento = data.Departamento.id;
                if (data.Grupo != null) _filtros.autoGrupo = data.Grupo.id;
                if (data.Marca != null) _filtros.autoMarca = data.Marca.id;
                if (data.Deposito != null) _filtros.autoDeposito = data.Deposito.id;
                if (data.Categoria != null)
                {
                    _filtros.categoria = (OOB.LibInventario.Producto.Enumerados.EnumCategoria)int.Parse(data.Categoria.id);
                }
                if (data.Origen != null)
                {
                    _filtros.origen = (OOB.LibInventario.Producto.Enumerados.EnumOrigen)int.Parse(data.Origen.id);
                }
                if (data.TasaIva != null) _filtros.autoTasa = data.TasaIva.id;
                if (data.Estatus != null)
                {
                    _filtros.estatus = (OOB.LibInventario.Producto.Enumerados.EnumEstatus)int.Parse(data.Estatus.id);
                }
                else
                {
                    if (!_activarProductosInactivos)
                    {
                        _filtros.estatus = OOB.LibInventario.Producto.Enumerados.EnumEstatus.Activo;
                    }
                }
                if (data.AdmDivisa != null)
                {
                    _filtros.admPorDivisa = (OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa)int.Parse(data.AdmDivisa.id);
                }
                if (data.Pesado != null)
                {
                    _filtros.pesado = (OOB.LibInventario.Producto.Enumerados.EnumPesado)int.Parse(data.Pesado.id);
                }
                if (data.Oferta != null)
                {
                    _filtros.oferta = (OOB.LibInventario.Producto.Enumerados.EnumOferta)int.Parse(data.Oferta.id);
                }
                if (data.Existencia != null)
                {
                    var xd = OOB.LibInventario.Producto.Filtro.Existencia.SinDefinir;
                    switch (data.Existencia.id)
                    {
                        case "1":
                            xd = OOB.LibInventario.Producto.Filtro.Existencia.MayorQueCero;
                            break;
                        case "2":
                            xd = OOB.LibInventario.Producto.Filtro.Existencia.IgualCero;
                            break;
                        case "3":
                            xd = OOB.LibInventario.Producto.Filtro.Existencia.MenorQueCero;
                            break;
                    }
                    _filtros.existencia = xd;
                }
                if (data.Catalogo != null)
                {
                    var xd = OOB.LibInventario.Producto.Enumerados.EnumCatalogo.SnDefinir;
                    switch (data.Catalogo.id)
                    {
                        case "1":
                            xd = OOB.LibInventario.Producto.Enumerados.EnumCatalogo.No;
                            break;
                        case "2":
                            xd = OOB.LibInventario.Producto.Enumerados.EnumCatalogo.Si;
                            break;
                    }
                    _filtros.catalogo = xd;
                }
                RealizarBusqueda(_filtros);
            }
            else 
            {
                var r00 = Sistema.MyData.Producto_GetId_ByCodigoBarra(data.CadenaBusq);
                if (r00.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r00.Mensaje);
                    return;
                }
                if (r00.Entidad.Trim() == "")
                {
                    return;
                }
                var _filtros = new OOB.LibInventario.Producto.Filtro();
                _filtros.autoProducto = r00.Entidad;
                RealizarBusqueda(_filtros);
            }
        }

        private void RealizarBusqueda(OOB.LibInventario.Producto.Filtro _filtros)
        {
            var r01 = Sistema.MyData.Producto_GetLista(_filtros);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _gestionLista.setLista(r01.Lista);
            frm.ActualizarItem();
        }

        public void VerExistencia()
        {
            if (Item != null)
            {
                _gestionPrdExistencia.setFicha(Item.identidad.auto);
                _gestionPrdExistencia.Inicia();
            }
        }

        public void Limpiar()
        {
            _gFiltrarProducto.LimpiarFiltros();
            _gFiltrarProducto.setCadenaBusc("");
            _gestionLista.Limpiar();
            frm.ActualizarItem();
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
            if (_gFiltrarProducto.DataFiltrarIsOk())
            {
                var filtros= Helpers.Filtro.BusqProducto((src.FiltroBusqAdm.dataFiltro) _gFiltrarProducto.FiltrosExportar);
                RealizarBusqueda(filtros);
            }
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
                _gestionVisualizarFicha.Inicializa();
                _gestionVisualizarFicha.setFicha(Item.identidad.auto);
                _gestionVisualizarFicha.Inicia();
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


        public void GenerarQR()
        {
            if (Item != null)
            {
                _gQR.Inicializa();
                _gQR.setFicha(Item.identidad.auto);
                _gQR.Inicia();
            }
        }

        public void GetImagen()
        {
            if (Item != null)
            {
                var r00 = Sistema.MyData.Permiso_CambiarImagenDelProducto(Sistema.UsuarioP.autoGru);
                if (r00.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r00.Mensaje);
                    return;
                }
                if (_gAccesoSistema.Verificar(r00.Entidad))
                {
                    _gImagen.Inicializa();
                    _gImagen.setFicha(Item.identidad.auto);
                    _gImagen.Inicia();
                }
            }
        }

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
            _gFiltrarProducto.setCadenaBusc(cadena);
        }
        public void setTipoBusqueda(string id)
        {
            _gTipoBusq.setFicha(id);
            switch (id)
            {
                case "01":
                    _gFiltrarProducto.setMetBusqByCodigo();
                    break;
                case "02":
                    _gFiltrarProducto.setMetBusqByNombre();
                    break;
                case "03":
                    _gFiltrarProducto.setMetBusqByReferencia();
                    break;
                case "04":
                    _gFiltrarProducto.setMetBusqByCodigoBarra();
                    break;
            }
        }

    }

}