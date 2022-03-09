using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Reportes.CompraVentaAlmacen
{
    
    public class FichaCompra
    {

        public string documento { get; set; }
        public DateTime fecha { get; set; }
        public decimal cnt { get; set; }
        public string empaque { get; set; }
        public int contenido { get; set; }
        public decimal cntUnd { get; set; }
        public decimal costoUnd { get; set; }
        public decimal factor { get; set; }
        public int signoDoc { get; set; }
        public string tipoDoc { get; set; }
        public decimal costoDivisaUnd { get; set; }
        public bool esAnulado { get; set; }

    }

}