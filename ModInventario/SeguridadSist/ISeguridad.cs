using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.SeguridadSist
{

    public interface ISeguridad : IGestion
    {

        bool IsOk { get; }


        void setGestionTipo(IModo gestion);

    }

}