﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Precio.EditarCambiar
{
    public class dataPrecio
    {
        public enum enumMetCalUtilidad { SinDefinir = -1, Financiero = 1, Lineal };


        private int _contenido;
        private decimal _utilidadNueva;
        private decimal _utilidadActual;
        private decimal _costoEmpCompra;
        private int _contEmpCompra;
        private bool _admDivisa;
        private decimal _tasaCambio;
        private decimal _tasaIva;
        private enumMetCalUtilidad _metodoCalculoUtilidad;
        private decimal _pn;
        private decimal _pf;
        private string _empaqueDesc;
        private bool _isError; 


        public int Contenido { get { return _contenido; } }
        public decimal Utilidad { get { return _utilidadNueva; } }
        public decimal UtilidadActual { get { return _utilidadActual; } }
        public decimal  Neto { get { return _pn; } }
        public decimal Full { get { return _pf; } }
        public decimal CostoEmpCompraUnd { get { return (_costoEmpCompra / _contEmpCompra) * _contenido; } }
        public bool IsError { get { return _utilidadNueva < 0m  || _isError; } }


        public dataPrecio() 
        {
            _isError = false;
            _contenido=0;
            _utilidadNueva=0m;
            _utilidadActual = 0m;
            _costoEmpCompra = 0m;
            _contEmpCompra = 0;
            _admDivisa = false;
            _tasaCambio = 0m;
            _tasaIva = 0m;
            _metodoCalculoUtilidad = enumMetCalUtilidad.SinDefinir;
            _pn = 0m;
            _pf = 0m;
            _empaqueDesc = "";
        }

        public void Inicializa()
        {
            _isError = false;
            _contenido = 0;
            _utilidadNueva = 0m;
            _utilidadActual = 0m;
            _costoEmpCompra = 0m;
            _contEmpCompra = 0;
            _admDivisa = false;
            _tasaCambio = 0m;
            _tasaIva = 0m;
            _metodoCalculoUtilidad = enumMetCalUtilidad.SinDefinir;
            _pn = 0m;
            _pf = 0m;
        }


        public void setUtilidadActual(decimal ut)
        {
            _utilidadActual = ut;
        }
        public void setCostoEmpCompra(decimal costo)
        {
            _costoEmpCompra = costo;
        }
        public void setContEmpCompra(int cont)
        {
            _contEmpCompra = cont;
        }
        public void setAdmDivisa(bool admDivisa)
        {
            _admDivisa = admDivisa;
        }
        public void setTasaCambio(decimal factorCambio)
        {
            _tasaCambio = factorCambio;
        }
        public void setTasaIva(decimal tasaIva)
        {
            _tasaIva = tasaIva;
        }
        public void setMetodoCalculoUtilidad(enumMetCalUtilidad modo)
        {
            _metodoCalculoUtilidad = modo;
        }
        public void setContenido(int cont)
        {
            _contenido = cont;
            setUtilidadNueva(_utilidadNueva);
        }
        public void setUtilidadNueva(decimal ut)
        {
            _isError = false;
            if (_metodoCalculoUtilidad == enumMetCalUtilidad.Financiero)
            {
                if (ut >= 100m || ut <= 0m)
                {
                    _utilidadNueva = 0;
                    _pn = 0m;
                    _pf = 0m;
                }
                else
                {
                    _utilidadNueva = ut;
                    var c = ((100m - ut) / 100m);
                    _pn = CostoEmpCompraUnd / c;
                    _pf = calculaFull(_pn);
                }
            }
            else if (_metodoCalculoUtilidad == enumMetCalUtilidad.Lineal) 
            {
                if (ut <= 0m)
                {
                    _utilidadNueva = 0m;
                    _pn = 0m;
                    _pf = 0m;
                }
                else 
                {
                    _utilidadNueva = ut;
                    _pn = CostoEmpCompraUnd + (CostoEmpCompraUnd * ut / 100);
                    _pf = calculaFull(_pn);
                }
            }
        }
        public void setNeto(decimal monto)
        {
            _isError = false;
            if (_metodoCalculoUtilidad == enumMetCalUtilidad.Financiero)
            {
                if (monto <= 0m)
                {
                    _utilidadNueva = 0m;
                    _pn = 0m;
                    _pf = 0m;
                }
                else 
                {
                    _pn = monto;
                    _pf = calculaFull(monto);
                    var c = 1- (CostoEmpCompraUnd / monto);
                    c *= 100m;
                    _utilidadNueva = c;
                }
            }
            else if (_metodoCalculoUtilidad == enumMetCalUtilidad.Lineal)
            {
                if (monto <= 0m)
                {
                    _utilidadNueva = 0m;
                    _pn = 0m;
                    _pf = 0m;
                }
                else 
                {
                    _pn = monto;
                    _pf = calculaFull(monto);
                    _utilidadNueva = 0m;
                    if (CostoEmpCompraUnd > 0m) 
                    {
                        var c = (monto / CostoEmpCompraUnd) - 1;
                        c *= 100m;
                        _utilidadNueva = c;
                    }
                }
            }
        }
        public void setFull(decimal monto)
        {
            _isError = false;
            if (_metodoCalculoUtilidad == enumMetCalUtilidad.Financiero)
            {
                if (monto < 0m)
                {
                }
                else if (monto==0m)
                {
                    _utilidadNueva = 0m;
                    _pn = 0m;
                    _pf = 0m;
                }
                else 
                {
                    _pf = monto;
                    _pn = calculaNeto(monto);
                    var c = 1 - (CostoEmpCompraUnd / _pn);
                    c *= 100m;
                    _utilidadNueva = c;
                }
            }
            else if (_metodoCalculoUtilidad == enumMetCalUtilidad.Lineal)
            {
                if (monto <= 0m)
                {
                    _utilidadNueva = 0m;
                    _pn = 0m;
                    _pf = 0m;
                }
                else
                {
                    _pf = monto;
                    _pn = calculaNeto(monto);
                    _utilidadNueva = 0m;
                    if (CostoEmpCompraUnd > 0) 
                    {
                        var c = (_pn / CostoEmpCompraUnd) - 1;
                        c *= 100m;
                        _utilidadNueva = c;
                    }
                }
            }
        }


        private decimal calculaNeto(decimal monto)
        {
            var rt = 0m;
            rt = monto / ((_tasaIva / 100) + 1);
            rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            return rt;
        }
        private decimal calculaFull(decimal monto)
        {
            var rt = 0m;
            rt = monto + (monto * _tasaIva / 100);
            rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            return rt;
        }


        public decimal Full_Divisa 
        {
            get
            {
                var rt = Full;
                if (!_admDivisa)
                {
                    rt /= _tasaCambio;
                }
                return rt;
            }
        }
        public decimal Neto_MonedaLocal 
        { 
            get 
            {
                var rt = Neto;
                if (_admDivisa) 
                {
                    rt *= _tasaCambio;
                }
                return rt;
            }
        }


        public string msgError { get; set; }
        public bool IsOk()
        {
            msgError = "";
            var rt = true;
            if (_contenido <= 0) 
            {
                msgError="CONTENIDO EMPAQUE INCORRECTO";
                return false;
            }
            if (_utilidadNueva < 0)
            {
                msgError = "MARGEN UTILIDAD INCORRECTO";
                return false;
            }
            ReCalcular();
            if (_isError) 
            {
                msgError = "PRECIO INCORRECTO";
                return false;
            }
            return rt;
        }


        public decimal TasaCambio { get { return _tasaCambio; } }
        public string EmpaqueDesc { get { return _empaqueDesc; } }
        public void setEmpDescVenta(string desc)
        {
            _empaqueDesc = desc;
        }
        public decimal Neto_OtraMoneda { get { return CalculaNetoOtraMoneda(); } }
        private decimal CalculaNetoOtraMoneda()
        {
            var rt = 0m;
            if (_admDivisa)
            {
                rt = Neto * _tasaCambio;
            }
            else 
            {
                if (_tasaCambio > 0) 
                {
                    rt = Neto / _tasaCambio;
                }
            }
            rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            return rt;
        }
        public decimal Full_OtraMoneda { get { return CalculaFullOtraMoneda(); } }
        private decimal CalculaFullOtraMoneda()
        {
            var _full = 0m;
            _full = CalculaIva(CalculaNetoOtraMoneda());
            return _full;
        }
        private decimal CalculaIva(decimal monto)
        {
            var rt = 0m;
            rt = (monto * _tasaIva) / 100m;
            rt += monto;
            rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            return rt;
        }
        public void ReCalcular()
        {
            _isError = false;
            if (_pn>0m && CostoEmpCompraUnd > _pn)
            {
                _isError = true;
                msgError = "PRECIO INCORRECTO";
            }
        }
    }
}