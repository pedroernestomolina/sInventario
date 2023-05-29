using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Producto.AgregarEditar.ModoSucursal
{
    public interface IVolumen
    {
        decimal Calcula(decimal alto, decimal largo, decimal ancho);
    }
}
