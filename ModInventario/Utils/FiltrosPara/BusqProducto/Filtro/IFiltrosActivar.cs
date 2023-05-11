using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.FiltrosPara.BusqProducto.Filtro
{
    public interface IFiltrosActivar
    {
        bool Departamento { get; set; }
        bool Marca { get; set; } 
        bool Origen { get;set; }
        bool TasaIva { get;set; }
        bool Estatus { get;set; }
        bool Divisa { get;set; }
        bool Pesado { get;set; }
        bool Deposito { get;set; }
        bool Catalogo { get;set; }
        bool Categoria { get;set; }
        bool Existencia { get;set; }
        bool TCS { get;set; }
        bool Oferta { get;set; }
        bool Proveedor { get; set; }
    }
}