using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MovimientoInvTipo
{

    public interface ICapturaMovAjuste: ICaptura
    {


        BindingSource TipoMovSource { get; }
        string TipoMovGetID { get; }
        void setTipoMov(string id);


    }

}