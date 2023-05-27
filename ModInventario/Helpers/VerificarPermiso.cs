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
            try
            {
                var rt = func.Invoke(idGrupo);
                return _seguridad.Verificar(rt.Entidad);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
    }
}