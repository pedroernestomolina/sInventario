using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Tools.Filtros.Proveedor.Lista
{

    public class ImpListaPrv: IListaPrv
    {
        private List<ficha> _lst;
        private BindingSource _bs;
        private ficha _itemSeleccionado;


        public bool ItemSeleccionadoIsOk { get { return _itemSeleccionado == null ? false : true; } }
        public BindingSource GetSource { get { return _bs; } }
        public int GetCtnItems{ get { return _bs.Count; } }
        public object ItemActual { get { return _bs.Current; } }
        public IEnumerable<object> GetListaItems { get { return (IEnumerable<object>)_bs.List; } }
        public ficha GetItemSeleccionado { get { return _itemSeleccionado; } }


        public ImpListaPrv() 
        {
            _lst = new List<ficha>();
            _bs = new BindingSource();
            _bs.DataSource = _lst;
            _itemSeleccionado = null;
        }


        public void Inicializa()
        {
            limpiar();
        }

        private void limpiar()
        {
            _lst.Clear();
            _bs.DataSource = _lst;
            _bs.CurrencyManager.Refresh();
            _itemSeleccionado = null;
        }


        Frm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null)
                {
                    frm = new Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public void setLista(List<ficha> lst)
        {
            _lst = lst;
            _bs.DataSource = _lst;
            _bs.CurrencyManager.Refresh();
        }


        public void SeleccionarItem()
        {
            if (_bs.Current != null)
            {
                _itemSeleccionado = (ficha)_bs.Current;
            }
        }
        public void Limpiar()
        {
        }


        private bool CargarData()
        {
            return true;
        }
    }
}