using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.TallaColorSabor.Visualizar
{
    public interface IVer: IGestion
    {
        BindingSource GetData_Source { get; }
        BindingSource GetDataDep_Source { get; }
        string GetEtq_Prd { get; }
        decimal GetEtq_CntGeneral { get; }
        decimal GetEtq_CntDetalle { get; }
        string GetEtq_PrdTCS { get; }
        void setIdPrd(string idPrd);
        void setIdDeposito(string idDep);
        bool CargarDepositos();
        void HabilitaBtDetalle(bool estado);
    }
}