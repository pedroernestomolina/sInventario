using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Plu
{

    public class Gestion
    {


        private List<data> ldata;
        private BindingSource bs;


        public BindingSource Source { get { return bs; } }
        public string ItemsEncontrados { get { return string.Format("Items Encontrados {0}", bs.Count); } }


        public Gestion()
        {
            ldata = new List<data>();
            bs = new BindingSource();
            bs.DataSource = ldata;
        }

        
        PluFrm frm;
        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new PluFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Producto_Plu_Lista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            ldata.Clear();
            foreach (var reg in r01.Lista.OrderBy(o=>o.plu).ToList())
            {
                ldata.Add(new data(reg));
            }
            bs.CurrencyManager.Refresh();

            return rt;
        }

        private void Limpiar()
        {
        }

    }

}