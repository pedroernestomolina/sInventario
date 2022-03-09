using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Proveedor.Buscar.Lista
{
    
    public class Gestion
    {

        private List<data> lista;
        private BindingSource bs;


        public BindingSource Source { get { return bs; } }
        public string Items { get { return bs.Count.ToString(); } }
        public data ItemSeleccionado { get; set; }


        public Gestion()
        {
            lista = new List<data>();
            bs = new BindingSource();
            bs.DataSource = lista;
            ItemSeleccionado = null;
        }

        public void setLista(List<OOB.LibInventario.Proveedor.Lista.Ficha> list)
        {
            lista.Clear();
            foreach (var reg in list.OrderBy(o=>o.nombreRazonSocial).ToList()) 
            {
                lista.Add(new data(reg));
            }
            bs.CurrencyManager.Refresh();
        }

        public void SeleccionarItem()
        {
            var it = (data) bs.Current;
            if (it != null) 
            {
                ItemSeleccionado = it;
            }
        }

        public void Limpiar()
        {
            ItemSeleccionado = null;
            lista.Clear();
            bs.CurrencyManager.Refresh();
        }

    }

}