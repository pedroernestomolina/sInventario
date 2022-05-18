using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    
    public interface IUsuario
    {

        OOB.ResultadoEntidad<OOB.LibInventario.Usuario.Ficha> Usuario_Principal();
        OOB.ResultadoEntidad<OOB.LibInventario.Usuario.Ficha> Usuario_Cargar(OOB.LibInventario.Usuario.Buscar.Ficha ficha);
        OOB.Resultado Usuario_ActualizarSesion(OOB.LibInventario.Usuario.ActualizarSesion.Ficha ficha);
        OOB.ResultadoEntidad<string>
            Usuario_GetClave_ById(string idUsuario);
        OOB.ResultadoEntidad<string>
            Usuario_GetId_ByClaveUsuGrupoAdm(string clave);

    }

}