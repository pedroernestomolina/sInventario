using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Movimiento.CapturaMov
{

    abstract public class BaseFiltro
    {

        public string idProducto { get; set; }
        public string idDeposito { get; set; }

    }

}