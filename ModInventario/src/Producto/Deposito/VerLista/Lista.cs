using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Producto.Deposito.VerLista
{
    public class Lista: IListaDep
    {
        private List<data> _lista;
        private BindingSource _bs;


        public BindingSource GetSource { get { return _bs; } }
        public int GetCtnItems { get { return _bs.Count; } }
        public object ItemActual { get { return _bs.Current; } }
        public decimal GetExFisica { get { return _lista.Sum(s => s.ExFisica); } }
        public decimal GetExReserva { get { return _lista.Sum(s => s.ExReserva); } }
        public decimal GetExDisponible { get { return _lista.Sum(s => s.ExDisponible); } }
        public IEnumerable<object> GetListaItems { get { throw new NotImplementedException(); } }


        public Lista()
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
            foreach (var rg in _lst)
            {
                _lista.Add(rg);
            }
            _bs.DataSource = _lista;
            _bs.CurrencyManager.Refresh();
        }
        public void setContenido(int cont)
        {
            foreach (var it in _lista)
            {
                it.setContenido(cont);
            }
        }
    }
}