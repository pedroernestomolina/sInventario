using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Sucursal.Lista
{

    public class ListaSuc: IListaSuc 
    {

        private List<data> _lst;
        private BindingList<data> _bl;
        private BindingSource _bs;


        public BindingSource Source { get { return _bs; } }
        public object ItemActual { get { return _bs.Current; } }
        public int CntItem { get { return _bs.Count; } }
 

        public ListaSuc() 
        {
            _lst = new List<data>();
            _bl = new BindingList<data>();
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }


        void IGestion.Inicializa()
        {
        }
        void Gestion.ILista.Inicializa()
        {
            _bl.Clear();
            _bs.CurrencyManager.Refresh();
        }


        ListaFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null)
                {
                    frm = new ListaFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return true;
        }
        
        public void setData(IEnumerable<object> lst)       
        {
            _bl.Clear();
            foreach (data rg in lst)
            {
                _bl.Add(rg);
            }
            _bs.CurrencyManager.Refresh();
        }

    }

}