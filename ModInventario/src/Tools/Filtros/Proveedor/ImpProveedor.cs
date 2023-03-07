using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Tools.Filtros.Proveedor
{
    public class ImpProveedor: IProveedor
    {
        private string _cadena;
        private ficha _item;
        private Lista.IListaPrv _hndLista;


        public bool IsOk { get { return _item != null; } }
        public ficha GetItem { get { return _item; } }
        public string GetNombre { get { return IsOk ? _item.desc : ""; } }


        public ImpProveedor() 
        {
            _cadena = "";
            _item = null;
            _hndLista = new Lista.ImpListaPrv();
        }


        public void setCadena(string cad)        
        {
            _cadena = cad;
        }


        public void Inicializa()
        {
            limpiar();
        }
        public void Buscar()
        {
            var _data= CargarData();
            if (_data != null && _data.Count>0) 
            {
                MostrarData(_data);
            }
        }
        public void Limpiar()
        {
            limpiar();
        }


        private List<ficha> CargarData()
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
                    var _lst = new List<ficha>();
                    foreach (var rg in r01.Lista.OrderBy(o => o.nombreRazonSocial).ToList())
                    {
                        var nr = new ficha(rg.auto, rg.codigo, rg.nombreRazonSocial);
                        _lst.Add(nr);
                    }
                    return _lst;
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                    return null;
                }
            }
            return null;
        }
        private void MostrarData(List<ficha> lst)
        {
            _hndLista.Inicializa();
            _hndLista.setLista(lst);
            _hndLista.Inicia();
            if (_hndLista.ItemSeleccionadoIsOk)
            {
                _item = (ficha)_hndLista.GetItemSeleccionado;
            }
        }
        private void limpiar()
        {
            _cadena = "";
            _item = null;
        }
    }
}