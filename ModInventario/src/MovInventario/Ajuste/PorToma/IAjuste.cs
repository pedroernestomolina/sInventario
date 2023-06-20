
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.MovInventario.Ajuste.PorToma
{
    public interface IAjuste:IMov
    {
        void SucOrigenSetId(string id);
        void BuscarTomas();
    }
}