using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Precio.VerVisualizar
{
    
    public interface IVisual: IGestion
    {

        void setFichaVisualizar(string idPrd);

        string GetProductoInfo { get; }
        string GetProductoAdmDivisa { get; }
        string GetProductoIva { get; }
        decimal GetTasaCambio { get; }
        string GetMetodoCalculoUtilidad { get; }

    }

}