using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.SeguridadSist.Usuario
{

    public interface IModoUsuario : IModo
    {

        void setUsuarioValidar(enumerados.enumTipo usu);

    }

}