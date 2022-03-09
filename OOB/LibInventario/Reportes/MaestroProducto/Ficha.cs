using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Reportes.MaestroProducto
{
    
    public class Ficha
    {

        public string codigoPrd { get; set; }
        public string nombrePrd { get; set; }
        public string referenciaPrd { get; set; }
        public string modeloPrd { get; set; }
        public int contenidoPrd { get; set; }
        public string departamento { get; set; }
        public string grupo { get; set; }
        public string empaque { get; set; }
        public decimal tasaIva { get; set; }
        public enumerados.EnumAdministradorPorDivisa admDivisa { get; set; }
        public enumerados.EnumEstatus estatus { get; set; }
        public enumerados.EnumCategoria categoria { get; set; }
        public enumerados.EnumOrigen origen { get; set; }

    }

}