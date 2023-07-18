using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.TomaInv.GenerarConteo
{
    public interface IConteo
    {
        bool GenerarConteoIsOk { get; }
        void GenerarConteo();
    }
}