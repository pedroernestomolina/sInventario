﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.TomaInv.Procesar
{
    public class Ficha
    {
        public string idToma { get; set; }
        public string observaciones { get; set; }
        public string autoriza { get; set; }
        public int cntItems { get; set; }
        public List<Item> items { get; set; }
    }
}