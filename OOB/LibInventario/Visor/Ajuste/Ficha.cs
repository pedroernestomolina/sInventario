﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Visor.Ajuste
{
    
    public class Ficha
    {

        public decimal montoVentaNeto { get; set; }
        public List<FichaDetalle> detalles { get; set; }

    }

}