using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Producto.ActualizarOfertaMasiva.Items
{
    public class ImpItems: IItems
    {
        private List<data> _lst;
        private BindingList<data> _bl;
        private BindingSource _bs;


        public int GetCnt { get { return _bs.Count; } }
        public BindingSource GetSource { get { return _bs; } }
        public IEnumerable<data> GetLista { get { return _bl.ToList(); } }


        public ImpItems()
        {
            _lst = new List<data>();
            _bl = new BindingList<data>(_lst);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }


        public void setData(List<data> lst)
        {
            _bl.Clear();
            foreach (var rg in lst)
            {
                _bl.Add(rg);
            }
        }

        public void Inicializa()
        {
            _bl.Clear();
        }
        public void LimpiarTodo()
        {
            _bl.Clear();
        }
    }
}