using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Kardex.Movimiento
{
    
    public interface IMov: IGestion
    {

        string GetProductoInfo { get; }
        void setFicha(string id);


        BindingSource GetDepositoSource { get; }
        void setDeposito(string id);

        BindingSource GetDiasSource { get; }


        BindingSource GetCompraSource { get; }
        BindingSource GetVentaSource { get; }
        BindingSource GetInventarioSource { get; }


        void VerDetalleCompra();
        void VerDetalleVenta();
        void VerDetalleInventario();


        void Procesar();


        string GetExActual { get; }
        string GetExFecha { get; }
        string GetFecha { get;  }


        void setDias(string p);
    }

}