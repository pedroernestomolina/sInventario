using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.Filtros
{
    public interface IFiltroLink: IFiltro
    {
        void CargarDataByIdLink(string id);
    }
}
