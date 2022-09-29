using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    
    public interface ITasaImpuesto
    {

        OOB.ResultadoLista<OOB.LibInventario.TasaImpuesto.Ficha> 
            TasaImpuesto_GetLista();
        OOB.ResultadoEntidad<OOB.LibInventario.TasaImpuesto.Ficha>
            TasaImpuesto_GetById(string id);

    }

}