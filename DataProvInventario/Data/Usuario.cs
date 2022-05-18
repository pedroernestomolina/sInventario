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

        public OOB.ResultadoEntidad<OOB.LibInventario.Usuario.Ficha> Usuario_Principal()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Usuario.Ficha>();

            var r01 = MyData.Usuario_Principal();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Usuario.Ficha()
            {
                autoUsu = s.autoUsu,
                codigoUsu = s.codigoUsu,
                nombreUsu = s.nombreUsu,
                apellidoUsu = s.apellidoUsu,
                isActivo = s.isActivo,
                autoGru = s.autoGru,
                NombreGru = s.nombreGru,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Usuario.Ficha> Usuario_Cargar(OOB.LibInventario.Usuario.Buscar.Ficha ficha)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Usuario.Ficha>();

            var fichaBuscar= new DtoLibInventario.Usuario.Buscar.Ficha()
            {
                codigo= ficha.Codigo,
                clave= ficha.Clave,
            };
            var r01 = MyData.Usuario_Buscar(fichaBuscar);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var u = r01.Entidad;
            var nr = new OOB.LibInventario.Usuario.Ficha()
            {
                autoUsu = u.autoUsu,
                codigoUsu = u.codigoUsu,
                nombreUsu = u.nombreUsu,
                apellidoUsu = u.apellidoUsu,
                isActivo = u.isActivo,
                autoGru = u.autoGru,
                NombreGru = u.nombreGru,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.Resultado Usuario_ActualizarSesion(OOB.LibInventario.Usuario.ActualizarSesion.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibInventario.Usuario.ActualizarSesion.Ficha()
            {
                autoUsu = ficha.autoUsu
            };
            var r01 = MyData.Usuario_ActualizarSesion(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }
        public OOB.ResultadoEntidad<string> 
            Usuario_GetClave_ById(string idUsuario)
        {
            var rt = new OOB.ResultadoEntidad<string>();

            var r01 = MyData.Usuario_GetClave_ById(idUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Entidad = r01.Entidad;

            return rt;
        }
        public OOB.ResultadoEntidad<string>
            Usuario_GetId_ByClaveUsuGrupoAdm(string clave)
        {
            var rt = new OOB.ResultadoEntidad<string>();

            var r01 = MyData.Usuario_GetId_ByClaveUsuGrupoAdm(clave);
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