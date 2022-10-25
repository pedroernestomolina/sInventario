using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.AnularDoc
{
    
    public interface IAnular: IGestion, Gestion.IAbandonar, Gestion.IProcesar
    {

        string GetMotivo_Desc { get; }
        void setMotivo(string desc);
        bool AnularIsOK { get; }

    }

}