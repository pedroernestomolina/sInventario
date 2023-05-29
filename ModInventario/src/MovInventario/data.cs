using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.MovInventario
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
        public decimal nivelMinimoDepDestino { get; set; }
        public decimal nivelOptimoDepDestino { get; set; }
        public decimal exFisicaDepDestino { get; set; }
        public int contEmpInv { get; set; }
        public string nombreEmpInv { get; set; }
        public string autoDepOrigen { get; set; }
        public string autoDepDestino { get; set; }
        public decimal cntReponerDepDestino 
        {
            get 
            {
                var r = nivelOptimoDepDestino - exFisicaDepDestino;
                if (r < 0) { r = 0m; }
                return r; 
            } 
        }
    }
}