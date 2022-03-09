using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Kardex.Movimiento
{

    public class data
    {

        private BindingSource _bs;
        private List<detalle> _detalle;


        public BindingSource Source { get { return _bs; } }
        public decimal CntInv { get { return _detalle.Sum(s => s.CntInventario); } }


        public data()
        {
            _detalle = new List<detalle>();
            _bs = new BindingSource();
            _bs.DataSource = _detalle;
        }


        public void setFicha(List<OOB.LibInventario.Kardex.Movimiento.Resumen.Data> list)
        {
            _detalle.Clear();
            foreach (var reg in list) 
            {
                _detalle.Add(new detalle(reg));
            }
            _bs.CurrencyManager.Refresh();
        }

        public void Limpiar()
        {
            _detalle.Clear();
            _bs.CurrencyManager.Refresh();
        }

    }

}
