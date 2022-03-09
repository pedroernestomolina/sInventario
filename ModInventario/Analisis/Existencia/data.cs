using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Analisis.Existencia
{
    
    public class data
    {

        private OOB.LibInventario.Analisis.Existencia.Ficha it;


        public OOB.LibInventario.Analisis.Existencia.Ficha Ficha { get { return it; } }
        public string codigoPrd { get { return it.codigoPrd; } }
        public string nombrePrd { get { return it.nombrePrd; } }
        public string existencia { get { return it.cantUnd.ToString("n"+it.decimales) ; } }


        public data(OOB.LibInventario.Analisis.Existencia.Ficha it)
        {
            this.it = it;
        }

    }

}