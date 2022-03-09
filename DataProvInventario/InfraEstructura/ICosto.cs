using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    
    public interface ICosto
    {

        OOB.ResultadoEntidad<OOB.LibInventario.Costo.Historico.Ficha> HistoricoCosto_GetLista(OOB.LibInventario.Costo.Historico.Filtro filtro);
        OOB.Resultado CostoProducto_Actualizar (OOB.LibInventario.Costo.Editar.Ficha ficha);

    }

}