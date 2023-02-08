using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    public interface ITallaColorSabor
    {
        OOB.ResultadoEntidad<OOB.LibInventario.TallaColorSabor.Existencia.Ficha>
            TallaColorSabor_ExDep(OOB.LibInventario.TallaColorSabor.Existencia.Filtro filtro);
    }
}