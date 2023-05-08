﻿using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Filtros.MaestroPrecioBasico
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
                var r01 = Sistema.MyData.Reportes_MaestroPrecio(filtro);
                Imprimir(r01.Lista, dataFiltros.ToString());
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }


        public void Imprimir(List<OOB.LibInventario.Reportes.MaestroPrecio.Ficha> lista, string filtro)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Filtros\MaestroPrecioBasico.rdlc";
            var ds = new DS();

            foreach (var it in lista.ToList().OrderBy(o => o.departamento).ThenBy(o=>o.grupo).ThenBy(o => o.nombre).ToList())
            {
                DataRow rt = ds.Tables["MaestroPrecioBasico"].NewRow();
                rt["nombre"] = it.codigo + Environment.NewLine + it.nombre.Trim();
                rt["departamento"] = it.departamento;
                rt["grupo"] = it.grupo;
                rt["divisa"] = it.admDivisa == "1" ? "Si" : "No";
                rt["tasaIva"] = it.tasa;

                var pemp1 = "";
                var pemp2 = "";
                var pemp3 = "";
                if (it.p1_neto > 0)
                {
                    pemp1 = Precio(it.p1_neto, it.p1_div_full, it.tasa, it.admDivisa).ToString() + Environment.NewLine + it.empaque_1.Trim() + "/(" + it.cont_1.ToString() + ")";
                }
                if (it.pM1_neto > 0)
                {
                    pemp2 = Precio(it.pM1_neto, it.pM1_div_full, it.tasa, it.admDivisa).ToString() + Environment.NewLine + it.empaque_M1.Trim() + "/(" + it.cont_M1.ToString() + ")"; 
                }
                if (it.pD1_neto > 0)
                {
                    pemp3 = Precio(it.pD1_neto, it.pD1_div_full, it.tasa, it.admDivisa).ToString() + Environment.NewLine + it.empaque_D1.Trim() + "/(" + it.cont_D1.ToString() + ")";
                }
                rt["empaque_1"] = pemp1;
                rt["empaque_2"] = pemp2;
                rt["empaque_3"] = pemp3;
                rt["precio_1"] = Precio(it.p1_neto, it.p1_div_full, it.tasa, it.admDivisa);
                rt["precio_2"] = Precio(it.pM1_neto, it.pM1_div_full, it.tasa, it.admDivisa);
                rt["precio_3"] = Precio(it.pD1_neto, it.pD1_div_full, it.tasa, it.admDivisa);  
                ds.Tables["MaestroPrecioBasico"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("FILTROS", filtro));
            Rds.Add(new ReportDataSource("MaestroPrecioBasico", ds.Tables["MaestroPrecioBasico"]));

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