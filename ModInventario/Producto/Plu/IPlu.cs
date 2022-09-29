using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Plu
{
    
    public interface IPlu: IGestion, ModInventario.Gestion.IAbandonar
    {

        BindingSource GetSource { get; }
        int GetCntItems { get; }

    }

}