using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Tools.CapturaMov
{
    public interface ITipMov
    {
        BindingSource GetSource { get; }
        string GetId { get; }
        ficha GetItem { get; }

        void setTipMov(string id);
        void Inicializa();
        void CargarData();
    }
}