using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Filtros.RelacionCompraVenta
{
    
    public class GestionRep
    {

        private FiltrosGen.Reportes.data dataFiltros;


        public GestionRep()
        {
        }


        public void setFiltros(FiltrosGen.Reportes.data data)
        {
            dataFiltros = data;
        }

        public void Generar()
        {
            var filtro = new OOB.LibInventario.Reportes.CompraVentaAlmacen.Filtro();
            if (dataFiltros.Producto!=null)
            {
                filtro.autoProducto = dataFiltros.Producto.id;
            }
            var r01 = Sistema.MyData.Reportes_CompraVentaAlmacen(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            Imprimir(r01.Entidad, dataFiltros.ToString());
        }

        public void Imprimir(OOB.LibInventario.Reportes.CompraVentaAlmacen.Ficha ficha, string filt)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Filtros\RelacionCompraVenta.rdlc";
            var ds = new DS();

            var diferencia = 0.0m;
            DataRow rt = ds.Tables["RelCompraVentaAlm"].NewRow();
            rt["producto"] = ficha.prdCodigo + Environment.NewLine + ficha.prdNombre;
            rt["exActual"] = ficha.exUnd;
            rt["empaque"] = ficha.empaque+"/"+ficha.contenido.ToString();
            rt["costoDivisaUnd"] = ficha.costoDivisaUnd;
            ds.Tables["RelCompraVentaAlm"].Rows.Add(rt);


            //COMPRAS
            var cUnd = 0.0m;
            foreach (var it in ficha.compras.ToList().OrderByDescending(o=>o.fecha).ToList())
            {
                DataRow xrt = ds.Tables["RelCompraVentaAlmDet"].NewRow();
                xrt["tipo"] = "COMPRA";
                xrt["documento"] = it.documento ;
                xrt["estatus"] = it.esAnulado?"ANULADO":"";
                xrt["fecha"] = it.fecha;
                xrt["cnt"] = it.cnt;
                xrt["empaque"] = it.empaque;
                xrt["contenido"] = it.contenido;
                xrt["costoPrecioDivisa"] = it.costoDivisaUnd;
                xrt["factor"] = it.factor;
                xrt["tipoDoc"] = it.tipoDoc;
                if (!it.esAnulado)
                {
                    cUnd += (it.cntUnd*it.signoDoc);
                    xrt["cntUnd"] = it.cntUnd*it.signoDoc;
                    xrt["montoDivisa"] = it.costoDivisaUnd * it.cntUnd * it.signoDoc;
                }
                else
                {
                    xrt["cntUnd"] = 0;
                    xrt["montoDivisa"] = 0;
                }
                ds.Tables["RelCompraVentaAlmDet"].Rows.Add(xrt);
            }


            //VENTAS
            var mp = 0.0m;
            var vcnt = ficha.ventas.Sum(s => s.cnt);
            if (vcnt>0)
                mp=ficha.ventas.Sum(s => s.montoVentaDivisa) / vcnt ;
            DataRow xrt2 = ds.Tables["RelCompraVentaAlmDet"].NewRow();
            xrt2["tipo"] = "VENTA";
            xrt2["empaque"] = "UNIDAD";
            xrt2["contenido"] = 1;
            xrt2["cntUnd"] = vcnt ;
            xrt2["costoPrecioDivisa"] = mp;
            xrt2["montoDivisa"] = ficha.ventas.Sum(s=>s.montoVentaDivisa);
            ds.Tables["RelCompraVentaAlmDet"].Rows.Add(xrt2);


            var aUnd = 0.0m;
            //ALMACEN
            foreach (var it in ficha.almacen.ToList().OrderByDescending(o => o.fecha).ToList())
            {
                DataRow xrt = ds.Tables["RelCompraVentaAlmDet"].NewRow();
                xrt["tipo"] = "ALMACEN";
                xrt["documento"] = it.documento+Environment.NewLine+it.nombreDoc;
                xrt["estatus"] = it.isAnulado ? "ANULADO" : "";
                xrt["fecha"] = it.fecha;
                xrt["cnt"] = it.cantUnd;
                xrt["empaque"] = "UNIDAD";
                xrt["contenido"] = 1;
                if (!it.isAnulado) 
                {
                    xrt["cntUnd"] = it.cantUnd * it.signo;
                    aUnd += (it.cantUnd * it.signo);
                }
                ds.Tables["RelCompraVentaAlmDet"].Rows.Add(xrt);
            }
            diferencia = ficha.exUnd - (cUnd + aUnd - vcnt);


            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("DIFERENCIA", diferencia.ToString("n2")));
            Rds.Add(new ReportDataSource("RelCompraVentaAlm", ds.Tables["RelCompraVentaAlm"]));
            Rds.Add(new ReportDataSource("RelCompraVentaAlmDet", ds.Tables["RelCompraVentaAlmDet"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}