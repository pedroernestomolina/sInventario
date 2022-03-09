using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MovimientoInv.AjusteInvCero
{

    public interface IItem
    {

        BindingSource Source { get; }
        int CntItem { get; }
        List<item> Items { get; }
        decimal TotalImporteMonedaLocal { get; }


        void Inicializa();
        void setData(List<OOB.LibInventario.Movimiento.AjusteInvCero.Capture.Data> list);
        void Limpiar();

    }

}