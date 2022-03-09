using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    
    public interface IAuditoria
    {

        OOB.ResultadoEntidad<OOB.LibInventario.Auditoria.Entidad.Ficha> Auditoria_Documento_GetFichaBy(OOB.LibInventario.Auditoria.Buscar.Ficha ficha);

    }

}