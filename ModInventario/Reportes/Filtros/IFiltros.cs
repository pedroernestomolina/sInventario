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
        bool ActivarGrupo { get; }
        bool ActivarPrecio { get; }

    }

}