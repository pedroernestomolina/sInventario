using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Producto.CodigosAlterno
{
    
    public class Gestion: IAlterno
    {

        private List<data> _lst;
        private BindingList<data> _bl;
        private BindingSource _bs;
        private string _codigoAgregar;


        public BindingSource GetSource { get { return _bs; } }
        public data Item { get { return (data)_bs.Current; } }
        public IEnumerable<data> CodigosExportar { get { return _lst; } }


        public Gestion()
        {
            _codigoAgregar = "";
            _lst = new List<data>();
            _bl = new BindingList<data>(_lst);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }

        public void setCodigoAgregar(string d)
        {
            _codigoAgregar = d;
        }
        public void Eliminar()
        {
            if (Item != null)
            {
                _bl.Remove(Item);
                _bs.CurrencyManager.Refresh();
            }
        }
        public void Agregar()
        {
            var cod = _codigoAgregar.Trim().ToUpper();
            if (cod != "")
            {
                var ent = _bl.FirstOrDefault(f => f.codigo == _codigoAgregar);
                if (ent == null)
                {
                    _bl.Add(new data(_codigoAgregar));
                    _bs.CurrencyManager.Refresh();
                }
            }
        }
        public void CargarData(List<string> lst)
        {
            _bl.Clear();
            foreach (var rg in lst)
            {
                _bl.Add(new data(rg));
            }
            _bs.CurrencyManager.Refresh();
        }


        public void Limpiar()
        {
            _bl.Clear();
            _bs.CurrencyManager.Refresh();
        }


        public void Inicializa()
        {
            _codigoAgregar = "";
            _bl.Clear();
            _bs.DataSource = _bl;
        }
        public void Inicia()
        {
        }

    }

}