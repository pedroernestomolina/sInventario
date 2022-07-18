using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Kardex.Movimiento.Resumen
{
    
    public class Filtro: Movimiento.Filtro
    {

        public string autoDeposito { get; set; }


        public Filtro() 
        {
            autoProducto = "";
            autoDeposito = "";
            ultDias = 0;
        }

    }

}
