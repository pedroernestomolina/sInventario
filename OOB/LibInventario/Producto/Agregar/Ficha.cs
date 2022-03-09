﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Producto.Agregar
{
    
    public class Ficha
    {

        public string autoDepartamento { get; set; }
        public string autoGrupo { get; set; }
        public string autoMarca { get; set; }
        public string autoTasaImpuesto { get; set; }
        public string autoEmpCompra { get; set; }

        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string modelo { get; set; }
        public string referencia { get; set; }
        public int contenidoCompra { get; set; }

        public string origen { get; set; }
        public string categoria { get; set; }
        public string estatusDivisa { get; set; }
        public string abc { get; set; }
        public decimal tasa { get; set; }
        public string estatus { get; set; }

        public byte[] imagen { get; set; }
        public string esPesado { get; set; }
        public string plu { get; set; }
        public int diasEmpaque { get; set; }

        public string estatusCatalogo { get; set; }

        public List<FichaCodAlterno> codigosAlterno { get; set; }

    }

}