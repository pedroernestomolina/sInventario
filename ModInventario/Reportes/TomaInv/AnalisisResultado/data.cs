using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.TomaInv.AnalisisResultado
{
    public class item
    {
        public string producto { get; set; }
        public decimal cant { get; set; }
        public string descToma { get; set; }
        public int signo { get; set; }
    }
    public class data
    {
        public string solicitudNro { get; set; }
        public string sucursal { get; set; }
        public string deposito { get; set; }
        public List<item> items { get; set; }
        public data()
        {
            solicitudNro = "";
            sucursal = "";
            deposito = "";
            items = new List<item>();
        }
    }
}