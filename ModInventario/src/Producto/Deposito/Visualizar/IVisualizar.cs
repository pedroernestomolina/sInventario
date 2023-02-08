using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Producto.Deposito.Visualizar
{
    public interface IVisualizar: IGestion
    {
        string GetInfo_Producto { get; }
        string GetInfo_Deposito { get; }
        string GetInfo_Ubicacion_1 { get; }
        string GetInfo_Ubicacion_2 { get; }
        string GetInfo_Ubicacion_3 { get; }
        string GetInfo_Ubicacion_4 { get; }
        string GetInfo_Minimo { get; }
        string GetInfo_Maximo { get; }
        string GetInfo_Pedido { get; }

        void setIdPrd(string idPrd);
        void setIdDep(string idDep);
    }
}