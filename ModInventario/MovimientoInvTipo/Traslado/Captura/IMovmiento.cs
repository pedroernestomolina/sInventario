using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MovimientoInvTipo.Traslado.Captura
{
    
    public interface ICaptura: IGestion
    {

        bool IsOk { get; }
        dataItem DataItem { get; }
        bool AbandonarIsOk { get; }
        bool ProcesarIsOk { get; }


        void AbandonarFicha();
        void Procesar();


        void setData(data dat);
        void setCantidad(decimal p);
        void setCosto(decimal p);
        void setEmpaque(string p);


        decimal InfTasaCambio { get; }
        string InfProductoDesc { get; }
        string InfProductoEmpaCompra { get; }
        string InfProductoEsAdmDivisa { get; }
        string InfProductoTasaIva { get; }
        string InfProductoFechaUltActCosto { get; }
        decimal InfExistenciaActual { get; }
        bool InfProductoEsDivisa { get;  }


        BindingSource EmpaqueSource { get; }
        decimal CntUnd { get; }
        decimal CostoUnd { get; }
        decimal Costo { get; }
        decimal Importe { get; }
        decimal Cantidad { get; }
        string EmpaqueGetID { get; }


        void setItemEditar(dataItem ItemActual);
        void setTasaCambio(decimal _tasaCambio);

    }

}