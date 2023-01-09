using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Visor.Traslados
{

    public class GestionRep
    {

        public GestionRep()
        {
        }


        public void Imprimir(List<src.Visor.Traslado.data> lista, string filt)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Visor\Traslados.rdlc";
            var ds = new DSVisor();
            foreach (var it in lista)
            {
                DataRow rt = ds.Tables["Traslado"].NewRow();
                rt["producto"] = it.NombrePrd.Trim() + Environment.NewLine + it.CodigoPrd;
                rt["origen"] = it.DepositoOrigen;
                rt["destino"] = it.DepositoDestino;
                rt["documento"] = it.DocumentoNro;
                rt["horaFecha"] = it.FechaHora;
                rt["usuario"] = it.Usuario;
                rt["cant"] = it.Cnt;
                rt["nota"] = it.Nota;
                ds.Tables["Traslado"].Rows.Add(rt);
            }
            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("FILTROS", filt));
            Rds.Add(new ReportDataSource("Traslado", ds.Tables["Traslado"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }

}