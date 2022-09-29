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

        public OOB.ResultadoLista<OOB.LibInventario.TasaImpuesto.Ficha> 
            TasaImpuesto_GetLista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.TasaImpuesto.Ficha>();

            var r01 = MyData.TasaImpuesto_GetLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }

            var list = new List<OOB.LibInventario.TasaImpuesto.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.TasaImpuesto.Ficha()
                        {
                            auto = s.auto,
                            tasa = s.tasa,
                            nombre = s.nombre,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.TasaImpuesto.Ficha> 
            TasaImpuesto_GetById(string id)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.TasaImpuesto.Ficha>();

            var r01 = MyData.TasaImpuesto_GetById(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            rt.Entidad = new OOB.LibInventario.TasaImpuesto.Ficha()
                        {
                            auto = r01.Entidad.auto,
                            tasa = r01.Entidad.tasa,
                            nombre = r01.Entidad.nombre,
                        };
            return rt;
        }

    }

}
