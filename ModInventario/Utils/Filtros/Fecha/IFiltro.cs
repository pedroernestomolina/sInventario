using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.Filtros.Fecha
{
    public interface IFiltro
    {
        DateTime? Valor { get;  }
        DateTime GetFecha { get; }

        void setFecha(DateTime fecha);
        void setHabilitarFecha (bool bl);

        void Inicializa();
        void LimpiarOpcion();

        void setHabilitarOff();
    }
}