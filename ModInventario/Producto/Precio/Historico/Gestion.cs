using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Precio.Historico
{
    
    public class Gestion
    {


        private string autoPrd;
        private List<data> list;
        private data item;
        private BindingSource bs;
        private OOB.LibInventario.Precio.Historico.Ficha _ficha;


        public BindingSource Source { get { return bs; } }
        public data Item { get { return item; } }
        public string Producto { get; set; }
        public string Nota 
        { 
            get 
            {
                var rt = "";
                if (item != null)
                {
                    rt = item.nota;
                }
                return rt;
            } 
        }


        public Gestion()
        {
            _ficha = null;
            autoPrd = "";
            Producto = "";
            list = new List<data>();
            bs = new BindingSource();
            bs.CurrentChanged+=bs_CurrentChanged;
            bs.DataSource = list;
        }

        private void bs_CurrentChanged(object sender, EventArgs e)
        {
            var it = (data)bs.Current;
            if (it != null) 
            {
                if (frm != null) 
                {
                    item = it;
                    frm.ActualizarItem();
                }
            }
        }


        public void setFicha(string autoprd)
        {
            this.autoPrd = autoprd;
        }

        HistoricoPrecioFrm frm;
        public void Inicia()
        {
            Limpiar();
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new HistoricoPrecioFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private void Limpiar()
        {
            list.Clear();
        }

        private bool CargarData()
        {
            var rt = true;

            var filtro = new OOB.LibInventario.Precio.Historico.Filtro()
            {
                autoProducto = autoPrd,
            };
            var r01 = Sistema.MyData.HistoricoPrecio_GetLista(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _ficha = r01.Entidad;

            Producto = r01.Entidad.codigo + Environment.NewLine + r01.Entidad.descripcion;
            foreach (var it in r01.Entidad.data.OrderByDescending(o => o.fecha).ThenByDescending(o => o.hora).ToList()) 
            {
                var nr = new data(it);
                list.Add(nr);
            }
            bs.CurrencyManager.Refresh();

            return rt;
        }

        public void Imprimir()
        {
            ImprimirLista();
        }

        private void ImprimirLista()
        {
            if (list.Count > 0)
            {
                var rp = new Reportes.HistoricoPrecio.gestionRep();
                rp.setLista(_ficha.data);
                rp.setFiltros(_ficha.descripcion.Trim() + "(" + _ficha.codigo.Trim() + ")");
                rp.Generar();
            }
        }

    }

}