using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Reportes.MaestroPrecio
{
    public class FichaFox
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string admDivisa { get; set; }
        public string departamento { get; set; }
        public string grupo { get; set; }
        public decimal tasa { get; set; }
        public decimal pDetal{ get; set; }
        public string empDetal { get; set; }
        public int contDetal{ get; set; }

        public decimal p1_neto1 { get; set; }
        public decimal p1_neto2 { get; set; }
        public decimal p1_neto3 { get; set; }
        public decimal p1_neto4 { get; set; }
        public int cont1_emp1 { get; set; }
        public int cont1_emp2 { get; set; }
        public int cont1_emp3 { get; set; }
        public int cont1_emp4 { get; set; }
        public string emp1_des1 { get; set; }
        public string emp1_des2 { get; set; }
        public string emp1_des3 { get; set; }
        public string emp1_des4 { get; set; }

        public decimal p2_neto1 { get; set; }
        public decimal p2_neto2 { get; set; }
        public decimal p2_neto3 { get; set; }
        public decimal p2_neto4 { get; set; }
        public int cont2_emp1 { get; set; }
        public int cont2_emp2 { get; set; }
        public int cont2_emp3 { get; set; }
        public int cont2_emp4 { get; set; }
        public string emp2_des1 { get; set; }
        public string emp2_des2 { get; set; }
        public string emp2_des3 { get; set; }
        public string emp2_des4 { get; set; }
    }
}