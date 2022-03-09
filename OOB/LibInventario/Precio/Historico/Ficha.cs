using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Precio.Historico
{
    
    public class Ficha
    {

        public string codigo { get; set; }
        public string descripcion { get; set; }
        public List<Data> data { get; set; }

    }

}