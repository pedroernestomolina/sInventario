using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    public interface IConcepto
    {
        OOB.ResultadoLista<OOB.LibInventario.Concepto.Ficha> 
            Concepto_GetLista();
        OOB.ResultadoEntidad<OOB.LibInventario.Concepto.Ficha> 
            Concepto_GetFicha(string auto);
        OOB.ResultadoAuto
            Concepto_Agregar(OOB.LibInventario.Concepto.Agregar ficha);
        OOB.Resultado 
            Concepto_Editar(OOB.LibInventario.Concepto.Editar ficha);
        OOB.ResultadoEntidad<OOB.LibInventario.Concepto.Ficha> 
            Concepto_PorTraslado();
        OOB.Resultado 
            Concepto_Eliminar(string auto);
    }
}