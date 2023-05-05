using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.Filtros.BuscarPor.ListaSelecciona.PorProveedor
{
    public class data: Idata
    {
        public string id { get; set; }
        public string codigo { get; set; }
        public string desc { get; set; }
        public string ciRif { get; set; }


        public override string ToString()
        {
            return desc;
        }
    }
}