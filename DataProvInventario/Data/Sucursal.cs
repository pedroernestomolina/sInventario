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

        public OOB.ResultadoLista<OOB.LibInventario.Sucursal.Ficha> 
            Sucursal_GetLista(OOB.LibInventario.Sucursal.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Sucursal.Ficha>();

            var filtroDTo = new DtoLibInventario.Sucursal.Filtro() { idEmpresaGrupo = filtro.idEmpresaGrupo };
            var r01 = MyData.Sucursal_GetLista(filtroDTo);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }

            var list = new List<OOB.LibInventario.Sucursal.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Sucursal.Ficha()
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
        public OOB.ResultadoEntidad<OOB.LibInventario.Sucursal.Ficha> 
            Sucursal_GetFicha(string auto)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Sucursal.Ficha>();

            var r01 = MyData.Sucursal_GetFicha(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Sucursal.Ficha()
            {
                auto = s.auto,
                codigo = s.codigo,
                nombre = s.nombre,
                autoDepositoPrincipal = s.autoDepositoPrincipal,
                codigoDepositoPrincipal = s.codigoDepositoPrincipal,
                nombreDepositoPrincipal = s.nombreDepositoPrincipal,
                autoEmpresaGrupo = s.autoEmpresaGrupo,
                nombreEmpresaGrupo = s.nombreEmpresaGrupo,
            };
            rt.Entidad = nr;

            return rt;
        }

    }

}