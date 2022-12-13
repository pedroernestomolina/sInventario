using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Visor.Traslado
{
    
    public interface IVisorTraslado: IGestion, Gestion.IAbandonar
    {
        BindingSource GetSource { get; }
        BindingSource GetMes_Source { get; }
        BindingSource GetAno_Source { get; }

        string GetNotas { get; }
        int GetCntItems { get; }

        void Buscar();

        void setMesFiltrar(string id);
        void setAnoFiltrar(string id);
        string GetMes_Id { get; }
        string GetAno_id { get; }
    }

}