using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.TomaInv.Analisis
{
    public interface IAnalisis: IGestion
    {
        BindingSource GetSource { get; }
        int CntItem { get; }

        void setTomaInvAnalizar(int idToma);
        void setMarcarTodas(bool m);
        void EliminarTomas();
        void ProcesarToma();
    }
}