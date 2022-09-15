using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Precio.Historico
{
    
    public class Data
    {

        public string nota { get; set; }
        public string usuario { get; set; }
        public string estacion { get; set; }
        public DateTime fecha { get; set; }
        public string hora { get; set; }
        public decimal precio { get; set; }
        public decimal factorCambio { get; set; }
        public string empaque { get; set; }
        public int contenido { get; set; }
        public string idPrecio { get; set; }

    }

}