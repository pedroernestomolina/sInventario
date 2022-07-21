﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Reportes.ResumenCostoInv
{
    
    public class PorCompras
    {

        public string auto { get; set; }
        public decimal cntUnd { get; set; }
        public decimal costoTotal { get; set; }
        public decimal factor { get; set; }
        public string documento { get; set; }
        public string siglas { get; set; }


        public PorCompras()
        {
            auto = "";
            cntUnd = 0m;
            costoTotal = 0m;
            factor = 0m;
            documento = "";
            siglas = "";
        }

    }

}