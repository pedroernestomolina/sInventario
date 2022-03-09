using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.FiltrosGen
{
    
    public interface IBuscar
    {

        bool ItemIsOk { get; }
        string DescItemSeleccionado { get; }
        ficha ItemSeleccionado { get; }


        void setCadenaBuscar(string cadena);
        void Buscar();
        void LimpiarItem();
        void Inicializa();

    }

}