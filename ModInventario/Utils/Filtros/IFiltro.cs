using LibUtilitis.CtrlCB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.Filtros
{
    public interface IFiltro
    {
        ICtrl Ctrl { get; }
        bool GetHabilitar { get; }

        void setHabilitar(bool hab);
        void CargarData();
    }
}