using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Tools.ListaSelProducto
{
    public class ImpListaSelProducto : IListaSelProducto
    {
        public event EventHandler Notificar;
        private bool _cerrarVentanaAlSeleccionar;
        private List<fichaSeleccion> _lst;
        private BindingSource _bs;
        private ficha _itemSeleccionado;


        public bool ItemSeleccionadoIsOk { get { return _itemSeleccionado == null ? false : true; } }
        public BindingSource GetSource { get { return _bs; } }
        public int GetCtnItems { get { return _bs.Count; } }
        public object ItemActual { get { return _bs.Current; } }
        public IEnumerable<object> GetListaItems { get { return (IEnumerable<object>)_bs.List; } }
        public ficha GetItemSeleccionado { get { return _itemSeleccionado; } }
        public bool CerrarVentanaAlSeleccionarItem { get { return _cerrarVentanaAlSeleccionar; } }


        public ImpListaSelProducto()
        {
            _cerrarVentanaAlSeleccionar = true;
            _lst = new List<fichaSeleccion>();
            _bs = new BindingSource();
            _bs.DataSource = _lst;
            _itemSeleccionado = null;
        }


        public void Inicializa()
        {
            _cerrarVentanaAlSeleccionar = true;
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


        public void setLista(List<fichaSeleccion> lst)
        {
            _lst = lst;
            _bs.DataSource = _lst;
            _bs.CurrencyManager.Refresh();
        }
        public void setCerrarVentanaAlSeleccionar(bool act)
        {
            _cerrarVentanaAlSeleccionar = act;
        }


        public void SeleccionarItem()
        {
            if (_bs.Current != null)
            {
                _itemSeleccionado = (ficha)_bs.Current;
                NotificarSeleccion();
            }
        }

        public void Limpiar()
        {
        }


        private void NotificarSeleccion()
        {
            if (Notificar != null)
            {
                EventHandler hnd = Notificar;
                hnd(this, null);
            }
        }
        private bool CargarData()
        {
            return true;
        }
    }
}