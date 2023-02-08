using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.FiltroBusqAdm.PorTCS
{
    public interface ITCS
    {
        BindingSource SourceTCS { get; }
        string GetIdTCS { get; }

        void Inicializa();
        void setIdTCS(string id);
    }
}