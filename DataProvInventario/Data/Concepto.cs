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

        OOB.ResultadoEntidad<OOB.LibInventario.Concepto.Ficha> IConcepto.Concepto_PorTraslado()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Concepto.Ficha>();

            var r01 = MyData.Concepto_PorTraslado();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Concepto.Ficha()
            {
                auto = s.auto,
                codigo = s.codigo,
                nombre = s.nombre,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibInventario.Concepto.Ficha> Concepto_GetLista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Concepto.Ficha>();

            var r01 = MyData.Concepto_GetLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Concepto.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Concepto.Ficha()
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

        public OOB.ResultadoEntidad<OOB.LibInventario.Concepto.Ficha> Concepto_GetFicha(string auto)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Concepto.Ficha>();

            var r01 = MyData.Concepto_GetFicha(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Concepto.Ficha()
            {
                auto = s.auto,
                codigo = s.codigo,
                nombre = s.nombre,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoAuto Concepto_Agregar(OOB.LibInventario.Concepto.Agregar ficha)
        {
            var rt = new OOB.ResultadoAuto();

            var fichaDTO = new DtoLibInventario.Concepto.Agregar()
            {
                nombre = ficha.nombre,
                codigo = ficha.codigo,
            };
            var r01 = MyData.Concepto_Agregar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Auto = r01.Auto;

            return rt;
        }

        public OOB.Resultado Concepto_Editar(OOB.LibInventario.Concepto.Editar ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibInventario.Concepto.Editar()
            {
                auto = ficha.auto,
                nombre = ficha.nombre,
                codigo = ficha.codigo,
            };
            var r01 = MyData.Concepto_Editar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.Resultado Concepto_Eliminar(string auto)
        {
            var rt = new OOB.Resultado();

            var r01 = MyData.Concepto_Eliminar(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

    }

}