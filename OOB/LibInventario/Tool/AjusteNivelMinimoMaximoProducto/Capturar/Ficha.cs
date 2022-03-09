using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Tool.AjusteNivelMinimoMaximoProducto.Capturar
{
    
    public class Ficha
    {

        public string autoProducto { get; set; }
        public string codigoProducto { get; set; }
        public string nombreProducto { get; set; }
        public string referenciaProducto { get; set; }
        public string decimales { get; set; }
        public decimal fisica { get; set; }
        public decimal nivelMinimo { get; set; }
        public decimal nivelOptimo { get; set; }
        public bool esPesado { get; set; }
        public string Estatus { get; set; }

    }

}