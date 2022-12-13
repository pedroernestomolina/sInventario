using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Visor.GananciaPerdida
{
    
    public interface IVisorGanPerd: IGestion, Gestion.IAbandonar
    {
        BindingSource GetSource { get; }
        BindingSource GetAno_Source { get; }
        BindingSource GetMes_Source { get; }
        string  GetMes_Id { get; }
        string GetAno_id { get; }
        string GetNotas { get; }
        void setMesFiltrar(string id);
        void setAnoFiltrar(string id);
        void Buscar();
        int GetCntItems { get; }
        decimal GetTotal { get; }
        decimal GetTasa { get; }
    }

}