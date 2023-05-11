using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.Filtros.BuscarPor.PorProveedor
{
    public class ImpFiltro: IFiltro
    {
        private string _cadena;
        private ListaSelecciona.ILista _lista;


        public string GetDescripcion { get { return _lista.ItemSeleccionadoIsOk ? _lista.ItemSeleccionado.desc : ""; } }
        public bool GetHabilitado { get { return !_lista.ItemSeleccionadoIsOk; } }
        public bool BuscarIsOk { get { return _lista.ItemSeleccionadoIsOk;} }
        public LibUtilitis.Opcion.IData ItemSeleccionado { get { return itemSeleccionado(); } }
        public string ValorSeleccionado 
        { 
            get 
            {
                var _id = "";
                var _item = itemSeleccionado();
                if (_item != null) 
                {
                    _id = _item.id;
                }
                return _id;
            } 
        }


        public ImpFiltro()
        {
            _habilitar = true;
            _cadena = "";
            _lista = new ListaSelecciona.PorProveedor.ImpLista();
        }


        public void setCadenaBuscar(string cad)
        {
            _cadena = cad;
        }


        public void Inicializa()
        {
            _cadena = "";
            _lista.Inicializa();
        }
        public void Limpiar()
        {
            _cadena = "";
            _lista.LimpiarItem();
        }
        public void Buscar()
        {
            if (_cadena.Trim() != "") 
            {
                try
                {
                    var filtro = new OOB.LibInventario.Proveedor.Lista.Filtro()
                    {
                        cadena = _cadena,
                        MetodoBusqueda = OOB.LibInventario.Proveedor.Enumerados.EnumMetodoBusqueda.Nombre,
                    };
                    var r01 = Sistema.MyData.Proveedor_GetLista(filtro);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        throw new Exception(r01.Mensaje);
                    }
                    var lst = new List<Idata>();
                    foreach (var rg in r01.Lista.OrderBy(o => o.nombreRazonSocial).ToList())
                    {
                        lst.Add(new ListaSelecciona.PorProveedor.data() { id = rg.auto, codigo = rg.codigo, desc = rg.nombreRazonSocial, ciRif = rg.ciRif });
                    }
                    _lista.Inicializa();
                    _lista.setDataListar(lst);
                    _lista.Inicia();
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                    return;
                }
            }
        }


        private LibUtilitis.Opcion.IData itemSeleccionado()
        {
            if (_lista.ItemSeleccionado == null)
            {
                return null;
            }
            else 
            {
                return new Utils.Filtros.dataFiltro()
                {
                    codigo = _lista.ItemSeleccionado.codigo,
                    desc = _lista.ItemSeleccionado.desc,
                    id = _lista.ItemSeleccionado.id,
                };
            }
        }


        protected bool _habilitar;
        public bool GetHabilitar { get { return _habilitar; } }
        public void setHabilitar(bool hab)
        {
            _habilitar = hab;
        }
    }
}