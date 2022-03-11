using System;
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
        private ficha _empaque;


        public int Id { get; set; }
        public decimal InfTasaCambio { get { return _tasaCambio; } }
        public string InfProductoDesc { get { return _data.InfProductoDesc; } }
        public string InfProductoEmpaCompra { get { return _data.InfProductoEmpaCompra; } }
        public string InfProductoEsAdmDivisa { get { return _data.InfProductoEsAdmDivisa; } }
        public string InfProductoTasaIva { get { return _data.InfProductoTasaIva; } }
        public string InfProductoFechaUltActCosto { get { return _data.InfProductoFechaUltActCosto; } }
        public decimal InfExistenciaActual { get { return _data.InfExistenciaActual; } }
        public bool InfProductoEsDivisa { get { return _data.InfProductoEsDivisa; } }


        public ficha EmpaqueFicha { get { return _empaque; } }
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
                var rt = _importe;
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
                return rt; ; 
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
            _empaque = null;
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
                    _costo = _data.costoUnd;
                    _costoUnd = _data.costoUnd;
                    if (_data.esAdmDivisa)
                    {
                        _costo = Math.Round(_data.costoDivisaUnd, 2, MidpointRounding.AwayFromZero);
                        _costoUnd = Math.Round(_data.costoDivisaUnd, 2, MidpointRounding.AwayFromZero);
                    }
                }
            }
            Calcular();
        }

        private void Calcular()
        {
            _importe = _costo * _cantidad;
            _cantidadUnd = _cantidad * _data.contEmp;
        }

    }

}