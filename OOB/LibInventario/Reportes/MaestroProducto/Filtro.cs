﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Reportes.MaestroProducto
{
    public class Filtro
    {
        public string autoDeposito { get; set; }
        public string autoDepartamento { get; set; }
        public string autoGrupo { get; set; }
        public string autoTasa { get; set; }
        public enumerados.EnumAdministradorPorDivisa admDivisa { get; set; }
        public enumerados.EnumOrigen origen { get; set; }
        public enumerados.EnumCategoria categoria { get; set; }
        public enumerados.EnumEstatus estatus { get; set; }
        public enumerados.EnumPesado pesado { get; set; }
        public string estatusOferta { get; set; }


        public Filtro()
        {
            admDivisa = enumerados.EnumAdministradorPorDivisa.SnDefinir;
            origen = enumerados.EnumOrigen.SnDefinir;
            categoria = enumerados.EnumCategoria.SnDefinir;
            estatus = enumerados.EnumEstatus.SnDefinir;
            pesado = enumerados.EnumPesado.SnDefinir;
            autoDepartamento = "";
            autoDeposito = "";
            autoTasa = "";
            autoGrupo = "";
            estatusOferta = "";
        }
    }
}