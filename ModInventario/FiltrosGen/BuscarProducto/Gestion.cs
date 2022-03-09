using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.FiltrosGen.BuscarProducto
{
    
    public class Gestion:IBuscar
    {

        private string _cadena;
        private ficha _item;
        private Buscar.IListaSeleccion _gListaSelPrd;


        public bool ItemIsOk { get { return _item == null ? false : true; } }
        public string DescItemSeleccionado { get { return ItemIsOk ? _item.desc : ""; } }
        public ficha ItemSeleccionado { get { return _item; } }


        public Gestion(Buscar.IListaSeleccion ctrSelPrd) 
        {
            _cadena = "";
            _item = null;
            _gListaSelPrd = ctrSelPrd;
        }


        public void setCadenaBuscar(string p)
        {
            _cadena = p;
        }

        public void Buscar()
        {
            if (_cadena.Trim() != "")
            {
                var r01 = Sistema.MyData.Configuracion_VisualizarProductosInactivos();
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                var _visualizarPrdInactivos = r01.Entidad;

                var filtro = new OOB.LibInventario.Producto.Filtro()
                {
                    cadena = _cadena,
                    MetodoBusqueda = OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda.Nombre,
                };
                if (!_visualizarPrdInactivos)
                {
                    filtro.estatus = OOB.LibInventario.Producto.Enumerados.EnumEstatus.Activo;
                }
                var r02 = Sistema.MyData.Producto_GetLista(filtro);
                if (r02.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r02.Mensaje);
                    return;
                }
                var lst = new List<fichaSeleccion>();
                foreach (var rg in r02.Lista.OrderBy(o => o.DescripcionPrd).ToList())
                {
                    lst.Add(new fichaSeleccion(rg.AutoId, rg.CodigoPrd, rg.DescripcionPrd, rg.IsInactivo));
                }

                _gListaSelPrd.Inicializa();
                _gListaSelPrd.setLista(lst);
                _gListaSelPrd.Inicia();
                if (_gListaSelPrd.ItemSeleccionadoIsOk)
                {
                    _item = (ficha)_gListaSelPrd.ItemSeleccionado;
                }
            }
        }


        public void LimpiarItem()
        {
            limpiar();
        }

        public void Inicializa()
        {
            limpiar();
            _gListaSelPrd.Inicializa();
        }

        private void limpiar()
        {
            _item = null;
            _cadena = "";
        }

    }

}