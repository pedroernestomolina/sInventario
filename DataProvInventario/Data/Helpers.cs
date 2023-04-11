using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.Data
{
    public class Helpers
    {
        public static OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> 
            PedirPermiso(Func<string, DtoLib.ResultadoEntidad<DtoLibInventario.Permiso.Ficha>> met, string idGrupo) 
        {
            var rs = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();
            var rt=met(idGrupo);
            if (rt.Result == DtoLib.Enumerados.EnumResult.isError) 
            {
                throw new Exception(rt.Mensaje);
            }
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = rt.Entidad.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)rt.Entidad.NivelSeguridad,
            };
            rs.Entidad = nr;
            return rs;
        }
    }
}