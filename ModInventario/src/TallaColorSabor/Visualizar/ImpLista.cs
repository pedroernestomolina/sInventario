using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.TallaColorSabor.Visualizar
{
    public class ImpLista: ITCSLista
    {
        private List<data> _lista;
        private BindingSource _bs;


        public BindingSource GetSource { get { return _bs; } }
        public int GetCtnItems { get { return _bs.Count; } }
        public decimal GetCntTotal { get { return _lista.Sum(s => s.Fisica); } }
        public IEnumerable<object> GetListaItems { get { return null; } }
        public object ItemActual { get { return _bs.Current; } }


        public ImpLista()
        {
            _lista = new List<data>();
            _bs = new BindingSource();
            _bs.DataSource = _lista;
            _bs.CurrencyManager.Refresh();
        }


        public void Inicializa()
        {
            _lista.Clear();
            _bs.DataSource = _lista;
            _bs.CurrencyManager.Refresh();
        }
        public void Limpiar()
        {
        }

        public void setLista(List<data> _lst)
        {
            _lista.Clear();
            foreach (var nr in _lst)
            {
                _lista.Add(nr);
            }
            _bs.CurrencyManager.Refresh();
        }
    }
}