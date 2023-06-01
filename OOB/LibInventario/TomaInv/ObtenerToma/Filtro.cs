using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.TomaInv.ObtenerToma
{
    public class Filtro
    {
        public string idDeposito { get; set; }
        public int periodoDias { get; set; }
        public List<string> idDepartExcluir { get; set; }
    }
}