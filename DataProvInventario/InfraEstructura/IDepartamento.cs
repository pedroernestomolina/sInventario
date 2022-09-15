using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    
    public interface IDepartamento
    {

        OOB.ResultadoLista<OOB.LibInventario.Departamento.Ficha> 
            Departamento_GetLista();
        OOB.ResultadoEntidad<OOB.LibInventario.Departamento.Ficha> 
            Departamento_GetFicha(string auto);
        OOB.ResultadoAuto 
            Departamento_Agregar(OOB.LibInventario.Departamento.Agregar ficha);
        OOB.Resultado 
            Departamento_Editar(OOB.LibInventario.Departamento.Editar ficha);
        OOB.Resultado 
            Departamento_Eliminar(string auto);

    }

}