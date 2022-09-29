using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Producto.CodigosAlterno
{
    
    public class data
    {

        public string codigo { get; set; }


        public data()
        {
            codigo = "";
        }

        public data(string CodigoAlterno)
            :this()
        {
            this.codigo = CodigoAlterno;
        }

    }

}