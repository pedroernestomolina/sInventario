using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{

    public interface IMovTransito
    {

        OOB.ResultadoId 
            Transito_Movimiento_Agregar(OOB.LibInventario.Transito.Movimiento.Agregar.Ficha ficha);
        OOB.ResultadoEntidad<int> 
            Transito_Movimiento_GetCnt(OOB.LibInventario.Transito.Movimiento.Lista.Filtro filtro);
        OOB.ResultadoEntidad<OOB.LibInventario.Transito.Movimiento.Entidad.Ficha>
            Transito_Movimiento_GetById(int idMov);
        OOB.ResultadoLista<OOB.LibInventario.Transito.Movimiento.Entidad.Mov>
            Transito_Movimiento_GetLista(OOB.LibInventario.Transito.Movimiento.Lista.Filtro filtro);
        OOB.Resultado
            Transito_Movimiento_AnularById(int idMod);

    }

}