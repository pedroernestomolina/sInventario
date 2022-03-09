using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.FiltrosGen
{
    

    public interface IAdmProducto: IFiltro
    {

        AdmProducto.data dataFiltrar { get; }
        int MetBusqueda { get; }
        string CadenaBusq { get; }


        void setCadenaBusc(string cadena);
        void setMetBusqByCodigo();
        void setMetBusqByNombre();
        void setMetBusqByReferencia();

    }

}