using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Tools
{
    public interface IListaSeleccion: ILista
    {
        ficha GetItemSeleccionado { get; }
        bool ItemSeleccionadoIsOk { get; }
        void SeleccionarItem();
    }
}