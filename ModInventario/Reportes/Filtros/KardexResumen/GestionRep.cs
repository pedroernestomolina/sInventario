using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Filtros.KardexResumen
{
    public class GestionRep: src.Reporte.IReporte
    {
        private FiltrosGen.Reportes.IData dataFiltros;


        public GestionRep()
        {
        }


        public void setFiltros(FiltrosGen.Reportes.IData data)
        {
            dataFiltros = data;
        }


        public void Generar()
        {
            var filtro = new OOB.LibInventario.Reportes.Kardex.Filtro();
            if (dataFiltros.Deposito != null)
            {
                filtro.autoDeposito = dataFiltros.Deposito.id;
            }
            if (dataFiltros.Desde.HasValue)
            {
                filtro.desde = dataFiltros.Desde.Value;
            }
            if (dataFiltros.Hasta.HasValue)
            {
                filtro.hasta = dataFiltros.Hasta.Value;
            }
            if (dataFiltros.Producto!=null)
            {
                filtro.autoProducto = dataFiltros.Producto.id;
            }
            var r01 = Sistema.MyData.Reportes_KardexResumen(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            Imprimir(r01.Lista, dataFiltros.ToString());
        }

        public void Imprimir(List<OOB.LibInventario.Reportes.KardexResumen.Ficha> lista, string filt)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Filtros\KardexResumen.rdlc";
            var ds = new DS();

            var saldo = 0.0m;
            var ent=lista.FirstOrDefault();
            if (ent != null)
                saldo = ent.exInicial;

            foreach (var it in lista.Where(s=>s.cnt!=0).ToList())
            {
                DataRow rt = ds.Tables["KardexResumen"].NewRow();
                rt["concepto"] = it.concepto;
                rt["cnt"] = it.cnt;
                rt["saldoI"] = saldo;
                if (it.cnt >0)
                    rt["entrada"] = it.cnt;
                else
                    rt["salida"] = Math.Abs(it.cnt);
                saldo += it.cnt;
                rt["saldo"] = saldo;
                ds.Tables["KardexResumen"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("FILTROS", filt));
            Rds.Add(new ReportDataSource("KardexResumen", ds.Tables["KardexResumen"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}