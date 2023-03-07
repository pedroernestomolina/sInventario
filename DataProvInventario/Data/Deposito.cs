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
        public OOB.ResultadoLista<OOB.LibInventario.Deposito.Ficha> 
            Deposito_GetLista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Deposito.Ficha>();
            var r01 = MyData.Deposito_GetLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var list = new List<OOB.LibInventario.Deposito.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Deposito.Ficha()
                        {
                            auto = s.auto.Trim(),
                            codigo = s.codigo.Trim(),
                            nombre = s.nombre.Trim(),
                            estatusActivo = s.estatusActivo.Trim(),
                            estatusPredeterminado = s.estatusPreDeterminado.Trim(),
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Deposito.Ficha> 
            Deposito_GetFicha(string autoDep)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Deposito.Ficha>();

            var r01 = MyData.Deposito_GetFicha(autoDep);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Deposito.Ficha()
            {
                auto = s.auto,
                codigo = s.codigo,
                nombre = s.nombre,
                autoSucursal = s.autoSucursal,
                codigoSucursal = s.codigoSucursal,
                nombreSucursal = s.nombreSucursal,
            };
            rt.Entidad= nr;

            return rt;
        }
        public OOB.ResultadoLista<OOB.LibInventario.Deposito.Ficha> 
            Deposito_GetListaBySucursal(string codSuc)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Deposito.Ficha>();
            var r01 = MyData.Deposito_GetListaBySucursal(codSuc);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            var list = new List<OOB.LibInventario.Deposito.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Deposito.Ficha()
                        {
                            auto = s.auto,
                            codigo = s.codigo,
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