using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Traslado
{
    public interface ITraslado: IMov
    {
        Tools.Deposito.IDeposito DepDestino { get; }
        void SucOrigenSetId(string id);
        void ActivarDepDestinoPreDeterminado(bool modo);
        bool ActivarDepPreDeterminadoParaDevolucion { get; }
        void ListaPendienteVisualizar();
        bool DejarEnPendienteIsOk { get; }
        void DejarEnPendiente();
    }
}