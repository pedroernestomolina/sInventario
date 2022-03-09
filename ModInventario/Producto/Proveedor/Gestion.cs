using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Proveedor
{
    
    public class Gestion
    {


        private string autoPrd;
        private BindingSource bs;
        private List<data> lista;


        public  string Producto { get; set; }
        public BindingSource Source { get { return bs; } }
        public string Items { get { return string.Format("Proveedores Encontrados: {0}", bs.Count); } }
        public data Item { get; set; }


        public Gestion()
        {
            autoPrd = "";
            lista = new List<data>();
            bs = new BindingSource();
            bs.CurrentChanged+=bs_CurrentChanged;
            bs.DataSource = lista;
        }

        private void bs_CurrentChanged(object sender, EventArgs e)
        {
            if (bs.Current != null) 
            {
                Item = (data)bs.Current;
                if (frm!=null)
                    frm.setActualizarItem();
            }
        }


        ProveedoresFrm frm;
        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                frm = new ProveedoresFrm();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Producto_GetProveedores(autoPrd);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            Producto = r01.Entidad.codigoProducto + Environment.NewLine + r01.Entidad.nombreProducto;
            lista.Clear();
            foreach (var rg in r01.Entidad.proveedores) 
            {
                lista.Add(new data(rg));
            }
            bs.CurrencyManager.Refresh();

            return rt;
        }

        private void Limpiar()
        {
            if (Item!=null)
                Item.Limpiar();
        }

        public void setFicha(string auto)
        {
            autoPrd = auto;
        }

    }

}