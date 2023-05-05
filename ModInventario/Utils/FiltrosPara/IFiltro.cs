using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Utils.FiltrosPara
{
    public interface IFiltro: IGestion, Gestion.IAbandonar, Gestion.IProcesar
    {
    }
}