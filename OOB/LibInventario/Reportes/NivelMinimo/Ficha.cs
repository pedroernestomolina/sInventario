﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Reportes.NivelMinimo
{
    
    public class Ficha
    {

        public string codigoPrd { get; set; }
        public string nombrePrd { get; set; }
        public string codigoDep { get; set; }
        public string nombreDep { get; set; }
        public decimal existencia { get; set; }
        public decimal nivelMin { get; set; }
        public decimal nivelMax { get; set; }
        public decimal reposicion { get { return nivelMax - existencia; } }
        public string departamento { get; set; }
        public string grupo { get; set; }

    }

}