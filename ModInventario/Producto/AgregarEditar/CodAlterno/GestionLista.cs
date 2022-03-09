using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.AgregarEditar.CodAlterno
{
    
    public class GestionLista
    {


        private List<data> lista;
        private BindingList<data> bl;
        private BindingSource bs;


        public BindingSource Source { get { return bs; } }
        public List<data> ListaCodigos { get { return lista; } }


        public GestionLista()
        {
            lista = new List<data>();
            bl = new BindingList<data>(lista);
            bs = new BindingSource();
            bs.DataSource = bl;
        }


        public void Agregar(string CodigoAlterno)
        {
            var cod = CodigoAlterno.Trim().ToUpper();
            if (cod != "") 
            {
                var ent = bl.FirstOrDefault(f => f.codigo == cod);
                if (ent==null)
                {
                    bl.Add(new data(cod));
                    bs.CurrencyManager.Refresh();
                }
            }
        }

        public void Eliminar()
        {
            if (bs.Current != null) 
            {
                var it = (data)bs.Current;
                bl.Remove(it);
                bs.CurrencyManager.Refresh();
            }
        }

        public void Limpiar()
        {
            bl.Clear();
            bs.CurrencyManager.Refresh();
        }

    }

}