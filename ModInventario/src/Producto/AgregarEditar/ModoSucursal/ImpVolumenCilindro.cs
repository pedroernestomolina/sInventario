using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Producto.AgregarEditar.ModoSucursal
{
    public class ImpVolumenCilindro: IVolumen
    {
        public decimal Calcula(decimal alto, decimal largo, decimal ancho)
        {
            return (decimal) Math.PI*alto*largo;
        }
    }
}
