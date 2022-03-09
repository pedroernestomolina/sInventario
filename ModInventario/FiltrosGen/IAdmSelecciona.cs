using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.FiltrosGen
{

    public interface IAdmSelecciona
    {

        event EventHandler NotificarSeleccion;


        bool ItemSeleccionadoIsOk { get; }
        ficha ItemSeleccionado { get; }
        int MetBusqueda { get; }
        string CadenaBusqueda { get; }


        void Inicializa();
        void Inicia();
        void BuscarSeleccionar();
        void setCadenaBusq(string cadena);
        void setMetBusqByCodigo();
        void setMetBusqByNombre();
        void setMetBusqByReferencia();

    }

}