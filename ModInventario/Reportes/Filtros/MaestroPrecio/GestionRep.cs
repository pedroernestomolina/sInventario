using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Filtros.MaestroPrecio
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
            var filtro = new OOB.LibInventario.Reportes.MaestroPrecio.Filtro();
            if (dataFiltros.Divisa!=null)
            {
                var rt= OOB.LibInventario.Reportes.enumerados.EnumAdministradorPorDivisa.Si;
                if (dataFiltros.Divisa.id=="2")
                    rt= OOB.LibInventario.Reportes.enumerados.EnumAdministradorPorDivisa.No;
                filtro.admDivisa = rt; 
            }
            if (dataFiltros.Origen != null)
            {
                filtro.origen = (OOB.LibInventario.Reportes.enumerados.EnumOrigen)int.Parse(dataFiltros.Origen.id);
            }
            if (dataFiltros.Categoria != null)
            {
                filtro.categoria = (OOB.LibInventario.Reportes.enumerados.EnumCategoria)int.Parse(dataFiltros.Categoria.id);
            }
            if (dataFiltros.Depart != null)
            {
                filtro.autoDepartamento= dataFiltros.Depart.id;
            }
            if (dataFiltros.Grupo != null)
            {
                filtro.autoGrupo= dataFiltros.Grupo.id;
            }
            if (dataFiltros.Marca != null)
            {
                filtro.autoMarca= dataFiltros.Marca.id;
            }
            if (dataFiltros.TasaIva != null)
            {
                filtro.autoTasa= dataFiltros.TasaIva.id;
            }
            var r01 = Sistema.MyData.Reportes_MaestroPrecio(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            Imprimir(r01.Lista, dataFiltros.ToString());
        }


        public void Imprimir(List<OOB.LibInventario.Reportes.MaestroPrecio.Ficha> lista, string filtro)
        {
            //var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Filtros\MaestroPrecio.rdlc";
            //var ds = new DS();

            //foreach (var it in lista.ToList().OrderBy(o=>o.departamento).ThenBy(o=>o.nombrePrd).ToList())
            //{
            //    DataRow rt = ds.Tables["MaestroPrecio"].NewRow();
            //    rt["codigo"] = it.codigoPrd;
            //    rt["nombre"] = it.nombrePrd + Environment.NewLine + it.codigoPrd;
            //    rt["modelo"] = it.modeloPrd;
            //    rt["referencia"] = it.referenciaPrd;
            //    rt["departamento"] = it.departamento;
            //    rt["grupo"] = it.grupo;
            //    rt["pfull_1"] = it.precioFull_1;
            //    rt["pfull_2"] = it.precioFull_2;
            //    rt["pfull_3"] = it.precioFull_3;
            //    rt["pfull_4"] = it.precioFull_4;
            //    rt["pfull_5"] = it.precioFull_5;
            //    ds.Tables["MaestroPrecio"].Rows.Add(rt);
            //}

            //var Rds = new List<ReportDataSource>();
            //var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("Filtro", filtro));
            //Rds.Add(new ReportDataSource("MaestroPrecio", ds.Tables["MaestroPrecio"]));

            //var frp = new ReporteFrm();
            //frp.rds = Rds;
            //frp.prmts = pmt;
            //frp.Path = pt;
            //frp.ShowDialog();
        }

    }

}