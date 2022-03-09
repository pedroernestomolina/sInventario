using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Visor.Precio
{
    
    
    public class dataVista
    {


        public string autoPrd { get; set; }
        public string codigoPrd { get; set; }
        public string nombrePrd { get; set; }
        public decimal costoDivisaUnd { get; set; }
        public decimal precio_1 { get; set; }
        public decimal precio_2 { get; set; }
        public decimal precio_3 { get; set; }
        public decimal precio_4 { get; set; }
        public decimal precio_5 { get; set; }
        public string estatus { get; set; }

        public bool precio_1_error 
        { 
            get 
            { 
                var rt=false;
                if (precio_1 > 0)
                {
                    return costoDivisaUnd > precio_1;
                }
                return rt;
            }
        }
        public bool precio_2_error
        {
            get
            {
                var rt = false;
                if (precio_2 > 0)
                {
                    return costoDivisaUnd > precio_2;
                }
                return rt;
            }
        }
        public bool precio_3_error
        {
            get
            {
                var rt = false;
                if (precio_3 > 0)
                {
                    return costoDivisaUnd > precio_3;
                }
                return rt;
            }
        }
        public bool precio_4_error
        {
            get
            {
                var rt = false;
                if (precio_4 > 0)
                {
                    return costoDivisaUnd > precio_4;
                }
                return rt;
            }
        }
        public bool precio_5_error
        {
            get
            {
                var rt = false;
                if (precio_5 > 0)
                {
                    return costoDivisaUnd > precio_5;
                }
                return rt;
            }
        }
        public bool Estatus_Inactivo
        {
            get
            {
                var rt = false;
                if (estatus.Trim().ToUpper()=="INACTIVO")
                {
                    rt = true;
                }
                return rt;
            }
        }


        public dataVista()
        {
            autoPrd = "";
            codigoPrd = "";
            nombrePrd = "";
            costoDivisaUnd = 0.0m;
            precio_1 = 0.0m;
            precio_2 = 0.0m;
            precio_3 = 0.0m;
            precio_4 = 0.0m;
            precio_5 = 0.0m;
        }

        public dataVista(OOB.LibInventario.Visor.Precio.Ficha it, decimal tasaCambio)
            :this()
        {
            this.autoPrd = it.autoPrd;
            this.codigoPrd = it.codigoPrd;
            this.nombrePrd = it.nombrePrd;
            this.costoDivisaUnd = it.costoDivisaUnd;
            this.estatus = it.estatus.Trim().ToUpper() == "ACTIVO" ? "" : "INACTIVO";
            if (tasaCambio > 0) 
            {
                this.precio_1 = it.precio_1/tasaCambio;
                this.precio_2 = it.precio_2/tasaCambio;
                this.precio_3 = it.precio_3/tasaCambio;
                this.precio_4 = it.precio_4/tasaCambio;
                this.precio_5 = it.precio_5/tasaCambio;
            }
        }

    }

}