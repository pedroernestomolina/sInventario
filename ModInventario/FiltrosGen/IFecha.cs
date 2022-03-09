using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.FiltrosGen
{
    
    public interface IFecha
    {

        DateTime GetFecha { get; }
        DateTime? FechaFiltro { get; }


        void setFecha(DateTime fecha);
        void setEstatusOff();
        void Limpiar();
        void Inicializa();

    }

}