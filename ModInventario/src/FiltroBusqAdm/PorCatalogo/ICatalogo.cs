using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.FiltroBusqAdm.PorCatalogo
{
    public interface ICatalogo
    {
        BindingSource SourceCatalogo { get; }
        string GetIdCatalogo { get; }

        void Inicializa();
        void setIdCatalogo(string id);
    }
}