using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Filtros.MaestroExistencia
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
            var filtro = new OOB.LibInventario.Reportes.MaestroExistencia.Filtro();
            if (dataFiltros.Depart != null) { filtro.autoDepartamento = dataFiltros.Depart.id; }
            if (dataFiltros.Deposito != null) { filtro.autoDeposito = dataFiltros.Deposito.id; }
            if (dataFiltros.Grupo != null) { filtro.autoGrupo = dataFiltros.Grupo.id; }
            if (dataFiltros.Producto != null) { filtro.autoProducto = dataFiltros.Producto.id; }
            try
            {
                var r01 = Sistema.MyData.Reportes_MaestroExistencia(filtro);
                Imprimir(r01.Lista, dataFiltros.ToString());
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }

        public void Imprimir(List<OOB.LibInventario.Reportes.MaestroExistencia.Ficha> lista, string filtro)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Filtros\MaestroExistencia.rdlc";
            var ds = new DS();

            foreach (var it in lista.ToList().OrderBy(o => o.nombrePrd).ToList())
            {
                var precio = 0.0m;
                switch (it.precioId) 
                {
                    case "1":
                        precio = it.pDivisaNeto_1;
                        break;
                    case "2":
                        precio = it.pDivisaNeto_2;
                        break;
                    case "3":
                        precio = it.pDivisaNeto_3;
                        break;
                    case "4":
                        precio = it.pDivisaNeto_4;
                        break;
                    case "5":
                        precio = it.pDivisaNeto_5;
                        break;
                }

                DataRow rt = ds.Tables["MaestroExistencia"].NewRow();
                rt["nombrePrd"] = it.nombrePrd + Environment.NewLine + it.codigoPrd; 
                //rt["nombreDep"] = it.codigoDep+", "+it.nombreDep;
                rt["nombreDep"] = it.nombreDep;
                rt["existencia"] = it.exFisica;
                rt["costoUnd"] = it.costoUndDivisa;
                rt["costoMonto"] = it.costoUndDivisa*it.exFisica;
                rt["precioUnd"] = precio;
                rt["ventaMonto"] = precio*it.exFisica;
                rt["departamento"] = it.departamento;
                rt["grupo"] = it.grupo;
                //if (it.exFisica != 0.0m)
                //    ds.Tables["MaestroExistencia"].Rows.Add(rt);
                ds.Tables["MaestroExistencia"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("Filtro", filtro));
            Rds.Add(new ReportDataSource("MaestroExistencia", ds.Tables["MaestroExistencia"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}