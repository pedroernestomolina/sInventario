using DataProvInventario.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.Data
{
    
    public partial class DataProv: IData
    {

        public OOB.ResultadoEntidad<OOB.LibInventario.Sistema.TipoDocumento.Entidad.Ficha> Sistema_TipoDocumento_GetFichaByTipo(OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento tipo)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Sistema.TipoDocumento.Entidad.Ficha>();

            var id = "";
            switch (tipo) 
            {
                case OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.CARGO:
                    id = "0000000024";
                    break;
                case OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.DESCARGO:
                    id = "0000000025";
                    break;
                case OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.TRASLADO:
                    id = "0000000026";
                    break;
                case OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.AJUSTE:
                    id = "0000000042";
                    break;
            }
            var r01 = MyData.Sistema_TipoDocumento_GetFichaById(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Sistema.TipoDocumento.Entidad.Ficha()
            {
                autoId = s.autoId,
                codigo = s.codigo,
                nombre = s.nombre,
                siglas = s.siglas,
                signo = s.signo,
                tipo = s.tipo,
            };
            rt.Entidad = nr;

            return rt;
        }

    }

}