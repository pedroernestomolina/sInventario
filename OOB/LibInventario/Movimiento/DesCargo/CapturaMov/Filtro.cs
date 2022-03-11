using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Movimiento.DesCargo.CapturaMov
{

    public class Filtro
    {

        public string idProducto { get; set; }
        public string idDeposito { get; set; }


        public Filtro() 
        {
            idProducto = "";
            idDeposito = "";
        }

    }

}
