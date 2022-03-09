using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Reportes.CompraVentaAlmacen
{
    
    public class Ficha
    {

        public string prdNombre { get; set; }
        public string prdCodigo { get; set; }
        public string empaque { get; set; }
        public int contenido { get; set; }
        public decimal exUnd { get; set; }
        public decimal costoDivisaUnd { get; set; }
        public List<FichaCompra> compras { get; set; }
        public List<FichaVenta> ventas { get; set; }
        public List<FichaAlmacen> almacen { get; set; }

    }

}