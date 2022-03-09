using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.TasaImpuesto
{
    
    public class Ficha
    {

        public string auto { get; set; }
        public string nombre { get; set; }
        public decimal tasa { get; set; }


        public override string ToString()
        {
            var r = "";
            r = tasa.ToString("n2").PadLeft(5,'0') + "%, " + nombre;
            return r;
        }

    }

}