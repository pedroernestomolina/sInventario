using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Gestion
{
    
    public interface IProcesarSalir
    {

        bool ProcesarSalirIsOk { get; }
        void ProcesarSalir();

    }

}