using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.TomaInv.GenerarToma
{
    public class Ficha
    {
        public string idDepositoTomaInv { get; set; }
        public List<PrdToma> ProductosTomaInv { get; set; }
    }
}