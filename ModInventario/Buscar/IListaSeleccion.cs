using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Buscar
{
    
    public interface IListaSeleccion
    {

        bool ItemSeleccionadoIsOk { get; }
        ModInventario.fichaSeleccion ItemSeleccionado { get; }


        void Inicializa();
        void setLista(List<fichaSeleccion> list);
        void setPermitirSeleccionarInactivos(bool op);
        void setCerrarVentanaAlSeleccionarItem(bool op);
        void Inicia();

    }

}