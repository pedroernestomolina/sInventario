using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario
{
    
    public interface ISeguridadAccesoSistema
    {

        bool Verificar(OOB.LibInventario.Permiso.Ficha ficha);
    }

}