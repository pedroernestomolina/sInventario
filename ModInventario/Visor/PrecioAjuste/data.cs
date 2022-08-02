using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Visor.PrecioAjuste
{
    
    public class data
    {

        public string idPrd { get; set; }
        public string nombre { get; set; }
        public decimal tasaIva { get; set; }
        public int cont_emp_1 { get; set; }
        public int cont_emp_2 { get; set; }
        public int cont_emp_3 { get; set; }
        public decimal pfull_divisa_emp_1 { get; set; }
        public decimal pfull_divisa_emp_2 { get; set; }
        public decimal pfull_divisa_emp_3 { get; set; }
        public decimal pneto_divisa_emp_1 { get { return Neto(pfull_divisa_emp_1); } }
        public decimal pneto_divisa_emp_2 { get { return Neto(pfull_divisa_emp_2); } }
        public decimal pneto_divisa_emp_3 { get { return Neto(pfull_divisa_emp_3); } }


        public data() 
        {
            idPrd = "";
            nombre = "";
            tasaIva = 0m;
            pfull_divisa_emp_1 = 0m;
            pfull_divisa_emp_2 = 0m;
            pfull_divisa_emp_3 = 0m;
            cont_emp_1 = 0;
            cont_emp_2 = 0;
            cont_emp_3 = 0;
        }

        private decimal Neto(decimal pfull)
        {
            var rt = pfull;
            if (tasaIva > 0)
            {
                rt = pfull / ((tasaIva / 100) + 1);
            }
            return rt;
        }

    }

}
