using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Graficas
{
    
    public class Gestion
    {


        private data dataFiltro;
        private List<OOB.LibInventario.Deposito.Ficha> lDeposito;
        private BindingSource bsDeposito;
        private List<OOB.LibInventario.Reportes.Top20.Ficha> lTop20;
        private OOB.LibInventario.Deposito.Ficha deposito;
        private string reportTitulo;


        public BindingSource SourceDeposito { get { return bsDeposito; } }


        public DateTime Desde { get { return dataFiltro.Desde; } set { dataFiltro.Desde = value; } }
        public DateTime Hasta { get { return dataFiltro.Hasta; } set { dataFiltro.Hasta = value; } }
        public string AutoDeposito { get { return dataFiltro.AutoDeposito; } set { dataFiltro.AutoDeposito = value; } }
        public string Modulo { get { return dataFiltro.Modulo; } set { dataFiltro.Modulo = value; } }


        public Gestion()
        {
            lTop20 = new List<OOB.LibInventario.Reportes.Top20.Ficha>();
            dataFiltro=new data ();
            lDeposito = new List<OOB.LibInventario.Deposito.Ficha>();
            bsDeposito = new BindingSource();
            bsDeposito.DataSource = lDeposito;
            deposito = null;
            reportTitulo = "";
        }


        GraficaFrm frm;
        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                frm = new GraficaFrm();
                frm.setControlador(this);
                frm.Show();
            }
        }

        private bool CargarData()
        {
            try
            {
                lDeposito.Clear();
                var r01 = Sistema.MyData.Deposito_GetLista();
                lDeposito.AddRange(r01.Lista.OrderBy(o => o.nombre));

                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }

        private void Limpiar()
        {
            deposito = null;
            lTop20.Clear();
            dataFiltro.Limpiar();
        }

        public void LimpiarFiltros()
        {
            dataFiltro.Limpiar();
        }

        public class DataGrafico 
        {
            public string Producto { get; set; }
            public decimal Cnt { get; set; }
        }

        public class DataVista
        {
            public string Producto { get; set; }
            public string CntUnd { get; set; }
            public int CntDoc { get; set; }
        }


        public void Buscar()
        {
            if (dataFiltro.IsOk) 
            {
                var titulo = "";
                var filtro = new OOB.LibInventario.Reportes.Top20.Filtro();
                filtro.Desde =dataFiltro.Desde ;
                filtro.Hasta = dataFiltro.Hasta ;
                filtro.autoDeposito = dataFiltro.AutoDeposito;
                if (dataFiltro.Modulo.Trim().ToUpper() == "ENTRADA")
                {
                    titulo = "TOP PRODUCTOS CON MAYOR ENTRADA: COMPRAS"; 
                    filtro.Modulo = OOB.LibInventario.Reportes.enumerados.EnumModulo.Compras;
                }
                if (dataFiltro.Modulo.Trim().ToUpper() == "SALIDA")
                {
                    titulo = "TOP PRODUCTOS CON MAYOR SALIDA: VENTAS"; 
                    filtro.Modulo = OOB.LibInventario.Reportes.enumerados.EnumModulo.Ventas;
                }
                if (dataFiltro.Modulo.Trim().ToUpper() == "AJUSTE")
                {
                    titulo = "TOP PRODUCTOS CON MAYOR AJUSTE: INVENTARIO";
                    filtro.Modulo = OOB.LibInventario.Reportes.enumerados.EnumModulo.Inventario;
                }

                reportTitulo = titulo;
                deposito = lDeposito.FirstOrDefault(f => f.auto == dataFiltro.AutoDeposito);
                var r01 = Sistema.MyData.Reportes_Top20(filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                lTop20 = r01.Lista;

                var dg = new List<DataGrafico>();
                foreach (var rg in r01.Lista.OrderByDescending(o => o.cntUnd).Take(20).ToList()) 
                {
                    var nr = new DataGrafico() { Cnt = rg.cntUnd, Producto = rg.nombre };
                    dg.Add(nr);
                }

                var dv = new List<DataVista>();
                foreach (var rg in r01.Lista.OrderByDescending(o => o.cntUnd).ToList())
                {
                    var nr = new DataVista () { CntUnd = rg.cntUnd.ToString("n"+rg.decimales), Producto = rg.nombre , CntDoc=(int)rg.cntDoc};
                    dv.Add(nr);
                }

                frm.SetGrafica(dg, dv, titulo);
            }

            //datosSeries = new List<sSeries>();
            //foreach (var nr in r01.Lista.OrderByDescending(d => d.cntUnd).Take(20).ToList())
            //{
            //    var reg = new sSeries()
            //    {
            //        producto = nr.nombre,
            //        Serie1 = nr.cntUnd,
            //    };
            //    datosSeries.Add(reg);
            //}

            //datosGV = new List<sSeries>();
            //foreach (var nr in r01.Lista.OrderByDescending(d => d.cntUnd).ToList())
            //{
            //    var reg = new sSeries()
            //    {
            //        producto = nr.nombre,
            //        SCnt = nr.cntUnd.ToString("n" + nr.decimales),
            //    };
            //    datosGV.Add(reg);
            //}
        }

        public void ImprimirResultados()
        {
            if (lTop20 != null)
            {
                if (lTop20.Count > 0)
                {
                    var rp = new Reportes.Graficas.Top20.GestionRep();
                    var dep = "N/A";
                    if (deposito != null)
                        dep = deposito.nombre;
                    rp.Imprimir(lTop20, dataFiltro.Desde.Date, dataFiltro.Hasta.Date,dep, reportTitulo);
                }
            }
        }

    }

}