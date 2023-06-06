using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    public interface IDeposito
    {
        OOB.ResultadoLista<OOB.LibInventario.Deposito.Ficha> 
            Deposito_GetLista();
        OOB.ResultadoLista<OOB.LibInventario.Deposito.Ficha> 
            Deposito_GetListaBySucursal(string codSuc);
        OOB.ResultadoEntidad<OOB.LibInventario.Deposito.Ficha> 
            Deposito_GetFicha(string autoDep);
    }
}