using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.TomaInv.Analisis
{
    public class data
    {
        public enum enumAnalisis { SinDefinir = -1, OK = 0, Falta, Sobra };
        private decimal _diferencia;
        private OOB.LibInventario.TomaInv.Analisis.Item _itemAnalisis;
        private enumAnalisis _analisis;


        public OOB.LibInventario.TomaInv.Analisis.Item itemAnalisis { get { return _itemAnalisis; } }
        public string CodigoPrd { get { return _itemAnalisis.codPrd; } }
        public string DescPrd { get { return _itemAnalisis.descPrd; } }
        public decimal Diferencia { get { return Math.Abs(_diferencia); } }
        public enumAnalisis Estado { get { return _analisis; } }
        public bool Eliminar { get; set; }


        public data(OOB.LibInventario.TomaInv.Analisis.Item item)
        {
            Eliminar = false;
            _itemAnalisis = item;
            var _ex = (_itemAnalisis.fisico + _itemAnalisis.cntVenta + _itemAnalisis.cntCompra + _itemAnalisis.cntMovInv+ _itemAnalisis.cntPorDespachar);
            if (_itemAnalisis.conteo.HasValue)
            {
                _diferencia = _ex - _itemAnalisis.conteo.Value;
                if (_diferencia == 0m)
                {
                    _analisis = enumAnalisis.OK;
                }
                else if (_diferencia > 0)
                {
                    _analisis = enumAnalisis.Falta;
                }
                else
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
    }
}