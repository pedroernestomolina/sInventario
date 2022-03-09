using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Visor.CostoExistencia
{
    
    public class data
    {

        private OOB.LibInventario.Visor.CostoExistencia.Ficha rg;


        public string CodigoPrd { get { return rg.codigoPrd; } }
        public string NombrePrd { get { return rg.nombrePrd; } }
        public string Deposito { get { return rg.nombreDeposito; } }
        public string Departamento { get { return rg.nombreDepart; } }
        public string SCntFisica { get { return rg.cntFisica.ToString("n" + rg.decimales); } }
        public string CostoUnd { get { return rg.costoUnd.ToString("n2"); } }
        public string CostoDivisaUnd { get { return rg.costoDivisaUnd.ToString("n2"); } }
        public string FechaUltCosto { get { return rg.fechaUltActCosto.ToShortDateString(); } }
        public bool EsAdmDivisa { get { return rg.esAdmDivisa == "S"; } }
        public bool EsPesado { get { return rg.esPesado == "S"; } }
        public decimal ExFisica { get { return rg.cntFisica; } }
        public string SImporteDivisa { get { return ImporteDivisa.ToString("n2"); } }
        public string SImporteLocal { get { return ImporteLocal.ToString("n2"); } }
        public decimal Importe 
        {
            get 
            {
                var rt = 0.0m;
                rt = rg.cntFisica* rg.costoUnd;
                return rt;
            }
        }
        public decimal ImporteDivisa 
        {
            get 
            {
                var rt = 0.0m;
                var costo = 0.0m ;
                if (EsAdmDivisa)
                    costo = rg.costoDivisaUnd;
                rt = (decimal)(rg.cntFisica * costo);
                return rt;
            }
        }
        public decimal ImporteLocal
        {
            get
            {
                var rt = 0.0m;
                var costo = rg.costoUnd;
                if (EsAdmDivisa)
                    costo = 0.0m ;
                rt = (decimal)(rg.cntFisica * costo);
                return rt;
            }
        }
        public int Estatus 
        {
            get 
            {
                var rt = 1;
                switch (rg.estatus.Trim().ToUpper()) 
                {
                    case "ACTIVO":
                        rt = 1;
                        break;
                    case "SUSPENDIDO":
                        rt = 2;
                        break;
                    case "INACTIVO":
                        rt = 3;
                        break;
                }
                return rt;
            }
        }


        public data(OOB.LibInventario.Visor.CostoExistencia.Ficha rg)
        {
            this.rg = rg;
        }

    }

}