using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.MovimientoInvTipo.Transito
{
    
    public interface ITransito: IGestion, IListaSeleccion, INotificarSeleccion
    {

        data ItemSeleccionado { get; }
        void setLista(List<data> list);
        void Limpiar();

    }

}