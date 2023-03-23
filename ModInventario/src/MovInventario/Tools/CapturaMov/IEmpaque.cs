using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Tools.CapturaMov
{
    public interface IEmpaque
    {
        BindingSource GetSource { get; }
        string GetId { get; }
        ficha GetItem { get;  }

        void setEmpaque(string id);
        void Inicializa();
        void CargarData();
    }
}