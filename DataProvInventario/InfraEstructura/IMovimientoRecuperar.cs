using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    public interface IMovimientoRecuperar
    {
        OOB.ResultadoEntidad<OOB.LibInventario.MovimientoRecuperar.Entidad.Ficha>
            movimientoRecuperarFicha(string idDoc);
    }
}