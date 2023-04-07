using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Producto.ActualizarOferta.ModoAdm.Actualizar
{
    public class Ficha
    {
        public string autoPrd { get; set; }
        public string estatusOferta { get; set; }
        public List<Precio> ofertas { get; set; }
    }
}