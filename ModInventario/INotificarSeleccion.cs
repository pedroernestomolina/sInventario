using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario 
{

    public interface INotificarSeleccion
    {

        event EventHandler NotificarSeleccion;


        void setActivarNotificacion(bool valor);

    }

}