using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.FiltroBusqAdm.PorCategoria
{
    public interface ICategoria
    {
        BindingSource SourceCategoria { get; }
        string GetIdCategoria { get; }

        void Inicializa();
        void setIdCategoria(string id);
    }
}