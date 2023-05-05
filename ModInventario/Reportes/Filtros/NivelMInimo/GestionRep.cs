using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Filtros.NivelMInimo
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
            var filtro = new OOB.LibInventario.Reportes.NivelMinimo.Filtro();
            if (dataFiltros.Depart != null)
            {
                filtro.autoDepartamento = dataFiltros.Depart.id;
            }
            if (dataFiltros.Grupo != null)
            {
                filtro.autoGrupo = dataFiltros.Grupo.id;
            }
            if (dataFiltros.Deposito != null)
            {
                filtro.autoDeposito = dataFiltros.Deposito.id;
            }
            var r01 = Sistema.MyData.Reportes_NivelMinimo(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Imprimir(r01.Lista, dataFiltros.ToString());
        }

        public void Imprimir(List<OOB.LibInventario.Reportes.NivelMinimo.Ficha> lista, string filtro)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Filtros\NivelMinimo.rdlc";
            var ds = new DS();

            foreach (var it in lista.ToList().OrderBy(o => o.nombrePrd).ToList())
            {
                DataRow rt = ds.Tables["NivelMinimo"].NewRow();
                rt["producto"] = it.nombrePrd + Environment.NewLine + it.codigoPrd;
                rt["deposito"] = it.nombreDep;
                rt["departamento"] = it.departamento;
                rt["grupo"] = it.grupo;
                rt["existencia"] = it.existencia;
                rt["nivelMinimo"] = it.nivelMin;
                rt["nivelMaximo"] = it.nivelMax ;
                rt["reposicion"] = it.reposicion;
                ds.Tables["NivelMinimo"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("Filtros", filtro));
            Rds.Add(new ReportDataSource("NivelMinimo", ds.Tables["NivelMinimo"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}