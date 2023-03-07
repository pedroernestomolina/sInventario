using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Tools.Filtros.Proveedor.Lista
{
    public interface IListaPrv: IListaSeleccion
    {
        void setLista(List<ficha> lst);

        void Inicia();
    }
}