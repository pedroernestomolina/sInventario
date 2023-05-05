using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Filtros.MaestroPrecio.ModoAdm
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
                if (dataFiltros.Pesado.id == "2")
                    rt = OOB.LibInventario.Reportes.enumerados.EnumPesado.No;
                filtro.pesado = rt;
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
                filtro.autoDepartamento = dataFiltros.Depart.id;
            }
            if (dataFiltros.Grupo != null)
            {
                filtro.autoGrupo = dataFiltros.Grupo.id;
            }
            if (dataFiltros.Marca != null)
            {
                filtro.autoMarca = dataFiltros.Marca.id;
            }
            if (dataFiltros.TasaIva != null)
            {
                filtro.autoTasa = dataFiltros.TasaIva.id;
            }
            if (dataFiltros.Oferta != null)
            {
                filtro.estatusOferta = dataFiltros.Oferta.desc.Trim().ToUpper() == "SI" ? "1" : "0";
            }
            try
            {
                var r01 = Sistema.MyData.Reportes_ModoAdm_MaestroPrecio(filtro);
                Imprimir(r01.Lista, dataFiltros.ToString(), dataFiltros.Precio);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }

        public void Imprimir(List<OOB.LibInventario.Reportes.MaestroPrecio.ModoAdm.Ficha> lista, string filtro, ficha precio)
        {
            var gr = lista.
                        GroupBy(g => new { g.prdNombre, g.prdCodigo, g.grupo, g.departamento, g.estatusDivisa, g.tasaIva}).
                        Select(s => new { key = s.Key, 
                                                lista = s.ToList() }).ToList();

            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Filtros\MaestroPrecioBasico.rdlc";
            var ds = new DS();

            foreach (var it in lista.
                        GroupBy(g => new { g.prdNombre, g.prdCodigo, g.grupo, g.departamento, g.estatusDivisa, g.tasaIva}).
                        Select(s => new { key = s.Key, 
                                                lista = s.ToList() }).ToList().OrderBy(o => o.key.departamento).ThenBy(o => o.key.grupo).ThenBy(o => o.key.prdNombre).ToList())
            {
                DataRow rt = ds.Tables["MaestroPrecioBasico"].NewRow();
                rt["nombre"] = it.key.prdCodigo + Environment.NewLine + it.key.prdNombre.Trim();
                rt["departamento"] = it.key.departamento;
                rt["grupo"] = it.key.grupo;
                rt["divisa"] = it.key.estatusDivisa == "1" ? "Si" : "No";
                rt["tasaIva"] = it.key.tasaIva;
                foreach (var r in it.lista)
                {
                    var pemp = "";
                    if (r.netoMonLocal > 0)
                    {
                        pemp = Precio(r.netoMonLocal, r.fullDivisa, it.key.tasaIva, it.key.estatusDivisa).ToString("N2",CultureInfo.CurrentCulture) + Environment.NewLine + r.empDesc.Trim() + "/(" + r.empCont.ToString() + ")";
                        switch (r.tipoEmpVta.Trim())
                        {
                            case "1":
                                rt["empaque_1"] = pemp;
                                rt["precio_1"] = Precio(r.netoMonLocal, r.fullDivisa, r.tasaIva, r.estatusDivisa);
                                break;
                            case "2":
                                rt["empaque_2"] = pemp;
                                rt["precio_2"] = Precio(r.netoMonLocal, r.fullDivisa, r.tasaIva, r.estatusDivisa);
                                break;
                            case "3":
                                rt["empaque_3"] = pemp;
                                rt["precio_3"] = Precio(r.netoMonLocal, r.fullDivisa, r.tasaIva, r.estatusDivisa);
                                break;
                        }
                    }
                }
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