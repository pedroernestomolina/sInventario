using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    public interface IGestionCosto
    {
        OOB.ResultadoEntidad<OOB.LibInventario.Producto.GestionCosto.CapturarDataPrdEditarCosto.Ficha>
            Producto_GestionCosto_CapturarDataPrdEditarCosto(string idPrd);
    }
}