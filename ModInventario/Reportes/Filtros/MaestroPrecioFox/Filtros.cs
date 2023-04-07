using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Filtros.MaestroPrecioFox
{
    public class Filtros: IFiltros
    {
        public bool ActivarDeposito { get { return false; } }
        public bool ActivarDepartamento { get { return true; } }
        public bool ActivarSucursal { get { return false; } }
        public bool ActivarAdmDivisa { get { return false; } }
        public bool ActivarProducto { get { return false; } }
        public bool ActivarDesde { get { return false; } }
        public bool ActivarHasta { get { return false; } }
        public bool ActivarTasaIva { get { return true; } }
        public bool ActivarEstatus { get { return false; } }
        public bool ActivarOrigen { get { return false; } }
        public bool ActivarCategoria { get { return false; } }
        public bool ActivarMarca { get { return true; } }
        public bool ActivarGrupo { get { return ActivarDepartamento; } }
        public bool ActivarPrecio { get { return true; } }
        public bool ActivarPesado { get { return true; } }
        public bool ActivarEntreFechas { get { return false; } }
        public bool ActivarEmpaquePrecio { get { return false; } }
        public bool ActivarOferta { get { return true; } }


        public Filtros()
        {
        }
    }
}