﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Reportes.MaestroExistenciaInventario
{
    
    public class Filtro
    {

        public string autoDepartamento { get; set; }
        public string autoGrupo { get; set; }
        public string autoDeposito { get; set; }


        public Filtro()
        {
            autoDepartamento = "";
            autoGrupo = "";
            autoDeposito = "";
        }

    }

}