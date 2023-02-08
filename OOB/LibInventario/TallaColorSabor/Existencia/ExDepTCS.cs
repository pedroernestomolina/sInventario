using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.TallaColorSabor.Existencia
{
    public class ExDepTCS
    {
        public string idDep { get; set; }
        public int idTCS { get; set; }
        public string NombreDep { get; set; }
        public string NombreTCS { get; set; }
        public decimal Fisica { get; set; }
        public decimal Reservada { get; set; }
        public decimal Disponible { get; set; }
    }
}