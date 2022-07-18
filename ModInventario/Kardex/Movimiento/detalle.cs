using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Kardex.Movimiento
{
    
    public class detalle
    {

        private OOB.LibInventario.Kardex.Movimiento.Resumen.Data reg;
        public string Siglas { get; set; }
        public string Deposito { get; set; }
        public string Concepto { get; set; }
        public int CntMovimiento { get; set; }
        public string CntInventario { get; set; }
        public OOB.LibInventario.Kardex.Movimiento.Resumen.Data Data { get { return reg; } }


        public detalle(OOB.LibInventario.Kardex.Movimiento.Resumen.Data reg, string decimales)
        {
            this.reg = reg;
            Siglas = reg.siglas;
            Deposito = reg.nombreDeposito.Trim() + "/" + reg.codigoDeposito;
            Concepto = reg.nombreConcepto.Trim() + "/" + reg.codigoConcepto;
            CntInventario = reg.cntInventario.ToString(decimales);
            CntMovimiento = reg.cntMovimiento;
        }

    }

}