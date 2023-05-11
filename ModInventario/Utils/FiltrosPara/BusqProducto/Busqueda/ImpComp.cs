using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Utils.FiltrosPara.BusqProducto.Busqueda
{
    public class ImpComp : IComp
    {
        private string _cadenaBusqueda;
        private CtrlMetodoBusq.IComp _ctrMetBusqueda;
        private Filtro.ICompFiltro _ctrlFiltro;


        public BindingSource MetodoBusqueda_GetSource { get { return _ctrMetBusqueda.Ctrl.GetSource; } }
        public string MetodoBusqueda_GetId { get { return _ctrMetBusqueda.Ctrl.GetId; } }
        public string GetCadena { get { return _cadenaBusqueda; } }
        public bool HayParametrosBusqueda { get { return verificarHatyParametrosBusqueda(); } }


        public ImpComp()
        {
            _cadenaBusqueda = "";
            _ctrMetBusqueda = new CtrlMetodoBusq.ImpComp();
            _ctrlFiltro = new Filtro.ImpComp();
        }


        public void setCadenaBuscar(string cadBuscar)
        {
            _cadenaBusqueda = cadBuscar;
        }
        public void setMetodo(string id)
        {
            _ctrMetBusqueda.Ctrl.setFichaById(id);
        }

        public void Inicializa()
        {
            _cadenaBusqueda = "";
            _ctrMetBusqueda.Inicializa();
            _ctrlFiltro.Inicializa();
        }
        public void CargarData()
        {
            _ctrMetBusqueda.CargarData();
            _ctrlFiltro.CargarData();

        }

        public void MostrarFiltros()
        {
            _ctrlFiltro.Inicia();
        }
        public void Buscar()
        {
        }
        public void Limpiar()
        {
            _cadenaBusqueda = "";
            _ctrMetBusqueda.Limpiar();
            _ctrlFiltro.LimpiarFiltros();
        }

        public OOB.LibInventario.Producto.Filtro DataExportar()
        {
            var _filtros = new OOB.LibInventario.Producto.Filtro();
            if (_ctrMetBusqueda.Ctrl.GetItem == null)
            {
                Helpers.Msg.Alerta("");
                return null;
            }

            if (_ctrMetBusqueda.Ctrl.GetId == "04")
            {
                try
                {
                    var r00 = Sistema.MyData.Producto_GetId_ByCodigoBarra(_cadenaBusqueda);
                    if (r00.Entidad.Trim() == "")
                    {
                        throw new Exception("CODIGO DE BARRA NO ENCONTRADO");
                    }
                    _filtros.autoProducto = r00.Entidad;
                    return _filtros;
                }
                catch (Exception e)
                {
                    Helpers.Msg.Alerta(e.Message);
                    return null;
                }
            }

            try
            {
                var r00 = Sistema.MyData.Configuracion_VisualizarProductosInactivos();
                var _activarProductosInactivos = r00.Entidad;

                _filtros.cadena = _cadenaBusqueda;
                switch (_ctrMetBusqueda.Ctrl.GetId)
                {
                    case "01":
                        _filtros.MetodoBusqueda = OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda.Codigo;
                        break;
                    case "02":
                        _filtros.MetodoBusqueda = OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda.Nombre;
                        break;
                    case "03":
                        _filtros.MetodoBusqueda = OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda.Referencia;
                        break;
                    default:
                        _filtros.MetodoBusqueda = OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda.SnDefinir;
                        break;
                }
                _filtros.autoProveedor = _ctrlFiltro.Proveedor.ValorSeleccionado;
                _filtros.autoDepartamento = _ctrlFiltro.DepartamentoGrupo.Departamento.Ctrl.GetId;
                _filtros.autoGrupo = _ctrlFiltro.DepartamentoGrupo.Grupo.Ctrl.GetId;
                _filtros.autoMarca = _ctrlFiltro.Marca.Ctrl.GetId;
                _filtros.autoDeposito = _ctrlFiltro.Deposito.Ctrl.GetId;
                _filtros.autoTasa = _ctrlFiltro.TasaIva.Ctrl.GetId;
                switch (_ctrlFiltro.Categoria.Ctrl.GetId)
                {
                    case "1":
                        _filtros.categoria = OOB.LibInventario.Producto.Enumerados.EnumCategoria.ProductoTerminado;
                        break;
                    case "2":
                        _filtros.categoria = OOB.LibInventario.Producto.Enumerados.EnumCategoria.BienServicio;
                        break;
                    case "3":
                        _filtros.categoria = OOB.LibInventario.Producto.Enumerados.EnumCategoria.MateriaPrima;
                        break;
                    case "4":
                        _filtros.categoria = OOB.LibInventario.Producto.Enumerados.EnumCategoria.UsoInterno;
                        break;
                    case "5":
                        _filtros.categoria = OOB.LibInventario.Producto.Enumerados.EnumCategoria.SubProducto;
                        break;
                    default:
                        _filtros.categoria = OOB.LibInventario.Producto.Enumerados.EnumCategoria.SnDefinir;
                        break;
                }
                switch (_ctrlFiltro.Origen.Ctrl.GetId)
                {
                    case "1":
                        _filtros.origen = OOB.LibInventario.Producto.Enumerados.EnumOrigen.Nacional;
                        break;
                    case "2":
                        _filtros.origen = OOB.LibInventario.Producto.Enumerados.EnumOrigen.Importado;
                        break;
                    default:
                        _filtros.origen = OOB.LibInventario.Producto.Enumerados.EnumOrigen.SnDefinir;
                        break;
                }
                switch (_ctrlFiltro.Divisa.Ctrl.GetId)
                {
                    case "1":
                        _filtros.admPorDivisa = OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa.Si;
                        break;
                    case "2":
                        _filtros.admPorDivisa = OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa.No;
                        break;
                    default:
                        _filtros.admPorDivisa = OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa.SnDefinir;
                        break;
                }
                switch (_ctrlFiltro.Pesado.Ctrl.GetId)
                {
                    case "1":
                        _filtros.pesado = OOB.LibInventario.Producto.Enumerados.EnumPesado.Si;
                        break;
                    case "2":
                        _filtros.pesado = OOB.LibInventario.Producto.Enumerados.EnumPesado.No;
                        break;
                    default:
                        _filtros.pesado = OOB.LibInventario.Producto.Enumerados.EnumPesado.SnDefinir;
                        break;
                }
                switch (_ctrlFiltro.Oferta.Ctrl.GetId)
                {
                    case "1":
                        _filtros.oferta = OOB.LibInventario.Producto.Enumerados.EnumOferta.Si;
                        break;
                    case "2":
                        _filtros.oferta = OOB.LibInventario.Producto.Enumerados.EnumOferta.No;
                        break;
                    default:
                        _filtros.oferta = OOB.LibInventario.Producto.Enumerados.EnumOferta.SnDefinir;
                        break;
                }
                switch (_ctrlFiltro.Existencia.Ctrl.GetId)
                {
                    case "1":
                        _filtros.existencia = OOB.LibInventario.Producto.Filtro.Existencia.MayorQueCero;
                        break;
                    case "2":
                        _filtros.existencia = OOB.LibInventario.Producto.Filtro.Existencia.IgualCero;
                        break;
                    case "3":
                        _filtros.existencia = OOB.LibInventario.Producto.Filtro.Existencia.MenorQueCero;
                        break;
                    default:
                        _filtros.existencia = OOB.LibInventario.Producto.Filtro.Existencia.SinDefinir;
                        break;
                }
                switch (_ctrlFiltro.Catalogo.Ctrl.GetId)
                {
                    case "1":
                        _filtros.catalogo = OOB.LibInventario.Producto.Enumerados.EnumCatalogo.Si;
                        break;
                    case "2":
                        _filtros.catalogo = OOB.LibInventario.Producto.Enumerados.EnumCatalogo.No;
                        break;
                    default:
                        _filtros.catalogo = OOB.LibInventario.Producto.Enumerados.EnumCatalogo.SnDefinir;
                        break;
                }
                switch (_ctrlFiltro.TCS.Ctrl.GetId)
                {
                    case "1":
                        _filtros.estatusTCS = "1";
                        break;
                    case "2":
                        _filtros.estatusTCS = "0";
                        break;
                }
                if (!_activarProductosInactivos)
                {
                    _filtros.estatus = OOB.LibInventario.Producto.Enumerados.EnumEstatus.Activo;
                }
                else
                {
                    switch (_ctrlFiltro.Estatus.Ctrl.GetId)
                    {
                        case "1":
                            _filtros.estatus = OOB.LibInventario.Producto.Enumerados.EnumEstatus.Activo;
                            break;
                        case "2":
                            _filtros.estatus = OOB.LibInventario.Producto.Enumerados.EnumEstatus.Activo;
                            break;
                        case "3":
                            _filtros.estatus = OOB.LibInventario.Producto.Enumerados.EnumEstatus.Inactivo;
                            break;
                        default:
                            _filtros.estatus = OOB.LibInventario.Producto.Enumerados.EnumEstatus.SnDefinir;
                            break;
                    }
                }
                return _filtros;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return null;
            }
        }


        private bool verificarHatyParametrosBusqueda()
        {
            if (_cadenaBusqueda.Trim() != "") 
            {
                if (_ctrMetBusqueda.Ctrl.GetId != "") return true;
            }

            if (_ctrlFiltro.Proveedor.ValorSeleccionado != "") return true;
            if (_ctrlFiltro.DepartamentoGrupo.Departamento.GetHabilitar) 
            {
                if (_ctrlFiltro.DepartamentoGrupo.Departamento.Ctrl.GetId != "") return true; ;
                if (_ctrlFiltro.DepartamentoGrupo.Grupo.Ctrl.GetId != "") return true;
            }
            if (_ctrlFiltro.Marca.GetHabilitar) 
            {
                if (_ctrlFiltro.Marca.Ctrl.GetId != "") return true;
            }
            if (_ctrlFiltro.Deposito.GetHabilitar)
            {
                if (_ctrlFiltro.Deposito.Ctrl.GetId != "") return true;
            }
            if (_ctrlFiltro.TasaIva.GetHabilitar)
            {
                if (_ctrlFiltro.TasaIva.Ctrl.GetId != "") return true;
            }
            if (_ctrlFiltro.Categoria.GetHabilitar) 
            {
                if (_ctrlFiltro.Categoria.Ctrl.GetId != "") return true;
            }
            if (_ctrlFiltro.Origen.GetHabilitar)
            {
                if (_ctrlFiltro.Origen.Ctrl.GetId != "") return true;
            }
            if (_ctrlFiltro.Divisa.GetHabilitar)
            {
                if (_ctrlFiltro.Divisa.Ctrl.GetId != "") return true;
            }
            if (_ctrlFiltro.Pesado.GetHabilitar)
            {
                if (_ctrlFiltro.Pesado.Ctrl.GetId != "") return true;
            }
            if (_ctrlFiltro.Oferta.GetHabilitar)
            {
                if (_ctrlFiltro.Oferta.Ctrl.GetId != "") return true;
            }
            if (_ctrlFiltro.Existencia.GetHabilitar)
            {
                if (_ctrlFiltro.Existencia.Ctrl.GetId != "") return true;
            }
            if (_ctrlFiltro.Catalogo.GetHabilitar)
            {
                if (_ctrlFiltro.Catalogo.Ctrl.GetId != "") return true;
            }
            if (_ctrlFiltro.Estatus.GetHabilitar)
            {
                if (_ctrlFiltro.Estatus.Ctrl.GetId != "") return true;
            }
            if (_ctrlFiltro.TCS.GetHabilitar)
            {
                if (_ctrlFiltro.TCS.Ctrl.GetId != "") return true;
            }
            return false;
        }


        public void setFiltros(Filtro.IFiltrosActivar filtrosActivar)
        {
            _ctrlFiltro.Catalogo.setHabilitar(filtrosActivar.Catalogo);
            _ctrlFiltro.Categoria.setHabilitar(filtrosActivar.Categoria);
            _ctrlFiltro.DepartamentoGrupo.Departamento.setHabilitar(filtrosActivar.Departamento);
            _ctrlFiltro.Deposito.setHabilitar(filtrosActivar.Deposito);
            _ctrlFiltro.Divisa.setHabilitar(filtrosActivar.Divisa);
            _ctrlFiltro.Estatus.setHabilitar(filtrosActivar.Estatus);
            _ctrlFiltro.Existencia.setHabilitar(filtrosActivar.Existencia);
            _ctrlFiltro.Marca.setHabilitar(filtrosActivar.Marca);
            _ctrlFiltro.Oferta.setHabilitar(filtrosActivar.Oferta);
            _ctrlFiltro.Origen.setHabilitar(filtrosActivar.Origen);
            _ctrlFiltro.Pesado.setHabilitar(filtrosActivar.Pesado);
            _ctrlFiltro.Proveedor.setHabilitar(filtrosActivar.Proveedor);
            _ctrlFiltro.TasaIva.setHabilitar(filtrosActivar.TasaIva);
            _ctrlFiltro.TCS.setHabilitar(filtrosActivar.TCS);
        }
    }
}