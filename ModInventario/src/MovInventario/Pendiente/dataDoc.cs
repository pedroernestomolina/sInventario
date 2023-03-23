using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.MovInventario.Pendiente
{
    public class dataDoc
    {
        public int id { get; set; }
        public int renglones { get; set; }
        public DateTime fecha { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public decimal monto { get; set; }
        public decimal montoDivisa { get; set; }
    }
}