using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.TomaInv.Generar
{
    public class data
    {
        private TomaInv.data _prdToma;


        public string CodigoPrd { get { return _prdToma.codigoPrd; } }
        public string DescPrd { get { return _prdToma.descPrd; } }
        public TomaInv.data PrdToma { get { return _prdToma; } }


        public data(TomaInv.data item)
        {
            _prdToma = item;
        }
    }
}