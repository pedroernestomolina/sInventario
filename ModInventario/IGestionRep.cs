using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario
{
    
    public interface IGestionRep: IGestion
    {

        bool FiltrosIsOK { get; }
        FiltrosGen.Reportes.data dataFiltrar { get; }


        void setValidarData(bool p);
        void setGestion(Reportes.Filtros.IFiltros filtros);

    }

}