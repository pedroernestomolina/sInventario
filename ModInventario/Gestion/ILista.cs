using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Gestion
{
    
    public interface ILista
    {

        BindingSource Source { get; }
        int CntItem { get; }
        object ItemActual { get;  }


        void Inicializa();
        void setData(IEnumerable<object> data);

    }

}