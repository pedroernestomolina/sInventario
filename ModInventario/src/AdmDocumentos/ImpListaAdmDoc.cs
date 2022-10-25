using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.AdmDocumentos
{
    
    public class ImpListaAdmDoc: IListaAdmDoc
    {

        private List<data> _list;
        private BindingSource _bs;
        private BindingList<data> _bl;


        public BindingSource GetSource { get { return _bs; } }
        public int GetCtnItems { get { return _bs.Count; } }
        public object ItemActual { get { return _bs.Current; } }
        public IEnumerable<object> GetListaItems { get { return _bl.ToList(); } }


        public ImpListaAdmDoc()
        {
            _list = new List<data>();
            _bl= new BindingList<data>();
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }


        public void Inicializa()
        {
            _bl.Clear();
        }
        public void setLista(List<OOB.LibInventario.Movimiento.Lista.Ficha> lst)
        {
            _bl.Clear();
            foreach (var rg in lst)
            {
                var dt = new data(rg);
                _bl.Add(dt);
            }
        }
        public void Limpiar()
        {
            _bl.Clear();
        }
        public void setEstatusAnulado(string idDoc)
        {
            var it = _bl.FirstOrDefault(f => f.Id == idDoc);
            if (it != null) 
            {
                it.setEstatusAnulado();
            }
            _bs.CurrencyManager.Refresh();
        }

    }

}