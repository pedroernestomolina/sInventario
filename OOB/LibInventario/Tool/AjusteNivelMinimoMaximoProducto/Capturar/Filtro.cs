﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Tool.AjusteNivelMinimoMaximoProducto.Capturar
{
    
    public class Filtro
    {

        public string autoDeposito { get; set; }
        public string autoDepartamento { get; set; }
        public string cadena { get; set; }


        public Filtro()
        {
            autoDeposito = "";
            autoDepartamento = "";
            cadena = "";
        }

    }

}