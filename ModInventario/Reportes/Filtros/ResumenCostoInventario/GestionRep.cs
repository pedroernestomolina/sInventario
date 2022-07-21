using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Filtros.ResumenCostoInventario
{
    
    public class GestionRep
    {

        private FiltrosGen.Reportes.data dataFiltros;
        private List<data> _ldata;


        public GestionRep()
        {
            _ldata = new List<data>();
        }


        public void setFiltros(FiltrosGen.Reportes.data data)
        {
            dataFiltros = data;
        }

        public void Generar()
        {
            var filtro = new OOB.LibInventario.Reportes.ResumenCostoInv.Filtro();
            if (dataFiltros.Depart != null)
            {
                filtro.autoDepartamento = dataFiltros.Depart.id;
            }
            if (dataFiltros.Deposito != null)
            {
                filtro.autoDeposito = dataFiltros.Deposito.id;
            }
            if (dataFiltros.Grupo != null)
            {
                filtro.autoGrupo = dataFiltros.Grupo.id;
            }
            filtro.desde = dataFiltros.Desde.Value;
            filtro.hasta = dataFiltros.Hasta.Value;
            var r01 = Sistema.MyData.Reportes_ResumenCostoInventario(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            foreach (var rg in r01.Entidad.enInventario.OrderBy(o => o.nombrePrd).ToList())
            {
                var nr = new data()
                {
                    autoPrd = rg.autoPrd,
                    codigoPrd = rg.codigoPrd,
                    contEmpPrd = rg.contEmpPrd,
                    costoIniEmpDivisa = rg.costoIniEmpDivisa,
                    exIniUnd = rg.exIniUnd,
                    nombrePrd = rg.nombrePrd,
                };
                var _l=r01.Entidad.enMovInv.Where(w => w.auto == rg.autoPrd).ToList();
                nr.cntUndMovInv =_l.Sum(s => s.cntUnd);
                nr.costoMovInvDivisa = _l.Sum(s => s.factor > 0 ? s.costoTotal / s.factor : 0m);

                var _lc = r01.Entidad.enCompras.Where(w => w.auto == rg.autoPrd).ToList();
                nr.cntUndCompra = _lc.Sum(s => s.cntUnd);
                nr.costoCompraDivisa = _lc.Sum(s => s.factor > 0 ? s.costoTotal / s.factor : 0m);

                var _lv = r01.Entidad.enVentas.Where(w => w.auto == rg.autoPrd).ToList();
                nr.cntUndVenta = Math.Abs(_lv.Sum(s => s.cntUnd));
                nr.costoVentaDivisa = Math.Abs(_lv.Sum(s => s.costoDivisa));
                nr.ventaDivisa = Math.Abs(_lv.Sum(s => s.ventaDivisa));

                _ldata.Add(nr);
            }
            foreach (var rg in r01.Entidad.enMovInv.OrderBy(o => o.auto).ToList())
            {
                var dat = "";
                dat += rg.siglas + " " + rg.documento.Substring(4) + Environment.NewLine;
                var it = _ldata.FirstOrDefault(f => f.autoPrd == rg.auto);
                it.datRegMovInv += dat;
            }
            foreach (var rg in r01.Entidad.enCompras.OrderBy(o => o.auto).ToList())
            {
                var dat = "";
                dat += rg.siglas + Environment.NewLine + rg.documento + Environment.NewLine;
                var it = _ldata.FirstOrDefault(f => f.autoPrd == rg.auto);
                it.datRegComp += dat;
            }

            Imprimir(_ldata, dataFiltros.ToString());
        }

        public void Imprimir(List<data> lista, string filtro)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Filtros\ResumenCostoInv.rdlc";
            var ds = new DS();

            var _dif = 0m;
            foreach (var it in lista.ToList().OrderBy(o => o.nombrePrd).ToList())
            {
                if (it.exIniUnd == 0m  && it.cntUndMovInv==0m && it.cntUndCompra == 0m && it.cntUndVenta == 0m )
                    continue;

                var _costoIni= 0m;
                if (it.contEmpPrd > 0)
                    _costoIni = Math.Round(it.costoIniEmpDivisa / it.contEmpPrd, 2, MidpointRounding.AwayFromZero);
                var _costoUndCompra = 0m;
                if (it.cntUndCompra > 0)
                    _costoUndCompra = it.costoCompraDivisa / it.cntUndCompra;
                var _costoUndVenta = 0m;
                if (it.cntUndVenta > 0)
                    _costoUndVenta= it.costoVentaDivisa / it.cntUndVenta;
                var _costoUndMovInv = 0m;
                if (it.cntUndMovInv > 0)
                    _costoUndMovInv= it.costoMovInvDivisa / it.cntUndMovInv;

                DataRow rt = ds.Tables["ResumenCostoInv"].NewRow();
                rt["codigoPrd"] = it.codigoPrd;
                rt["nombrePrd"] = it.nombrePrd;
                rt["exInicial"] = it.exIniUnd;
                rt["costoInicial"] = _costoIni;
                rt["costoInicialTotal"] = Math.Round(_costoIni * it.exIniUnd, 2, MidpointRounding.AwayFromZero);

                //INVENTARIO: MOV
                rt["cntMovInv"] = it.cntUndMovInv;
                rt["datMovInv"] = it.datRegMovInv;
                rt["costoUndMovInv"] = _costoUndMovInv;
                rt["costoTotalMovInv"] = it.costoMovInvDivisa;

                // ENTRADAS: COMPRAS
                rt["cntEntrada"] = it.cntUndCompra;
                rt["costoUndEntrada"] = _costoUndCompra;
                rt["costoTotalEntrada"] = it.costoCompraDivisa ;
                rt["datComp"] = it.datRegComp;

                //SALIDAS: VENTAS
                rt["cntSalida"] = it.cntUndVenta;
                rt["costoUndSalida"] = _costoUndVenta;
                rt["costoTotalSalida"] = it.costoVentaDivisa;
                rt["ventaTotalSalida"] = it.ventaDivisa;
                rt["gananciaTotalSalida"] = it.ventaDivisa - it.costoVentaDivisa;

                //
                var _exFinal = it.exIniUnd + it.cntUndMovInv + it.cntUndCompra - it.cntUndVenta;
                rt["exFinal"] = _exFinal;
                rt["costoFinal"] = Math.Round(_exFinal * _costoIni, 2, MidpointRounding.AwayFromZero);

                ds.Tables["ResumenCostoInv"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("FILTROS", filtro));
            Rds.Add(new ReportDataSource("ResumenCostoInv", ds.Tables["ResumenCostoInv"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}