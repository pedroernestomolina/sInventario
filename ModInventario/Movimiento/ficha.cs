using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Movimiento
{
    
    public class ficha
    {

        public string id { get; set; }
        public string descripcion { get; set; }
        public string codigo { get; set; }


        public ficha() 
        {
            limpiar();
        }

        public ficha(string _id, string _desc, string cod)
            :this()
        {
            this.id = _id;
            this.descripcion = _desc;
            this.codigo = cod;
        }

        private void limpiar()
        {
            id = "";
            descripcion = "";
            codigo = "";
        }

    }

}