using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.MovInventario.Pendiente
{
    public interface IPendiente
    {
        int CntDoc { get; }
        IListaPend Pendiente { get; }

        void setTipoDocumentoTrabajar(enumerados.enumTipoDocAbrirPend tipoDoc);
        void setTipoMovTraslado(enumerados.enumTipoMovTraslado tipoTraslado);

        void Inicializa();
        void CargarData();
        void ListaVisualizar();

        bool SeleccionItemIsOk { get; }
        int IdItemSeleccionado { get; }
        void SeleccionarItem();
        void ActualizarContador();

        bool DejarEnPendienteIsOk { get; }
        void DejarEnPendiente(OOB.LibInventario.Transito.Movimiento.Agregar.Ficha ficha);
    }
}