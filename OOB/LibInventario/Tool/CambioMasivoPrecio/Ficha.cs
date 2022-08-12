using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Tool.CambioMasivoPrecio
{
    
    public class Ficha
    {

        public string codigoPrecioOrigen { get; set; }
        public string codigoPrecioDestino { get; set; }
        public string idDepartamento { get; set; }
        public string idGrupo { get; set; }


        public Ficha()
        {
            codigoPrecioOrigen = "";
            codigoPrecioDestino= "";
            idDepartamento = "";
            idGrupo = "";
        }

    }

}