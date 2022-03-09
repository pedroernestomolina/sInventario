using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.HistoricoCosto
{
    
    public class gestionRep
    {

        private List<data> _list;
        private string _filtros;


        public gestionRep()
        {
            _list = new List<data>();
            _filtros = "";
        }


        public void setLista(List<OOB.LibInventario.Costo.Historico.Data> lista)
        {
            _list = lista.OrderByDescending(o => o.fecha).ThenByDescending(o => o.hora).Select(s =>
            {
                return new data(s);
            }).ToList();
        }

        public void setFiltros(string p)
        {
            _filtros = p;
        }

        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\HistoricoCosto\HistoricoCosto.rdlc";
            var ds = new DS_COSTO();

            foreach (var it in _list)
            {
                DataRow rt = ds.Tables["HISTORICO"].NewRow();
                rt["serie"] = it.serie;
                rt["fechaHora"] = it.fechaHora;
                rt["usuarioEstacion"] = it.usuarioEstacion;
                rt["nota"] = it.nota;
                rt["costoNeto"] = it.costoNeto;
                rt["costoDivisa"] = it.costoDivisa;
                rt["divisa"] = it.divisa;
                ds.Tables["HISTORICO"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("FILTROS", _filtros));
            Rds.Add(new ReportDataSource("HISTORICO", ds.Tables["HISTORICO"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}