using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    
    public interface ISucursal
    {

        OOB.ResultadoLista<OOB.LibInventario.Sucursal.Ficha> Sucursal_GetLista();
        OOB.ResultadoEntidad<OOB.LibInventario.Sucursal.Ficha> Sucursal_GetFicha(string auto);
        
    }

}