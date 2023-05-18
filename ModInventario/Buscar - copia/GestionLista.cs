using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace ModInventario.Buscar
{

    public class GestionLista
    {

        public event EventHandler CambioItemActual;


        private List<OOB.LibInventario.Producto.Data.Ficha> lLista;
        private BindingList<OOB.LibInventario.Producto.Data.Ficha> blLista;
        private BindingSource bsLista;
        private OOB.LibInventario.Producto.Data.Ficha _item;


        public BindingSource Source { get { return bsLista; } }
        public int Items { get { return bsLista.Count; } }
        public OOB.LibInventario.Producto.Data.Ficha Item { get { return _item; } }


        public GestionLista()
        {
            lLista = new List<OOB.LibInventario.Producto.Data.Ficha>();
            blLista = new BindingList<OOB.LibInventario.Producto.Data.Ficha>(lLista);
            bsLista = new BindingSource();
            bsLista.CurrentChanged +=bsLista_CurrentChanged;
            bsLista.DataSource = blLista;
        }

        private void bsLista_CurrentChanged(object sender, EventArgs e)
        {
            _item = (OOB.LibInventario.Producto.Data.Ficha)  bsLista.Current;
            if (_item != null) 
            {
                EventHandler hnd = CambioItemActual;
                if (hnd != null)
                {
                    hnd(this, null);
                }
            }
        }

        public void setLista(List<OOB.LibInventario.Producto.Data.Ficha> list)
        {
            blLista.Clear();
            blLista.RaiseListChangedEvents = false;
            foreach (var it in list.OrderBy(o=>o.identidad.descripcion).ToList())
            {
                blLista.Add(it);
            }
            blLista.RaiseListChangedEvents = true;
            blLista.ResetBindings();
            bsLista.CurrencyManager.Refresh();
        }

        public OOB.LibInventario.Producto.Data.Ficha SeleccionarItem()
        {
            var it= (OOB.LibInventario.Producto.Data.Ficha) bsLista.Current;
            return it;
        }

        public void Limpiar()
        {
            blLista.Clear();
            bsLista.CurrencyManager.Refresh();
        }

        public void Reemplazar(List<OOB.LibInventario.Producto.Data.Ficha> lista)
        {
            foreach (var it in lista) 
            {
                var t = blLista.First(f => f.identidad.auto == it.identidad.auto);
                if (t != null) 
                {
                    blLista.Remove(t);
                    blLista.Add(it);
                }
            }
            ActualizarLista();
        }

        public void Agregar(List<OOB.LibInventario.Producto.Data.Ficha> list)
        {
            foreach (var it in list)
            {
                blLista.Add(it);
            }
            ActualizarLista();
        }

        private void ActualizarLista()
        {
            var l = blLista.OrderBy(o => o.identidad.descripcion).ToList();
            blLista.Clear();
            foreach (var it in l)
            {
                blLista.Add(it);
            }
            bsLista.CurrencyManager.Refresh();
        }

        public void ListaPosicion(string auto)
        {
            var it = blLista.FirstOrDefault(f => f.identidad.auto == auto);
            if (it != null) 
            {
                bsLista.Position = blLista.IndexOf(it);
            }
            bsLista.CurrencyManager.Refresh();
        }

    }

}