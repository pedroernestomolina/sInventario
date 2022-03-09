using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Plu
{
    
    public class data
    {
        private OOB.LibInventario.Producto.Plu.Lista.Ficha reg;


        public string Codigo { get { return reg.codigo; } }
        public string Producto { get { return reg.descripcion; } }
        public string Plu { get { return reg.plu; } }


        public data(OOB.LibInventario.Producto.Plu.Lista.Ficha reg)
        {
            this.reg = reg;
        }

    }

}