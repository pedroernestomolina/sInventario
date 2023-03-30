using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    public interface IReportes_ModoAdm
    {
        OOB.ResultadoLista<OOB.LibInventario.Reportes.MaestroPrecio.ModoAdm.Ficha>
            Reportes_ModoAdm_MaestroPrecio(OOB.LibInventario.Reportes.MaestroPrecio.Filtro filtro);
    }
}