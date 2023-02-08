using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Analisis.General
{


    public enum EnumModulo { SinDefinir = -1, Ventas = 1, Compras, Inventario }

    
    public class Gestion
    {

        public event EventHandler ItemSeleccionado;


        private string _autoDeposito;
        private int _ultDias;
        private EnumModulo _modulo;
        private OOB.LibInventario.Deposito.Ficha _deposito;
        private BindingSource _bs;
        private List<data> _lstData;
        private Analisis.Detallado.Gestion _gestionAnalisisDetallado;
        //private Producto.Deposito.Listar.Gestion _gestionExistencia;
        private Analisis.Existencia.Gestion _gestionAnalisisExistencia;
        private data _item;


        public BindingSource SourceData { get { return _bs; } }
        public string Filtros { get { return "ANALISIS VENTAS ULTIMOS " + _ultDias.ToString()+" Días"+Environment.NewLine+"Deposito: "+_deposito.nombre; } }
        public data Item { get { return _item; } }


        public Gestion()
        {
            _gestionAnalisisDetallado = new Detallado.Gestion();
            _gestionAnalisisExistencia = new Existencia.Gestion();
            //_gestionExistencia = new Producto.Deposito.Listar.Gestion();
            _lstData = new List<data>();
            _bs = new BindingSource();
            _bs.DataSource = _lstData;
            Limpiar();
        }


        public void setDeposito(string p)
        {
            _autoDeposito = p;
        }

        public void setUltimosXDias(int p)
        {
            _ultDias = p;
        }

        public void setModulo(EnumModulo modulo)
        {
            _modulo = modulo;
        }

        private AnalisisFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null)
                {
                    frm = new AnalisisFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var filtro = new OOB.LibInventario.Analisis.General.Filtro()
            {
                autoDeposito = _autoDeposito,
                modulo =   (OOB.LibInventario.Analisis.Enumerados.EnumModulo) _modulo,
                ultimosXDias = _ultDias,
            };
            var r01 = Sistema.MyData.Producto_Analisis_General(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            var r02 = Sistema.MyData.Deposito_GetFicha(_autoDeposito);
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            _deposito = r02.Entidad;

            _lstData.Clear();
            foreach (var rg in r01.Lista.OrderByDescending(o=>o.cntUnd).ToList()) 
            {
                _lstData.Add(new data(rg, _ultDias));
            }
            _bs.CurrencyManager.Refresh();

            return rt;
        }

        public void Inicializar()
        {
            Limpiar();
        }

        private void Limpiar()
        {
            _ultDias = 0;
            _autoDeposito = "";
            _modulo = EnumModulo.SinDefinir;
            _lstData.Clear();
            _bs.CurrencyManager.Refresh();
            _item = null;
        }

        public void VerExistencia()
        {
            //if (_bs.Current == null)
            //    return;

            //var it = (data)_bs.Current;
            //_gestionExistencia.setFicha(it.autoId);
            //_gestionExistencia.Inicia();
        }

        public void VerComportamientoDiario()
        {
            if (_bs.Current == null)
                return;

            var it = (data)_bs.Current;
            _gestionAnalisisDetallado.Inicializar();
            _gestionAnalisisDetallado.setDeposito(_deposito.auto);
            _gestionAnalisisDetallado.setProducto(it.autoId);
            _gestionAnalisisDetallado.setUltimosXDias(15);
            _gestionAnalisisDetallado.setModulo(Analisis.Detallado.EnumModulo.Ventas);
            _gestionAnalisisDetallado.Inicia();
        }

        public void SeleccionarItem()
        {
            if (_bs.Current == null)
                return;
            _item = (data)_bs.Current;

            EventHandler hnd = ItemSeleccionado;
            if (hnd != null)
            {
                hnd(this, null);
            }
        }

        public void ListaExistencia()
        {
            _gestionAnalisisExistencia.Inicializa();
            _gestionAnalisisExistencia.setDeposito(_autoDeposito);
            _gestionAnalisisExistencia.Inicia();
        }

    }

}