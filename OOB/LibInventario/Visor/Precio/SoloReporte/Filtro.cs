﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Visor.Precio.SoloReporte
{
    
    public class Filtro
    {
        public int desdeCntDias { get; set; }
        public string autoDeposito { get; set; }
        public bool excluirCambiosMasivo { get; set; }
    }

}