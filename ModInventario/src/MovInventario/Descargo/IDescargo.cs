using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Descargo
{
    public interface IDescargo: IMov
    {
        void SucOrigenSetId(string id);
    }
}