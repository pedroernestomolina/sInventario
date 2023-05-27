using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Producto.ActualizarOfertaMasiva.Items
{
    public interface IItems
    {
        int GetCnt { get; }
        BindingSource GetSource { get; }
        IEnumerable<data> GetLista { get; }

        void Inicializa();
        void LimpiarTodo();

        void setData(List<data> _lst);
    }
}