using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Movimiento.Traslado.CapturaMov
{

    public class Filtro: Movimiento.CapturaMov.BaseFiltro
    {

        public string IdDepDestino { get; set; }


        public Filtro() 
        {
            idProducto = "";
            idDeposito = "";
            IdDepDestino = "";
        }

    }

}