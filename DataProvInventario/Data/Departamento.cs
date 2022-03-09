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

        public OOB.ResultadoLista<OOB.LibInventario.Departamento.Ficha> Departamento_GetLista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Departamento.Ficha>();

            var r01 = MyData.Departamento_GetLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Departamento.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Departamento.Ficha()
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

        public OOB.ResultadoEntidad<OOB.LibInventario.Departamento.Ficha> Departamento_GetFicha(string auto)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Departamento.Ficha>();

            var r01 = MyData.Departamento_GetFicha(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Departamento.Ficha()
            {
                auto = s.auto,
                codigo = s.codigo,
                nombre = s.nombre,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoAuto Departamento_Agregar(OOB.LibInventario.Departamento.Agregar ficha)
        {
            var rt = new OOB.ResultadoAuto();

            var fichaDTO = new DtoLibInventario.Departamento.Agregar()
            {
                nombre = ficha.nombre,
                codigo = ficha.codigo,
            };
            var r01 = MyData.Departamento_Agregar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Auto = r01.Auto;

            return rt;
        }

        public OOB.Resultado Departamento_Editar(OOB.LibInventario.Departamento.Editar ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibInventario.Departamento.Editar()
            {
                auto = ficha.auto,
                nombre = ficha.nombre,
                codigo = ficha.codigo,
            };
            var r01 = MyData.Departamento_Editar (fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.Resultado Departamento_Eliminar(string auto)
        {
            var rt = new OOB.Resultado();

            var r01 = MyData.Departamento_Eliminar(auto);
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