using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Visor.CostoEdad
{

    public class Gestion
    {

        private List<data> lista;
        private List<OOB.LibInventario.Departamento.Ficha> lDepart;
        private List<OOB.LibInventario.Deposito.Ficha> lDeposito;
        private List<OOB.LibInventario.Visor.CostoEdad.FichaDetalle> detalles;
        private DateTime fechaServidor;
        private BindingSource bs;
        private BindingSource bsDepart;
        private BindingSource bsDeposito;
        private string _idDeposito;
        private string _idDepartamento;


        public string Items { get { return bs.Count.ToString("n0"); } }
        public BindingSource Source { get { return bs; } }
        public BindingSource SourceDepartamento { get { return bsDepart; } }
        public BindingSource SourceDeposito { get { return bsDeposito; } }
        public int EdadFiltrar { get; set; }
        public string CadenaBuscar { get; set; }


        public Gestion()
        {
            _idDeposito = "";
            _idDepartamento = "";
            EdadFiltrar = 0;
            CadenaBuscar = "";
            lista = new List<data>();
            lDepart = new List<OOB.LibInventario.Departamento.Ficha>();
            lDeposito = new List<OOB.LibInventario.Deposito.Ficha>();
            bs = new BindingSource();
            bs.DataSource = lista;
            bsDepart = new BindingSource();
            bsDepart.DataSource = lDepart;
            bsDeposito = new BindingSource();
            bsDeposito.DataSource = lDeposito;
        }


        CostoEdadFrm frm;
        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                frm = new CostoEdadFrm();
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
            lDepart.AddRange(r02.Lista.OrderBy(o=>o.nombre).ToList());
            bsDepart.CurrencyManager.Refresh();

            return rt;
        }

        private void Limpiar()
        {
            _idDeposito = "";
            _idDepartamento = "";
            EdadFiltrar = 0;
            CadenaBuscar = "";
            lista.Clear();
            lDepart.Clear();
            lDeposito.Clear();
        }

        public void Buscar()
        {
            var filtro = new OOB.LibInventario.Visor.CostoEdad.Filtro();
            filtro.autoDepartamento = _idDepartamento;
            filtro.autoDeposito = _idDeposito;
            var r01 = Sistema.MyData.Visor_CostoEdad(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            detalles = r01.Entidad.detalles;
            fechaServidor = r01.Entidad.fechaServidor;

            lista.Clear();
            bs.DataSource = null;
            foreach (var rg in r01.Entidad.detalles.ToList())
            {
                lista.Add(new data(rg, r01.Entidad.fechaServidor));
            }

            if (CadenaBuscar.Trim()!="")
                lista = lista.Where(w => w.NombrePrd.Contains(CadenaBuscar)).ToList();
            if (EdadFiltrar>0)
                lista = lista.Where(w => w.CostoEdad > EdadFiltrar).ToList();
            lista = lista.OrderByDescending(o=>o.CostoEdad).ToList();

            bs.DataSource = lista;
            bs.CurrencyManager.Refresh();
            CadenaBuscar = "";
        }

        public void OrdenaPorDeposito()
        {
            bs.DataSource = null;
            lista = lista.OrderBy(o => o.Deposito).ToList();
            bs.DataSource = lista;
            bs.CurrencyManager.Refresh();
        }

        public void OrdenaPorNombre()
        {
            bs.DataSource = null;
            lista = lista.OrderBy(o => o.NombrePrd).ToList();
            bs.DataSource = lista;
            bs.CurrencyManager.Refresh();
        }

        public void OrdenaPorDepartamento()
        {
            bs.DataSource = null;
            lista = lista.OrderBy(o => o.Departamento).ToList();
            bs.DataSource = lista;
            bs.CurrencyManager.Refresh();
        }

        public void OrdenaPorExistencia()
        {
            bs.DataSource = null;
            lista = lista.OrderByDescending(o => o.ExFisica).ToList();
            bs.DataSource = lista;
            bs.CurrencyManager.Refresh();
        }

        public void OrdenaPorCostoEdad()
        {
            bs.DataSource = null;
            lista = lista.OrderByDescending(o => o.CostoEdad).ToList();
            bs.DataSource = lista;
            bs.CurrencyManager.Refresh();
        }

        public void setDeposito(string id)
        {
            _idDeposito = id;
        }

        public void setDepartamento(string id)
        {
            _idDepartamento = id;
        }
    }

}