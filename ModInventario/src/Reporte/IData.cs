using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Reporte
{
    public interface IData
    {
        ficha Depart { get; set; }
        ficha Deposito { get; set; }
        ficha Grupo { get; set; }
        ficha Marca { get; set; }
        ficha TasaIva { get; set; }
        ficha Divisa { get; set; }
        ficha Estatus { get; set; }
        ficha Origen { get; set; }
        ficha Categoria { get; set; }
        ficha Sucursal { get; set; }
        ficha Producto { get; set; }
        DateTime? Desde  { get; set; }
        DateTime? Hasta { get; set; }
        ficha Pesado { get; set; }
        ficha Precio { get; set; }
        ficha EmpqPrecio { get; set; }
        ficha Oferta { get; set; }
        ficha Concepto { get; set; }
    }
}