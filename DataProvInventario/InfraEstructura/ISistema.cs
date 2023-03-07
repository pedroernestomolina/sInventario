using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    public interface ISistema
    {
        OOB.ResultadoEntidad<OOB.LibInventario.Sistema.TipoDocumento.Entidad.Ficha> 
            Sistema_TipoDocumento_GetFichaByTipo(OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento tipo);
        OOB.ResultadoLista<OOB.LibInventario.Sistema.HndPrecios.Lista.Ficha>
            Sistema_TipoPreciosDefinidos_Lista();
    }
}