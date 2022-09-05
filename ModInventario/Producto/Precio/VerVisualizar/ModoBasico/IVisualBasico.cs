using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Precio.VerVisualizar.ModoBasico
{
    
    public interface IVisualBasico: IVisual
    {

        dataEmp Emp1_1 { get; }
        dataEmp Emp1_2 { get; }
        dataEmp Emp1_3 { get; }

    }

}