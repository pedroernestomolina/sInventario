using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Tools.InfPrd
{
    public interface IPrdInf : IGestion, Gestion.IAbandonar
    {
        BindingSource GetSource { get; }

        string GetInvEmpCompra { get; }
        string GetInvEmpInv { get; }
        string GetInvEmpUnd { get; }
        decimal GetEx_InvEmpCompra { get; }
        decimal GetEx_InvEmpInv { get; }
        decimal GetEx_InvEmpUnd { get; }
        decimal GetEx_Total { get; }

        void setIdPrd(string idPrd);
        void setIdDeposito(string idDep);
    }
}