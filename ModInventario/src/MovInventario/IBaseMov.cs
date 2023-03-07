using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario
{
    public interface IBaseMov: IGestion, Gestion.IAbandonar, Gestion.IProcesar
    {
        void BuscarProducto();
    }
}