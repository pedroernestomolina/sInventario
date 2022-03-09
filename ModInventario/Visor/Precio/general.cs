using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Visor.Precio
{
    
    public class general
    {


        public string id { get; set; }
        public string desc { get; set; }


        public general()
        {
            id = "";
            desc = "";
        }

        public general(string id, string des)
            :this()
        {
            this.id = id;
            this.desc = des;
        }

    }

}