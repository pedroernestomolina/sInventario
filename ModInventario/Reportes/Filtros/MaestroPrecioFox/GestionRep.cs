using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Filtros.MaestroPrecioFox
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
            var filtro = new OOB.LibInventario.Reportes.MaestroPrecio.Filtro();
            if (dataFiltros.Divisa!=null)
            {
                var rt= OOB.LibInventario.Reportes.enumerados.EnumAdministradorPorDivisa.Si;
                if (dataFiltros.Divisa.id=="2")
                    rt= OOB.LibInventario.Reportes.enumerados.EnumAdministradorPorDivisa.No;
                filtro.admDivisa = rt; 
            }
            if (dataFiltros.Pesado != null)
            {
                var rt = OOB.LibInventario.Reportes.enumerados.EnumPesado.Si;
                if (dataFiltros.Pesado.id == "02")
                    rt = OOB.LibInventario.Reportes.enumerados.EnumPesado.No;
                filtro.pesado = rt;
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
            try
            {
                var r01 = Sistema.MyData.Reportes_MaestroPrecio_FoxSystem(filtro);
                Imprimir(r01.Lista, dataFiltros.ToString());
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }


        public void Imprimir(List<OOB.LibInventario.Reportes.MaestroPrecio.FichaFox> lista, string filtro)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Filtros\MaestroPrecioFox.rdlc";
            var ds = new DS();

            foreach (var it in lista.ToList().OrderBy(o => o.departamento).ThenBy(o => o.grupo).ThenBy(o => o.nombre).ToList())
            {
                DataRow rt = ds.Tables["MaestroPrecioFox"].NewRow();
                rt["nombre"] = it.codigo + Environment.NewLine + it.nombre.Trim();
                rt["departamento"] = it.departamento;
                rt["grupo"] = it.grupo;
                rt["tasaIva"] = it.tasa;

                var pemp1 = "";
                var pemp2 = "";
                var pemp3 = "";
                var pemp4 = "";
                var pemp5 = "";
                if (it.p1_neto1 > 0)
                {
                    pemp1 = Precio(it.p1_neto1, 0m, it.tasa, "0").ToString("n2") + Environment.NewLine + it.emp1_des1.Trim() + "/(" + it.cont1_emp1.ToString() + ")";
                }
                if (it.p1_neto2 > 0)
                {
                    pemp2 = Precio(it.p1_neto2, 0m, it.tasa, "0").ToString("n2") + Environment.NewLine + it.emp1_des2.Trim() + "/(" + it.cont1_emp2.ToString() + ")";
                }
                if (it.p1_neto3 > 0)
                {
                    pemp3 = Precio(it.p1_neto3, 0m, it.tasa, "0").ToString("n2") + Environment.NewLine + it.emp1_des3.Trim() + "/(" + it.cont1_emp3.ToString() + ")";
                }
                if (it.p1_neto4 > 0)
                {
                    pemp4 = Precio(it.p1_neto4, 0m, it.tasa, "0").ToString("n2") + Environment.NewLine + it.emp1_des4.Trim() + "/(" + it.cont1_emp4.ToString() + ")";
                }
                if (it.pDetal > 0)
                {
                    pemp5 = Precio(it.pDetal, 0m, it.tasa, "0").ToString("n2") + Environment.NewLine + it.empDetal.Trim() + "/(" + it.contDetal.ToString() + ")";
                }
                rt["empaque_1"] = pemp1;
                rt["empaque_2"] = pemp2;
                rt["empaque_3"] = pemp3;
                rt["empaque_4"] = pemp4;
                rt["empaque_5"] = pemp5;
                ds.Tables["MaestroPrecioFox"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("FILTROS", filtro));
            Rds.Add(new ReportDataSource("MaestroPrecioFox", ds.Tables["MaestroPrecioFox"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }


        private decimal Precio(decimal pNeto, decimal pDivFull, decimal tasaIva, string admDivisa)
        {
            if (admDivisa.Trim().ToUpper() == "1")
                return pDivFull;
            else
            {
                return Full(pNeto, tasaIva);
            }
        }

        private decimal Full(decimal pNeto, decimal tasaIva)
        {
            var p = pNeto;
            return p + (pNeto * tasaIva / 100);
        }
    }
}