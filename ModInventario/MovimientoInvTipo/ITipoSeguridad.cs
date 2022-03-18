using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.MovimientoInvTipo
{
    
    public interface ITipoSeguridad: ITipo
    {

        void setModoSeguridad(SeguridadSist.IModo _gSecurityModoUsuario);

    }

}