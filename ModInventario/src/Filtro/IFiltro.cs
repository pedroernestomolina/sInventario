using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Filtro
{
    public interface IFiltro: IGestion, Gestion.IAbandonar, Gestion.IProcesar
    {
    }
}