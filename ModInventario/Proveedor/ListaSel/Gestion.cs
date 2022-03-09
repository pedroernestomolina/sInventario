using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Proveedor.ListaSel
{

    public class Gestion: ModInventario.Buscar.IListaSeleccion
    {

        private List<fichaSeleccion> _lst;
        private BindingSource _bs;
        private fichaSeleccion _itemSeleccionado;
        private bool _cerrarVentanaIsOk;
        private bool _setCerrarVentanaAlSeleccionarItem;


        public fichaSeleccion ItemSeleccionado { get { return _itemSeleccionado; } }
        public bool ItemSeleccionadoIsOk { get { return ItemSeleccionado == null ? false : true; } }
        public int CntItem { get { return _bs.Count; } }
        public BindingSource SourceData { get { return _bs; } }
        public bool CerrarVentanaIsOk { get { return _cerrarVentanaIsOk; } }


        public Gestion() 
        {
            _lst = new List<fichaSeleccion>();
            _bs = new BindingSource();
            _bs.DataSource = _lst;
            _itemSeleccionado = null;
            _cerrarVentanaIsOk = false;
            _setCerrarVentanaAlSeleccionarItem = true;
        }


        public void Inicializa()
        {
            limpiar();
        }

        private void limpiar()
        {
            _lst.Clear();
            _bs.DataSource = _lst;
            _itemSeleccionado = null;
            _cerrarVentanaIsOk = false;
            _setCerrarVentanaAlSeleccionarItem = true;
        }

        public void setLista(List<fichaSeleccion> list)
        {
            _lst = list;
            _bs.DataSource = _lst;
        }

        ListaSelFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null)
                {
                    frm = new ListaSelFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return true;
        }

        public void SeleccionarItem()
        {
            if (_bs.Current != null)
            {
                _itemSeleccionado = (fichaSeleccion)_bs.Current;
                if (_setCerrarVentanaAlSeleccionarItem)
                {
                    _cerrarVentanaIsOk = true;
                }
            }
        }

        public void setPermitirSeleccionarInactivos(bool op)
        {
        }

        public void setCerrarVentanaAlSeleccionarItem(bool op)
        {
            _setCerrarVentanaAlSeleccionarItem = op;
        }

    }

}