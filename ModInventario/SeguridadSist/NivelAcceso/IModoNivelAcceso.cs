using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.SeguridadSist.NivelAcceso
{

    public interface IModoNivelAcceso : IModo
    {

        void setTipoAcceso(OOB.LibInventario.Permiso.Ficha ficha);

    }

}