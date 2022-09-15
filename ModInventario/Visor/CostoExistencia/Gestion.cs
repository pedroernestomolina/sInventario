using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Visor.CostoExistencia
{
    
    public class Gestion
    {

        private List<data> lista;
        private List<OOB.LibInventario.Departamento.Ficha> lDepart;
        private List<OOB.LibInventario.Deposito.Ficha> lDeposito;
        private BindingSource bs;
        private BindingSource bsDepart;
        private BindingSource bsDeposito;


        public string Items { get { return bs.Count.ToString("n0"); } }
        public BindingSource Source { get { return bs; } }
        public BindingSource SourceDeposito { get { return bsDeposito; } }
        public BindingSource SourceDepartamento { get { return bsDepart; } }
        public OOB.LibInventario.Visor.Existencia.Enumerados.enumFiltrarPor Filtrar { get; set; }
        public string Deposito { get; set; }
        public string Departamento { get; set; }
        public string ImporteLocal { get { return lista.Sum(s => s.ImporteLocal).ToString("n2"); } }
        public string ImporteDivisa { get { return lista.Sum(s => s.ImporteDivisa).ToString("n2"); } }
        public string CadenaBuscar { get; set; }


        public Gestion()
        {
            CadenaBuscar = "";
            Deposito = "";
            Departamento = "";
            Filtrar = OOB.LibInventario.Visor.Existencia.Enumerados.enumFiltrarPor.SinDefinir;
            lista = new List<data>();
            lDepart = new List<OOB.LibInventario.Departamento.Ficha>();
            lDeposito = new List<OOB.LibInventario.Deposito.Ficha>();
            bs = new BindingSource();
            bs.DataSource = lista;
            bsDeposito = new BindingSource();
            bsDeposito.DataSource = lDeposito;
            bsDepart = new BindingSource();
            bsDepart.DataSource = lDepart;
        }


        CostoExistenciaFrm frm;
        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                frm = new CostoExistenciaFrm();
                frm.setControlador(this);
                frm.Show();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            try
            {
                var r01 = Sistema.MyData.Deposito_GetLista();
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return false;
                }
                lDeposito.Clear();
                lDeposito.AddRange(r01.Lista.OrderBy(o => o.nombre).ToList());
                bsDeposito.CurrencyManager.Refresh();

                lDepart.Clear();
                var r02 = Sistema.MyData.Departamento_GetLista();
                lDepart.AddRange(r02.Lista);
                bsDepart.CurrencyManager.Refresh();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }

            return rt;
        }

        private void Limpiar()
        {
            Deposito = "";
            Departamento = "";
            Filtrar = OOB.LibInventario.Visor.Existencia.Enumerados.enumFiltrarPor.SinDefinir;
            lista.Clear();
            lDeposito.Clear();
            lDepart.Clear();
        }

        public void Buscar()
        {
            var filtro = new OOB.LibInventario.Visor.CostoExistencia.Filtro();
            filtro.autoDepartamento = Departamento;
            filtro.autoDeposito = Deposito;
            var r01 = Sistema.MyData.Visor_CostoExistencia(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            lista.Clear();
            bs.DataSource = null;
            foreach (var rg in r01.Lista.OrderBy(o => o.nombrePrd).ToList())
            {
                lista.Add(new data(rg));
            }

            if (CadenaBuscar != "") 
            {
                lista = lista.Where(w => w.NombrePrd.Contains(CadenaBuscar)).ToList();
            }

            bs.DataSource = lista;
            bs.CurrencyManager.Refresh();
        }

    }

}