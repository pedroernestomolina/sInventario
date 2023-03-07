using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.MovInventario.Tools.CapturaMov
{
    public interface IDataCaptura
    {
        int Id { get; set; }

        string AutoPrd { get;  }
        string CodigoPrd { get; }
        string DescripcionPrd { get; }
        decimal Cantidad { get; }
        string EmpaqueMov { get; }
        decimal CostoNeto { get; }
        decimal ImporteNeto { get; }
        bool EsAdmDivisa { get; }
        decimal ImporteNetoMonedaLocal { get; }
        decimal ImporteNetoDivisa { get; }

        IDataPrd Ficha { get; }
        IEmpaque Empaque { get; }
        decimal TasaCambio { get; }
        decimal Mov_GetCantidad { get; }
        decimal Mov_GetCosto { get; }
        decimal Mov_GetCntUnd { get; }
        decimal Mov_GetCostoUnd { get; }
        decimal Mov_GetImporte { get; }
        dataItem GetItem { get; }

        void setEmpaque(string id);
        void setCantidad(decimal cnt);
        void setCosto(decimal mont);
        void setTasaCambio(decimal tasa);
        void setFicha(data dat);

        void Inicializa();
        bool ValidarParaProcesarIsOk();
    }
}