using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Visor.PrecioAjuste
{
    
    public class AjusteLista: IAjusteLista
    {

        private List<data> _lst;
        private BindingList<data> _bl;
        private BindingSource _bs;


        public BindingSource Source { get { return _bs; } }
        public int CntItem { get { return _bs.Count; } }
        public object ItemActual { get { return _bs.Current; } }


        public AjusteLista() 
        {
            _lst = new List<data>();
            _bl = new BindingList<data>();
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }


        public void Inicializa()
        {
            _bl.Clear();
            _bs.CurrencyManager.Refresh();
        }
        public void setData(IEnumerable<object> lst)
        {
            _bl.Clear();
            foreach(data rg in lst)
            {
                _bl.Add(rg);
            }
        }

        public void setFiltrar(string id)
        {
            var _lst = _bl.ToList();
            switch (id)
            { 
                case "01":
                    _lst = _bl.Where(w => w.pneto_divisa_emp_1 <= 0m).ToList();
                    break;
                case "02":
                    _lst = _bl.Where(w => w.pneto_divisa_emp_2 <= 0m).ToList();
                    break;
                case "03":
                    _lst = _bl.Where(w => w.pneto_divisa_emp_3 <= 0m).ToList();
                    break;
            }
            _bl.Clear();
            foreach (var rg in _lst)
            {
                _bl.Add(rg);
            }
            _bs.CurrencyManager.Refresh();
        }

        public void EliminarItem(string idAuto)
        {
            var it = _bl.FirstOrDefault(f => f.idPrd == idAuto);
            if (it != null)
            {
                _bl.Remove(it);
            }
            _bs.CurrencyManager.Refresh();
        }

    }

}