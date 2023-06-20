using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.TomaInv.Analisis
{
    public class Ficha
    {
        public string solicitudNro { get; set; }
        public string tomaNro { get; set; }
        public string sucursal { get; set; }
        public string deposito { get; set; }
        public List<Item> Items { get; set; }
    }
}