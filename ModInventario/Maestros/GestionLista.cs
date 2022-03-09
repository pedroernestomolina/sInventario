using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Maestros
{
    
    public class GestionLista: IGestionLista
    {

        private List<data> lLista;
        private BindingList<data> blLista;
        private BindingSource bsLista;


        public BindingSource Source { get { return bsLista; } }
        public object ItemActual { get { return bsLista.Current; } }


        public GestionLista()
        {
            lLista = new List<data>();
            blLista = new BindingList<data>(lLista);
            bsLista = new BindingSource();
            bsLista.DataSource = blLista;
        }


        public int TotalItems
        {
            get { return blLista.Count; }
        }

        public void setLista(List<data> list)
        {
        }

        public void setLista(List<OOB.LibInventario.Concepto.Ficha> list)
        {
            blLista.Clear();
            foreach(var it in list.OrderBy(o=>o.nombre).ToList()) 
            {
                blLista.Add(new data(it));
            }
            bsLista.CurrencyManager.Refresh();
        }

        public void Agregar(OOB.LibInventario.Concepto.Ficha ficha)
        {
            blLista.Add(new data(ficha));
            ActualizarLista();
        }

        public void ActualizarItem(OOB.LibInventario.Concepto.Ficha ficha)
        {
            var it = blLista.FirstOrDefault(f => f.id == ficha.auto);
            if (it != null)
                blLista.Remove(it);
            Agregar(ficha);
        }

        public void setLista(List<OOB.LibInventario.Departamento.Ficha> list)
        {
            blLista.Clear();
            foreach (var it in list.OrderBy(o => o.nombre).ToList())
            {
                blLista.Add(new data(it));
            }
            bsLista.CurrencyManager.Refresh();
        }

        public void Agregar(OOB.LibInventario.Departamento.Ficha ficha)
        {
            blLista.Add(new data(ficha));
            ActualizarLista();
        }

        public void ActualizarItem(OOB.LibInventario.Departamento.Ficha ficha)
        {
            var it = blLista.FirstOrDefault(f => f.id == ficha.auto);
            if (it != null)
                blLista.Remove(it);
            Agregar(ficha);
        }

        public void setLista(List<OOB.LibInventario.Grupo.Ficha> list)
        {
            blLista.Clear();
            foreach (var it in list.OrderBy(o => o.nombre).ToList())
            {
                blLista.Add(new data(it));
            }
            bsLista.CurrencyManager.Refresh();
        }

        public void ActualizarItem(OOB.LibInventario.Grupo.Ficha ficha)
        {
            var it = blLista.FirstOrDefault(f => f.id == ficha.auto);
            if (it != null)
                blLista.Remove(it);
            Agregar(ficha);
        }

        public void Agregar(OOB.LibInventario.Grupo.Ficha ficha)
        {
            blLista.Add(new data(ficha));
            ActualizarLista();
        }
        
        public void setLista(List<OOB.LibInventario.Marca.Ficha> list)
        {
            blLista.Clear();
            foreach (var it in list.OrderBy(o => o.nombre).ToList())
            {
                blLista.Add(new data(it));
            }
            bsLista.CurrencyManager.Refresh();
        }

        public void ActualizarItem(OOB.LibInventario.Marca.Ficha ficha)
        {
            var it = blLista.FirstOrDefault(f => f.id == ficha.auto);
            if (it != null)
                blLista.Remove(it);
            Agregar(ficha);
        }

        public void Agregar(OOB.LibInventario.Marca.Ficha ficha)
        {
            blLista.Add(new data(ficha));
            ActualizarLista();
        }

        public void setLista(List<OOB.LibInventario.EmpaqueMedida.Ficha> list)
        {
            blLista.Clear();
            foreach (var it in list.OrderBy(o => o.nombre).ToList())
            {
                blLista.Add(new data(it));
            }
            bsLista.CurrencyManager.Refresh();
        }

        public void ActualizarItem(OOB.LibInventario.EmpaqueMedida.Ficha ficha)
        {
            var it = blLista.FirstOrDefault(f => f.id == ficha.auto);
            if (it != null)
                blLista.Remove(it);
            Agregar(ficha);
        }

        public void Agregar(OOB.LibInventario.EmpaqueMedida.Ficha ficha)
        {
            blLista.Add(new data(ficha));
            ActualizarLista();
        }

        public void ActualizarLista()
        {
            var l = blLista.OrderBy(o => o.descripcion).ToList();
            blLista.Clear();
            foreach (var r in l)
            {
                blLista.Add(r);
            }
            bsLista.CurrencyManager.Refresh();
        }

        public void EliminarItem(data itActual)
        {
            blLista.Remove(itActual);
            ActualizarLista();
        }

    }

}