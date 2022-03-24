using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Transito.Movimiento.Lista
{
    
    public class Filtro
    {

        public string codigoMov { get; set; }
        public string tipoMov { get; set; }


        public Filtro() 
        {
            codigoMov = "";
            tipoMov = "";
        }

    }

}