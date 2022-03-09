using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Producto.Depositos.Asignar
{
    
    public class Ficha
    {

        public string autoProducto { get; set; }
        public List<DepAsignar> depAsignar { get; set; }
        public List<DepRemover> depRemover { get; set; }


        public Ficha()
        {
            autoProducto = "";
            depAsignar = new List<DepAsignar>();
            depRemover = new List<DepRemover>();
        }

    }

}