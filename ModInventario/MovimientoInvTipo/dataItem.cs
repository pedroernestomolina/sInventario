﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.MovimientoInvTipo
{
    
    public class dataItem
    {

        private data _data;
        private decimal _tasaCambio;
        private decimal _cantidad;
        private decimal _cantidadUnd;
        private decimal _costo;
        private decimal _costoUnd;
        private decimal _importe;
        private int _signo;
        private ficha _empaque;
        private ficha _tipoMov;
        private string _empSeleccionado;
        private int _contEmpSeleccionado;



        public int Id { get; set; }
        public data Data{ get { return _data; } }


        public decimal InfTasaCambio { get { return _tasaCambio; } }
        public string InfProductoDesc { get { return _data.InfProductoDesc; } }
        public string InfProductoEmpaCompra { get { return _data.InfProductoEmpaCompra; } }
        public string InfProductoEsAdmDivisa { get { return _data.InfProductoEsAdmDivisa; } }
        public string InfProductoTasaIva { get { return _data.InfProductoTasaIva; } }
        public string InfProductoFechaUltActCosto { get { return _data.InfProductoFechaUltActCosto; } }
        public decimal InfExistenciaActual { get { return _data.InfExistenciaActual; } }
        public bool InfProductoEsDivisa { get { return _data.InfProductoEsDivisa; } }
        //
        public decimal InfNivelMinimoDepDestino { get { return _data.InfNivelMinimoDepDestino; } }
        public decimal InfNivelOptimoDepDestino { get { return _data.InfNivelOptimoDepDestino ; } }
        public decimal InfExFisicaDepDestino { get { return _data.InfExFisicaDepDestino; } }
        public decimal InfCntReponerDepDestino { get { return _data.InfCntReponerDepDestino; } }


        public ficha TipoMovFicha { get { return _tipoMov; } }
        public ficha EmpaqueFicha { get { return _empaque; } }


        public string TipoMovimiento { get { return _tipoMov.desc; } }
        public int Signo { get { return _signo; } }
        public string CodigoPrd { get { return _data.codigoPrd; } }
        public string DescripcionPrd { get { return _data.nombrePrd; } }
        public bool EsAdmDivisa { get { return _data.esAdmDivisa; } }
        public decimal CntUnd { get { return _cantidadUnd; } }
        public decimal CostoUnd { get { return _costoUnd; } }
        public decimal Importe { get { return _importe; } }
        public decimal Cantidad { get { return _cantidad; } }
        public decimal Costo { get { return _costo; } }
        public decimal ImporteNacional 
        { 
            get 
            {
                var rt = _importe * _signo;
                if (_data.esAdmDivisa)
                {
                    rt *= _tasaCambio;
                    rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                }
                return rt; 
            } 
        }
        public string Empaque 
        { 
            get 
            {
                var rt = "UNIDAD(1)";
                if (_empaque.id == "1")
                    rt = _data.InfProductoEmpaCompra;
                else if (_empaque.id == "3")
                    rt = _data.InfProductoEmpInventario;
                return rt; ; 
            } 
        }
        public bool MovPorUnidad { get { return _empaque.id == "2" ? true : false; } }
        public decimal CostoNacional 
        {
            get 
            {
                var rt = _costo;
                if (EsAdmDivisa)
                    rt *= _tasaCambio;
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            } 
        }
        public decimal CostoUndNacional 
        { 
            get 
            {
                var rt = _costoUnd;
                if (EsAdmDivisa)
                    rt *= _tasaCambio;
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            } 
        }


        public dataItem() 
        {
            Id = -1;
            _data = new data();
            _tasaCambio = 0m;
            _cantidad = 0m;
            _cantidadUnd = 0m;
            _costo = 0m;
            _costoUnd = 0m;
            _importe = 0m;
            _signo = 1;
            _empaque = null;
            _tipoMov = null;
            _empSeleccionado = null;
            _contEmpSeleccionado = 0;
        }

        public dataItem(dataItem ItemActual)
            :this()
        {
            Id = ItemActual.Id;
            _data = ItemActual._data;
            _tasaCambio = ItemActual._tasaCambio;
            _cantidad = ItemActual._cantidad;
            _cantidadUnd = ItemActual._cantidadUnd;
            _costo = ItemActual._costo;
            _costoUnd = ItemActual._costoUnd;
            _importe = ItemActual._importe;
            _signo = ItemActual._signo;
            _empaque = ItemActual._empaque;
            _tipoMov = ItemActual._tipoMov;
            _empSeleccionado = ItemActual._empSeleccionado;
            _contEmpSeleccionado = ItemActual._contEmpSeleccionado;
        }


        public void setTasaCambio(decimal p)
        {
            _tasaCambio = p;
        }

        public void setFicha(data dat)
        {
            _data = dat;
        }
        public void setCantidad(decimal p)
        {
            _cantidad = p;
            Calcular();
        }
        public void setCosto(decimal p)
        {
            _costo = p;
            Calcular();
        }
        public void setEmpaque(ficha ficha)
        {
            _empaque = ficha;
            if (ficha != null) 
            {
                if (ficha.id == "1")
                {
                    _contEmpSeleccionado = _data.contEmp;
                    _empSeleccionado = _data.nombreEmp;
                    _costo = _data.costo;
                    _costoUnd = _data.costoUnd;
                    if (_data.esAdmDivisa)
                    {
                        _costo = Math.Round(_data.costoDivisa, 2, MidpointRounding.AwayFromZero);
                        _costoUnd = Math.Round(_data.costoDivisaUnd, 2, MidpointRounding.AwayFromZero);
                    }
                }
                if (ficha.id == "2")
                {
                    _contEmpSeleccionado = 1;
                    _empSeleccionado = "UNIDAD";
                    _costo = _data.costoUnd;
                    _costoUnd = _data.costoUnd;
                    if (_data.esAdmDivisa)
                    {
                        _costo = Math.Round(_data.costoDivisaUnd, 2, MidpointRounding.AwayFromZero);
                        _costoUnd = Math.Round(_data.costoDivisaUnd, 2, MidpointRounding.AwayFromZero);
                    }
                }
                if (ficha.id == "3")
                {
                    _contEmpSeleccionado = _data.contEmpInv;
                    _empSeleccionado = _data.nombreEmpInv;
                    _costo = _data.costoUnd * _data.contEmpInv;
                    _costoUnd = _data.costoUnd;
                    if (_data.esAdmDivisa)
                    {
                        _costo = Math.Round(_data.costoDivisaUnd * _data.contEmpInv, 2, MidpointRounding.AwayFromZero);
                        _costoUnd = Math.Round(_data.costoDivisaUnd, 2, MidpointRounding.AwayFromZero);
                    }
                }
            }
            Calcular();
        }
        public void setTipoMov(ficha ficha)
        {
            _tipoMov = ficha;
            if (ficha != null)
            {
                _signo = 1;
                if (ficha.id == "2") 
                {
                    _signo = -1;
                }
            }
            Calcular();
        }


        private void Calcular()
        {
            _importe = _costo * _cantidad;
            var cont=1;
            if (_empaque != null)
            {
                if (_empaque.id == "1")
                {
                    cont = _data.contEmp;
                }
                else if (_empaque.id == "3") 
                {
                    cont = _data.contEmpInv;
                }
            }
            _cantidadUnd = _cantidad * cont;
            _costoUnd = _costo / cont ;
        }


        public string InfProductoEmpInventario { get { return _data.InfProductoEmpInventario; } }
        public string InfProductoEmpUnidad { get { return _data.InfProductoEmpUnidad; } }


        public string empSeleccionado { get { return _empSeleccionado; } }
        public int contEmpSeleccionado { get { return _contEmpSeleccionado; } }
    }

}