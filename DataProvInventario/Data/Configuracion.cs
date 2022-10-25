using DataProvInventario.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.Data
{

    public partial class DataProv: IData
    {

        public OOB.ResultadoEntidad<Enumerados.modoConfInventario> 
            Configuracion_ModuloInventario_Modo()
        {
            var rt = new OOB.ResultadoEntidad<Enumerados.modoConfInventario>();
            var r01 = MyData.Configuracion_ModuloInventario_Modo();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }

            Enumerados.modoConfInventario _modo = Enumerados.modoConfInventario.SinDefinir;
            var _dato=r01.Entidad;
            switch(_dato.Trim().ToUpper())
            {
                case "BASICO":
                    _modo = Enumerados.modoConfInventario.Basico;
                    break;
                case "SUCURSAL":
                    _modo = Enumerados.modoConfInventario.Sucursal;
                    break;
            }
            rt.Entidad = _modo;

            return rt;
        }


        public OOB.ResultadoEntidad<OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda> 
            Configuracion_PreferenciaBusqueda()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda>();

            var r01 = MyData.Configuracion_PreferenciaBusqueda();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            rt.Entidad = (OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda) s;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad> 
            Configuracion_MetodoCalculoUtilidad()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad>();

            var r01 = MyData.Configuracion_MetodoCalculoUtilidad();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            rt.Entidad = (OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad)s;

            return rt;
        }
        public OOB.ResultadoEntidad<decimal> 
            Configuracion_TasaCambioActual()
        {
            var rt = new OOB.ResultadoEntidad<decimal>();

            var r01 = MyData.Configuracion_TasaCambioActual();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var cnf = r01.Entidad;
            var m1 = 0.0m;
            if (cnf.Trim() != "")
            {
                var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
                var culture = CultureInfo.CreateSpecificCulture("es-ES");
                //var culture = CultureInfo.CreateSpecificCulture("en-EN");
                Decimal.TryParse(cnf, style, culture, out m1);
            }
            rt.Entidad = m1;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta> 
            Configuracion_ForzarRedondeoPrecioVenta()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta>();

            var r01 = MyData.Configuracion_ForzarRedondeoPrecioVenta();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            rt.Entidad = (OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta)s;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio> 
            Configuracion_PreferenciaRegistroPrecio()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio>();

            var r01 = MyData.Configuracion_PreferenciaRegistroPrecio();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            rt.Entidad = (OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio)s;

            return rt;
        }
        public OOB.ResultadoEntidad<int> 
            Configuracion_CostoEdadProducto()
        {
            var rt = new OOB.ResultadoEntidad<int>();

            var r01 = MyData.Configuracion_CostoEdadProducto ();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Entidad = r01.Entidad;

            return rt;
        }
        public OOB.ResultadoEntidad<bool> 
            Configuracion_VisualizarProductosInactivos()
        {
            var rt = new OOB.ResultadoEntidad<bool>();

            var r01 = MyData.Configuracion_VisualizarProductosInactivos();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Entidad = r01.Entidad.Trim().ToUpper()=="SI"?true:false;

            return rt;
        }
        public OOB.ResultadoEntidad<int> 
            Configuracion_CantDocVisualizar()
        {
            var rt = new OOB.ResultadoEntidad<int>();

            var r01 = MyData.Configuracion_CantDocVisualizar();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var cnf = r01.Entidad;
            var m1 = 1000;
            if (cnf.Trim() != "")
            {
                var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
                var culture = CultureInfo.CreateSpecificCulture("es-ES");
                int.TryParse(cnf, style, culture, out m1);
            }
            rt.Entidad = m1;

            return rt;
        }

        public OOB.Resultado 
            Configuracion_SetCostoEdadProducto(OOB.LibInventario.Configuracion.CostoEdad.Editar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibInventario.Configuracion.CostoEdad.Editar.Ficha()
            {
                Edad = ficha.Edad,
            };
            var r01 = MyData.Configuracion_SetCostoEdadProducto(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }
        public OOB.Resultado 
            Configuracion_SetRedondeoPrecioVenta(OOB.LibInventario.Configuracion.RedondeoPrecio.Editar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibInventario.Configuracion.RedondeoPrecio.Editar.Ficha()
            {
                Redondeo = ficha.Redondeo,
            };
            var r01 = MyData.Configuracion_SetRedondeoPrecioVenta(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }
        public OOB.Resultado 
            Configuracion_SetPreferenciaRegistroPrecio(OOB.LibInventario.Configuracion.PreferenciaPrecio.Editar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibInventario.Configuracion.PreferenciaPrecio.Editar.Ficha()
            {
                Preferencia = ficha.Preferencia,
            };
            var r01 = MyData.Configuracion_SetPreferenciaRegistroPrecio(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }
        public OOB.Resultado 
            Configuracion_SetMetodoCalculoUtilidad(OOB.LibInventario.Configuracion.MetodoCalculoUtilidad.Editar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibInventario.Configuracion.MetodoCalculoUtilidad.Editar.Ficha()
            {
                Metodo = ficha.Metodo,
                Precio = ficha.Precio.Select(s => 
                {
                    var nr = new DtoLibInventario.Configuracion.MetodoCalculoUtilidad.Editar.FichaPrecio()
                    {
                        idProducto = s.idProducto,
                        Precio_1 = new DtoLibInventario.Configuracion.MetodoCalculoUtilidad.Editar.Precio()
                        {
                            pdf = s.Precio_1.pdf,
                            pneto = s.Precio_1.pneto,
                        },
                        Precio_2 = new DtoLibInventario.Configuracion.MetodoCalculoUtilidad.Editar.Precio()
                        {
                            pdf = s.Precio_2.pdf,
                            pneto = s.Precio_2.pneto,
                        },
                        Precio_3 = new DtoLibInventario.Configuracion.MetodoCalculoUtilidad.Editar.Precio()
                        {
                            pdf = s.Precio_3.pdf,
                            pneto = s.Precio_3.pneto,
                        },
                        Precio_4 = new DtoLibInventario.Configuracion.MetodoCalculoUtilidad.Editar.Precio()
                        {
                            pdf = s.Precio_4.pdf,
                            pneto = s.Precio_4.pneto,
                        },
                        Precio_5 = new DtoLibInventario.Configuracion.MetodoCalculoUtilidad.Editar.Precio()
                        {
                            pdf = s.Precio_5.pdf,
                            pneto = s.Precio_5.pneto,
                        },
                    };
                    return nr;
                }).ToList(),
            };
            var r01 = MyData.Configuracion_SetMetodoCalculoUtilidad(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }
        public OOB.Resultado 
            Configuracion_SetBusquedaPredeterminada(OOB.LibInventario.Configuracion.BusquedaPredeterminada.Editar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibInventario.Configuracion.BusquedaPredeterminada.Editar.Ficha()
            {
                Busqueda = ficha.Busqueda,
            };
            var r01 = MyData.Configuracion_SetBusquedaPredeterminada(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }
        public OOB.Resultado 
            Configuracion_SetDepositosPreDeterminado(OOB.LibInventario.Configuracion.DepositoPreDeterminado.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibInventario.Configuracion.DepositoPredeterminado.Ficha();
            fichaDTO.ListaPreDet = ficha.ListaPreDet.Select(s =>
            {
                var rg = new DtoLibInventario.Configuracion.DepositoPredeterminado.Item()
                {
                    AutoDeposito = s.AutoDeposito,
                    Estatus = s.Estatus,
                };
                return rg;
            }).ToList();
            var r01 = MyData.Configuracion_SetDepositosPreDeterminado(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibInventario.Configuracion.MetodoCalculoUtilidad.CapturarData.Ficha> 
            Configuracion_MetodoCalculoUtilidad_CapturarData()
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Configuracion.MetodoCalculoUtilidad.CapturarData.Ficha>();

            var r01 = MyData.Configuracion_MetodoCalculoUtilidad_CapturarData();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var lst = new List<OOB.LibInventario.Configuracion.MetodoCalculoUtilidad.CapturarData.Ficha>();
            if (r01.Lista != null) 
            {
                if (r01.Lista.Count > 0) 
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibInventario.Configuracion.MetodoCalculoUtilidad.CapturarData.Ficha()
                        {
                            contenido_1 = s.contenido_1,
                            contenido_2 = s.contenido_2,
                            contenido_3 = s.contenido_3,
                            contenido_4 = s.contenido_4,
                            contenido_5 = s.contenido_5,
                            contenidoEmpCompra = s.contenidoEmpCompra,
                            costoDivisa = s.costoDivisa,
                            costoUnd = s.costoUnd,
                            estatusDivisa = s.estatusDivisa,
                            idProducto = s.idProducto,
                            tasaIva = s.tasaIva,
                            utilidad_1 = s.utilidad_1,
                            utilidad_2 = s.utilidad_2,
                            utilidad_3 = s.utilidad_3,
                            utilidad_4 = s.utilidad_4,
                            utilidad_5 = s.utilidad_5,
                            precio_1 = s.precio_1,
                            precio_2 = s.precio_2,
                            precio_3 = s.precio_3,
                            precio_4 = s.precio_4,
                            precio_5 = s.precio_5,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = lst;
           
            return rt;
        }
        public OOB.ResultadoEntidad<bool> 
            Configuracion_HabilitarPrecio_5_ParaVentaMayorPos()
        {
            var rt = new OOB.ResultadoEntidad<bool>();

            var r01 = MyData.Configuracion_HabilitarPrecio_5_ParaVentaMayorPos();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Entidad = false;
            if (r01.Entidad.Trim().ToUpper()=="SI")
                rt.Entidad = true;

            return rt;
        }
        
        //
        public OOB.ResultadoEntidad<OOB.LibInventario.Configuracion.DepositoConceptoDevMerc.Captura.Ficha> 
            Configuracion_DepositoConceptoPreDeterminadoDevolucionMercancia()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Configuracion.DepositoConceptoDevMerc.Captura.Ficha>();

            var r01 = MyData.Configuracion_DepositoConceptoPreDeterminadoParaDevolucion();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            var s= r01.Entidad;
            var rg = new OOB.LibInventario.Configuracion.DepositoConceptoDevMerc.Captura.Ficha()
            {
                IdConcepto = s.IdConcepto,
                IdDeposito = s.IdDeposito,
            };
            rt.Entidad= rg;

            return rt;
        }
        public OOB.Resultado 
            Configuracion_SetDepositoConceptoPreDeterminadoDevolucionMercancia(OOB.LibInventario.Configuracion.DepositoConceptoDevMerc.Editar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibInventario.Configuracion.DepositoConceptoDev.Editar.Ficha()
            {
                IdConcepto = ficha.IdConcepto,
                IdDeposito = ficha.IdDeposito,
            };
            var r01 = MyData.Configuracion_SetDepositoConceptoPreDeterminadoParaDevolucion (fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }
        //
        public OOB.ResultadoEntidad<bool> 
            Configuracion_PermitirCambiarPrecioAlModificarCosto()
        {
            var rt = new OOB.ResultadoEntidad<bool>();

            var r01 = MyData.Configuracion_PermitirCambiarPrecioAlModificarCosto();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Entidad = r01.Entidad.ToString().Trim().ToUpper() == "SI";

            return rt;
        }
        public OOB.Resultado 
            Configuracion_SetPermitirCambiarPrecioAlModificarCosto(bool conf)
        {
            var rt = new OOB.Resultado();

            var dat = conf ? "Si" : "No";
            var r01 = MyData.Configuracion_SetPermitirCambiarPrecioAlModificarCosto(dat);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

    }

}