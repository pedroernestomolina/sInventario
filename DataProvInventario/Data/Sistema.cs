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

        public OOB.ResultadoEntidad<OOB.LibInventario.Sistema.TipoDocumento.Entidad.Ficha> 
            Sistema_TipoDocumento_GetFichaByTipo(OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento tipo)
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
        public OOB.ResultadoLista<OOB.LibInventario.Sistema.HndPrecios.Lista.Ficha> 
            Sistema_TipoPreciosDefinidos_Lista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Sistema.HndPrecios.Lista.Ficha>();

            var r01 = MyData.Sistema_TipoPreciosDefinidos_Lista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.LibInventario.Sistema.HndPrecios.Lista.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0) 
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibInventario.Sistema.HndPrecios.Lista.Ficha()
                        {
                            descripcion = s.descripcion,
                            codigo = s.codigo,
                            id = s.id.ToString(),
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = lst;

            return rt;
        }

    }

}