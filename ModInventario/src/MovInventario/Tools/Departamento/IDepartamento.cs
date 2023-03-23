using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Tools.Departamento
{
    public interface IDepartamento
    {
        BindingSource GetSource { get; }
        string GetId { get; }
        object GetItem { get; }

        void setId(string id);

        void Inicializa();
        void CargarData();
    }
}