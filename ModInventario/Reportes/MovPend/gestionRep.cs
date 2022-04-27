using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.MovPend
{
    
    public class gestionRep
    {

        private List<AdmMovPend.dataItem> _lst;
        private string _filtros;
        private string p;


        public gestionRep(IEnumerable <object> lst, string filtros)
        {
            _lst = (List<ModInventario.AdmMovPend.dataItem>)lst;
            _filtros = filtros;
        }


        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\MovPend\MovPend.rdlc";
            var ds = new DS_MOVPEND();

            foreach (var it in _lst.ToList())
            {
                DataRow rt = ds.Tables["Movimiento"].NewRow();
                rt["fecha"] = it.fecha;
                rt["tipoDoc"] = it.tipoDoc;
                rt["origen"] = it.origen ;
                rt["destino"] = it.destino;
                rt["cntRenglones"] = it.cntRenglones ;
                rt["montoDivisa"] = it.montoDivisa ;
                rt["usuario"] = it.usuarioEstacion ;
                ds.Tables["Movimiento"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("Filtros", _filtros));
            Rds.Add(new ReportDataSource("Movimiento", ds.Tables["Movimiento"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}