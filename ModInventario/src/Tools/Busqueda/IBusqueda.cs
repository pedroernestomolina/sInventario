using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Tools.Busqueda
{
    public interface IBusqueda
    {
        BindingSource GetMetBusquedaSource { get; }
        string GetMetBusquedaId { get; }
        bool BuscarIsOk { get; }
        string GetCadenaBusqueda { get;  }
        Object FiltrosExportar { get; }


        void setCadenaBusqueda(string cad);
        void setMetBusqueda(string id);

        void Inicializa();
        void CargarData();
        void ActivarFiltros();
        void LimpiarTodo();
        void Buscar();
    }
}