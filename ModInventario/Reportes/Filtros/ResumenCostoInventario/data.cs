using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Filtros.ResumenCostoInventario
{
    
    public class data
    {

        public string autoPrd { get; set; }
        public string codigoPrd { get; set; }
        public string nombrePrd { get; set; }
        public decimal contEmpPrd { get; set; }
        public decimal exIniUnd { get; set; }
        public decimal costoIniEmpDivisa { get; set; }
        public decimal cntUndMovInv { get; set; }
        public decimal costoMovInvDivisa { get; set; }
        public decimal cntUndCompra { get; set; }
        public decimal costoCompraDivisa { get; set; }
        public decimal cntUndVenta { get; set; }
        public decimal costoVentaDivisa { get; set; }
        public string datRegMovInv { get; set; }
        public string datRegComp { get; set; }
        public decimal ventaDivisa { get; set; }


        public data() 
        {
            autoPrd = "";
            codigoPrd = "";
            nombrePrd = "";
            contEmpPrd = 0m;
            exIniUnd = 0m;
            costoIniEmpDivisa = 0m;
            cntUndMovInv = 0m;
            costoMovInvDivisa = 0m;
            cntUndCompra = 0m;
            costoCompraDivisa = 0m;
            cntUndVenta = 0m;
            costoVentaDivisa = 0m;
            datRegMovInv = "";
            datRegComp = "";
            ventaDivisa = 0m;
        }

    }

}
