using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OOB.LibInventario.Producto.Data
{
    
    public class Extra
    {

        public Enumerados.EnumPesado esPesado { get; set; }
        public string lugar { get; set; }
        public List<string> codigosAlterno { get; set; }


        public Extra()
        {
            esPesado = Enumerados.EnumPesado.SnDefinir;
            lugar = "";
            codigosAlterno = null;
        }

    }

}