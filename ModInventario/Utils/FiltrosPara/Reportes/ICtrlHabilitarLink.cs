using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.FiltrosPara.Reportes
{
    public interface ICtrlHabilitarLink: Utils.Filtros.IFiltroLink
    {
        bool GetHabilitar { get;  }
        void setHabilitar(bool hab);
    }
}