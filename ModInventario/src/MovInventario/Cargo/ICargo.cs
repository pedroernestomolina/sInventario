using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Cargo
{
    public interface ICargo: IMov
    {
        void SucOrigenSetId(string id);
    }
}