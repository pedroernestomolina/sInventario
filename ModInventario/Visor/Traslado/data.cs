using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Visor.Traslado
{
    
    public class data
    {

        private OOB.LibInventario.Visor.Traslado.Ficha rg;


        public string CodigoPrd { get { return rg.codigoPrd; } }
        public string NombrePrd { get { return rg.nombrePrd; } }
        public string DepositoOrigen { get { return rg.nombreDepositoOrigen; } }
        public string DepositoDestino { get { return rg.nombreDepositoDestino; } }
        public string DocumentoNro { get { return rg.documentoNro; } }
        public string FechaHora { get { return rg.fecha.ToShortDateString()+", "+rg.hora; } }
        public string Usuario { get { return rg.nombreUsuario; } }
        public string Cnt { get { return rg.cantidad.ToString("n"+rg.decimales); } }
        public string Nota { get { return rg.nota; } }


        public data(OOB.LibInventario.Visor.Traslado.Ficha rg)
        {
            this.rg = rg;
        }

    }

}