using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Reportes.Kardex
{
    
    public class Mov
    {

        public string autoPrd { get; set; }
        public string codigoPrd { get; set; } 
        public string nombrePrd { get; set; } 
        public string referenciaPrd { get; set; } 
        public string modeloPrd { get; set; } 
        public string decimalesPrd { get; set; } 
        public DateTime fechaMov { get; set; } 
        public string horaMov { get; set; } 
        public string moduloMov { get; set; } 
        public string siglasMov { get; set; } 
        public string documentoNro { get; set; } 
        public string deposito { get; set; } 
        public decimal cantidadUnd { get; set; } 
        public string concepto { get; set; }
        public int signoMov { get; set; } 
        public string entidadMov { get; set; } 
        public decimal existenciaInicial { get; set; }
        public int ordenPrioridad 
        {
            get 
            {
                var xr=0;
                switch (moduloMov.Trim().ToUpper())
                {
                    case "COMPRAS":
                        xr=1;
                        break;
                    case "INVENTARIO":
                        xr=2;
                        break;
                    case "VENTAS":
                        xr=3;
                        break;
                }
                return xr;
            }
        }


        public Mov() 
        {
            autoPrd = "";
            codigoPrd = "";
            nombrePrd = "";
            referenciaPrd = "";
            modeloPrd = "";
            decimalesPrd = "";
            fechaMov = DateTime.Now.Date;
            horaMov = "";
            moduloMov = "";
            siglasMov = "";
            documentoNro = "";
            deposito = "";
            cantidadUnd = 0m;
            concepto = "";
            signoMov = 1;
            entidadMov = "";
            existenciaInicial = 0m;
        }

    }

}