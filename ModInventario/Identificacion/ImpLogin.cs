using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Identificacion
{
    
    public class ImpLogin: ILogin
    {


        private string _codUsu;
        private string _pswUsu;
        private bool _loginIsOk;


        public string GetCodigo { get { return _codUsu; } }
        public string GetClave { get { return _pswUsu; } }
        public bool UsuarioIsOk { get { return VerificarUsuario(); } }
        public bool LoginIsOK { get { return _loginIsOk; } }
        
        
        public ImpLogin()
        {
            _codUsu = "";
            _pswUsu = "";
            _loginIsOk = false;
        }


        public void Inicializa()
        {
            _codUsu = "";
            _pswUsu = "";
            _loginIsOk = false;
        }
        Identificacion.IdentificacionFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new Identificacion.IdentificacionFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public void setCodigoUsu(string usu)
        {
            _codUsu = usu;
        }
        public void setClaveUsu(string psw)
        {
            _pswUsu = psw;
        }


        private bool VerificarUsuario()
        {
            _loginIsOk = false;
            try
            {
                var ficha = new OOB.LibInventario.Usuario.Buscar.Ficha() { Clave = _pswUsu, Codigo = _codUsu, };
                var r01 = Sistema.MyData.Usuario_Cargar(ficha);
                var r02 = Sistema.MyData.Permiso_ToolInventario(r01.Entidad.autoGru);
                if (r02.Entidad.IsHabilitado)
                {
                    var fichaSesion = new OOB.LibInventario.Usuario.ActualizarSesion.Ficha() 
                    { 
                        autoUsu = r01.Entidad.autoUsu, 
                    };
                    var r03 = Sistema.MyData.Usuario_ActualizarSesion(fichaSesion);
                    Sistema.UsuarioP = r01.Entidad;
                    _loginIsOk = true;
                    return true;
                }
                else
                {
                    throw new Exception("PERMISO DENEGADO");
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }


        private bool CargarData()
        {
            return true;
        }

    }

}