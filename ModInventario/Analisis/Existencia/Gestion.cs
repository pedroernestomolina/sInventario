using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Analisis.Existencia
{
    
    public class Gestion
    {


        private string _autoDeposito;
        private List<data> _lst;
        private BindingSource _bs;
        private OOB.LibInventario.Deposito.Ficha _deposito;


        public BindingSource Source { get { return _bs; } }
        public string Deposito { get { return "Existencia Depósito: " + _deposito.nombre; } }


        public Gestion()
        {
            _lst = new List<data>();
            _bs = new BindingSource();
            _bs.DataSource = _lst;
            _bs.CurrencyManager.Refresh();
        }


        public void Inicializa()
        {
            _autoDeposito = "";
            _lst.Clear();
            _bs.CurrencyManager.Refresh();
        }

        public void setDeposito(string autoDep)
        {
            _autoDeposito = autoDep;
        }

        private ExistenciaFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null)
                {
                    frm = new ExistenciaFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Deposito_GetFicha(_autoDeposito);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _deposito = r01.Entidad;

            var filtro = new OOB.LibInventario.Analisis.Existencia.Filtro()
            {
                autoDeposito = _autoDeposito,
            };
            var r02 = Sistema.MyData.Producto_Analisis_Existencia(filtro);
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            _lst.Clear();
            foreach (var it in r02.Lista.OrderBy(o=>o.nombrePrd).ToList())
            {
                _lst.Add(new data(it));
            }
            _bs.CurrencyManager.Refresh();

            return rt;
        }

    }

}