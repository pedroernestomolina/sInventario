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
                    rt = _usuarioValidar == enumerados.enumTipo.Actual ? "Clave Usuario ACTUAL" : "Clave Usuario ADMINISTRADOR";
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
                idUsuario = Sistema.UsuarioP.autoUsu;
            if (_usuarioValidar == enumerados.enumTipo.Administrador)
                idUsuario = Sistema.ID_USUARIO_ADMINISTRADOR;
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