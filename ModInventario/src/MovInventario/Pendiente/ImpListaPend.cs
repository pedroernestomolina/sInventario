using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Pendiente
{
    public class ImpListaPend: IListaPend
    {
        private List<dataDoc> _lst;
        private BindingSource _bs;


        public BindingSource GetSource { get { return _bs; } }
        public int GetCtnItems { get { return _bs.Count; } }
        public object ItemActual { get { return _bs.Current; } }
        public IEnumerable<object> GetListaItems { get { return _lst.ToList(); } }


        public ImpListaPend() 
        {
            _lst = new List<dataDoc>();
            _bs = new BindingSource();
            _bs.DataSource = _lst;
            _bs.CurrencyManager.Refresh();
        }

        public void Inicializa()
        {
            _lst.Clear();
            _bs.CurrencyManager.Refresh();
        }
        public void Limpiar()
        {
        }


        public void setData(List<OOB.LibInventario.Transito.Movimiento.Entidad.Mov> list)
        {
            _lst.Clear();
            foreach (var rg in list.OrderBy(o => o.id).ToList())
            {
                var nr = new dataDoc()
                {
                    id = rg.id,
                    fecha = rg.fecha,
                    renglones = rg.cntRenglones,
                    monto = rg.monto,
                    montoDivisa = rg.montoDivisa,
                    Origen = rg.descSucOrigen + ", " + rg.descDepOrigen,
                    Destino = rg.descSucDestino + ", " + rg.descDepDestino,
                };
                _lst.Add(nr);
            }
            _bs.CurrencyManager.Refresh();
        }
    }
}