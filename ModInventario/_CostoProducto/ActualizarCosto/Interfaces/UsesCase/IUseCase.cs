using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario._CostoProducto.ActualizarCosto.Interfaces.UsesCase
{
    public interface IUseCase
    {
        Modelo.Producto 
            GetFichaPrdToEditarCostoUseCase(string idPrd);
    }
}