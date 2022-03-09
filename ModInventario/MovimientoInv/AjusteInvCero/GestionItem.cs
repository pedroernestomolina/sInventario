using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MovimientoInv.AjusteInvCero
{

    public class GestionItem : IItem
    {

        private List<item> _lst;
        private BindingList<item> _bl;
        private BindingSource _bs;


        public BindingSource Source { get { return _bs; } }
        public int CntItem { get { return _bs.Count; } }
        public List<item> Items { get { return _bl.ToList(); } }
        public decimal TotalImporteMonedaLocal { get { return _bl.Sum(s => s.TotalImporteMonedaLocal); } }


        public GestionItem()
        {
            _lst = new List<item>();
            _bl = new BindingList<item>(_lst);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }


        public void Inicializa()
        {
            _bl.Clear();
        }


        public void setData(List<OOB.LibInventario.Movimiento.AjusteInvCero.Capture.Data> lst)
        {
            _bl.Clear();
            var i = 1;
            foreach (var rg in lst)
            {
                _bl.Add(new item(i, rg));
                i++;
            }
        }

        public void Limpiar()
        {
            _bl.Clear();
        }

    }

}