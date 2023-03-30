﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Tools.FiltrosPara.Productos
{
    public class dataExportar
    {
        private string _cadenaBusq;
        private Enumerados.enumMetBusqueda _metBusqueda;


        public ficha Deposito { get; set; }
        public ficha Catalogo { get; set; }
        public ficha Oferta { get; set; }
        public ficha Categoria { get; set; }
        public ficha Existencia { get; set; }
        public ficha Departamento { get; set; }
        public ficha Grupo { get; set; }
        public ficha Marca { get; set; }
        public ficha Origen { get; set; }
        public ficha Estatus { get; set; }
        public ficha TasaIva { get; set; }
        public ficha AdmDivisa { get; set; }
        public ficha Pesado { get; set; }
        public ficha Proveedor { get; set; }
        public ficha TCS { get; set; }
        public string CadenaBusq { get { return _cadenaBusq; } }
        public Enumerados.enumMetBusqueda MetBusqueda { get { return _metBusqueda; } }


        public dataExportar()
        {
            _cadenaBusq = "";
            _metBusqueda = Enumerados.enumMetBusqueda.SinDefinir;
            limpiar();
        }


        public void Inicializa()
        {
            limpiar();
        }


        public void setCadenaBusq(string cadena)
        {
            _cadenaBusq = cadena;
        }
        public void setMetBusqByCodigo()
        {
            _metBusqueda = Enumerados.enumMetBusqueda.PorCodigo;
        }
        public void setMetBusqByNombre()
        {
            _metBusqueda = Enumerados.enumMetBusqueda.PorNombre;
        }
        public void setMetBusqByReferencia()
        {
            _metBusqueda = Enumerados.enumMetBusqueda.PorReferencia;
        }
        public void setMetBusqByCodigoBarra()
        {
            _metBusqueda = Enumerados.enumMetBusqueda.PorCodigoBarra;
        }


        public bool FiltrarIsOk()
        {
            if (CadenaBusq.Trim() != "") return true;
            if (Deposito != null) return true;
            if (Catalogo != null) return true;
            if (Categoria != null) return true;
            if (Oferta != null) return true;
            if (Existencia != null) return true;
            if (Departamento != null) return true;
            if (Grupo != null) return true;
            if (Marca != null) return true;
            if (Origen != null) return true;
            if (TasaIva != null) return true;
            if (Estatus != null) return true;
            if (AdmDivisa != null) return true;
            if (Pesado != null) return true;
            if (Proveedor != null) return true;
            if (TCS != null) return true;
            return false;
        }

        private void limpiar()
        {
            _cadenaBusq = "";
            Deposito = null;
            Categoria = null;
            Catalogo = null;
            Oferta = null;
            Existencia = null;
            Departamento = null;
            Grupo = null;
            Marca = null;
            Origen = null;
            Estatus = null;
            TasaIva = null;
            AdmDivisa = null;
            Pesado = null;
            Proveedor = null;
            TCS = null;
        }
    }
}