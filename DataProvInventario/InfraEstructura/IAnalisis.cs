using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    
    public interface IAnalisis
    {

        OOB.ResultadoLista<OOB.LibInventario.Analisis.General.Ficha> Producto_Analisis_General(OOB.LibInventario.Analisis.General.Filtro filtro);
        OOB.ResultadoLista<OOB.LibInventario.Analisis.Detallado.Ficha> Producto_Analisis_Detallado(OOB.LibInventario.Analisis.Detallado.Filtro filtro);
        OOB.ResultadoLista<OOB.LibInventario.Analisis.Existencia.Ficha> Producto_Analisis_Existencia(OOB.LibInventario.Analisis.Existencia.Filtro filtro);

    }

}