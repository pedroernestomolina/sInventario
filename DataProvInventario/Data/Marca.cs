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
        public OOB.ResultadoLista<OOB.LibInventario.Marca.Ficha> 
            Marca_GetLista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Marca.Ficha>();
            var r01 = MyData.Marca_GetLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var list = new List<OOB.LibInventario.Marca.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Marca.Ficha()
                        {
                            auto = s.auto.Trim(),
                            nombre = s.nombre.Trim(),
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;
            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Marca.Ficha> 
            Marca_GetFicha(string auto)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Marca.Ficha>();
            var r01 = MyData.Marca_GetFicha(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Marca.Ficha()
            {
                auto = s.auto,
                nombre = s.nombre,
            };
            rt.Entidad = nr;
            return rt;
        }
        public OOB.ResultadoAuto 
            Marca_Agregar(OOB.LibInventario.Marca.Agregar ficha)
        {
            var rt = new OOB.ResultadoAuto();
            var fichaDTO = new DtoLibInventario.Marca.Agregar()
            {
                nombre = ficha.nombre,
            };
            var r01 = MyData.Marca_Agregar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Auto = r01.Auto;
            return rt;
        }
        public OOB.Resultado 
            Marca_Editar(OOB.LibInventario.Marca.Editar ficha)
        {
            var rt = new OOB.Resultado();
            var fichaDTO = new DtoLibInventario.Marca.Editar()
            {
                auto = ficha.auto,
                nombre = ficha.nombre,
            };
            var r01 = MyData.Marca_Editar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            return rt;
        }
        public OOB.Resultado 
            Marca_Eliminar(string auto)
        {
            var rt = new OOB.Resultado();
            var r01 = MyData.Marca_Eliminar(auto);
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