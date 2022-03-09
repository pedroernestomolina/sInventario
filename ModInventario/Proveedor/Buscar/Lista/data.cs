using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Proveedor.Buscar.Lista
{

    public class data
    {


        private OOB.LibInventario.Proveedor.Lista.Ficha reg;


        public string Auto { get { return reg.auto; } }
        public string Codigo { get { return reg.codigo; } }
        public string CiRif { get { return reg.ciRif; } }
        public string NombreRazonSocial { get { return reg.nombreRazonSocial; } }


        public data(OOB.LibInventario.Proveedor.Lista.Ficha reg)
        {
            this.reg = reg;
        }

    }

}