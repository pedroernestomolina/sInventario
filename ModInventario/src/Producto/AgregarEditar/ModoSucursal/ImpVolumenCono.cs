using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Producto.AgregarEditar.ModoSucursal
{
    public class ImpVolumenCono: IVolumen
    {
        public decimal Calcula(decimal alto, decimal largo, decimal ancho)
        {
            var r= (1 / 3m);
            var t = r  *(decimal)Math.PI * largo * largo;
            return t;
        }
    }
}
