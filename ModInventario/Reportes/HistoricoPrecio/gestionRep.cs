using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.HistoricoPrecio
{
    
    public class gestionRep
    {

        private List<Producto.Precio.Historico.dataHist> _lst;
        private string _filtros;


        public gestionRep()
        {
            _filtros = "";
        }


        public void setLista(List<Producto.Precio.Historico.dataHist> lst)
        {
            _lst = lst;
        }
        public void setFiltros(string p)
        {
            _filtros = p;
        }

        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\HistoricoPrecio\HistoricoPrecio.rdlc";
            var ds = new DS_Precio();

            foreach (var it in _lst)
            {
                DataRow rt = ds.Tables["PrecioHist"].NewRow();
                rt["precio"] = it.precioLocalNeto;
                rt["precioDivisa"] = it.precioDivisaNeto;
                rt["factorCambio"] = it.factorCambio;
                rt["empContenido"] = it.empContenido;
                rt["fechaHora"] = it.fechaHora;
                rt["usuarioEstacion"] = it.usuarioEstacion;
                rt["nota"] = it.nota;
                rt["idPrecio"] = it.idPrecio;
                ds.Tables["PrecioHist"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("FILTROS", _filtros));
            Rds.Add(new ReportDataSource("PrecioHist", ds.Tables["PrecioHist"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}