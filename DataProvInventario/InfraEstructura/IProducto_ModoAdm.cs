using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    public interface IProducto_ModoAdm
    {
        OOB.ResultadoLista<OOB.LibInventario.Producto.Data.EmpaqueVenta>
            Producto_ModoAdm_GetEmpaqueVenta_By(string autoPrd);
        OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.ModoAdm.Precio.Ficha>
            Producto_ModoAdm_GetPrecio_By(string autoPrd, string tipoPrecio);
        OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.ModoAdm.Costo.Ficha>
            Producto_ModoAdm_GetCosto_By(string autoPrd);
        OOB.Resultado
            Producto_ModoAdm_ActualizarPrecio(OOB.LibInventario.Producto.ActualizarPrecio.ModoAdm.Ficha ficha);
    }
}