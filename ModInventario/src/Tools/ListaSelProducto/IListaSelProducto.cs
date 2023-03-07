using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Tools.ListaSelProducto
{
    public interface IListaSelProducto: IListaSeleccion
    {
        event EventHandler Notificar;
        bool CerrarVentanaAlSeleccionarItem { get; }
        void setLista(List<fichaSeleccion> lst);
        void setCerrarVentanaAlSeleccionar(bool act);
        void Inicia();
    }
}