using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Producto.Data.ModoAdm.Precio
{
    public class Entidad
    {
        public string auto { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public decimal tasaIva { get; set; }
        public string estatusDivisa { get; set; }
        public bool esDivisa { get { return estatusDivisa.Trim().ToUpper() == "1" ? true : false; } }
    }
}