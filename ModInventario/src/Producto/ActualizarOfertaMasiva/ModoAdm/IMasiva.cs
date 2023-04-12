using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Producto.ActualizarOfertaMasiva.ModoAdm
{
    public interface IMasiva: IOferta
    {
        Tools.Busqueda.IBusqueda Busqueda { get; }
        Items.IItems Items { get; }
        Precio.IPrecio Precio { get; }
        bool BuscarIsOk { get; }
        DateTime GetDesde { get; }
        DateTime GetHasta { get; }
        string GetPorctDesc { get; }

        void setDesde(DateTime dateTime);
        void setHasta(DateTime dateTime);
        void setPorct(decimal monto);

        void LimpiarTodo();
        void Buscar();

    }
}