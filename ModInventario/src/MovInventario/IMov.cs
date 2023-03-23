using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario
{
    public interface IMov: IBaseMov
    {
        event EventHandler<string> NotificarDocGenerado;
        string GetInf_TipoMovimiento { get; }
        string GetEnt_Motivo { get; }
        string GetEnt_AutorizadoPor { get; }
        DateTime GetFechaSistema { get; }
        Tools.Sucursal.ISucursal SucOrigen { get; }
        Tools.Concepto.IConcepto Concepto { get; }
        Tools.Deposito.IDeposito DepOrigen { get; }
        Tools.ListaMov.IListaMov ListaItems { get; }
        src.Tools.BusqProducto.IBusqProducto MetBusProducto { get; }
        src.MovInventario.Pendiente.IPendiente Pendiente { get; }


        void setAutorizadoPor(string aut);
        void setMotivo(string mot);

        void AgregarConcepto();
        bool LImpiezaGenerarIsOk { get; }
        void LimpiezaGeneral();
        void EliminarItem();
        void EditarItem();
    }
}