using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Reportes.MaestroPrecio
{
    
    public class Ficha
    {

        public string codigoPrd { get; set; } 
        public string nombrePrd { get; set; }  
        public string referenciaPrd { get; set; }  
        public string modeloPrd { get; set; }
        public string departamento { get; set; }
        public string grupo { get; set; }
        public decimal tasaIvaPrd { get; set; }  
        public decimal precioNeto_1 { get; set; }  
        public decimal precioNeto_2 { get; set; }  
        public decimal precioNeto_3 { get; set; }  
        public decimal precioNeto_4 { get; set; }  
        public decimal precioNeto_5 { get; set; }  
        public decimal precioDivisaFull_1 { get; set; }  
        public decimal precioDivisaFull_2 { get; set; }  
        public decimal precioDivisaFull_3 { get; set; }  
        public decimal precioDivisaFull_4 { get; set; }  
        public decimal precioDivisaFull_5 { get; set; } 
        public DateTime fechaUltCambioPrd { get; set; }  
        public enumerados.EnumAdministradorPorDivisa isAdmDivisaPrd { get; set; }

        public decimal precioFull_1 { get { return calculaFull(precioNeto_1); } }
        public decimal precioFull_2 { get { return calculaFull(precioNeto_2); } }
        public decimal precioFull_3 { get { return calculaFull(precioNeto_3); } }
        public decimal precioFull_4 { get { return calculaFull(precioNeto_4); } }
        public decimal precioFull_5 { get { return calculaFull(precioNeto_5); } }

        
        private decimal calculaFull(decimal neto )
        {
            var rt = 0.0m;
            rt = neto + (neto * tasaIvaPrd / 100);
            return rt;
        }

    }

}