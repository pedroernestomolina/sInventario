using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Visor.EntradaxCompra.ModoSoloReporte
{
    
    public class data
    {

        private OOB.LibInventario.Visor.EntradaxCompra.Ficha rg;


        public string codPrd { get { return rg.codigoPrd; } }
        public string descPrd { get { return rg.nombrePrd; } }
        public string fechaHora { get { return rg.fecha.ToShortDateString() + ", " + rg.hora; } }
        public string documento { get { return rg.nroDoc; } }
        public string siglas { get { return rg.siglasDoc; } }
        public string entidad { get { return rg.entidadProv; } }
        public decimal cnt { get { return rg.cantUnd * rg.signoDoc; } }


        public data(OOB.LibInventario.Visor.EntradaxCompra.Ficha rg)
        {
            this.rg = rg;
        }

    }

}