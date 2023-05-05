using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Reporte
{
    public interface IReporte
    {
        void setFiltros(FiltrosGen.Reportes.IData data);
        void Generar();
    }
}