using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.MaestrosInv
{

    public interface ILista
    {

        int CntItems { get; }
        System.Windows.Forms.BindingSource Source { get; }
        data ItemActual { get; }

        void setLista(List<data> lst);
        void Agregar(data data);
        void Actualizar(data data);
        void Inicializa();
        void EliminarItemActual();

    }

}