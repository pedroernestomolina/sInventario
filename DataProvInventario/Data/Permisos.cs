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

        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_CrearProducto(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();  

            var r01 = MyData.Permiso_CrearProducto(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_ModificarProducto(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_ModificarProducto(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_CambiarPrecios(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_CambiarPrecios(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_CambiarCostos(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_CambiarCostos(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_AsignarDepositos(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_AsignarDepositos(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_CambiarDatosDelDeposito(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_CambiarDatosDelDeposito(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_ActualizarEstatusDelProducto(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_ActualizarEstatusDelProducto(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_CambiarImagenDelProducto(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_CambiarImagenDelProducto(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }


        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_Departamento(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_Departamento(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_CrearDepartamento(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_CrearDepartamento (autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_ModificarDepartamento(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_ModificarDepartamento (autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_EliminarDepartamento(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_EliminarDepartamento(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_Grupo(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_Grupo(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_CrearGrupo(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_CrearGrupo (autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_ModificarGrupo(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_ModificarGrupo (autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_EliminarGrupo(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_EliminarGrupo(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_Marca(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_Marca(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_CrearMarca(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_CrearMarca (autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_ModificarMarca(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_ModificarMarca (autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_EliminarMarca(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_EliminarMarca(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_UnidadEmpaque(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_UnidadEmpaque(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_CrearUnidadEmpaque(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_CrearUnidadEmpaque (autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_ModificarUnidadEmpaque(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_ModificarUnidadEmpaque (autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_EliminarUnidadEmpaque(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_EliminarUnidadEmpaque(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_ConceptoInventario(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_ConceptoInventario(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_CrearConceptoInventario(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_CrearConceptoInventario (autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_ModificarConceptoInventario(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_ModificarConceptoInventario (autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_EliminarConceptoInventario(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_EliminarConceptoInventario(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }


        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_ToolInventario(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_ToolInventario(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }


        public OOB.ResultadoEntidad<string> Permiso_PedirClaveAcceso_NivelMaximo()
        {
            var rt = new OOB.ResultadoEntidad<string>();

            var r01 = MyData.Permiso_PedirClaveAcceso_NivelMaximo();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Entidad = r01.Entidad;

            return rt;
        }
        public OOB.ResultadoEntidad<string> Permiso_PedirClaveAcceso_NivelMedio()
        {
            var rt = new OOB.ResultadoEntidad<string>();

            var r01 = MyData.Permiso_PedirClaveAcceso_NivelMedio();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Entidad = r01.Entidad;

            return rt;
        }
        public OOB.ResultadoEntidad<string> Permiso_PedirClaveAcceso_NivelMinimo()
        {
            var rt = new OOB.ResultadoEntidad<string>();

            var r01 = MyData.Permiso_PedirClaveAcceso_NivelMinimo();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Entidad = r01.Entidad;

            return rt;
        }


        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_MovimientoCargoInventario(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_MovimientoCargoInventario(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_MovimientoDescargoInventario(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_MovimientoDescargoInventario(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_MovimientoTrasladoInventario(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_MovimientoTrasladoInventario(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_MovimientoTrasladoPorDevolucion(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_MovimientoTrasladoPorDevolucionInventario(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_MovimientoAjusteInventario(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_MovimientoAjusteInventario(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_AdministradorMovimientoInventario(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_AdministradorMovimientoInventario(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_AdmAnularMovimientoInventario(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_AdmAnularMovimientoInventario(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_AdmVisualizarMovimientoInventario(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_AdmVisualizarMovimientoInventario(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_AdmReporteMovimientoInventario(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_AdmReporteMovimientoInventario(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_MovimientoAjusteInventarioCero(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_MovimientoAjusteInventarioCero(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_DefinirNivelMinimoMaximoInventario(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_DefinirNivelMinimoMaximoInventario(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_MovimientoTrasladoEntreSucursales_PorExistenciaDebajoDelMinimo(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_MovimientoTrasladoEntreSucursales_PorExistenciaDebajoDelMinimo(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_Reportes(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_Reportes(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_Visor(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_Visor(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_Estadistica(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_Estadistica(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }


        public OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_ConfiguracionSistema(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>();

            var r01 = MyData.Permiso_Configuracion_Sistema(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

    }

}