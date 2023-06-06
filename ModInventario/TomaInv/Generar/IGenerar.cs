using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModInventario.Utils.Tools;
using System.Windows.Forms;


namespace ModInventario.TomaInv.Generar
{
    public interface IGenerar: IGestion, Gestion.IAbandonar, Gestion.IProcesar
    {
        string GetEnt_Motivo { get; }
        string GetEnt_AutorizadoPor { get; }
        DateTime GetFechaSistema { get; }
        ICtrl SucOrigen { get; }
        ICtrlLink DepOrigen { get; }
        decimal GetCntDias { get; }
        BindingSource GetSource { get; }


        void GenerarToma();
        void SucOrigenSetId(string id);
        void setAutorizadoPor(string desc);
        void setMotivo(string desc);
        void setCntDias(decimal cnt);
        void Limpiar();
    }
}