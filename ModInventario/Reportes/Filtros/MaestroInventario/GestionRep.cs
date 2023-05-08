using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Filtros.MaestroInventario
{
    public class GestionRep: src.Reporte.IReporte
    {
        private ModInventario.src.Reporte.IData dataFiltros;


        public GestionRep()
        {
        }


        public void setFiltros(ModInventario.src.Reporte.IData data)
        {
            dataFiltros = data;
        }


        public void Generar()
        {
            var filtro = new OOB.LibInventario.Reportes.MaestroInventario.Filtro();
            if (dataFiltros.Divisa != null)
            {
                var rt = OOB.LibInventario.Reportes.enumerados.EnumAdministradorPorDivisa.Si;
                if (dataFiltros.Divisa.id == "2")
                    rt = OOB.LibInventario.Reportes.enumerados.EnumAdministradorPorDivisa.No;
                filtro.admDivisa = rt;
            }
            if (dataFiltros.Pesado != null)
            {
                var rt = OOB.LibInventario.Reportes.enumerados.EnumPesado.Si;
                if (dataFiltros.Pesado.id == "02")
                    rt = OOB.LibInventario.Reportes.enumerados.EnumPesado.No;
                filtro.pesado = rt;
            }
            if (dataFiltros.Deposito != null)
            {
                filtro.autoDeposito = dataFiltros.Deposito.id;
            }
            if (dataFiltros.Depart != null)
            {
                filtro.autoDepartamento = dataFiltros.Depart.id;
            }
            if (dataFiltros.Grupo != null)
            {
                filtro.autoGrupo= dataFiltros.Grupo.id;
            }
            try
            {
                var r01 = Sistema.MyData.Reportes_MaestroInventario(filtro);
                Imprimir(r01.Lista, dataFiltros.ToString());
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }

        public void Imprimir(List<OOB.LibInventario.Reportes.MaestroInventario.Ficha> lista, string sFiltro)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Filtros\MaestroInventario.rdlc";
            var ds = new DS();

            foreach (var it in lista.ToList().OrderBy(o => o.departamento).OrderBy(o => o.nombrePrd).ToList())
            {
                var existencia = 0.0m;
                if (it.existencia.HasValue)
                    existencia= it.existencia.Value;
                var costoUnd = it.costoUnd;
                var costoDivisaUnd = 0.0m;
                var admDivisa = "No";
                var importe = 0.0m;
                var importeDivisa = 0.0m;
                if (it.admDivisa == OOB.LibInventario.Reportes.enumerados.EnumAdministradorPorDivisa.Si) 
                {
                    admDivisa = "Si";
                    costoDivisaUnd = it.costoDivisaUnd;
                    costoUnd = 0.0m;
                }
                importe = costoUnd * existencia;
                importeDivisa = costoDivisaUnd * existencia;


                DataRow rt = ds.Tables["MaestroInventario"].NewRow();
                rt["codigo"] = it.codigoPrd;
                rt["nombre"] = it.nombrePrd +Environment.NewLine + it.codigoPrd;
                rt["modelo"] = it.modeloPrd;
                rt["referencia"] = it.referenciaPrd;
                rt["departamento"] = it.departamento;
                rt["grupo"] = it.grupo;
                rt["existencia"] = existencia.ToString("n" + it.decimales);
                rt["costoUnd"] = costoUnd.ToString("n2");
                rt["costoDivisaUnd"] = costoDivisaUnd.ToString("n2");
                rt["importe"] = importe;
                rt["importeDivisa"] = importeDivisa;
                rt["admDivisa"] = admDivisa;

                var precio = 0.0m;
                switch (it.precioId) 
                {
                    case "1":
                        precio = it.pn1;
                        break;
                    case "2":
                        precio = it.pn2;
                        break;
                    case "3":
                        precio = it.pn3;
                        break;
                    case "4":
                        precio = it.pn4;
                        break;
                    case "5":
                        precio = it.pn5;
                        break;
                }
                rt["precio"] = precio;
                rt["venta"] = precio * existencia;

                if (existencia!=0.0m)
                    ds.Tables["MaestroInventario"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("FILTROS", sFiltro));
            Rds.Add(new ReportDataSource("MaestroInventario", ds.Tables["MaestroInventario"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}