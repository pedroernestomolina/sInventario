using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Movimiento.Insertar
{
    
    
    abstract public class BaseFichaMovDeposito
    {


        public string autoProducto { get; set; }
        public string autoDeposito { get; set; }
        public string nombreProducto { get; set; }
        public string nombreDeposito { get; set; }
        public decimal cantidadUnd { get; set; }

    }

}