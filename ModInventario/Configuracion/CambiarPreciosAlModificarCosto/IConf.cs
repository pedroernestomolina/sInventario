using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Configuracion.CambiarPreciosAlModificarCosto
{
    
    public interface IConf: IGestion, Gestion.IAbandonar, Gestion.IProcesar
    {

        bool GetOpcion { get; }
        void setOpcion();

    }

}