using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Analisis.General
{
    
    public class data
    {

        private OOB.LibInventario.Analisis.General.Ficha rg;
        private int _dias;


        public string autoId { get { return rg.autoPrd; } }
        public string cntUnd { get { return rg.cntUnd.ToString("n"+rg.decimales.ToString().Trim()); } }
        public int cntDoc { get { return rg.cntDoc; } }
        public string nombrePrd { get { return rg.nombrePrd; } }
        public string codigoPrd { get { return rg.codigoPrd; } }
        public string cntUndxDia { get { return (rg.cntUnd/_dias).ToString("n0"); } }


        public data(OOB.LibInventario.Analisis.General.Ficha rg, int dias)
        {
            this.rg = rg;
            _dias = dias;
        }

    }

}