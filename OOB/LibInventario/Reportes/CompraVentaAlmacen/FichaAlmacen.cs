using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Reportes.CompraVentaAlmacen
{
    
    public class FichaAlmacen
    {

        public string documento { get; set; }
        public DateTime fecha { get; set; }
        public string nombreDoc { get; set; }
        public string nota { get; set; }
        public decimal cantUnd { get; set; }
        public decimal costoUnd { get; set; }
        public int signo { get; set; }
        public bool isAnulado { get; set; }

    }

}