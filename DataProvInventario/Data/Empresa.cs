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

        public OOB.ResultadoLista<OOB.LibInventario.Empresa.Grupo.Lista.Ficha> 
            EmpresaGrupo_GetLista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Empresa.Grupo.Lista.Ficha>();

            var r01 = MyData.EmpresaGrupo_GetLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var _lst = new List<OOB.LibInventario.Empresa.Grupo.Lista.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    _lst = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Empresa.Grupo.Lista.Ficha()
                        {
                            descripcion = s.descripcion,
                            idGrupo = s.idGrupo,
                        };
                    }).ToList();
                }
            }
            rt.Lista = _lst;

            return rt;
        }
        public OOB.ResultadoEntidad<string> 
            EmpresaGrupo_PrecioManejar_GetById(string idGrupo)
        {
            var rt = new OOB.ResultadoEntidad<string>();

            var r01 = MyData.EmpresaGrupo_PrecioManejar_GetById(idGrupo);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Entidad = r01.Entidad;

            return rt;
        }

    }

}