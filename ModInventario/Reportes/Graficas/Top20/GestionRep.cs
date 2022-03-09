using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Graficas.Top20
{
    
    public class GestionRep
    {


        public GestionRep()
        {
        }


        public void Imprimir(List<OOB.LibInventario.Reportes.Top20.Ficha> lTop20, DateTime _desde, DateTime _hasta, string deposito,string titulo)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Graficas\Top20.rdlc";
            var ds = new DS();

            foreach (var it in lTop20.OrderByDescending(o => o.cntUnd).ToList())
            {
                DataRow rt = ds.Tables["Top20"].NewRow();
                rt["nombrePrd"] = it.nombre;
                rt["codigoPrd"] = it.codigo;
                rt["cntUnd"] = it.cntUnd.ToString("n"+it.decimales);
                rt["cntDoc"] = it.cntDoc.ToString("n0");
                ds.Tables["Top20"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("Desde", _desde.ToShortDateString()));
            pmt.Add(new ReportParameter("Hasta", _hasta.ToShortDateString()));
            pmt.Add(new ReportParameter("Deposito", deposito));
            pmt.Add(new ReportParameter("Reporte", titulo));
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            Rds.Add(new ReportDataSource("Top20", ds.Tables["Top20"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}