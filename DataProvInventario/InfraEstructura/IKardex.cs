using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    
    public interface IKardex
    {

        OOB.ResultadoEntidad<OOB.LibInventario.Kardex.Movimiento.Resumen.Ficha> 
            Producto_Kardex_Movimiento_Lista_Resumen(OOB.LibInventario.Kardex.Movimiento.Resumen.Filtro filtro);
        OOB.ResultadoEntidad<OOB.LibInventario.Kardex.Movimiento.Detalle.Ficha> 
            Producto_Kardex_Movimiento_Lista_Detalle(OOB.LibInventario.Kardex.Movimiento.Detalle .Filtro filtro);

    }

}