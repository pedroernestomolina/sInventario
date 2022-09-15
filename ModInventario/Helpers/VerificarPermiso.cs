using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Helpers
{
    
    public class VerificarPermiso
    {

        public static bool PermitirAcceso(Func<string, OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>> func, string idGrupo, ISeguridadAccesoSistema _seguridad)
        {
            var rt= func.Invoke(idGrupo);
            if (rt.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt.Mensaje);
                return false;
            }
            return _seguridad.Verificar(rt.Entidad);
        }

    }

}
