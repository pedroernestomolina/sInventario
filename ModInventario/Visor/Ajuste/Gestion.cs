using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Visor.Ajuste
{
    
    public class Gestion
    {

        private List<data> lista;
        private BindingSource bs;
        private decimal ventasNeta;


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
                    if (bs.Current != null)
                        rt = ((data)bs.Current).Nota;
                return rt;
            }
        }
        public decimal Total 
        {
            get
            {
                var rt = 0.0m;
                if (lista != null)
                    if (lista.Count > 0)
                        rt = lista.Sum(s => s.Monto* s.Signo);
                return rt;
            } 
        }
        public decimal Tasa 
        {
            get 
            {
                var rt = 0.0m;
                if (ventasNeta>0)
                    rt = Total / ventasNeta * 100;
                return rt;
            }
        }



        public Gestion()
        {
            lista = new List<data>();
            bs = new BindingSource();
            bs.CurrentChanged += bs_CurrentChanged;
            bs.DataSource = lista;
            MesFiltrar = DateTime.Now.Month;
            AnoFiltrar = DateTime.Now.Year;
        }

        private void bs_CurrentChanged(object sender, EventArgs e)
        {
            if (frm != null)
                frm.SetActualizarNota();
        }


        AjusteFrm frm;
        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                frm = new AjusteFrm();
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
            var filtro = new OOB.LibInventario.Visor.Ajuste.Filtro();
            filtro.ano = AnoFiltrar;
            filtro.mes = MesFiltrar;
            var r01 = Sistema.MyData.Visor_Ajuste (filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            ventasNeta = r01.Entidad.montoVentaNeto;

            lista.Clear();
            foreach (var rg in r01.Entidad.detalles.OrderBy(o => o.fecha).ThenBy(o => o.documentoNro).ThenBy(o => o.nombrePrd).ToList())
            {
                lista.Add(new data(rg));
            }
            bs.CurrencyManager.Refresh();
        }

    }

}