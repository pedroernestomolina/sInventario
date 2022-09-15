using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    
    public interface IGrupo
    {

        OOB.ResultadoLista<OOB.LibInventario.Grupo.Ficha> 
            Grupo_GetLista();
        OOB.ResultadoEntidad<OOB.LibInventario.Grupo.Ficha> 
            Grupo_GetFicha(string auto);
        OOB.ResultadoAuto 
            Grupo_Agregar(OOB.LibInventario.Grupo.Agregar ficha);
        OOB.Resultado 
            Grupo_Editar(OOB.LibInventario.Grupo.Editar ficha);
        OOB.ResultadoLista<OOB.LibInventario.Grupo.Ficha> 
            Grupo_GetListaByIdDepartamento(string idDepart);
        OOB.Resultado 
            Grupo_Eliminar(string auto);

    }

}