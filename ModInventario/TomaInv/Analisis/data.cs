using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.TomaInv.Analisis
{
    public class data
    {
        public enum enumAnalisis { SinDefinir = -1, OK = 0, Falta, Sobra, NoHay };
        private decimal _diferencia;
        private OOB.LibInventario.TomaInv.Analisis.Item _itemAnalisis;
        private enumAnalisis _analisis;


        public OOB.LibInventario.TomaInv.Analisis.Item itemAnalisis { get { return _itemAnalisis; } }
        public string CodigoPrd { get { return _itemAnalisis.codPrd; } }
        public string DescPrd { get { return _itemAnalisis.descPrd; } }
        public decimal Diferencia { get { return Math.Abs(_diferencia); } }
        public enumAnalisis Estado { get { return _analisis; } }
        public bool Eliminar { get; set; }


        private decimal _conteoGeneral=0m;
        private decimal _conteoPorEmpCompra= 0m;
        private decimal _conteoPorEmpInv = 0m;
        private decimal _conteoPorEmpUnd = 0m;
        public decimal conteoGeneral 
        {
            get 
            {
                _conteoGeneral = 0m;
                _conteoGeneral = _itemAnalisis.conteo.HasValue ? _itemAnalisis.conteo.Value : 0m;
                return _conteoGeneral;
            } 
        }
        public decimal conteoPorEmpCompra 
        { 
            get 
            {
                _conteoGeneral = _itemAnalisis.conteo.HasValue ? _itemAnalisis.conteo.Value : 0m;
                _conteoPorEmpCompra = 0m;
                if (_conteoGeneral > 0m) 
                {
                    if (_itemAnalisis.contEmpCompra > 0) 
                    {
                        _conteoPorEmpCompra = (int)(_conteoGeneral / _itemAnalisis.contEmpCompra);
                    }
                }
                return _conteoPorEmpCompra;
            } 
        }
        public string descEmpCompra { get { return _itemAnalisis.descEmpCompra.Trim()+"(" + _itemAnalisis.contEmpCompra.ToString("n0") + ")"; } }
        public decimal conteoPorEmpInv 
        {
            get
            {
                _conteoPorEmpInv = 0m;
                var _cnt = (_conteoGeneral - (_conteoPorEmpCompra * _itemAnalisis.contEmpCompra));
                if (_cnt > 0m)
                {
                    if (_itemAnalisis.contEmpInv > 0)
                    {
                        _conteoPorEmpInv = (int)(_cnt/ _itemAnalisis.contEmpInv);
                    }
                }
                return _conteoPorEmpInv;
            }
        }
        public string descEmpInv { get { return _itemAnalisis.descEmpInv.Trim()+"(" + _itemAnalisis.contEmpInv.ToString("n0") + ")"; } }
        public decimal conteoPorEmpUnd
        {
            get 
            {
                var _e1= _conteoPorEmpCompra * _itemAnalisis.contEmpCompra;
                var _e2= _conteoPorEmpInv * _itemAnalisis.contEmpInv;
                _conteoPorEmpUnd = (int)(_conteoGeneral - (_e1 + _e2));
                return _conteoPorEmpUnd;
            }
        }
        public string descEmpUnd { get { return "Und (1)"; } }


        public data(OOB.LibInventario.TomaInv.Analisis.Item item)
        {
            Eliminar = false;
            _itemAnalisis = item;
            var _ex = (_itemAnalisis.fisico + _itemAnalisis.cntVenta + _itemAnalisis.cntCompra + _itemAnalisis.cntMovInv+ _itemAnalisis.cntPorDespachar);
            if (_itemAnalisis.conteo.HasValue)
            {
                if (_itemAnalisis.conteo.Value < 0m)
                {
                    _analisis = enumAnalisis.NoHay;
                    return;
                }

                _diferencia = _ex - _itemAnalisis.conteo.Value;
                if (_diferencia == 0m && _itemAnalisis.conteo.Value>0m)
                {
                    _analisis = enumAnalisis.OK;
                }
                else if (_diferencia > 0)
                {
                    _analisis = enumAnalisis.Falta;
                }
                else if (_diferencia < 0)
                {
                    _analisis = enumAnalisis.Sobra;
                }
            }
            else 
            {
                _analisis = enumAnalisis.SinDefinir;
            }
        }

        public void setConteoNull()
        {
            _diferencia = 0;
            _analisis = enumAnalisis.SinDefinir;
            Eliminar = false;
        }
        public void Marcar(bool m)
        {
            Eliminar = m;
        }

        public void setMotivo(string desc)
        {
            _itemAnalisis.motivo = desc;
        }
        public void setConteoNoHay()
        {
            _analisis = enumAnalisis.NoHay;
        }
    }
}