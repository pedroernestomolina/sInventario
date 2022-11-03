using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Kardex
{

    public class gestionRep
    {
        
        private string _filtros;
        private List<ModInventario.Kardex.Detalle.data> _lst;


        public gestionRep(List<ModInventario.Kardex.Detalle.data> lData, string filt)
        {
            _lst = lData;
            _filtros = filt;
        }


        public void Generar() 
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Kardex\Movimientos.rdlc";
            var ds = new DS_Kardex();

            foreach (var it in _lst.ToList())
            {
                DataRow rt = ds.Tables["Documento"].NewRow();
                rt["documentoNro"] = it.Documento;
                rt["fechaHora"] = it.FechaHora;
                rt["estatus"] = it.Estatus;
                rt["entidad"] = it.Entidad;
                rt["siglas"] = it.Siglas;
                rt["cnt"] = it.SCntInventario;
                ds.Tables["Documento"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("FILTROS", _filtros));
            Rds.Add(new ReportDataSource("Documento", ds.Tables["Documento"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}