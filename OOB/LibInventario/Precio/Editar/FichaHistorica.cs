using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Precio.Editar
{

    public class FichaHistorica
    {

        public string nota { get; set; }
        public string precio_id { get; set; }
        public decimal precio { get; set; }
        public string empaque { get; set; }
        public int contenido { get; set; }
        public decimal factorCambio { get; set; }


        public FichaHistorica() 
        {
            nota = "";
            precio_id = "";
            precio = 0.0m;
            empaque = "UNIDAD";
            contenido = 1;
            factorCambio = 0m;
        }

    }

}