using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Visor.Precio
{
    
    public class Filtro
    {

        public string autoDepart { get; set; }
        public string autoGrupo { get; set; }


        public Filtro()
        {
            autoDepart = "";
            autoGrupo = "";
        }

    }

}