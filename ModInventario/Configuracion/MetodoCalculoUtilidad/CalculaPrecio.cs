using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Configuracion.MetodoCalculoUtilidad
{
    
    public class CalculaPrecio
    {

        private List<OOB.LibInventario.Configuracion.MetodoCalculoUtilidad.CapturarData.Ficha> list;
        private decimal _tasaCambio;
        private metodoCalculoUtilidad _metodoCalculoUt;
        private OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio _preferenciaPrecio;
        private OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta _redondeoPrecio;


        public enum metodoCalculoUtilidad { SinDefinir=-1, Lineal = 1, Financiero };


        public CalculaPrecio()
        {
            list = null;
            _tasaCambio = 0.0m;
            _metodoCalculoUt = metodoCalculoUtilidad.SinDefinir;
            _preferenciaPrecio = OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio.SinDefinir;
            _redondeoPrecio = OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.SinDefinir;
        }

        public CalculaPrecio(List<OOB.LibInventario.Configuracion.MetodoCalculoUtilidad.CapturarData.Ficha> list)
        {
            this.list = list;
        }

        public void setTasaCambio(decimal tasa)
        {
            _tasaCambio = tasa;
        }

        public void setMetodoCalculoUtilidad(metodoCalculoUtilidad metodo)
        {
            _metodoCalculoUt = metodo;
        }

        public void setPreferenciaPrecio(OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio enumPreferenciaRegistroPrecio)
        {
            _preferenciaPrecio = enumPreferenciaRegistroPrecio;
        }

        public void setRedondeoPrecio(OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta enumForzarRedondeoPrecioVenta)
        {
            _redondeoPrecio = enumForzarRedondeoPrecioVenta;
        }

        public List<Item> Recalcula()
        {
            var lst = list.Select(s =>
            {
                var nr = new Item(s,_tasaCambio, _metodoCalculoUt, _preferenciaPrecio, _redondeoPrecio);
                return nr;
            }).ToList();

            return lst;
        }

    }

}