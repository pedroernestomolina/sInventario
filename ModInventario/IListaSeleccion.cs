using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario
{
    
    public interface IListaSeleccion: IGestion
    {

        bool ItemSeleccionadoIsOk { get; }


        void setPermitirSeleccionarInactivos(bool op);
        void setCerrarVentanaAlSeleccionarItem(bool op);

    }

}
