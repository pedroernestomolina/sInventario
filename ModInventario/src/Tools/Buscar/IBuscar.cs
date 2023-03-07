using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Tools.Buscar
{
    public interface IBuscar
    {
        BindingSource Source { get; }
        string Id { get; }
        string GetCadena { get; }
        dataExportar DataExportar { get; }

        void setCadena(string cadBuscar);
        void setMetodo(string id);

        void Inicializa();
        void CargarData();
        void LimpiarCargarMetPreferencia();
    }
}