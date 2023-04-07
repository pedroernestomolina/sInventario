using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Producto.ActualizarOferta.ModoAdm.Actualizar
{
    public class Precio
    {
        public int idPrecioVta { get; set; }
        public string estatus { get; set; }
        public decimal portc { get; set; }
        public DateTime desde { get; set; }
        public DateTime hasta { get; set; }


        public Precio()
        {
            idPrecioVta = -1;
            estatus = "0";
            portc = 0m;
            desde = DateTime.Now.Date;
            hasta = DateTime.Now.Date;
        }
    }
}