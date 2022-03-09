using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    
    public interface IProveedor
    {

        OOB.ResultadoLista<OOB.LibInventario.Proveedor.Lista.Ficha> Proveedor_GetLista(OOB.LibInventario.Proveedor.Lista.Filtro filtro);

    }

}