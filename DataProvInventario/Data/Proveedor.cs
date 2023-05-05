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
        public OOB.ResultadoLista<OOB.LibInventario.Proveedor.Lista.Ficha> 
            Proveedor_GetLista(OOB.LibInventario.Proveedor.Lista.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Proveedor.Lista.Ficha>();
            var filtroDto = new DtoLibInventario.Proveedor.Lista.Filtro ()
            {
                cadena = filtro.cadena,
                MetodoBusqueda = (DtoLibInventario.Proveedor.Enumerados.EnumMetodoBusqueda)filtro.MetodoBusqueda,
            };
            var r01 = MyData.Proveedor_GetLista (filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Proveedor.Lista.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        var id = new OOB.LibInventario.Proveedor.Lista.Ficha ();
                        id.auto = s.auto;
                        id.codigo = s.codigo;
                        id.nombreRazonSocial = s.nombreRazonSocial;
                        id.ciRif = s.ciRif;
                        return id;
                    }).ToList();
                }
            }
            rt.Lista = list;
            return rt;
        }
    }
}