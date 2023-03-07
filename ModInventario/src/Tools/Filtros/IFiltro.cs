using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Tools.Filtros
{
    public interface IFiltro
    {
        BindingSource GetSource { get; }
        ficha GetItem { get; }
        string GetId { get; }
        bool GetHabilitar { get; }

        void setId(string id);
        void setHabilitar(bool hab);

        void Inicializa();
        void CargarData();
    }
}