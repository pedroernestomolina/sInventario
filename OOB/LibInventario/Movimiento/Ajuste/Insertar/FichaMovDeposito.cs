using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Movimiento.Ajuste.Insertar
{
    
    public class FichaMovDeposito: Movimiento.Insertar.BaseFichaMovDeposito
    {


        public FichaMovDeposito()
        {
            autoProducto = "";
            autoDeposito = "";
            nombreProducto = "";
            nombreDeposito = "";
            cantidadUnd = 0m;
        }

    }

}