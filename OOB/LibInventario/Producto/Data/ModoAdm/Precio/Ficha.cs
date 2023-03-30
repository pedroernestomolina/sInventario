using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Producto.Data.ModoAdm.Precio
{
    public class Ficha
    {
        public Entidad entidad { get; set; }
        public List<OOB.LibInventario.Producto.Data.ModoAdm.Precio.Precio> precios { get; set; }
    }
}