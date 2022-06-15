using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Filtros.MaestroExistenciaInventario
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
            var filtro = new OOB.LibInventario.Reportes.MaestroExistenciaInventario.Filtro();
            if (dataFiltros.Depart != null) 
            {
                filtro.autoDepartamento = dataFiltros.Depart.id;
            }
            if (dataFiltros.Deposito != null)
            {
                filtro.autoDeposito= dataFiltros.Deposito.id;
            }
            if (dataFiltros.Grupo != null)
            {
                filtro.autoGrupo = dataFiltros.Grupo.id;
            }
            var r01 = Sistema.MyData.Reportes_MaestroExistenciaInventario(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Imprimir(r01.Lista, dataFiltros.ToString());
        }

        public void Imprimir(List<OOB.LibInventario.Reportes.MaestroExistenciaInventario.Ficha> lista, string filtro)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Filtros\MaestroExistenciaInv.rdlc";
            var ds = new DS();

            foreach (var it in lista.ToList().OrderBy(o => o.nombrePrd).ToList())
            {
                decimal r=it.eFisica;
                var eEmpCompra = (int)(it.eFisica / it.contEmpCompra);
                r-= (eEmpCompra * it.contEmpCompra);
                var eEmpInv = (int)(r / it.contEmpInv);
                r-= (eEmpInv* it.contEmpInv);

                DataRow rt = ds.Tables["MaestroExistenciaInv"].NewRow();
                rt["codigoPrd"] = it.codigoPrd;
                rt["nombrePrd"] = it.codigoPrd + Environment.NewLine + it.nombrePrd;
                rt["deposito"] = it.nombreDeposito;
                rt["eEmpCompra"] = eEmpCompra.ToString("n0")+ Environment.NewLine+ " ("+it.nombreEmpCompra.Trim()+"/"+it.contEmpCompra.ToString("n0")+")";
                rt["eEmpInv"] = eEmpInv.ToString("n0") + Environment.NewLine + " (" + it.nombreEmpInv.Trim() + "/" + it.contEmpInv.ToString("n0") + ")";
                rt["eEmpUnd"] = r.ToString("n0") + Environment.NewLine + "(Und)";
                rt["eFisica"] = it.eFisica;
                rt["departamento"] = it.nombreDepart;
                rt["grupo"] = it.nombreGrupo;
                ds.Tables["MaestroExistenciaInv"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("Filtro", filtro));
            Rds.Add(new ReportDataSource("MaestroExistenciaInv", ds.Tables["MaestroExistenciaInv"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}