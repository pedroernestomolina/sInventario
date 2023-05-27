using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Utils.FiltrosPara.BusqProducto.Busqueda
{
    public interface IComp
    {
        BindingSource MetodoBusqueda_GetSource { get; }
        string MetodoBusqueda_GetId { get; }
        string GetCadena { get; }

        void setCadenaBuscar(string cadBuscar);
        void setMetodo(string id);

        void Inicializa();
        void CargarData();
        void CargarData(bool fozarCargaData);

        void MostrarFiltros();
        void Limpiar();

        bool HayParametrosBusqueda { get; }
        OOB.LibInventario.Producto.Filtro DataExportar();
        void setFiltros(BusqProducto.Filtro.IFiltrosActivar filtrosActivar);
    }
}