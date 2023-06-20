using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.TomaInv.AnalisisResultado
{
    public class gestionRep
    {
        private List<item> _list;
        private string _solicitudNro;
        private string _sucursal;
        private string _deposito;


        public gestionRep()
        {
            _solicitudNro = "";
            _sucursal = "";
            _deposito = "";
            _list = new List<item>();
        }

        public void setData(data ficha)
        {
            _solicitudNro = ficha.solicitudNro;
            _sucursal = ficha.sucursal;
            _deposito = ficha.deposito;
            _list.Clear();
            _list = ficha.items;
        }


        public void Generar() 
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\TomaInv\TomaResultado.rdlc";
            var ds = new DS_TOMA();

            foreach (var it in _list)
            {
                DataRow rt = ds.Tables["resultado"].NewRow();
                rt["producto"] = it.producto;
                rt["cantidad"] = it.cant;
                rt["descToma"] = it.descToma;
                rt["signo"] = it.signo;
                ds.Tables["resultado"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("SOLICITUD", _solicitudNro));
            pmt.Add(new ReportParameter("SUCURSAL",_sucursal ));
            pmt.Add(new ReportParameter("DEPOSITO", _deposito));
            //pmt.Add(new ReportParameter("EX_COMPRA", exCompra.ToString()));
            //pmt.Add(new ReportParameter("EX_INV", exInv.ToString()));
            //pmt.Add(new ReportParameter("EX_UND", exUnd.ToString()));
            Rds.Add(new ReportDataSource("resultado", ds.Tables["resultado"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}