using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Producto.Data.Proveedor
{
    
    public class Ficha
    {

        public string autoProducto { get; set; }
        public string codigoProducto { get; set; }
        public string nombreProducto { get; set; }
        public string referenciaProducto { get; set; }
        public List<Detalle> proveedores { get; set; }


        public Ficha()
        {
            autoProducto = "";
            codigoProducto = "";
            nombreProducto="";
            referenciaProducto="";
            proveedores= new List<Detalle>();
        }

    }

}