using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    
    public interface IPrecio
    {

        OOB.ResultadoEntidad<OOB.LibInventario.Precio.Historico.Ficha> HistoricoPrecio_GetLista(OOB.LibInventario.Precio.Historico.Filtro filtro);
        OOB.ResultadoEntidad<OOB.LibInventario.Precio.PrecioCosto.Ficha> PrecioCosto_GetFicha(string autoPrd);
        OOB.Resultado PrecioProducto_Actualizar(OOB.LibInventario.Precio.Editar.Ficha ficha);

    }

}