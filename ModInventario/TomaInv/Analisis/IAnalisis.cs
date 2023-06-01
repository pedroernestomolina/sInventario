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

        void setTomaInvAnalizar(int idToma);
        void EliminarTomas();
        void setMarcarTodas(bool m);
    }
}
