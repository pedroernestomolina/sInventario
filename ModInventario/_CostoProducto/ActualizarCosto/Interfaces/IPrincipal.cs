using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario._CostoProducto.ActualizarCosto.interfaces
{
    public interface IPrincipal: __.interfaces.IGestion
    {
        bool FichaIsOk { get; }
        bool AbandonarFichaIsOk { get; }
        void AbandonarFicha();
        void ProcesarFicha();
        void setIdFichaEditar(string idPrdEditar);
        //
        string Get_DescProducto { get; }
        string Get_TasaCambio { get; }
        string Get_CostoFinal_Und { get; }
        string Get_AdmDivisa { get; }
        string Get_DescTasaIva { get; }
        string Get_FechaUltActCosto { get; }
        string Get_DescEmqCompra { get; }
    }
}