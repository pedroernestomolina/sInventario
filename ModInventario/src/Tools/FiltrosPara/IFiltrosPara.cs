using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Tools.FiltrosPara
{
    public interface IFiltrosPara: Gestion.IAbandonar
    {
        void Inicializa();
        void Inicia();
        void LimpiarFiltros();
    }
}