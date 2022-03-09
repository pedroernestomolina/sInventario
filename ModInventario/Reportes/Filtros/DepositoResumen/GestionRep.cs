using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Filtros.DepositoResumen
{
    
    public class GestionRep
    {


        public GestionRep()
        {
        }


        public void Generar()
        {
            var r01 = Sistema.MyData.Reportes_DepositoResumen();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var filt = "";
            Imprimir(r01.Lista, filt);
        }


        public void Imprimir(List<OOB.LibInventario.Reportes.DepositoResumen.Ficha> lst , string filt)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Filtros\DepositoResumen.rdlc";
            var ds = new DS();

            foreach (var it in lst.OrderBy(o=>o.nombreDeposito).ToList())
            {
                var venta = 0.0m;
                switch (it.precioId)
                {
                    case "1":
                        venta = it.pn1;
                        break;
                    case "2":
                        venta = it.pn2;
                        break;
                    case "3":
                        venta = it.pn3;
                        break;
                    case "4":
                        venta = it.pn4;
                        break;
                    case "5":
                        venta = it.pn5;
                        break;
                }
                DataRow xrt = ds.Tables["DepositoResumen"].NewRow();
                xrt["deposito"] = it.nombreDeposito;
                xrt["codigoSuc"] = it.codigoSuc;
                xrt["grupo"] = it.nombreGrupo;
                xrt["item"] = it.cItem;
                xrt["cntStock"] = it.cntStock;
                xrt["precioId"] = it.precioId;
                xrt["montoCosto"] = it.costo;
                xrt["montoVenta"] = venta;
                ds.Tables["DepositoResumen"].Rows.Add(xrt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            Rds.Add(new ReportDataSource("DepositoResumen", ds.Tables["DepositoResumen"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}