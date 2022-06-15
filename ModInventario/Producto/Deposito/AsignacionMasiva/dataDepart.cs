using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Deposito.AsignacionMasiva
{
    
    public class dataDepart
    {

        public string id { get; set; }
        public string nombre { get; set; }
        public bool excluir { get; set; }


        public dataDepart() 
        {
            id = "";
            nombre = "";
            excluir = false;
        }

    }

}