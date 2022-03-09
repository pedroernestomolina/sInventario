using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Reportes.CompraVentaAlmacen
{
    
    public class FichaVenta
    {

        public decimal cnt { get; set; }
        public decimal montoVenta { get; set; }
        public decimal montoCosto { get; set; }
        public decimal factor { get; set; }
        public string tipoDoc { get; set; }
        public decimal montoVentaDivisa { get; set; }
        public decimal montoCostoDivisa { get;set; }

    }

}