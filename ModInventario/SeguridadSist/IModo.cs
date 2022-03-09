using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.SeguridadSist
{

    public interface IModo
    {

        string Titulo { get; }


        void setClave(string p);
        void Inicializa();
        bool AceptarVerificar();

    }

}