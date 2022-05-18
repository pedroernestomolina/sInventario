using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.SeguridadSist.Usuario
{

    public class Gestion : IModoUsuario
    {


        private string _clave;
        private enumerados.enumTipo _usuarioValidar;


        public string Titulo
        {
            get
            {
                var rt = "";
                if (_usuarioValidar != enumerados.enumTipo.SinDefinir)
                    switch (_usuarioValidar)
                    { 
                        case enumerados.enumTipo.Actual :
                            rt = "Clave Usuario ACTUAL";
                            break;
                        case enumerados.enumTipo.Administrador:
                            rt = "Clave Usuario ADMINISTRADOR";
                            break;
                        case enumerados.enumTipo.GrupoAdministrador:
                            rt = "Clave Usuario QUE PERTENEZCA AL GRUPO ADMINISTRADOR";
                            break;
                    }
                return rt;
            }
        }


        public Gestion()
        {
            _usuarioValidar = enumerados.enumTipo.SinDefinir;
            _clave = "";
        }


        public void setClave(string p)
        {
            _clave = p;
        }

        public void Inicializa()
        {
            _clave = "";
        }

        public bool AceptarVerificar()
        {
            var idUsuario = "";
            if (_usuarioValidar == enumerados.enumTipo.SinDefinir)
            {
                Helpers.Msg.Alerta("NO SE HA DEFINIDO EL TIPO DE USUARIO A VALIDAR");
                return false;
            }
            if (_usuarioValidar == enumerados.enumTipo.Actual)
            {
                idUsuario = Sistema.UsuarioP.autoUsu;
            }
            if (_usuarioValidar == enumerados.enumTipo.Administrador)
            {
                idUsuario = Sistema.ID_USUARIO_ADMINISTRADOR;
            }
            if (_usuarioValidar == enumerados.enumTipo.GrupoAdministrador)
            {
                var rt1 = Sistema.MyData.Usuario_GetId_ByClaveUsuGrupoAdm(_clave);
                if (rt1.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(rt1.Mensaje);
                    return false;
                }
                if (rt1.Entidad == "")
                {
                    Helpers.Msg.Error("CLAVE NO REGISTRADA PARA NINGUN USUARIO TIPO ADMINISTRADOR, VERIFIQUE POR FAVOR");
                    return false;
                }
                else 
                {
                    return true;
                }
            }

            var r01 = Sistema.MyData.Usuario_GetClave_ById(idUsuario);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            if (_clave == r01.Entidad)
                return true;
            else
            {
                Helpers.Msg.Error("CLAVE INCORRECTA, VERIFIQUE POR FAVOR");
                return false;
            }

        }

        public void setUsuarioValidar(enumerados.enumTipo usu)
        {
            _usuarioValidar = usu;
        }

    }

}