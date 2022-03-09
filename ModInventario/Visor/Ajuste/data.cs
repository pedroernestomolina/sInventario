using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Visor.Ajuste
{
    
    public class data
    {

        private OOB.LibInventario.Visor.Ajuste.FichaDetalle rg;


        public string CodigoPrd { get { return rg.codigoPrd; } }
        public string NombrePrd { get { return rg.nombrePrd; } }
        public string DepositoOrigen { get { return rg.nombreDepositoOrigen; } }
        public string DocumentoNro { get { return rg.documentoNro; } }
        public string FechaHora { get { return rg.fecha.ToShortDateString() + ", " + rg.hora; } }
        public string Usuario { get { return rg.nombreUsuario; } }
        public string CntUnd { get { return rg.cantidadUnd.ToString("n" + rg.decimales); } }
        public string CostoUnd { get { return rg.costoUnd.ToString("n2"); } }
        public string Importe { get { return rg.importe.ToString("n2"); } }
        public string Nota { get { return rg.nota; } }
        public int Signo { get { return rg.signo; } }
        public decimal Monto { get { return rg.importe; } }

        public string Tipo 
        {
            get 
            {
                var rt = "GANANCIA";
                if (rg.signo == -1)
                    rt = "PERDIDA";
                return rt;
            }
        }

        public data(OOB.LibInventario.Visor.Ajuste.FichaDetalle rg)
        {
            this.rg = rg;
        }

    }

}