using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Configuracion.RegistroPrecio
{
    
    public class data
    {


        public string auto { get; set; }
        public string descripcion { get; set; }


        public data()
        {
            auto = "";
            descripcion = "";
        }

        public data(string id, string desc)
        {
            this.auto = id;
            this.descripcion = desc;
        }

    }

}