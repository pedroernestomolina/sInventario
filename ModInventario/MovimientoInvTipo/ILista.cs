using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MovimientoInvTipo
{
    
    public interface ILista
    {

        BindingSource Source { get; }
        int CntItem { get; }
        List<dataItem> Items { get; }
        decimal TotalImporte { get; }
        dataItem ItemActual { get; }


        void Inicializa();
        void setItemAgregar(dataItem item);
        void setItemEliminar(int idItem);
        void setListaAgregar(List<dataItem> list);
        void setActualizarItem(int idItemEditar, dataItem dataItem);
        void setEliminarExistenciaNoDisponible();
        void Limpiar();


        bool EncuentraItemPrd(string p);
    }

}