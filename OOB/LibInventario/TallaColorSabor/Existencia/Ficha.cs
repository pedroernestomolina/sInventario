using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.TallaColorSabor.Existencia
{
    public class Ficha
    {
        public string idPrd { get; set; }
        public string NombrePrd { get; set; }
        public string EstatusTCS { get; set; }
        public List<ExDepTCS> ExDep { get; set; }
        public bool HndTallaColorSabor { get { return EstatusTCS.Trim().ToUpper() == "1"; } }
    }
}