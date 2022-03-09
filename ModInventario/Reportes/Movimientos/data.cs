using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Movimientos
{
    
    public class data
    {

        public string fechaHora { get; set; }
        public string documentoNro { get; set; }
        public string sucursal { get; set; }
        public string concepto { get; set; }
        public string usuarioEstacion { get; set; }
        public decimal importe { get; set; }
        public string situacion { get; set; }
        public bool isAnulado { get; set; }
        public string renglones { get; set; }
        public string nombreDocumento { get; set; }

    }

}