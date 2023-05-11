using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.FiltrosPara.Reportes
{
    public interface ICtrlHabilitar: Utils.Filtros.IFiltro
    {
        bool GetIsRequerido { get; }
        void setIsRequerido(bool req);

        bool IsOk();
    }
}