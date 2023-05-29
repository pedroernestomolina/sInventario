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
        int GetEx_InvEmpCompra { get; }
        int GetEx_InvEmpInv { get; }
        int GetEx_InvEmpUnd { get; }

        void setIdPrd(string idPrd);
        void setIdDeposito(string idDep);
    }
}