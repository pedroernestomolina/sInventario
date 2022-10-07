using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Filtros.Kardex
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
            var filtro = new OOB.LibInventario.Reportes.Kardex.Filtro();
            if (dataFiltros.Deposito != null)
            {
                filtro.autoDeposito = dataFiltros.Deposito.id;
            }
            if (dataFiltros.Desde.HasValue )
            {
                filtro.desde = dataFiltros.Desde.Value;
            }
            if (dataFiltros.Hasta.HasValue)
            {
                filtro.hasta = dataFiltros.Hasta.Value;
            }
            if (dataFiltros.Producto !=null)
            {
                filtro.autoProducto = dataFiltros.Producto.id;
            }
            try
            {
                var r01 = Sistema.MyData.Reportes_Kardex(filtro);
                Imprimir(r01.Entidad, dataFiltros.ToString());
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }


        public void Imprimir(OOB.LibInventario.Reportes.Kardex.Ficha ficha, string filt)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Filtros\Kardex.rdlc";
            var ds = new DS();

            var grupos = ficha.movimientos.GroupBy(g => g.nombrePrd).OrderBy(o=>o.Key).ToList();
            foreach (var g in grupos)
            {
                var autoPrd = ficha.movimientos.FirstOrDefault(f => f.nombrePrd == g.Key).autoPrd;
                var saldo = ficha.exInicial.FirstOrDefault(f => f.autoPrd == autoPrd).exInicial;

                //var saldo = 0.0m;
                //saldo = ficha.movimientos.FirstOrDefault(f => f.nombrePrd == g.Key).existenciaInicial;
                //foreach (var it in lista.Where(w => w.nombrePrd == g.Key).OrderBy(o=>o.moduloMov).ThenBy(o=>o.fechaMov).ToList())
                foreach (var it in ficha.movimientos.Where(w => w.nombrePrd == g.Key).OrderBy(o => o.fechaMov).ThenBy(o=>o.ordenPrioridad).ToList())
                {
                    DataRow rt = ds.Tables["Kardex"].NewRow();
                    rt["nombre"] = it.nombrePrd.Trim()+Environment.NewLine+it.codigoPrd;
                    rt["fechaHora"] = it.fechaMov.ToShortDateString() + ", " + it.horaMov;
                    rt["modulo"] = it.moduloMov;
                    rt["siglas"] = it.siglasMov;
                    rt["documento"] = it.documentoNro;
                    rt["deposito"] = it.deposito;
                    rt["concepto"] = it.concepto;
                    rt["cantidadUnd"] = it.cantidadUnd;
                    rt["entidadMov"] = it.entidadMov;
                    rt["saldoIni"] = saldo;

                    if (it.signoMov == -1)
                    {
                        saldo -= it.cantidadUnd;
                        rt["entrada"] = 0.0m;
                        rt["salida"] = it.cantidadUnd;
                        rt["saldo"] = saldo;
                    }
                    else 
                    {
                        saldo += it.cantidadUnd;
                        rt["entrada"] = it.cantidadUnd ;
                        rt["salida"] = 0.0m;
                        rt["saldo"] = saldo;
                    }
                    ds.Tables["Kardex"].Rows.Add(rt);
                }
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("FILTROS", filt));
            Rds.Add(new ReportDataSource("Kardex", ds.Tables["Kardex"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}