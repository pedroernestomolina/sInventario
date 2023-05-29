using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Producto.AgregarEditar.ModoSucursal
{
    public class ImpVolEsferico:IVolumen
    {
        public decimal Calcula(decimal alto, decimal largo, decimal ancho)
        {
            var x = (4 / 3m);
            var y = (decimal)Math.Pow((double)largo, 3d);
            var z = (decimal)Math.PI; 
            var r = (x * y * z);
            return r;
        }
    }
}
