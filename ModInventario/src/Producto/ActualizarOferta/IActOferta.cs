using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Producto.ActualizarOferta
{
    public interface IActOferta: IGestion, Gestion.IAbandonar, Gestion.IProcesar
    {
        void setFichaByIdPrd(string id);
    }
}