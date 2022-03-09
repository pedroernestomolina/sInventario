using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Visor.Existencia
{

    public class GestionRep
    {

        public GestionRep()
        {
        }


        public void Imprimir(List<ModInventario.Visor.Existencia.data> lista, string filt)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Visor\Existencia.rdlc";
            var ds = new DSVisor();

            foreach (var it in lista.Where(f=>f.IsActivo).ToList())
            {
                DataRow rt = ds.Tables["Existencia"].NewRow();
                rt["nombre"] = it.NombrePrd.Trim() + Environment.NewLine + it.CodigoPrd;
                rt["deposito"] = it.Deposito ;
                rt["departamento"] = it.Departamento ;
                rt["exReal"] = it.CntFisica;
                rt["nivelMinimo"] = it.NivelMinimo;
                rt["nivelMaximo"] = it.NivelOptimo;
                rt["reponer"] = it.Reponer;
                ds.Tables["Existencia"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("FILTROS", filt));
            Rds.Add(new ReportDataSource("Existencia", ds.Tables["Existencia"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}