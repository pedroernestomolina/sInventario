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

        public OOB.ResultadoLista<OOB.LibInventario.TasaImpuesto.Ficha> TasaImpuesto_GetLista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.TasaImpuesto.Ficha>();

            var r01 = MyData.TasaImpuesto_GetLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
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

    }

}
