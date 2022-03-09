﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Producto
{
    
    public class Filtro
    {

        public enum Existencia { SinDefinir = -1, MayorQueCero = 1, IgualCero, MenorQueCero };


        public string cadena { get; set; }
        public string autoProducto { get; set; }
        public string autoDepartamento { get; set; }
        public string autoGrupo { get; set; }
        public string autoDeposito { get; set; }
        public string autoTasa { get; set; }
        public string autoProveedor { get; set; }
        public string autoMarca { get; set; }
        public Existencia existencia { get; set; }
        public Enumerados.EnumOrigen origen { get; set; }
        public Enumerados.EnumEstatus estatus { get; set; }
        public Enumerados.EnumCategoria categoria { get; set; }
        public Enumerados.EnumAdministradorPorDivisa admPorDivisa { get; set; }
        public Enumerados.EnumPesado pesado { get; set; }
        public Enumerados.EnumCatalogo catalogo { get; set; }
        public Enumerados.EnumOferta oferta { get; set; }
        public Enumerados.EnumMetodoBusqueda MetodoBusqueda { get; set; }
        public bool? precioMayorHabilitado { get; set; }


        public Filtro()
        {
            Limpiar();
        }

        public void Limpiar()
        {
            cadena = "";
            autoProducto = "";
            autoDepartamento = "";
            autoDeposito = "";
            autoGrupo = "";
            autoTasa = "";
            autoProveedor = "";
            autoMarca = "";
            origen = Enumerados.EnumOrigen.SnDefinir;
            estatus = Enumerados.EnumEstatus.SnDefinir;
            categoria = Enumerados.EnumCategoria.SnDefinir;
            admPorDivisa = Enumerados.EnumAdministradorPorDivisa.SnDefinir;
            pesado = Enumerados.EnumPesado.SnDefinir;
            catalogo = Enumerados.EnumCatalogo.SnDefinir;
            oferta = Enumerados.EnumOferta.SnDefinir;
            MetodoBusqueda = Enumerados.EnumMetodoBusqueda.SnDefinir;
            existencia = Existencia.SinDefinir;
            precioMayorHabilitado = null;
        }

        public bool BusquedaOk 
        {
            get
            {
                var rt = false;
                if (cadena != "")
                    return true;
                if (autoProducto != "")
                    return true;
                if (autoDepartamento != "")
                    return true;
                if (autoGrupo != "")
                    return true;
                if (autoMarca != "")
                    return true;
                if (autoDeposito != "")
                    return true;
                if (autoTasa!= "")
                    return true;
                if (autoProveedor != "")
                    return true;
                return rt;
            }
        }

    }

}