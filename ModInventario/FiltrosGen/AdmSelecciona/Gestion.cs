using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.FiltrosGen.AdmSelecciona
{
    
    public class Gestion: IAdmSelecciona
    {

        public event EventHandler NotificarSeleccion;


        private IAdmProducto _gAdmPrd;
        private Buscar.INotificarSeleccion _gSelNotifica;
        private bool _activarBusquedaParaTraslado ;
        private string _idDepOrigen;
        private string _idDepDestino;


        public bool ItemSeleccionadoIsOk { get { return _gSelNotifica.ItemSeleccionadoIsOk; } }
        public ficha ItemSeleccionado { get { return _gSelNotifica.ItemSeleccionado; } }
        public int MetBusqueda { get { return _gAdmPrd.MetBusqueda; } }
        public string CadenaBusqueda { get { return _gAdmPrd.CadenaBusq; } }


        public Gestion(IAdmProducto admPrd, Buscar.INotificarSeleccion selNotifica)
        {
            _activarBusquedaParaTraslado = false;
            _idDepOrigen = "";
            _idDepDestino = "";
            _gAdmPrd = admPrd;
            _gSelNotifica = selNotifica;
        }


        public void Inicializa()
        {
            _activarBusquedaParaTraslado = false;
            _idDepOrigen = "";
            _idDepDestino = "";
            _gAdmPrd.Inicializa();
            _gSelNotifica.Inicializa();
        }

        public void Inicia()
        {
            _gAdmPrd.Inicia();
        }

        public void BuscarSeleccionar()
        {
            if (_gAdmPrd.DataFiltrarIsOk()) 
            {
                Buscar(_gAdmPrd.dataFiltrar);
            }
        }
        private void Buscar(AdmProducto.data data)
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
            //if (data.PrecioMayor != null)
            //{
            //    if (data.PrecioMayor.id == "1")
            //        _filtros.precioMayorHabilitado = true;
            //}
            _filtros.activarBusquedaParaMovTraslado = _activarBusquedaParaTraslado;
            _filtros.autoDepOrigen = _idDepOrigen;
            _filtros.autoDepDestino = _idDepDestino;
            
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
            var lst = new List<fichaSeleccion>();
            foreach (var rg in r01.Lista.OrderBy(o => o.DescripcionPrd).ToList())
            {
                lst.Add(new fichaSeleccion(rg.AutoId, rg.CodigoPrd, rg.DescripcionPrd, rg.IsInactivo));
            }

            _gSelNotifica.NotificarSeleccion += _gSelNotifica_NotificarSeleccion;
            _gSelNotifica.Inicializa();
            _gSelNotifica.setActivarNotificacion(true);
            _gSelNotifica.setCerrarVentanaAlSeleccionarItem(false);
            _gSelNotifica.setPermitirSeleccionarInactivos(false);
            _gSelNotifica.setLista(lst);
            _gSelNotifica.Inicia();
            _gSelNotifica.NotificarSeleccion -= _gSelNotifica_NotificarSeleccion;
        }

        private void _gSelNotifica_NotificarSeleccion(object sender, EventArgs e)
        {
            EventHandler hnd = NotificarSeleccion;
            hnd(this, null);
        }


        public void setCadenaBusq(string cadena)
        {
            _gAdmPrd.setCadenaBusc(cadena);
        }
        public void setMetBusqByCodigo()
        {
            _gAdmPrd.setMetBusqByCodigo();
        }
        public void setMetBusqByNombre()
        {
            _gAdmPrd.setMetBusqByNombre();
        }
        public void setMetBusqByReferencia()
        {
            _gAdmPrd.setMetBusqByReferencia();
        }
        public void setActivarBusquedaParaTraslado()
        {
            _activarBusquedaParaTraslado = true;
        }
        public void setActivarDepOrigen(string id)
        {
            _idDepOrigen = id;
        }
        public void setActivarDepDestino(string id)
        {
            _idDepDestino = id;
        }

    }

}