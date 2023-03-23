using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.MovInventario.Pendiente
{
    public interface IListaPend: ILista
    {
        void setData(List<OOB.LibInventario.Transito.Movimiento.Entidad.Mov> list);
    }
}
