using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.TomaInv
{
    public class data: IComparable<data>
    {
        public string idPrd { get; set; }
        public string codigoPrd { get; set; }
        public string descPrd { get; set; }
        public decimal costoPrd { get; set; }
        public decimal margen { get; set; }
        public decimal cnt { get; set; }


        public int CompareTo(data y)
        {
            if (this.costoPrd > y.costoPrd)
                return 1;
            else if (this.costoPrd < y.costoPrd)
                return -1;

            if (this.margen > y.margen)
                return 1;
            else if (this.margen < y.margen)
                return -1;

            if (this.cnt > y.cnt)
                return 1;
            else if (this.cnt < y.cnt)
                return -1;

            return 0;
        }
    }
}