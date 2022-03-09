using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.MovimientoInv
{

    public interface IGestionMov : IGestion
    {


        void setGestion(IMov ctr);
        void Finaliza();

    }

}