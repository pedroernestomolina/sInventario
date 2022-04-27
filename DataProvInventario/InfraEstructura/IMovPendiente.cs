using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    
    public interface IMovPendiente
    {

        OOB.ResultadoLista<OOB.LibInventario.MovPend.Entidad.Ficha>
            MovPendiente_GetLista(OOB.LibInventario.MovPend.Lista.Filtro filtro);
        OOB.Resultado
            MovPendiente_Anular(int idMov );

    }

}