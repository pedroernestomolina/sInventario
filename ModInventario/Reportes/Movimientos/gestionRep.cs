using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Movimientos
{

    public class gestionRep
    {
        
        private List<data> _list;
        private string _filtros;


        public gestionRep(List<data> list, string xfiltros)
        {
            _list = list;
            _filtros = xfiltros;
        }


        public void Generar() 
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Movimientos\Movimientos.rdlc";
            var ds = new DS();

            foreach (var it in _list.ToList())
            {
                var anulado = "";
                if (it.isAnulado) 
                {
                    anulado = "A N U L A D O";
                }

                DataRow rt = ds.Tables["Documento"].NewRow();
                rt["documentoNro"] = it.documentoNro;
                rt["fechaHora"] = it.fechaHora;
                rt["sucursal"] = it.sucursal;
                rt["concepto"] = it.concepto;
                rt["usuarioEstacion"] = it.usuarioEstacion;
                rt["importe"] = it.importe;
                rt["situacion"] = it.situacion;
                rt["renglones"] = it.renglones;
                rt["nombreDocumento"] = it.nombreDocumento;
                rt["isAnulado"] = anulado;
                ds.Tables["Documento"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("Filtros", _filtros));
            Rds.Add(new ReportDataSource("Documento", ds.Tables["Documento"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}