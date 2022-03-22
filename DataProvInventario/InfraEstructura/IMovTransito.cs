using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{

    public interface IMovTransito
    {

        OOB.ResultadoId Transito_Movimiento_Agregar(OOB.LibInventario.Transito.Movimiento.Agregar.Ficha ficha);

    }

}