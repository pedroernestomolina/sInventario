using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MovimientoInvTipo
{
    
    public class Lista: ILista
    {

        private List<dataItem> _lista;
        private BindingList<dataItem> _bl;
        private BindingSource _bs;


        public BindingSource Source { get { return _bs; } }
        public int CntItem { get { return _bs.Count; } }
        public List<dataItem> Items { get { return _bl.ToList(); } }
        public decimal TotalImporte { get { return _bl.Sum(s => s.ImporteNacional); } }
        public dataItem ItemActual { get { return (dataItem)_bs.Current; } }


        public Lista() 
        {
            _lista = new List<dataItem>();
            _bl = new BindingList<dataItem>(_lista);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }


        public void Inicializa()
        {
            _bl.Clear();
            _bs.CurrencyManager.Refresh();
        }

        public void setItemAgregar(dataItem item)
        {
            var mx = 1;
            if (_bl.Count > 0)
                mx = _bl.Max(s => s.Id) + 1;
            item.Id = mx;
            _bl.Add(item);
        }
        public void setItemEliminar(int idItem)
        {
            var ent = _bl.FirstOrDefault(f => f.Id == idItem);
            if (ent != null)
            {
                _bl.Remove(ent);
            }
        }

        public void Limpiar()
        {
            _bl.Clear();
            _bs.CurrencyManager.Refresh();
        }

    }

}