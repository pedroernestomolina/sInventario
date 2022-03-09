using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Analisis.Detallado
{
    
    public class data
    {

        private OOB.LibInventario.Analisis.Detallado.Ficha rg;


        public string cntUnd { get { return rg.cntUnd.ToString("n" + rg.decimales.ToString().Trim()); } }
        public int cntDoc { get { return rg.cntDoc; } }
        public DateTime fecha { get { return rg.fecha; } }
        public OOB.LibInventario.Analisis.Detallado.Ficha ficha { get { return rg; } } 


        public data(OOB.LibInventario.Analisis.Detallado.Ficha rg)
        {
            this.rg = rg;
        }

    }

}