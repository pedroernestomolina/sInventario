using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.FiltrosGen.BuscarProveedor
{
    
    public class Gestion:IBuscar
    {

        private string _cadena;
        private ficha _item;
        private Buscar.IListaSeleccion _gListaSelPrv;


        public bool ItemIsOk { get { return _item == null ? false : true; } }
        public string DescItemSeleccionado { get { return ItemIsOk ? _item.desc : ""; } }
        public ficha ItemSeleccionado { get { return _item; } }


        public Gestion(Buscar.IListaSeleccion ctrSelPrv) 
        {
            _cadena = "";
            _item = null;
            _gListaSelPrv = ctrSelPrv;
        }


        public void setCadenaBuscar(string p)
        {
            _cadena = p;
        }

        public void Buscar()
        {
            if (_cadena.Trim() != "")
            {
                var filtro = new OOB.LibInventario.Proveedor.Lista.Filtro()
                {
                    cadena = _cadena,
                    MetodoBusqueda = OOB.LibInventario.Proveedor.Enumerados.EnumMetodoBusqueda.Nombre,
                };
                var r01 = Sistema.MyData.Proveedor_GetLista(filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                var lst = new List<fichaSeleccion>();
                foreach (var rg in r01.Lista.OrderBy(o => o.nombreRazonSocial).ToList())
                {
                    var nr = new fichaSeleccion(rg.auto, rg.codigo, rg.nombreRazonSocial, true);
                    lst.Add(nr);
                }
                _gListaSelPrv.Inicializa();
                _gListaSelPrv.setLista(lst);
                _gListaSelPrv.Inicia();
                if (_gListaSelPrv.ItemSeleccionadoIsOk)
                {
                    _item = (ficha)_gListaSelPrv.ItemSeleccionado;
                }
            }
        }


        public void LimpiarItem()
        {
            limpiar();
        }

        public void Inicializa()
        {
            _gListaSelPrv.Inicializa();
            limpiar();
        }

        private void limpiar()
        {
            _cadena = "";
            _item = null;
        }

    }

}