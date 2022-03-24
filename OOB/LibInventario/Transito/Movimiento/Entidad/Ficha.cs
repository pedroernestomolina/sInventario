﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Transito.Movimiento.Entidad
{
    
    public class Ficha
    {


        public Mov mov { get; set; }
        public List<Detalle> detalles { get; set; }


        public Ficha() 
        {
            mov = new Mov();
            detalles = new List<Detalle>();
        }

    }

}