using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Estatus
{

    public class data
    {

        private string autoPrd;
        private string producto;


        public string Producto { get { return producto; } }
        public OOB.LibInventario.Producto.Enumerados.EnumEstatus Estatus { get; set; }
        public string AutoProducto { get { return autoPrd; } }


        public data()
        {
            Limpiar();
        }

        public void setFicha(OOB.LibInventario.Producto.Estatus.Actual.Ficha ficha)
        {
            producto=ficha.codigoProducto + Environment.NewLine + ficha.nombreProducto;
            autoPrd = ficha.autoProducto;
            Estatus = ficha.estatus ;
        }

        public void Limpiar()
        {
            producto = "";
            autoPrd = "";
            Estatus = OOB.LibInventario.Producto.Enumerados.EnumEstatus.SnDefinir;
        }

    }

}