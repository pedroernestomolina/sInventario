using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Visor.Existencia
{
    
    public class Gestion
    {

        private List<data> lista;
        private List<OOB.LibInventario.Departamento.Ficha> lDepart;
        private List<OOB.LibInventario.Deposito.Ficha> lDeposito;
        private BindingSource bs;
        private BindingSource bsDepart;
        private BindingSource bsDeposito;
        private Reportes.Visor.Existencia.GestionRep _gestionRep;
        private string _filtros;


        public string Items { get { return bs.Count.ToString("n0"); } }
        public BindingSource Source { get { return bs; } }
        public BindingSource SourceDeposito { get { return bsDeposito; } }
        public BindingSource SourceDepartamento { get { return bsDepart; } }
        public OOB.LibInventario.Visor.Existencia.Enumerados.enumFiltrarPor Filtrar { get; set; }
        public string Deposito { get; set; }
        public string Departamento { get; set; }


        public Gestion()
        {
            _filtros = "";
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
            _gestionRep = new Reportes.Visor.Existencia.GestionRep();
        }


        ExistenciaFrm frm;
        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                frm = new ExistenciaFrm();
                frm.setControlador(this);
                frm.Show();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Deposito_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            var r02 = Sistema.MyData.Departamento_GetLista();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }

            lDeposito.Clear();
            lDeposito.AddRange(r01.Lista.OrderBy(o=>o.nombre).ToList());
            bsDeposito.CurrencyManager.Refresh();

            lDepart.Clear();
            lDepart.AddRange(r02.Lista);
            bsDepart.CurrencyManager.Refresh();

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
            if (Filtrar == OOB.LibInventario.Visor.Existencia.Enumerados.enumFiltrarPor.SinDefinir) { return; }

            var filtro = new OOB.LibInventario.Visor.Existencia.Filtro();
            filtro.autoDepartamento = Departamento;
            filtro.autoDeposito = Deposito;
            filtro.filtrarPor = Filtrar ;

            _filtros = "";
            _filtros += Filtrar.ToString();
            if (Departamento.Trim()!="")
            {
                var ent = lDepart.FirstOrDefault(f=>f.auto==Departamento);
                if (ent !=null)
                {
                    _filtros += ", Departamento: " + ent.nombre;
                }
            }
            if (Deposito.Trim() != "")
            {
                var ent = lDeposito.FirstOrDefault(f => f.auto == Deposito);
                if (ent != null)
                {
                    _filtros += ", Deposito: " + ent.nombre;
                }
            }

            var r01 = Sistema.MyData.Visor_Existencia(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            lista.Clear();
            foreach (var rg in r01.Lista.OrderBy(o=>o.nombrePrd).ToList()) 
            {
                lista.Add(new data(rg,Filtrar));
            }
            bs.CurrencyManager.Refresh();
        }

        public void Imprimir()
        {
            Buscar();
            _gestionRep.Imprimir(lista, _filtros);
        }

    }

}