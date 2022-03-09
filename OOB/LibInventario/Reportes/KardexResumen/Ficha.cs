using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Reportes.KardexResumen
{
    
    public class Ficha
    {

        public decimal cnt { get; set; }
        public string concepto { get; set; }
        public decimal exInicial { get; set; }


        public Ficha()
        {
            cnt = 0.0m;
            concepto = "";
            exInicial = 0.0m;
        }

    }

}