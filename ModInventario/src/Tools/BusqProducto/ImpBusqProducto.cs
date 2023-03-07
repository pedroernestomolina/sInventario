using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Tools.BusqProducto
{
    public class ImpBusqProducto: IBusqProducto
    {
        private Buscar.IBuscar _hndBuscar;
        private ModInventario.src.Tools.FiltrosPara.Productos.IProducto _hndFiltPrd;


        public BindingSource GetSource { get { return _hndBuscar.Source; } }
        public string GetId { get { return _hndBuscar.Id; } }
        public string GetCadenaBusq { get { return _hndBuscar.GetCadena; } }


        public ImpBusqProducto()
        {
            _hndBuscar = new Buscar.ImpBuscar();
            _hndFiltPrd = new ModInventario.src.Tools.FiltrosPara.Productos.ModoSucursal.ImpSucursal();
        }


        public void setCadenaBusqueda(string cadBusq)
        {
            _hndBuscar.setCadena(cadBusq);
        }
        public void setMetodoBusq(string id)
        {
            _hndBuscar.setMetodo(id);
        }
        public void setHabilitarFiltroDeposito(bool act)
        {
            _hndFiltPrd.Deposito.setHabilitar(act);
        }


        public void Inicializa()
        {
            _hndBuscar.Inicializa();
            _hndFiltPrd.Inicializa();
        }
        public void CargarData()
        {
            _hndBuscar.CargarData();
        }
        public void ActivarFiltros()
        {
            _hndFiltPrd.Inicia();
        }
        public void LimpiarFiltros()
        {
            _hndBuscar.LimpiarCargarMetPreferencia();
            _hndFiltPrd.LimpiarFiltros();
        }
        public OOB.LibInventario.Producto.Filtro BuscarFiltros()
        {
            var _filtros = _hndFiltPrd.FiltrosExportar;
            var _metodo=_hndBuscar.DataExportar;
            if (_filtros.FiltrosIsOk() || _metodo.IsOk())
            {
                return CrearFiltrosBusqueda(_metodo, _filtros);
            }
            else 
            {
                Helpers.Msg.Alerta("NO HAY PARAMETROS DE BUSQUEDA DEFINIDOS");
                return null;
            }
        }


        private OOB.LibInventario.Producto.Filtro CrearFiltrosBusqueda(Tools.Buscar.dataExportar met, FiltrosPara.Productos.filtrosExportar filt)
        {
            var _filtros = new OOB.LibInventario.Producto.Filtro();
            if ((FiltrosGen.AdmProducto.data.enumMetBusqueda)met.MetodoValor != FiltrosGen.AdmProducto.data.enumMetBusqueda.PorCodigoBarra)
            {
                try
                {
                    var r00 = Sistema.MyData.Configuracion_VisualizarProductosInactivos();
                    var _activarProductosInactivos = r00.Entidad;

                    _filtros.cadena = met.Cadena;
                    _filtros.MetodoBusqueda = (OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda)met.MetodoValor;
                    if (filt.Proveedor != null) _filtros.autoProveedor = filt.Proveedor.id;
                    if (filt.Departamento != null) _filtros.autoDepartamento = filt.Departamento.id;
                    if (filt.Grupo != null) _filtros.autoGrupo = filt.Grupo.id;
                    if (filt.Marca != null) _filtros.autoMarca = filt.Marca.id;
                    if (filt.Deposito != null) _filtros.autoDeposito = filt.Deposito.id;
                    if (filt.Categoria != null)
                    {
                        _filtros.categoria = (OOB.LibInventario.Producto.Enumerados.EnumCategoria)int.Parse(filt.Categoria.id);
                    }
                    if (filt.Origen != null)
                    {
                        _filtros.origen = (OOB.LibInventario.Producto.Enumerados.EnumOrigen)int.Parse(filt.Origen.id);
                    }
                    if (filt.TasaIva != null) _filtros.autoTasa = filt.TasaIva.id;
                    if (filt.Estatus != null)
                    {
                        _filtros.estatus = (OOB.LibInventario.Producto.Enumerados.EnumEstatus)int.Parse(filt.Estatus.id);
                    }
                    else
                    {
                        if (!_activarProductosInactivos)
                        {
                            _filtros.estatus = OOB.LibInventario.Producto.Enumerados.EnumEstatus.Activo;
                        }
                    }
                    if (filt.AdmDivisa != null)
                    {
                        _filtros.admPorDivisa = (OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa)int.Parse(filt.AdmDivisa.id);
                    }
                    if (filt.Pesado != null)
                    {
                        _filtros.pesado = (OOB.LibInventario.Producto.Enumerados.EnumPesado)int.Parse(filt.Pesado.id);
                    }
                    if (filt.Oferta != null)
                    {
                        _filtros.oferta = (OOB.LibInventario.Producto.Enumerados.EnumOferta)int.Parse(filt.Oferta.id);
                    }
                    if (filt.Existencia != null)
                    {
                        var xd = OOB.LibInventario.Producto.Filtro.Existencia.SinDefinir;
                        switch (filt.Existencia.id)
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
                    if (filt.Catalogo != null)
                    {
                        var xd = OOB.LibInventario.Producto.Enumerados.EnumCatalogo.SnDefinir;
                        switch (filt.Catalogo.id)
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
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                    return null;
                }
            }
            else
            {
                try
                {
                    var r00 = Sistema.MyData.Producto_GetId_ByCodigoBarra(met.Cadena);
                    if (r00.Entidad.Trim() == "")
                    {
                        throw new Exception("CODIGO DE BARRA NO ENCONTRADO");
                    }
                    _filtros.autoProducto = r00.Entidad;
                }
                catch (Exception e)
                {
                    Helpers.Msg.Alerta(e.Message);
                    _filtros = null;
                }
            }
            return _filtros;
        }
        public void LimpiarCargarMetBusPreferido()
        {
            _hndBuscar.LimpiarCargarMetPreferencia();
            _hndFiltPrd.Inicializa();
        }
    }
}