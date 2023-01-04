using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Identificacion
{
    
    public interface ILogin: IGestion
    {
        string GetCodigo { get; }
        string GetClave { get; }
        bool UsuarioIsOk { get; }
        bool LoginIsOK { get; }

        void setCodigoUsu(string usu);
        void setClaveUsu(string psw);
    }

}