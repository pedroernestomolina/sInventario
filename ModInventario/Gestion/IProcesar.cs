using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Gestion
{
    
    public interface IProcesar
    {

        bool ProcesarIsOk { get; }
        void ProcesarFicha();

    }

}