using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Configuracion.MetodoCalculoUtilidad
{
    
    public class Item
    {

        private OOB.LibInventario.Configuracion.MetodoCalculoUtilidad.CapturarData.Ficha s;
        private decimal _tasaCambio;
        private CalculaPrecio.metodoCalculoUtilidad _metodoCalculoUt;
        private OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio _preferenciaPrecio;
        private OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta _redondeoPrecio;

        public string IdProducto { get { return s.idProducto; } }
        public Precio precio_1 { get; set; }
        public Precio precio_2 { get; set; }
        public Precio precio_3 { get; set; }
        public Precio precio_4 { get; set; }
        public Precio precio_5 { get; set; }

        public decimal costoEmpaque_1
        {
            get
            {
                var costo = 0.0m;
                costo = s.costoDivisaUnd * s.contenido_1 *_tasaCambio;
                if (!s.isDivisa)
                {
                    costo = s.costoUnd * s.contenido_1;
                }
                return costo;
            }
        }

        public decimal costoEmpaque_2
        {
            get
            {
                var costo = 0.0m;
                costo = s.costoDivisaUnd * s.contenido_2 * _tasaCambio;
                if (!s.isDivisa)
                {
                    costo = s.costoUnd * s.contenido_2;
                }
                return costo;
            }
        }

        public decimal costoEmpaque_3
        {
            get
            {
                var costo = 0.0m;
                costo = s.costoDivisaUnd * s.contenido_3 * _tasaCambio;
                if (!s.isDivisa)
                {
                    costo = s.costoUnd * s.contenido_3;
                }
                return costo;
            }
        }

        public decimal costoEmpaque_4
        {
            get
            {
                var costo = 0.0m;
                costo = s.costoDivisaUnd * s.contenido_4 * _tasaCambio;
                if (!s.isDivisa)
                {
                    costo = s.costoUnd * s.contenido_4;
                }
                return costo;
            }
        }

        public decimal costoEmpaque_5
        {
            get
            {
                var costo = 0.0m;
                costo = s.costoDivisaUnd * s.contenido_5 * _tasaCambio;
                if (!s.isDivisa)
                {
                    costo = s.costoUnd * s.contenido_5;
                }
                return costo;
            }
        }


        public Item(OOB.LibInventario.Configuracion.MetodoCalculoUtilidad.CapturarData.Ficha s, decimal _tasaCambio, CalculaPrecio.metodoCalculoUtilidad _metodoCalculoUt, OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio _preferenciaPrecio, OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta _redondeoPrecio)
        {
            this.s = s;
            this._tasaCambio = _tasaCambio;
            this._metodoCalculoUt = _metodoCalculoUt;
            this._preferenciaPrecio = _preferenciaPrecio;
            this._redondeoPrecio = _redondeoPrecio;

            if (_metodoCalculoUt == CalculaPrecio.metodoCalculoUtilidad.Lineal)
            {
                if (s.precio1_IsHabilitado)
                    precio_1 = CostoLineal(costoEmpaque_1, s.utilidad_1);
                else
                    precio_1 = new Precio();

                if (s.precio2_IsHabilitado)
                    precio_2 = CostoLineal(costoEmpaque_2, s.utilidad_2);
                else
                    precio_2 = new Precio();

                if (s.precio3_IsHabilitado)
                    precio_3 = CostoLineal(costoEmpaque_3, s.utilidad_3);
                else
                    precio_3 = new Precio();

                if (s.precio4_IsHabilitado)
                    precio_4 = CostoLineal(costoEmpaque_4, s.utilidad_4);
                else
                    precio_4 = new Precio();

                if (s.precio5_IsHabilitado)
                    precio_5 = CostoLineal(costoEmpaque_5, s.utilidad_5);
                else
                    precio_5 = new Precio();
            }
            else
            {
                if (s.precio1_IsHabilitado)
                    precio_1 = CostoFinanciero(costoEmpaque_1, s.utilidad_1);
                else
                    precio_1 = new Precio();

                if (s.precio2_IsHabilitado)
                    precio_2 = CostoFinanciero(costoEmpaque_2, s.utilidad_2);
                else
                    precio_2 = new Precio();

                if (s.precio3_IsHabilitado)
                    precio_3 = CostoFinanciero(costoEmpaque_3, s.utilidad_3);
                else
                    precio_3 = new Precio();

                if (s.precio4_IsHabilitado)
                    precio_4 = CostoFinanciero(costoEmpaque_4, s.utilidad_4);
                else
                    precio_4 = new Precio();

                if (s.precio5_IsHabilitado)
                    precio_5 = CostoFinanciero(costoEmpaque_5, s.utilidad_5);
                else
                    precio_5 = new Precio();
            }

        }

        private Precio CostoFinanciero(decimal _costo, decimal _ut)
        {
            var costo = _costo;
            if (_ut == 100)
                _ut = 0.0m;
            var pn = costo / ((100 - _ut) / 100);
            return NuevoPrecio(pn);
        }

        private Precio CostoLineal(decimal _costo, decimal _ut)
        {
            var costo = _costo;
            var pn = costo + (costo * _ut / 100);
            return NuevoPrecio(pn);
        }

        private Precio NuevoPrecio(decimal _precioNeto)
        {
            var rt = new Precio();

            var pn = _precioNeto;
            var pf = 0.0m;
            if (_preferenciaPrecio == OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio.Full)
            {
                pf = pn + (pn * (s.tasaIva / 100));
                switch (_redondeoPrecio)
                {
                    case OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.Unidad:
                        pf = Helpers.MetodosExtension.RoundUnidad((int)pf);
                        break;
                    case OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.Decena:
                        pf = Helpers.MetodosExtension.RoundDecena((int)pf);
                        break;
                }
                pn = Math.Round(pf / (1 + (s.tasaIva / 100)), 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                switch (_redondeoPrecio)
                {
                    case OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.Unidad:
                        pn = Helpers.MetodosExtension.RoundUnidad((int)pn);
                        break;
                    case OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.Decena:
                        pn = Helpers.MetodosExtension.RoundDecena((int)pn);
                        break;
                }
                pf = pn + (pn * (s.tasaIva / 100));
            }
            var pdf = Math.Round(pf / _tasaCambio, 2, MidpointRounding.AwayFromZero);
            rt.pneto = pn;
            rt.pdf = pdf;

            return rt;
        }

        //private Precio PrecioLineal(decimal _costo, decimal ut)
        //{
        //    var rt = new Precio();

        //    var costo = _costo;
        //    var pn = costo + (costo * ut / 100);
        //    var pf = 0.0m;
        //    if (_preferenciaPrecio == OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio.Full)
        //    {
        //        pf = pn + (pn * (s.tasaIva / 100));
        //        switch (_redondeoPrecio)
        //        {
        //            case OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.Unidad:
        //                pf = Helpers.MetodosExtension.RoundUnidad((int)pf);
        //                break;
        //            case OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.Decena:
        //                pf = Helpers.MetodosExtension.RoundDecena((int)pf);
        //                break;
        //        }
        //        pn = Math.Round(pf / (1 + (s.tasaIva / 100)), 2, MidpointRounding.AwayFromZero);
        //    }
        //    else
        //    {
        //        switch (_redondeoPrecio)
        //        {
        //            case OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.Unidad:
        //                pn = Helpers.MetodosExtension.RoundUnidad((int)pn);
        //                break;
        //            case OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.Decena:
        //                pn = Helpers.MetodosExtension.RoundDecena((int)pn);
        //                break;
        //        }
        //        pf = pn + (pn * (s.tasaIva / 100));
        //    }
        //    var pdf = Math.Round(pf / _tasaCambio, 2, MidpointRounding.AwayFromZero);
        //    rt.pneto = pn;
        //    rt.pdf = pdf;

        //    return rt;
        //}

    }

}