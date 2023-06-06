using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    public interface ITomaInv
    {
        OOB.ResultadoLista<OOB.LibInventario.TomaInv.ObtenerToma.Ficha>
            TomaInv_GetListaPrd(OOB.LibInventario.TomaInv.ObtenerToma.Filtro filtro);
        OOB.Resultado
            TomaInv_GenerarToma(OOB.LibInventario.TomaInv.GenerarToma.Ficha Ficha);
        OOB.ResultadoEntidad<OOB.LibInventario.TomaInv.Analisis.Ficha>
            TomaInv_Analisis(int idToma);
        OOB.Resultado
            TomaInv_RechazarItemToma(OOB.LibInventario.TomaInv.RechazarItem.Ficha ficha);
        OOB.Resultado
            TomaInv_Procesar(OOB.LibInventario.TomaInv.Procesar.Ficha ficha);
    }
}