using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Movimiento.DesCargo.CapturaMov
{

    public class Data
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
        public string estatusDivisa { get; set; }
        public decimal costoDivisa { get; set; }
        public string autoTasa { get; set; }
        public string descTasa { get; set; }
        public decimal valorTasa { get; set; }
        public string fechaUltActualizacionCosto { get; set; }
        public bool esAdmDivisa { get { return estatusDivisa.Trim() == "1" ? true : false; } }
        public decimal costoDivisaUnd { get { return Math.Round(costoDivisa / contEmp, 2, MidpointRounding.AwayFromZero); } }


        public Data()
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
            estatusDivisa = "";
            costoDivisa = 0m;
            autoTasa = "";
            descTasa = "";
            valorTasa = 0m;
            fechaUltActualizacionCosto = "";
        }

    }

}