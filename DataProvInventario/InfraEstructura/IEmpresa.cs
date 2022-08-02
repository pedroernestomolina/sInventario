using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    
    public interface IEmpresa
    {

        OOB.ResultadoLista<OOB.LibInventario.Empresa.Grupo.Lista.Ficha>
            EmpresaGrupo_GetLista();
        OOB.ResultadoEntidad<string>
            EmpresaGrupo_PrecioManejar_GetById(string idGrupo);

    }

}