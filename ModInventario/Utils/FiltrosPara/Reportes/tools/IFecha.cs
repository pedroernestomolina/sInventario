using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.FiltrosPara.Reportes.tools
{
    public interface IFecha
    {
        DateTime GetFecha { get; }

        void setFecha(DateTime fecha);

        void Inicializa();
        void LimpiarOpcion();
    }
}