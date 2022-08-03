using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Precio.Visualizar
{
    
    public interface IVisual: IGestion
    {

        void setFichaVisualizar(string idPrd);

        dataEmp Emp1_1 { get; }
        dataEmp Emp1_2 { get; }
        dataEmp Emp1_3 { get; }
        dataEmp Emp1_4 { get; }
        dataEmp Emp1_5 { get; }
        //
        dataEmp Emp2_1 { get; }
        dataEmp Emp2_2 { get; }
        dataEmp Emp2_3 { get; }
        dataEmp Emp2_4 { get; }
        dataEmp Emp2_5 { get; }
        //
        dataEmp Emp3_1 { get; }
        dataEmp Emp3_2 { get; }
        dataEmp Emp3_3 { get; }
        dataEmp Emp3_4 { get; }
        dataEmp Emp3_5 { get; }


        string GetProductoInfo { get; }
        string GetProductoAdmDivisa { get; }
        string GetProductoIva { get; }
        decimal GetTasaCambio { get; }
        string GetMetodoCalculoUtilidad { get; }

    }

}