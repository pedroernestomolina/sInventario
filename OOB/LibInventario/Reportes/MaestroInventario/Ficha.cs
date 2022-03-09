using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Reportes.MaestroInventario
{
    
    public class Ficha
    {

        public string codigoPrd { get; set; }
        public string nombrePrd { get; set; }
        public string referenciaPrd { get; set; }
        public string modeloPrd { get; set; }
        public string departamento { get; set; }
        public string grupo { get; set; }
        public decimal? existencia { get; set; }
        public decimal costoUnd { get; set; }
        public decimal costoDivisaUnd { get; set; }
        public string decimales { get; set; }
        public decimal pn1 { get; set; }
        public decimal pn2 { get; set; }
        public decimal pn3 { get; set; }
        public decimal pn4 { get; set; }
        public decimal pn5 { get; set; }
        public string codigoSuc { get; set; }
        public string nombreGrupo { get; set; }
        public string precioId { get; set; }
        public enumerados.EnumAdministradorPorDivisa admDivisa { get; set; }
        public enumerados.EnumEstatus estatus {get;set;}

    }

}