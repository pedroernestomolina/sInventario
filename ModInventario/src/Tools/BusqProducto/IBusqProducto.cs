using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Tools.BusqProducto
{
    public interface IBusqProducto
    {
        BindingSource GetSource { get; }
        string GetId { get; }
        string GetCadenaBusq { get; }
        void setCadenaBusqueda(string cadBusq);
        void setMetodoBusq(string id);
        void Inicializa();
        void CargarData();
        void ActivarFiltros();
        void LimpiarFiltros();
        OOB.LibInventario.Producto.Filtro BuscarFiltros();
        void setHabilitarFiltroDeposito(bool act);
        void LimpiarCargarMetBusPreferido();
    }
}