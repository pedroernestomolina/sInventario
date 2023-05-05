using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Filtros.MaestroProducto
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
            var filtro = new OOB.LibInventario.Reportes.MaestroProducto.Filtro();
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
            if (dataFiltros.Origen != null)
            {
                filtro.origen = (OOB.LibInventario.Reportes.enumerados.EnumOrigen)int.Parse(dataFiltros.Origen.id);
            }
            if (dataFiltros.Categoria != null)
            {
                filtro.categoria = (OOB.LibInventario.Reportes.enumerados.EnumCategoria)int.Parse(dataFiltros.Categoria.id);
            }
            if (dataFiltros.Estatus != null)
            {
                filtro.estatus = (OOB.LibInventario.Reportes.enumerados.EnumEstatus)int.Parse(dataFiltros.Estatus.id);
            }
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
            if (dataFiltros.TasaIva != null)
            {
                filtro.autoTasa = dataFiltros.TasaIva.id;
            }
            if (dataFiltros.Oferta != null)
            {
                filtro.estatusOferta = dataFiltros.Oferta.desc.Trim().ToUpper()=="SI"?"1":"0";
            }
            try
            {
                var r01 = Sistema.MyData.Reportes_MaestroProducto(filtro);
                Imprimir(r01.Lista, dataFiltros.ToString());
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }


        public void Imprimir(List<OOB.LibInventario.Reportes.MaestroProducto.Ficha> lista, string filtros)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Filtros\MaestroProductos.rdlc";
            var ds = new DS();
            foreach (var it in lista.ToList().OrderBy(o => o.departamento).ThenBy(o => o.nombrePrd).ToList())
            {
                DataRow rt = ds.Tables["MaestroProducto"].NewRow();
                rt["codigo"] = it.codigoPrd;
                rt["nombre"] = it.nombrePrd;
                rt["modelo"] = it.modeloPrd;
                rt["referencia"] = it.referenciaPrd;
                rt["departamento"] = it.departamento;
                rt["empaque"] = it.empaque.Trim() + " (" + it.contenidoPrd.ToString("n0") + ")";
                rt["tasa"] = it.tasaIva.ToString("n2") + "%";
                rt["admDivisa"] = it.admDivisa.ToString();
                rt["origen"] = it.origen.ToString();
                rt["categoria"] = it.categoria.ToString();
                rt["grupo"] = it.grupo;
                ds.Tables["MaestroProducto"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("FILTROS", filtros));
            Rds.Add(new ReportDataSource("MaestroProducto", ds.Tables["MaestroProducto"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}