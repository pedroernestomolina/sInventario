using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Tools.ListaMov
{
    public class ImpListaMov: IListaMov
    {
        private List<Tools.CapturaMov.IDataCaptura> _lista;
        private BindingList<Tools.CapturaMov.IDataCaptura> _bl;
        private BindingSource _bs;


        public decimal GetImporte_MonedaLocal { get { return _bl.Sum(s => s.ImporteNetoMonedaLocal); } }
        public decimal GetImporte_MonedaOtra { get { return _bl.Sum(s => s.ImporteNetoDivisa); } }
        public BindingSource GetSource { get { return _bs; } }
        public int GetCtnItems { get { return _bs.Count; } }
        public IEnumerable<object> GetListaItems { get { return (IEnumerable<object>)_bl.ToList(); } }
        object ILista.ItemActual { get { return _bs.Current; } }
        //
        public List<MovInventario.dataItem> GetItems { get { return _lista.Select(s => s.GetItem).ToList(); } }


        public ImpListaMov() 
        {
            _lista = new List<Tools.CapturaMov.IDataCaptura>();
            _bl = new BindingList<Tools.CapturaMov.IDataCaptura>(_lista);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }


        public void Inicializa()
        {
            _bl.Clear();
            _bs.CurrencyManager.Refresh();
        }

        public void Limpiar()
        {
            _bl.Clear();
            _bs.CurrencyManager.Refresh();
        }


        public bool VerificaItemRegistradoLista(string idPrd)
        {
            var item = _bl.FirstOrDefault(f => f.AutoPrd == idPrd);
            return (item != null);
        }
        public void AgregarItem(CapturaMov.IDataCaptura data)
        {
            var mx = 1;
            if (_bl.Count > 0)
            {
                mx = _bl.Max(s => s.Id) + 1;
            }
            data.Id = mx;
            _bl.Add(data);
        }
        public void EliminarItem(int id)
        {
            var item = _bl.FirstOrDefault(f => f.Id == id);
            _bl.Remove(item);
            _bs.CurrencyManager.Refresh();
        }
        public void EliminarItemsDondeExistenciaEnDepOrigenSeaCero()
        {
            var _lst = _bl.Where(f => f.Cantidad > 0).ToList();
            _bl.Clear();
            foreach (var rg in _lst)
            {
                _bl.Add(rg);
            }
            _bs.CurrencyManager.Refresh();
        }
    }
}