using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.TomaInv.Tools.ExcluirDepart
{
    public interface IExcluir: IGestion, Gestion.IAbandonar, Gestion.IProcesar
    {
        BindingSource GetDatatSource { get; }
        List<Tools.ExcluirDepart.data> GetLista { get; }
        void setMarcarTodas(bool marcar);
    }
}