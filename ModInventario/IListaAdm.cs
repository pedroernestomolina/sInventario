using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario
{
    
    public interface IListaAdm
    {

        BindingSource Source { get; }
        int CntItems { get; }
        IEnumerable <object> Items { get; }
        object ItemActual { get; }


        void Inicializa();
        void ActAgreagatItem (object  item);
        void ActEliminarItem(object item);
        void ActAgregarListaItem(IEnumerable<object> lst);
        void ActActualizarItem(object itemActual, object itemNuevo);
        void ActLimpiarLista();

    }

}