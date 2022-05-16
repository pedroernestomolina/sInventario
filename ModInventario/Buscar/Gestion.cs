using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Buscar
{

    public class Gestion
    {

        public enum enumMetodoBusqueda { SinDefinir = -1, PorCodigo = 1, PorNombre, PorReferencia };


        private GestionLista _gestionLista;
        //private Producto.Precio.Editar.Gestion _gestionEditarPrecio;
        private Producto.Deposito.Listar.Gestion _gestionPrdExistencia;
        private Producto.Precio.Historico.Gestion _gestionHistoricoPrecio;
        private Producto.Precio.Ver.Gestion _gestionPrdPrecios;
        private Producto.Costo.Historico.Gestion _gestionHistoricoCosto;
        private Producto.Costo.Ver.Gestion _gestionPrdCosto;
        private Producto.Costo.Editar.Gestion _gestionEditarCosto;
        private Producto.QR.Gestion _gestionQR;
        private Producto.Deposito.Asignar.Gestion _gestionDeposito;
        private Producto.AgregarEditar.Gestion _gestionEditarFicha;
        private Producto.AgregarEditar.Gestion _gestionAgregarFicha;
        private Producto.Estatus.Gestion _gestionEstatus;
        private Kardex.Movimiento.Gestion _gestionKardex;
        private Producto.Imagen.Gestion _gestionImagen;
        private Producto.Proveedor.Gestion _gestionProveedor;
        private Producto.VisualizarFicha.Gestion _gestionVisualizarFicha;
        //
        private FiltrosGen.IAdmProducto _gFiltrarProducto;
        private ISeguridadAccesoSistema _gAccesoSistema;
        //
        private Producto.Precio.ModoSucursal.Editar.IEditar _gEditarPrecio;
        private SeguridadSist.ISeguridad _gSeguridadUsu;
        private SeguridadSist.Usuario.IModoUsuario _gSeguridadModoUsu;


        public object Source { get { return _gestionLista.Source; } }
        public int Items { get { return _gestionLista.Items; } }
        public OOB.LibInventario.Producto.Data.Ficha Item { get { return _gestionLista.Item; } }
        public bool HayItemSeleccionado { get; set; }
        public string CadenaBusqProducto { get { return _gFiltrarProducto.CadenaBusq; } }
        public enumMetodoBusqueda MetodoBusqueda { get { return (enumMetodoBusqueda)_gFiltrarProducto.MetBusqueda; } }


        public Gestion(FiltrosGen.IAdmProducto ctrFiltrarProducto, 
            ISeguridadAccesoSistema ctrSeguridad,
            Helpers.Maestros.ICallMaestros ctrMaestros,
            SeguridadSist.ISeguridad _seguridadUsu,
            SeguridadSist.Usuario.IModoUsuario seguridadModo)
        {
            _gAccesoSistema = ctrSeguridad;
            _gFiltrarProducto = ctrFiltrarProducto;
            _gSeguridadUsu = _seguridadUsu;
            _gSeguridadModoUsu= seguridadModo;
            //
            _gestionLista = new GestionLista();
            _gestionLista.CambioItemActual+=_gestionLista_CambioItemActual;
            _gestionPrdExistencia = new Producto.Deposito.Listar.Gestion();
            _gestionPrdPrecios = new Producto.Precio.Ver.Gestion();
            _gestionHistoricoPrecio = new Producto.Precio.Historico.Gestion();
           // _gestionEditarPrecio = new Producto.Precio.Editar.Gestion(new Producto.Precio.Editar.ModoSucursal.Gestion());
            _gestionHistoricoCosto= new Producto.Costo.Historico.Gestion();
            _gestionPrdCosto = new Producto.Costo.Ver.Gestion();
            _gestionEditarCosto = new Producto.Costo.Editar.Gestion();
            _gestionQR = new Producto.QR.Gestion();
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

            _gestionEstatus = new Producto.Estatus.Gestion();
            _gestionKardex = new Kardex.Movimiento.Gestion();
            _gestionImagen = new Producto.Imagen.Gestion();
            _gestionProveedor = new Producto.Proveedor.Gestion();
            _gestionVisualizarFicha = new Producto.VisualizarFicha.Gestion();
            //
            //
            //
            _gEditarPrecio = new Producto.Precio.ModoSucursal.Editar.Editar();
        }

        private void _gestionLista_CambioItemActual(object sender, EventArgs e)
        {
            frm.ActualizarItem();
        }

        public void Inicializa() 
        {
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

            var r01 = Sistema.MyData.Configuracion_PreferenciaBusqueda();
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            switch (r01.Entidad) 
            {
                case OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda.PorCodigo:
                    _gFiltrarProducto.setMetBusqByCodigo();
                    break;
                case OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda.PorNombre:
                    _gFiltrarProducto.setMetBusqByNombre();
                    break;
                case OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda.PorReferencia:
                    _gFiltrarProducto.setMetBusqByReferencia();
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
            if (data.PrecioMayor != null)
            {
                if (data.PrecioMayor.id == "1")
                    _filtros.precioMayorHabilitado = true;
            }

            RealizarBusqueda(_filtros);
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

        public void VerPrecios()
        {
            //if (Item != null)
            //{
            //    _gestionPrdPrecios.setFicha(Item.identidad.auto);
            //    _gestionPrdPrecios.Inicia();
            //}
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
                _gestionHistoricoPrecio.setFicha(Item.identidad.auto);
                _gestionHistoricoPrecio.Inicia();
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
                if (Item.identidad.estatus != OOB.LibInventario.Producto.Enumerados.EnumEstatus.Inactivo)
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

        public void GenerarQR()
        {
            if (Item != null)
            {
                _gestionQR.setFicha(Item.identidad.auto);
                _gestionQR.Inicia();
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

        public void MovKardex()
        {
            if (Item != null)
            {
                _gestionKardex.setFicha(Item.identidad.auto);
                _gestionKardex.Inicia();
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
                RealizarBusqueda(_gFiltrarProducto.dataFiltrar);
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
                    _gestionImagen.setFicha(Item.identidad.auto);
                    _gestionImagen.Inicia();
                }
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

        public void setCadenaBusc(string cadena)
        {
            _gFiltrarProducto.setCadenaBusc(cadena);
        }
        public void setMetodoBusquedaByCodigo()
        {
            _gFiltrarProducto.setMetBusqByCodigo();
        }
        public void setMetodoBusquedaByNombre()
        {
            _gFiltrarProducto.setMetBusqByNombre();
        }
        public void setMetodoBusquedaByReferencia()
        {
            _gFiltrarProducto.setMetBusqByReferencia();
        }

        public void SeleccionarItem()
        {
            HayItemSeleccionado = _gestionLista.SeleccionarItem() != null ? true : false;
        }

        public void EditarPrecio()
        {
            if (Item != null)
            {
                if (Item.identidad.estatus != OOB.LibInventario.Producto.Enumerados.EnumEstatus.Inactivo)
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
                        _gEditarPrecio.Inicializa();
                        _gEditarPrecio.setIdItemEditar(idAuto);
                        _gEditarPrecio.Inicia();
                        if (_gEditarPrecio.IsEditarPrecioIsOk)
                        {
                            var filtros = new OOB.LibInventario.Producto.Filtro();
                            filtros.autoProducto = idAuto;
                            ActualizarItemLista(filtros);
                        }
                        _gestionLista.ListaPosicion(idAuto);

                        //_gestionEditarPrecio.setFicha(Item.identidad.auto);
                        //_gestionEditarPrecio.Inicia();
                        //if (_gestionEditarPrecio.IsEditarPrecioOk)
                        //{
                        //    var filtros = new OOB.LibInventario.Producto.Filtro();
                        //    filtros.autoProducto = Item.identidad.auto;
                        //    ActualizarItemLista(filtros);
                        //}
                        //_gestionLista.ListaPosicion(idAuto);
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

    }

}