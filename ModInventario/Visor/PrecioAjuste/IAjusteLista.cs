using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Visor.PrecioAjuste
{
    
    public interface IAjusteLista: Gestion.ILista
    {

        void setFiltrar(string id);
        void EliminarItem(string idAuto);

    }

}