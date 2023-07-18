using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.TomaInv.Analisis
{
    public interface IAnalisis: IGestion,  Gestion.IAbandonar, Gestion.IProcesar
    {
        BindingSource GetSource { get; }
        LibUtilitis.CtrlCB.ICtrl Terminal { get; }
        LibUtilitis.CtrlCB.ICtrl ExistenciaFiltro { get; }
        int CntItem { get; }

        void setTomaInvAnalizar(string idToma);
        void setMarcarTodas(bool m);
        void EliminarTomas();
        void RefrescarVista();
        void MostrarConteo();
        void ImprimirAnalisis();
        void EditarItem();
        void setTerminalId(string id);
        void setExistenciaFiltroId(string id);

        void NoHayEnExistencia();
    }
}