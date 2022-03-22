using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Transito.Movimiento.Agregar
{
    
    public class Ficha
    {

        public Mov mov { get; set; }


        public Ficha() 
        {
            mov = new Mov();
        }

    }

}