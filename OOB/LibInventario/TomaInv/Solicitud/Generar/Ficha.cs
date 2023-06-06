using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.TomaInv.Solicitud.Generar
{
    public class Ficha
    {
        public string idSucursal { get; set; }
        public string idDeposito { get; set; }
        public string autorizadoPor { get; set; }
        public string motivo { get; set; }
        public string codigoDeposito { get; set; }
        public string descDeposito { get; set; }
        public string codigoSucursal { get; set; }
        public string descSucursal { get; set; }
        public int cantItems { get; set; }
        public List<PrdToma> ProductosTomaInv { get; set; }
    }
}