using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.FiltrosGen
{
    
    public interface IAdmDoc : IFiltro
    {

        AdmDoc.data  DataFiltrar { get; }
        IOpcion Sucursal { get;  }
        IOpcion TipoDoc { get; }
        IFecha FechaDesde { get; }
        IFecha FechaHasta { get; }

    }

}