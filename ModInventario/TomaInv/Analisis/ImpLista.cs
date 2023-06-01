using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.TomaInv.Analisis
{
    public class ImpLista: ILista
    {
        private List<data> _lst;
        private BindingList<data> _bl;
        private BindingSource _bs;


        public BindingSource GetDataSource { get { return _bs; } }
        public List<data> GetLista { get { return _bl.ToList(); } }


        public ImpLista()
        {
            _lst = new List<data>();
            _bl = new BindingList<data>(_lst);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
            _bs.CurrencyManager.Refresh();
        }


        public void Inicializa()
        {
            _bl.Clear();
            _bs.CurrencyManager.Refresh();
        }

        public void setDataListar(List<data> lst)
        {
            _lst.Clear();
            _lst.AddRange(lst);
            _bs.CurrencyManager.Refresh();
        }
        public void setEliminarItems(IEnumerable<data> lst)
        {
            foreach (var rg in lst)
            {
                rg.setConteoNull();
            }
            _bs.CurrencyManager.Refresh();
        }
        public void setMarcarTodas(bool m)
        {
            foreach (var rg in _lst)
            {
                rg.Marcar(m);
                _bs.CurrencyManager.Refresh();
            }
        }
    }
}