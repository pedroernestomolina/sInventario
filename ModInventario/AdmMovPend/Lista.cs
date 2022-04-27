using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.AdmMovPend
{
    
    public class Lista: IListaAdmMovPend 
    {

        private List<dataItem> _lst;
        private BindingList<dataItem> _bl;
        private BindingSource _bs;


        public int CntItems { get { return _bs.Count; } }
        public BindingSource Source { get { return _bs; } }
        public IEnumerable<object> Items { get { return _bl.ToList(); } }
        public object ItemActual { get { return _bs.Current;  } }


        public Lista() 
        {
            _lst = new List<dataItem>();
            _bl = new BindingList<dataItem>(_lst);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }


        public void Inicializa()
        {
            _bl.Clear();
            _bs.CurrencyManager.Refresh();
        }


        public void ActAgreagatItem(object item)
        {
        }
        public void ActEliminarItem(object idMov)
        {
            if (idMov != null)
            {
                var it = _bl.FirstOrDefault(f => f.id == (int)idMov);
                if (it != null)
                {
                    _bl.Remove(it);
                    _bs.CurrencyManager.Refresh();
                }
            }
        }
        public void ActActualizarItem(object itemActual, object itemNuevo)
        {
        }
        public void ActLimpiarLista()
        {
            _bl.Clear();
            _bs.CurrencyManager.Refresh();
        }
        public void ActAgregarListaItem(IEnumerable<object> lst)
        {
            _bl.Clear();
            foreach (dataItem rg in lst)
            {
                var nr = new dataItem(rg);
                _bl.Add(nr);
            }
            _bs.CurrencyManager.Refresh();
        }

    }

}