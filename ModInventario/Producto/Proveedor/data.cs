using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Proveedor
{

    public class data
    {
        private OOB.LibInventario.Producto.Data.Proveedor.Detalle rg;


        public string RazonSocial { get { return rg.razonSocial; } }
        public string Rif { get { return rg.ciRif; } }
        public string Codigo { get { return rg.codigo; } }
        public string Direccion { get { return rg.direccionFiscal; } }
        public string Telefono { get { return rg.telefonos; } } 


        public data(OOB.LibInventario.Producto.Data.Proveedor.Detalle rg)
        {
            this.rg = rg;
        }


        public void Limpiar()
        {
            rg.LImpiar();
        }

    }

}