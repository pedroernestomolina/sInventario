using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.MaestrosInv
{

    public class data
    {

        public string auto { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }


        public data(string id, string cod, string desc)
        {
            this.auto = id;
            this.codigo = cod;
            this.descripcion = desc;
        }

    }

}