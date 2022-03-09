using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Analisis.Detallado
{

    public enum EnumModulo { SinDefinir = -1, Ventas = 1, Compras, Inventario }


    public class Gestion
    {


        private string _autoDeposito;
        private string _autoProducto;
        private int _ultDias;
        private EnumModulo _modulo;
        private OOB.LibInventario.Deposito.Ficha _deposito;
        private OOB.LibInventario.Producto.Data.Identificacion _producto;
        private BindingSource _bs;
        private List<data> _lstData;


        public BindingSource SourceData { get { return _bs; } }
        public string Filtros { get { return "ANALISIS VENTA DETALLADO ULTIMOS " + _ultDias.ToString()+"DIAS"+Environment.NewLine+"Deposito: "+_deposito.nombre; } }
        public string Producto { get { return _producto.codigo + Environment.NewLine + _producto.descripcion; } }
        public string VentasTotales { get { return _lstData.Sum(s=>s.ficha.cntUnd).ToString("n0"); } }
        public string VentasPromedio { get { return _lstData.Average(s => s.ficha.cntUnd).ToString("n2"); } }


        public Gestion()
        {
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

        public void setProducto(string p)
        {
            _autoProducto= p;
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

            var filtro = new OOB.LibInventario.Analisis.Detallado.Filtro()
            {
                autoDeposito = _autoDeposito,
                autoProducto=_autoProducto,
                modulo =   (OOB.LibInventario.Analisis.Enumerados.EnumModulo) _modulo,
                ultimosXDias = _ultDias,
            };
            var r01 = Sistema.MyData.Producto_Analisis_Detallado(filtro);
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
            var r03 = Sistema.MyData.Producto_GetIdentificacion(_autoProducto);
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            _deposito = r02.Entidad;
            _producto = r03.Entidad;

            _lstData.Clear();
            foreach (var rg in r01.Lista.OrderByDescending(o=>o.fecha).ToList()) 
            {
                _lstData.Add(new data(rg));
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
            _producto = null;
            _deposito = null;
            _ultDias = 0;
            _autoDeposito = "";
            _autoProducto = "";
            _modulo = EnumModulo.SinDefinir;
            _lstData.Clear();
            _bs.CurrencyManager.Refresh();
        }

    }

}