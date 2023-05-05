using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Filtros.MaestroPrecioSoloReporte
{
    public class Filtros: IFiltros
    {
        public bool ActivarDepartamento { get { return true; } }
        public bool ActivarDeposito { get { return false; } }
        public bool ActivarSucursal { get { return false; } }
        public bool ActivarAdmDivisa { get { return true;} }
        public bool ActivarProducto { get { return false; } }
        public bool ActivarDesde { get { return false; } }
        public bool ActivarHasta { get { return false; } }
        public bool ActivarTasaIva { get { return true; } }
        public bool ActivarEstatus { get { return false; } }
        public bool ActivarOrigen { get { return true; } }
        public bool ActivarCategoria { get { return true; } }
        public bool ActivarMarca { get { return true; } }
        public bool ActivarPrecio { get { return false; } }
        public bool ActivarPesado { get { return true; } }
        public bool ActivarEntreFechas { get { return false; } }
        public bool ActivarEmpaquePrecio { get { return true; } }
        public bool ActivarOferta { get { return false; } }
        public bool ActivarConcepto { get { return false; } }
        //
        public bool IsReqeridoPrecio { get { return false; } }
        public bool IsRequeridoProducto { get { return false; } }
        public bool IsRequeridoDepartamento { get { return false; } }
        public bool IsRequeridoDeposito { get { return false; } }
        public bool IsRequeridoSucursal { get { return false; } }
        public bool IsRequeridoTasaIva { get { return false; } }
        public bool IsRequeridoAdmDivisa { get { return false; } }
        public bool IsRequeridoDesde { get { return false; } }
        public bool IsRequeridoHasta { get { return false; } }
        public bool IsRequeridoEstatus { get { return false; } }
        public bool IsRequeridoOrigen { get { return false; } }
        public bool IsRequeridoCategoria { get { return false; } }
        public bool IsRequeridoMarca { get { return false; } }
        public bool IsRequeridoPrecio { get { return false; } }
        public bool IsRequeridoPesado { get { return false; } }
        public bool IsRequeridoEntreFechas { get { return false; } }
        public bool IsRequeridoEmpaquePrecio { get { return false; } }
        public bool IsRequeridoOferta { get { return false; } }
        public bool IsRequeridoConcepto { get { return false; } }
    }
}