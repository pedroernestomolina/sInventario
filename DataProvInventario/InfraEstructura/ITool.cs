using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    
    public interface ITool
    {

        OOB.ResultadoLista<OOB.LibInventario.Tool.AjusteNivelMinimoMaximoProducto.Capturar.Ficha> 
            Tools_AjusteNivelMinimoMaximo_GetLista(OOB.LibInventario.Tool.AjusteNivelMinimoMaximoProducto.Capturar.Filtro filtro);

        OOB.Resultado Tools_AjusteNivelMinimoMaximo_Ajustar(List<OOB.LibInventario.Tool.AjusteNivelMinimoMaximoProducto.Ajustar.Ficha> lista);

    }

}