using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{

    public interface IEmpaqueMedida
    {

        OOB.ResultadoLista<OOB.LibInventario.EmpaqueMedida.Ficha> 
            EmpaqueMedida_GetLista();
        OOB.ResultadoEntidad<OOB.LibInventario.EmpaqueMedida.Ficha>
            EmpaqueMedida_GetFicha(string auto);
        OOB.ResultadoAuto 
            EmpaqueMedida_Agregar(OOB.LibInventario.EmpaqueMedida.Agregar ficha);
        OOB.Resultado 
            EmpaqueMedida_Editar(OOB.LibInventario.EmpaqueMedida.Editar ficha);
        OOB.Resultado 
            EmpaqueMedida_Eliminar(string auto);

    }

}