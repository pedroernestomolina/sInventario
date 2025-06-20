using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.__.interfaces
{
    public interface IBoton
    {
        bool ResultIsOK { get; }
        void Inicializa();
        void Execute();
    }
}