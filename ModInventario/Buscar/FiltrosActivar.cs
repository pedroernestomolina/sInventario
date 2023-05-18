using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Buscar
{
    public class FiltrosActivar : Utils.FiltrosPara.BusqProducto.Filtro.IFiltrosActivar
    {
        public bool Departamento { get; set; }
        public bool Marca { get; set; }
        public bool Origen { get; set; }
        public bool TasaIva { get; set; }
        public bool Estatus { get; set; }
        public bool Divisa { get; set; }
        public bool Pesado { get; set; }
        public bool Deposito { get; set; }
        public bool Catalogo { get; set; }
        public bool Categoria { get; set; }
        public bool Existencia { get; set; }
        public bool TCS { get; set; }
        public bool Oferta { get; set; }
        public bool Proveedor { get; set; }


        public FiltrosActivar()
        {
            Departamento = true;
            Marca = true;
            Origen = true;
            TasaIva = true;
            Estatus = true;
            Divisa = true;
            Pesado = true;
            Deposito = true;
            Catalogo = true;
            Categoria = true;
            Existencia = true;
            TCS = true;
            Oferta = true;
            Proveedor = true;
        }
    }
}
