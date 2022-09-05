using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Precio.EditarCambiar
{

    public interface IEditar : IGestion, Gestion.IAbandonar, Gestion.IProcesar
    {

        bool EditarPrecioIsOk { get; }

        void setIdItemEditar(string idAuto);

    }

}