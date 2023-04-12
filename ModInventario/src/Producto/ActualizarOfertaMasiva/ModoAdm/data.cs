using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Producto.ActualizarOfertaMasiva.ModoAdm
{
    public class data
    {
        private OOB.LibInventario.Producto.ActualizarOfertaMasiva.ModoAdm.Capturar.Ficha _rg;
        private decimal _porctOferta;


        public string AutoPrd { get { return _rg.idPrd; } }
        public int IdPrecioVta { get { return _rg.idPrecioVta; } }


        public data(OOB.LibInventario.Producto.ActualizarOfertaMasiva.ModoAdm.Capturar.Ficha rg, decimal porctOferta)
        {
            _rg = rg;
            _porctOferta = porctOferta;
        }


        public bool IsOk()
        {
            if (_rg.pnetoVtaUnd > 0m)
            {
                var _costo = _rg.costoUnd * _rg.contEmpVta;
                var _precio = _rg.pnetoVtaUnd;
                _costo = Math.Round(_costo, 2, MidpointRounding.AwayFromZero);
                var dscto = (_precio * _porctOferta / 100m);
                _precio -= dscto;
                _precio = Math.Round(_precio, 2, MidpointRounding.AwayFromZero);
                return _precio >= _costo;
            }
            return false;
        }
    }
}