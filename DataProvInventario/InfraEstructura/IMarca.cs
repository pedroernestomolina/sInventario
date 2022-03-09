using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    
    public interface IMarca
    {

        OOB.ResultadoLista<OOB.LibInventario.Marca.Ficha> Marca_GetLista();
        OOB.ResultadoEntidad<OOB.LibInventario.Marca.Ficha> Marca_GetFicha(string auto);
        OOB.ResultadoAuto Marca_Agregar(OOB.LibInventario.Marca.Agregar ficha);
        OOB.Resultado Marca_Editar(OOB.LibInventario.Marca.Editar ficha);
        OOB.Resultado Marca_Eliminar(string auto);

    }

}
