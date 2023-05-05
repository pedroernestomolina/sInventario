using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.Filtros.BuscarPor
{
    public interface Idata
    {
        string id { get; set; }
        string codigo { get; set; }
        string desc { get; set; }
    }
}