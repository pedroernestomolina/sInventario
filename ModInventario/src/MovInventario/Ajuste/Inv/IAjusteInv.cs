
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.MovInventario.Ajuste.Inv
{
    public interface IAjusteInv:IMov
    {
        void SucOrigenSetId(string id);
        void ListaPendienteVisualizar();
        bool DejarEnPendienteIsOk { get; }
        void DejarEnPendiente();
        void CargarPendiente(int idMovCargar);
    }
}