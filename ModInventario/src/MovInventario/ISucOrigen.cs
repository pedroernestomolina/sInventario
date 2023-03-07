using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario
{
    public interface ISucOrigen
    {
        BindingSource GetSucOrigen_Source { get; }
        string GetSucOrigen_Id { get; }
        void setSucOrigen(string id);
    }
}