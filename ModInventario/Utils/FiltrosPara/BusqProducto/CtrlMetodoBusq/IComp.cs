using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.FiltrosPara.BusqProducto.CtrlMetodoBusq
{
    public interface IComp
    {
        LibUtilitis.CtrlCB.ICtrl Ctrl { get; }

        void Inicializa();
        void CargarData();
        void Limpiar();
    }
}
