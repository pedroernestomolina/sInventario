﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Configuracion.DepositoPreDeterminado
{
    
    public class Ficha
    {

        public List<Item> ListaPreDet { get; set; }


        public Ficha() 
        {
            ListaPreDet= new List<Item>();
        }

    }

}