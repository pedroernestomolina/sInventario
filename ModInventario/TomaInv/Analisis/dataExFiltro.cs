﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.TomaInv.Analisis
{
    public class dataExFiltro: LibUtilitis.Opcion.IData 
    {
        public string codigo {get;set;}
        public string desc {get;set;}
        public string id {get;set;}
        public dataExFiltro()
        {
            codigo = "";
            desc = "";
            id = "";
        }
    }
}
