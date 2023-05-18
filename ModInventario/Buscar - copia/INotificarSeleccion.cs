using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Buscar
{

    public interface INotificarSeleccion: IListaSeleccion
    {

        event EventHandler NotificarSeleccion;


        void setActivarNotificacion(bool valor);

    }

}