using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.Filtros.DesdeHasta
{
    public interface IFiltro
    {
        Fecha.IFiltro Desde { get; }
        Fecha.IFiltro Hasta { get; }

        void Inicializa();
        void LimpiarOpcion();
    }
}