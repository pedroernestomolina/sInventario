using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.FiltrosGen
{
    
    public interface IFiltro
    {


        void Inicializa();
        void Inicia();
        void LimpiarFiltros();
        bool DataFiltrarIsOk();

    }

}