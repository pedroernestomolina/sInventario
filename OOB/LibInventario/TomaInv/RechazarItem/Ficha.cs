using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.TomaInv.RechazarItem
{
    public class Ficha
    {
        public int IdToma { get; set; }
        public List<Item> Items { get; set; }
    }
}