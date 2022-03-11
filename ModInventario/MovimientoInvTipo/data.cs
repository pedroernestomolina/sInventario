using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.MovimientoInvTipo
{
    
    public class data
    {
        
        public string autoPrd { get; set; }
        public string autoDepart { get; set; }
        public string autoGrupo { get; set; }
        public string codigoPrd { get; set; }
        public string nombrePrd { get; set; }
        public string catPrd { get; set; }
        public decimal exFisica { get; set; }
        public int contEmp { get; set; }
        public string nombreEmp { get; set; }
        public string decimales { get; set; }
        public decimal costoUnd { get; set; }
        public decimal costo { get; set; }
        public decimal costoDivisa { get; set; }
        public string autoTasa { get; set; }
        public string descTasa { get; set; }
        public decimal valorTasa { get; set; }
        public bool esAdmDivisa { get ;set; }
        public decimal costoDivisaUnd { get; set; }
        public string fechaUltimaActCosto { get; set; }


        public string InfProductoDesc 
        { 
            get 
            {
                return codigoPrd + Environment.NewLine + nombrePrd;
            } 
        }
        public string InfProductoEmpaCompra 
        {
            get 
            {
                return nombreEmp + "(" + contEmp.ToString() + ")";
            }
        }
        public string InfProductoEsAdmDivisa
        {
            get
            {
                return esAdmDivisa ? "SI" : "NO";
            }
        }
        public string InfProductoTasaIva 
        {
            get
            {
                var rt = "EXENTO";
                if (valorTasa > 0)
                    rt = descTasa + "( " + valorTasa.ToString("n2") + " )";
                return rt;
            }
        }
        public string InfProductoFechaUltActCosto { get { return fechaUltimaActCosto; } }
        public decimal InfExistenciaActual { get { return exFisica; } }
        public bool InfProductoEsDivisa { get { return esAdmDivisa; } }



        public data()
        {
            autoPrd = "";
            autoDepart = "";
            autoGrupo = "";
            codigoPrd = "";
            nombrePrd = "";
            catPrd = "";
            exFisica = 0m;
            contEmp = 0;
            nombreEmp = "";
            decimales = "";
            costoUnd = 0m;
            costo = 0m;
            costoDivisa = 0m;
            autoTasa = "";
            descTasa = "";
            valorTasa = 0m;
            esAdmDivisa = false;
            costoDivisaUnd = 0m;
            fechaUltimaActCosto = "";
        }

    }

}