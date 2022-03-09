using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Visor.CostoEdad
{
    
    public class data
    {

        private OOB.LibInventario.Visor.CostoEdad.FichaDetalle rg;
        private DateTime fechaServidor;


        public string CodigoPrd { get { return rg.codigoPrd; } }
        public string NombrePrd { get { return rg.nombrePrd; } }
        public string Deposito { get { return rg.nombreDeposito; } }
        public string Departamento { get { return rg.nombreDepart; } }
        public string CntFisica { get { return rg.cntFisica.ToString("n" + rg.decimales); } }
        public string CostoUnd { get { return rg.costoUnd.ToString("n2"); } }
        public string CostoDivisaUnd { get { return rg.costoDivisaUnd.ToString("n2"); } }
        public string FechaUltCosto { get { return rg.fechaUltActCosto.ToShortDateString(); } }
        public string FechaUltVenta { get { return rg.fechaUltVenta.ToShortDateString(); } }
        public int CostoEdad { get { return fechaServidor.Subtract(rg.fechaUltActCosto).Days; } }
        public bool EsAdmDivisa { get { return rg.esAdmDivisa=="S"; } }
        public bool EsPesado { get { return rg.esPesado == "S"; } }
        public decimal ExFisica { get { return rg.cntFisica; } }
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


        public data(OOB.LibInventario.Visor.CostoEdad.FichaDetalle rg, DateTime fecha)
        {
            this.rg = rg;
            this.fechaServidor = fecha;
        }

    }

}