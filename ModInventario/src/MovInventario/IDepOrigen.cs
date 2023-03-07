using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario
{
    public interface IDepOrigen
    {
        BindingSource GetDepOrigen_Source { get; }
        string GetDepOrigen_Id { get; }
        void setDepOrigen(string id);
    }
}