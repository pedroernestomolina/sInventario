﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Producto.Estatus.Actual
{

    public class Ficha
    {

        public string autoProducto { get; set; }
        public string codigoProducto { get; set; }
        public string nombreProducto { get; set; }
        public string referenciaProducto { get; set; }
        public Enumerados.EnumEstatus estatus { get; set; }


        public void Limpiar()
        {
            autoProducto = "";
            codigoProducto = "";
            nombreProducto = "";
            referenciaProducto = "";
            estatus = Enumerados.EnumEstatus.SnDefinir;
        }

    }

}