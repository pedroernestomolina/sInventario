using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Visor.Traslado
{
    
    public class Gestion
    {

        private List<data> lista;
        private BindingSource bs;


        public string Items { get { return bs.Count.ToString("n0"); } }
        public BindingSource Source { get { return bs; } }
        public int MesFiltrar { get; set; }
        public int AnoFiltrar { get; set; }
        public string NotaMovimiento
        { 
            get 
            {
                var rt = "";
                if (bs != null) 
                    if (bs.Current!=null)
                        rt=((data)bs.Current).Nota;
                return rt;
            }
        }


        public Gestion()
        {
            lista = new List<data>();
            bs = new BindingSource();
            bs.CurrentChanged +=bs_CurrentChanged;
            bs.DataSource = lista;
            MesFiltrar = DateTime.Now.Month;
            AnoFiltrar = DateTime.Now.Year;
        }

        private void bs_CurrentChanged(object sender, EventArgs e)
        {
            if (frm!=null)
                frm.SetActualizarNota();
        }


        TrasladoFrm frm;
        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                frm = new TrasladoFrm();
                frm.setControlador(this);
                frm.Show();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            return rt;
        }

        private void Limpiar()
        {
            MesFiltrar = DateTime.Now.Month;
            AnoFiltrar = DateTime.Now.Year;
            lista.Clear();
        }

        public void Buscar()
        {
            var filtro = new OOB.LibInventario.Visor.Traslado.Filtro();
            filtro.ano = AnoFiltrar;
            filtro.mes = MesFiltrar;
            var r01 = Sistema.MyData.Visor_Traslado(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            lista.Clear();
            foreach (var rg in r01.Lista.OrderByDescending(o => o.fecha).ThenBy(o=>o.documentoNro).ThenBy(o=>o.nombrePrd).ToList())
            {
                lista.Add(new data(rg));
            }
            bs.CurrencyManager.Refresh();
        }

    }

}