﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Configuracion.MetodoCalculoUtilidad
{
    
    public class Precio
    {

        public decimal pneto { get; set; }
        public decimal pdf { get; set; }


        public Precio()
        {
            pneto = 0.0m;
            pdf = 0.0m;
        }

    }

}
