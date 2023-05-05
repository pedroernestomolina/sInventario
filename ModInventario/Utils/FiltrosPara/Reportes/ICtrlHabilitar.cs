using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.FiltrosPara.Reportes
{
    public interface ICtrlHabilitar: Utils.Filtros.IFiltro
    {
        bool GetHabilitar { get;  }
        void setHabilitar(bool hab);

        bool GetIsRequerido { get; }
        void setIsRequerido(bool req);

        bool IsOk();
    }
}