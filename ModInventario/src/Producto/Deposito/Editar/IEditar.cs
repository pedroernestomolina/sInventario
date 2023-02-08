using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Producto.Deposito.Editar
{
    public interface IEditar : IGestion, Gestion.IAbandonar, Gestion.IProcesar
    {
        string GetInfo_Producto { get; }
        string GetInfo_Deposito { get; }
        string GetInfo_Ubicacion_1 { get; }
        string GetInfo_Ubicacion_2 { get; }
        string GetInfo_Ubicacion_3 { get; }
        string GetInfo_Ubicacion_4 { get; }
        decimal GetInfo_Minimo { get; }
        decimal GetInfo_Maximo { get; }
        decimal GetInfo_Pedido { get; }

        void setUbicacion_1(string des);
        void setUbicacion_2(string des);
        void setUbicacion_3(string des);
        void setUbicacion_4(string des);
        void setMinimo(int cnt);
        void setMaximo(int cnt);
        void setPedido(int cnt);
        void setIdPrd(string idPrd);
        void setIdDep(string idDep);
    }
}