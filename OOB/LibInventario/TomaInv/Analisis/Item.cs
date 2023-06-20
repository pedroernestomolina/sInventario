﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.TomaInv.Analisis
{
    public class Item
    {
        public string idPrd { get; set; }
        public string codPrd { get; set; }
        public string descPrd { get; set; }
        public decimal fisico { get; set; }
        public decimal? conteo { get; set; }
        public decimal cntVenta { get; set; }
        public decimal cntCompra { get; set; }
        public decimal cntMovInv { get; set; }
        public decimal cntPorDespachar { get; set; }
        public decimal exDeposito { get; set; }
        public decimal costoMonLocal { get; set; }
        public decimal costoMonDivisa { get; set; }
        public int contEmpCompra { get; set; }
        public int contEmpInv { get; set; }
        public string estatusDivisa { get; set; }
        public string descEmpCompra { get; set; }
        public string descEmpInv { get; set; }
    }
}