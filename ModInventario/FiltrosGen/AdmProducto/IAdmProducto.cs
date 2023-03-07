using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.FiltrosGen.AdmProducto
{
    public interface IAdmProducto: IFiltro
    {
        Object FiltrosExportar { get; }
        int MetBusqueda { get; }
        string CadenaBusq { get; }

        void setCadenaBusc(string cadena);
        void setMetBusqByCodigo();
        void setMetBusqByNombre();
        void setMetBusqByReferencia();
        void setMetBusqByCodigoBarra();

        void HabilitaDeposito(bool act);
    }
}