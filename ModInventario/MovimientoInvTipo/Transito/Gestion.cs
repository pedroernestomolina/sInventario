using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModInventario.MovimientoInvTipo.Transito;


namespace ModInventario.MovimientoInvTipo.Transito
{

    public class Gestion: ITransito
    {


        private List<data> _lst;
        private BindingSource _bs;
        private data _itemSeleccionado;
        private bool _permitirSeleccionarInactivos;
        private bool _cerrarVentanaIsOk;
        private bool _setCerrarVentanaAlSeleccionarItem;
        private bool _setActivarNotificacion;


        public event EventHandler NotificarSeleccion;
        data ITransito.ItemSeleccionado { get { return _itemSeleccionado; } }
        public bool ItemSeleccionadoIsOk { get { return _itemSeleccionado == null ? false : true; } }
        public int CntItem { get { return _bs.Count; } }
        public BindingSource SourceData { get { return _bs; } }
        public bool CerrarVentanaIsOk { get { return _cerrarVentanaIsOk; } } 


        public Gestion() 
        {
            _lst = new List<data>();
            _bs = new BindingSource();
            _bs.DataSource = _lst;
            _itemSeleccionado = null;
            _cerrarVentanaIsOk = false;
            _setActivarNotificacion = false;
            _setCerrarVentanaAlSeleccionarItem=true;
        }


        public void Inicializa()
        {
            limpiar();
        }

        private void limpiar()
        {
            _setCerrarVentanaAlSeleccionarItem=true; 
            _setActivarNotificacion = false;
            _cerrarVentanaIsOk = false;
            _permitirSeleccionarInactivos = true;
            _lst.Clear();
            _bs.DataSource = _lst;
            _itemSeleccionado = null;
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
                var it = (data)_bs.Current;
                _itemSeleccionado = (data)_bs.Current;
                if (_setCerrarVentanaAlSeleccionarItem) 
                {
                    _cerrarVentanaIsOk = true;
                }
                if (_setActivarNotificacion) 
                {
                    EventHandler hnd = NotificarSeleccion;
                    hnd(this, null);
                }
            }
        }

        public void setPermitirSeleccionarInactivos(bool op)
        {
            _permitirSeleccionarInactivos = op;
        }
        public void setActivarNotificacion(bool valor)
        {
            _setActivarNotificacion = valor;
        }
        public void setCerrarVentanaAlSeleccionarItem(bool op)
        {
            _setCerrarVentanaAlSeleccionarItem = op;
        }
        public void setLista(List<data> list) 
        {
            _lst = list;
            _bs.DataSource = _lst;
        }

        public void Limpiar()
        {
            _lst.Clear();
            _bs.DataSource = _lst;
            _itemSeleccionado = null;
        }
        public void CargarDoc(int idMovPend)
        {
            var r01 = Sistema.MyData.Transito_Movimiento_GetById(idMovPend);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            var rg = r01.Entidad.mov;
            var nr = new data()
            {
                id = rg.id,
                fecha = rg.fecha,
                renglones = rg.cntRenglones,
                monto = rg.monto,
                montoDivisa = rg.montoDivisa,
                Origen = rg.descSucOrigen + ", " + rg.descDepOrigen,
                Destino = rg.descSucDestino + ", " + rg.descDepDestino,
            };
            _itemSeleccionado = nr;
        }

    }

}