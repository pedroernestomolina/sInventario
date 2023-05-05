using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Filtros
{
    public interface IFiltros
    {
        bool ActivarProducto { get; }
        bool ActivarDepartamento { get; }
        bool ActivarDeposito { get; }
        bool ActivarSucursal { get; }
        bool ActivarTasaIva { get; }
        bool ActivarAdmDivisa { get; }
        bool ActivarDesde { get; }
        bool ActivarHasta { get; }
        bool ActivarEstatus { get; }
        bool ActivarOrigen { get; }
        bool ActivarCategoria { get; }
        bool ActivarMarca { get; }
        bool ActivarPrecio { get; }
        bool ActivarPesado { get; }
        bool ActivarEntreFechas { get; }
        bool ActivarEmpaquePrecio { get; }
        bool ActivarOferta { get; }
        bool ActivarConcepto { get; }
        //
        bool IsRequeridoProducto { get; }
        bool IsRequeridoDepartamento { get; }
        bool IsRequeridoDeposito { get; }
        bool IsRequeridoSucursal { get; }
        bool IsRequeridoTasaIva { get; }
        bool IsRequeridoAdmDivisa { get; }
        bool IsRequeridoDesde { get; }
        bool IsRequeridoHasta { get; }
        bool IsRequeridoEstatus { get; }
        bool IsRequeridoOrigen { get; }
        bool IsRequeridoCategoria { get; }
        bool IsRequeridoMarca { get; }
        bool IsRequeridoPrecio { get; }
        bool IsRequeridoPesado { get; }
        bool IsRequeridoEntreFechas { get; }
        bool IsRequeridoEmpaquePrecio { get; }
        bool IsRequeridoOferta { get; }
        bool IsRequeridoConcepto { get; }
    }
}