using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Utils.Filtros.BuscarPor.ListaSelecciona.PorProducto
{
    public class ImpLista: ILista
    {
        private List<Idata> _lst;
        private BindingSource _bs;
        private bool _itemSeleccionadoIsOk;
        private Idata _itemSeleccionado;


        public BindingSource GetSource{	get { return _bs; }}
        public int CntItem { get { return _bs.Count; } }
        public bool ItemSeleccionadoIsOk { get { return _itemSeleccionadoIsOk; } }
        public Idata ItemSeleccionado { get { return _itemSeleccionado; } }


        public ImpLista() 
        {
            _lst = new List<Idata>();
            _bs = new BindingSource();
            _bs.DataSource = _lst;
            _itemSeleccionado = null;
            _itemSeleccionadoIsOk=false;
        }


        public void Inicializa()
        {
            limpiar();
        }
        Frm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null)
                {
                    frm = new Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public void setDataListar(IEnumerable<Idata> lst)
        {
            _lst.Clear();
            _lst.AddRange(lst);
            _bs.DataSource = _lst;
            _bs.CurrencyManager.Refresh();
        }
        public void SeleccionarItem()
        {
            _itemSeleccionadoIsOk = false;
            if (_bs.Current != null)
            {
                var it = (Idata)_bs.Current;
                try
                {
                    var r01 = Sistema.MyData.Producto_Estatus_GetFicha(it.id);
                    if (r01.Entidad.estatus == OOB.LibInventario.Producto.Enumerados.EnumEstatus.Inactivo)
                    {
                        throw new Exception("ESTATUS DEL ITEM INACTIVO");
                    }
                    _itemSeleccionado = it;
                    _itemSeleccionadoIsOk = true;
                }
                catch (Exception e)
                {
                    Helpers.Msg.Alerta(e.Message);
                    return;
                }
            }
        }
        public void LimpiarItem()
        {
            _itemSeleccionadoIsOk = false;
            _itemSeleccionado = null;
        }


        private bool CargarData()
        {
            return true;
        }
        private void limpiar()
        {
            _lst.Clear();
            _bs.DataSource = _lst;
            _itemSeleccionado = null;
            _itemSeleccionadoIsOk = false;
        }
    }
}