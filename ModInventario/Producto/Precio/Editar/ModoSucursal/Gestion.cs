using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Precio.Editar.ModoSucursal
{

    public class Gestion: IGestion
    {

        private string autoPrd;
        private string producto;
        private string costoUnit;
        private string admDivisa;
        private string tasaIva;
        private decimal _tasaIvaValor; 
        private data.enumModo modoUtilidad;
        private decimal tasaCambioActual;
        private string fechaUltActCosto;
        private bool isModoActualDivisa;
        private decimal costoUnd;
        private decimal costoUndDivisa;
        private bool _isCerrarHabilitado;
        private OOB.LibInventario.Precio.PrecioCosto.Ficha fichaPrecioCosto;
        private bool prefRegistroPrecioIsNeto;
        private bool editarPrecioIsOk;
        private bool _habilitarContenidoEmpaque5_ParaVentaMayor;

        private List<OOB.LibInventario.EmpaqueMedida.Ficha> empaque1;
        private List<OOB.LibInventario.EmpaqueMedida.Ficha> empaque2;
        private List<OOB.LibInventario.EmpaqueMedida.Ficha> empaque3;
        private List<OOB.LibInventario.EmpaqueMedida.Ficha> empaque4;
        private List<OOB.LibInventario.EmpaqueMedida.Ficha> empaque5;
        private List<OOB.LibInventario.EmpaqueMedida.Ficha> _empaqueMay_1;
        private List<OOB.LibInventario.EmpaqueMedida.Ficha> _empaqueMay_2;

        private BindingSource sourceEmpaque1;
        private BindingSource sourceEmpaque2;
        private BindingSource sourceEmpaque3;
        private BindingSource sourceEmpaque4;
        private BindingSource sourceEmpaque5;
        private BindingSource _sourceEmpaqueMay_1;
        private BindingSource _sourceEmpaqueMay_2;

        private data precio_1;
        private data precio_2;
        private data precio_3;
        private data precio_4;
        private data precio_5;
        private data _may_1;
        private data _may_2;


        public bool IsModoDivisa { get { return isModoActualDivisa; } }

        public List<OOB.LibInventario.EmpaqueMedida.Ficha> Empaque1 { get { return empaque1; } }
        public List<OOB.LibInventario.EmpaqueMedida.Ficha> Empaque2 { get { return empaque2; } }
        public List<OOB.LibInventario.EmpaqueMedida.Ficha> Empaque3 { get { return empaque3; } }
        public List<OOB.LibInventario.EmpaqueMedida.Ficha> Empaque4 { get { return empaque4; } }
        public List<OOB.LibInventario.EmpaqueMedida.Ficha> Empaque5 { get { return empaque5; } }
        public BindingSource SourceEmpaque1 { get { return sourceEmpaque1; } }
        public BindingSource SourceEmpaque2 { get { return sourceEmpaque2; } }
        public BindingSource SourceEmpaque3 { get { return sourceEmpaque3; } }
        public BindingSource SourceEmpaque4 { get { return sourceEmpaque4; } }
        public BindingSource SourceEmpaque5 { get { return sourceEmpaque5; } }
        public BindingSource SourceEmpaqueMay_1 { get { return _sourceEmpaqueMay_1; } }
        public BindingSource SourceEmpaqueMay_2 { get { return _sourceEmpaqueMay_2; } }

        public bool IsCerrarHabilitado { get { return _isCerrarHabilitado; } }
        public data Precio_1 { get { return precio_1; } }
        public data Precio_2 { get { return precio_2; } }
        public data Precio_3 { get { return precio_3; } }
        public data Precio_4 { get { return precio_4; } }
        public data Precio_5 { get { return precio_5; } }
        public data May_1 { get { return _may_1; } }
        public data May_2 { get { return _may_2; } }


        public string Producto
        {
            get { return producto; }
        }

        public string CostoUnitario
        {
            get { return costoUnit; }
        }

        public string AdmDivisa
        {
            get { return admDivisa; }
        }

        public string TasaIva
        {
            get { return tasaIva; }
        }

        public decimal TasaIvaValor
        {
            get { return _tasaIvaValor; }
        }

        public string TasaCambioActual
        {
            get { return tasaCambioActual.ToString("n2"); }
        }

        public string MetodoCalculoUtilidad
        {
            get { return modoUtilidad.ToString(); }
        }

        public string FechaUltActCosto
        {
            get { return fechaUltActCosto; }
        }

        public bool Habilitar_ContenidoEmpaque
        {
            get { return false; }
        }

        public bool Habilitar_ContenidoEmpaque5
        {
            //CONDICION DE QUE EL PRECIO 5, SIRVA PARA VENTA DE MAYOR
            get { return _habilitarContenidoEmpaque5_ParaVentaMayor; }
        }

        public bool Habilitar_Empaque
        {
            get { return false; }
        }

        public bool PrefRegistroPrecioIsNeto
        {
            get { return prefRegistroPrecioIsNeto; }
        }

        public bool IsEditarPrecioOk
        {
            get { return editarPrecioIsOk; }
        }


        public Gestion()
        {
            _isCerrarHabilitado = true;
            _tasaIvaValor = 0.0m;

            empaque1 = new List<OOB.LibInventario.EmpaqueMedida.Ficha>();
            empaque2 = new List<OOB.LibInventario.EmpaqueMedida.Ficha>();
            empaque3 = new List<OOB.LibInventario.EmpaqueMedida.Ficha>();
            empaque4 = new List<OOB.LibInventario.EmpaqueMedida.Ficha>();
            empaque5 = new List<OOB.LibInventario.EmpaqueMedida.Ficha>();
            _empaqueMay_1 = new List<OOB.LibInventario.EmpaqueMedida.Ficha>();
            _empaqueMay_2 = new List<OOB.LibInventario.EmpaqueMedida.Ficha>();

            sourceEmpaque1 = new BindingSource();
            sourceEmpaque2 = new BindingSource();
            sourceEmpaque3 = new BindingSource();
            sourceEmpaque4 = new BindingSource();
            sourceEmpaque5 = new BindingSource();
            _sourceEmpaqueMay_1 = new BindingSource();
            _sourceEmpaqueMay_2 = new BindingSource();

            sourceEmpaque1.DataSource = empaque1;
            sourceEmpaque2.DataSource = empaque2;
            sourceEmpaque3.DataSource = empaque3;
            sourceEmpaque4.DataSource = empaque4;
            sourceEmpaque5.DataSource = empaque5;
            _sourceEmpaqueMay_1.DataSource = _empaqueMay_1;
            _sourceEmpaqueMay_2.DataSource = _empaqueMay_2;

            precio_1 = new data();
            precio_2 = new data();
            precio_3 = new data();
            precio_4 = new data();
            precio_5 = new data();
            _may_1 = new data();
            _may_2 = new data();
        }


        public bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.PrecioCosto_GetFicha(autoPrd);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            fichaPrecioCosto = r01.Entidad;

            var r02 = Sistema.MyData.EmpaqueMedida_GetLista();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }

            var r03 = Sistema.MyData.Configuracion_TasaCambioActual();
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }

            var r04 = Sistema.MyData.Configuracion_MetodoCalculoUtilidad();
            if (r04.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r04.Mensaje);
                return false;
            }

            var r05 = Sistema.MyData.Configuracion_ForzarRedondeoPrecioVenta();
            if (r05.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r05.Mensaje);
                return false;
            }

            var r06 = Sistema.MyData.Configuracion_PreferenciaRegistroPrecio();
            if (r06.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r06.Mensaje);
                return false;
            }
            prefRegistroPrecioIsNeto = (r06.Entidad == OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio.Neto);

            //var r07 = Sistema.MyData.Configuracion_HabilitarPrecio_5_ParaVentaMayorPos();
            //if (r07.Result == OOB.Enumerados.EnumResult.isError)
            //{
            //    Helpers.Msg.Error(r07.Mensaje);
            //    return false;
            //}
            //_habilitarContenidoEmpaque5_ParaVentaMayor = r07.Entidad;
            _habilitarContenidoEmpaque5_ParaVentaMayor = false;


            //PREFERENCIA PRECIO
            var preferenciaPrecio = data.enumPreferenciaPrecio.Neto;
            if (r06.Entidad == OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio.Full) 
            {
                preferenciaPrecio = data.enumPreferenciaPrecio.Full;
            }

            //REDONDEO
            var redondeo = data.enumModoRedondeo.SinRedondeo;
            switch (r05.Entidad)
            {
                case OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.Unidad:
                    redondeo= data.enumModoRedondeo.Unidad;
                    break;
                case OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.Decena:
                    redondeo= data.enumModoRedondeo.Decena;
                    break;
            }

            //TASA CAMBIO ACTUAL
            tasaCambioActual = r03.Entidad;

            //UTILIDAD METODO
            modoUtilidad = data.enumModo.Lineal;
            if (r04.Entidad == OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad.Financiero) 
            {
                modoUtilidad = data.enumModo.Financiero;
            }

            //FICHA PRODUCTO
            producto = r01.Entidad.codigo + Environment.NewLine + r01.Entidad.descripcion;
            admDivisa = r01.Entidad.admDivisa.ToString();
            tasaIva = "EXENTO";
            fechaUltActCosto = r01.Entidad.fechaUltimaActCosto;
            costoUnd = r01.Entidad.costoUnd;
            costoUndDivisa = r01.Entidad.costoUndDivisa;

            if (r01.Entidad.tasaIva > 0)
            {
                tasaIva = r01.Entidad.tasaIva.ToString("n2").Trim().PadLeft(5, '0') + "%";
                _tasaIvaValor = r01.Entidad.tasaIva;
            }

            var _modoDivisa = false;
            var _costoUnd = r01.Entidad.costoUnd;
            var _p1 = r01.Entidad.precioNeto1;
            var _p2=r01.Entidad.precioNeto2;
            var _p3=r01.Entidad.precioNeto3;
            var _p4=r01.Entidad.precioNeto4;
            var _p5=r01.Entidad.precioNeto5;
            var _pMay1 = r01.Entidad.precioNetoMay1;
            var _pMay2 = r01.Entidad.precioNetoMay2;
            costoUnit = r01.Entidad.costoUnd.ToString("N2");
            if (r01.Entidad.admDivisa == OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa.Si)
            {
                isModoActualDivisa = true;
                _p1 = r01.Entidad.precioFullDivisa1;
                _p2 = r01.Entidad.precioFullDivisa2;
                _p3 = r01.Entidad.precioFullDivisa3;
                _p4 = r01.Entidad.precioFullDivisa4;
                _p5 = r01.Entidad.precioFullDivisa5;
                _pMay1 = r01.Entidad.precioFullDivisaMay1;
                _pMay2 = r01.Entidad.precioFullDivisaMay2;
                _modoDivisa = true;
                _costoUnd = r01.Entidad.costoUndDivisa;
                costoUnit = r01.Entidad.costoUndDivisa.ToString("N2");
            }
            var _tasaIva = r01.Entidad.tasaIva;
            precio_1.setData(r01.Entidad.contenido1, _costoUnd, _tasaIva, r01.Entidad.utilidad1, _p1, modoUtilidad, r01.Entidad.etiqueta1, "0000000001", _modoDivisa, tasaCambioActual, redondeo, preferenciaPrecio, r01.Entidad.costoUndDivisa, r01.Entidad.costoUnd);
            precio_2.setData(r01.Entidad.contenido2, _costoUnd, _tasaIva, r01.Entidad.utilidad2, _p2, modoUtilidad, r01.Entidad.etiqueta2, "0000000001", _modoDivisa, tasaCambioActual, redondeo, preferenciaPrecio, r01.Entidad.costoUndDivisa, r01.Entidad.costoUnd);
            precio_3.setData(r01.Entidad.contenido3, _costoUnd, _tasaIva, r01.Entidad.utilidad3, _p3, modoUtilidad, r01.Entidad.etiqueta3, "0000000001", _modoDivisa, tasaCambioActual, redondeo, preferenciaPrecio, r01.Entidad.costoUndDivisa, r01.Entidad.costoUnd);
            precio_4.setData(r01.Entidad.contenido4, _costoUnd, _tasaIva, r01.Entidad.utilidad4, _p4, modoUtilidad, r01.Entidad.etiqueta4, "0000000001", _modoDivisa, tasaCambioActual, redondeo, preferenciaPrecio, r01.Entidad.costoUndDivisa, r01.Entidad.costoUnd);
            precio_5.setData(r01.Entidad.contenido5, _costoUnd, _tasaIva, r01.Entidad.utilidad5, _p5, modoUtilidad, r01.Entidad.etiqueta5, "0000000001", _modoDivisa, tasaCambioActual, redondeo, preferenciaPrecio, r01.Entidad.costoUndDivisa, r01.Entidad.costoUnd);
            _may_1.setData(r01.Entidad.contenidoMay1, _costoUnd, _tasaIva, r01.Entidad.utilidadMay1, _pMay1, modoUtilidad, "MAYOR 1", r01.Entidad.autoEmpMay1, _modoDivisa, tasaCambioActual, redondeo, preferenciaPrecio, r01.Entidad.costoUndDivisa, r01.Entidad.costoUnd);
            _may_2.setData(r01.Entidad.contenidoMay2, _costoUnd, _tasaIva, r01.Entidad.utilidadMay2, _pMay2, modoUtilidad, "MAYOR 2", r01.Entidad.autoEmpMay2, _modoDivisa, tasaCambioActual, redondeo, preferenciaPrecio, r01.Entidad.costoUndDivisa, r01.Entidad.costoUnd);

            //empaques
            empaque1.Clear();
            empaque1.AddRange(r02.Lista);
            sourceEmpaque1.CurrencyManager.Refresh();

            empaque2.Clear();
            empaque2.AddRange(r02.Lista);
            sourceEmpaque2.CurrencyManager.Refresh();

            empaque3.Clear();
            empaque3.AddRange(r02.Lista);
            sourceEmpaque3.CurrencyManager.Refresh();

            empaque4.Clear();
            empaque4.AddRange(r02.Lista);
            sourceEmpaque4.CurrencyManager.Refresh();

            empaque5.Clear();
            empaque5.AddRange(r02.Lista);
            sourceEmpaque5.CurrencyManager.Refresh();

            _empaqueMay_1.Clear();
            _empaqueMay_1.AddRange(r02.Lista);
            _sourceEmpaqueMay_1.CurrencyManager.Refresh();

            _empaqueMay_2.Clear();
            _empaqueMay_2.AddRange(r02.Lista);
            _sourceEmpaqueMay_2.CurrencyManager.Refresh();

            return rt;
        }

        public void setFicha(string autoprd)
        {
            autoPrd = autoprd;
        }

        public void ModoPrecioSw()
        {
            var msg = "Cambiar a Modo BCV (BsF) ?";
            if (!isModoActualDivisa) 
            {
                msg = "Cambiar a Modo DIVISA ($) ?";
            }
            var rt = MessageBox.Show(msg,"*** ALERTA ***",  MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (rt == DialogResult.Yes)
            {
                isModoActualDivisa = !isModoActualDivisa;
                precio_1.sw();
                precio_2.sw();
                precio_3.sw();
                precio_4.sw();
                precio_5.sw();
                //
                _may_1.sw();
                _may_2.sw();
            }
            costoUnit=costoUnd.ToString("n2");
            if (isModoActualDivisa)
            { 
                costoUnit=costoUndDivisa.ToString("n2");
            };
        }

        public void Procesar()
        {
            editarPrecioIsOk = false;
            var msg = "Procesar Cambios ?";
            var rt = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (rt == DialogResult.Yes)
            {
                _isCerrarHabilitado = Guardar();
            }
            else 
            {
                _isCerrarHabilitado = false;
            }
        }

        private bool Guardar()
        {
            var rt = true;

            if (!precio_1.IsOk())
            {
                Helpers.Msg.Error("[ UTILIDAD/CONTENIDO EMPAQUE ] PRECIO VENTA ( 1 ) INCORRECTO");
                return false;
            }
            if (!precio_2.IsOk())
            {
                Helpers.Msg.Error("[ UTILIDAD/CONTENIDO EMPAQUE ] PRECIO VENTA ( 2 ) INCORRECTO");
                return false;
            }
            if (!precio_3.IsOk())
            {
                Helpers.Msg.Error("[ UTILIDAD/CONTENIDO EMPAQUE ] PRECIO VENTA ( 3 ) INCORRECTO");
                return false;
            }
            if (!precio_4.IsOk())
            {
                Helpers.Msg.Error("[ UTILIDAD/CONTENIDO EMPAQUE ] PRECIO VENTA ( 4 ) INCORRECTO");
                return false;
            }
            if (!precio_5.IsOk())
            {
                Helpers.Msg.Error("[ UTILIDAD/CONTENIDO EMPAQUE ] PRECIO VENTA ( 5 ) INCORRECTO");
                return false;
            }
            //
            if (!May_1.IsOk())
            {
                Helpers.Msg.Error("[ UTILIDAD/CONTENIDO EMPAQUE ] PRECIO MAYOR ( 1 ) INCORRECTO");
                return false;
            }
            if (!May_2.IsOk())
            {
                Helpers.Msg.Error("[ UTILIDAD/CONTENIDO EMPAQUE ] PRECIO MAYOR ( 2 ) INCORRECTO");
                return false;
            }

            var ficha = new OOB.LibInventario.Precio.Editar.Ficha()
            {
                autoProducto = autoPrd,
                autoUsuario = Sistema.UsuarioP.autoUsu,
                codigoUsuario = Sistema.UsuarioP.codigoUsu,
                estacion = Environment.MachineName,
                nombreUsuario = Sistema.UsuarioP.nombreUsu,
            };

            var p1 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = precio_1.autoEmpaque,
                contenido = precio_1.contenido,
                precio_divisa_Neto = precio_1.PrecioFull_Divisa,
                precioNeto = precio_1.PrecioNeto_BsF,
                utilidad = precio_1.utilidad,
            };
            ficha.precio_1= p1;
            var h1 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            {
                nota = "",
                precio = precio_1.PrecioNeto_BsF,
                precio_id = "1",
                empaque = "UNIDAD",
                contenido = precio_1.contenido,
            };

            var p2 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = precio_2.autoEmpaque,
                contenido = precio_2.contenido,
                precio_divisa_Neto = precio_2.PrecioFull_Divisa,
                precioNeto = precio_2.PrecioNeto_BsF,
                utilidad = precio_2.utilidad,
            };
            ficha.precio_2 = p2;
            var h2 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            {
                nota = "",
                precio = precio_2.PrecioNeto_BsF,
                precio_id = "2",
                empaque = "UNIDAD",
                contenido = precio_2.contenido,
            };

            var p3 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = precio_3.autoEmpaque,
                contenido = precio_3.contenido,
                precio_divisa_Neto = precio_3.PrecioFull_Divisa,
                precioNeto = precio_3.PrecioNeto_BsF,
                utilidad = precio_3.utilidad,
            };
            ficha.precio_3 = p3;
            var h3 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            {
                nota = "",
                precio = precio_3.PrecioNeto_BsF,
                precio_id = "3",
                empaque = "UNIDAD",
                contenido = precio_3.contenido,
            };

            var p4 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = precio_4.autoEmpaque,
                contenido = precio_4.contenido,
                precio_divisa_Neto = precio_4.PrecioFull_Divisa,
                precioNeto = precio_4.PrecioNeto_BsF,
                utilidad = precio_4.utilidad,
            };
            ficha.precio_4 = p4;
            var h4 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            {
                nota = "",
                precio = precio_4.PrecioNeto_BsF,
                precio_id = "4",
                empaque = "UNIDAD",
                contenido = precio_4.contenido,
            };

            var p5 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = precio_5.autoEmpaque,
                contenido = precio_5.contenido,
                precio_divisa_Neto = precio_5.PrecioFull_Divisa,
                precioNeto = precio_5.PrecioNeto_BsF,
                utilidad = precio_5.utilidad,
            };
            ficha.precio_5 = p5;
            var h5 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            {
                nota = "",
                precio = precio_5.PrecioNeto_BsF,
                precio_id = "PTO",
                empaque = "UNIDAD",
                contenido = precio_5.contenido,
            };

            //
            var m1 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = _may_1.autoEmpaque,
                contenido = _may_1.contenido,
                precio_divisa_Neto = _may_1.PrecioFull_Divisa,
                precioNeto = _may_1.PrecioNeto_BsF,
                utilidad = _may_1.utilidad,
            };
            ficha.may_1 = m1;
            var entEmpMay_1 = _empaqueMay_1.FirstOrDefault(f => f.auto == _may_1.autoEmpaque);
            var hM1 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            {
                nota = "",
                precio = _may_1.PrecioNeto_BsF,
                precio_id = "MY1",
                empaque = entEmpMay_1 == null ? "" : entEmpMay_1.nombre,
                contenido = _may_1.contenido,
            };

            var m2 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = _may_2.autoEmpaque,
                contenido = _may_2.contenido,
                precio_divisa_Neto = _may_2.PrecioFull_Divisa,
                precioNeto = _may_2.PrecioNeto_BsF,
                utilidad = _may_2.utilidad,
            };
            ficha.may_2 = m2;
            var entEmpMay_2 = _empaqueMay_2.FirstOrDefault(f => f.auto == _may_2.autoEmpaque);
            var hM2 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            {
                nota = "",
                precio = _may_2.PrecioNeto_BsF,
                precio_id = "MY2",
                empaque = entEmpMay_2 == null ? "" : entEmpMay_2.nombre,
                contenido=_may_2.contenido,
            };

            var historia = new List<OOB.LibInventario.Precio.Editar.FichaHistorica>();
            if (VerificaCambio(precio_1,1)) { historia.Add(h1); }
            if (VerificaCambio(precio_2,2)) { historia.Add(h2); }
            if (VerificaCambio(precio_3,3)) { historia.Add(h3); }
            if (VerificaCambio(precio_4,4)) { historia.Add(h4); }
            if (VerificaCambio(precio_5,5)) { historia.Add(h5); }
            //
            if (VerificaCambio(_may_1, 6)) { historia.Add(hM1); }
            if (VerificaCambio(_may_2, 7)) { historia.Add(hM2); }

            ficha.historia = historia;
            var r01 = Sistema.MyData.PrecioProducto_Actualizar(ficha);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            editarPrecioIsOk = true;

            return rt;
        }

        private bool VerificaCambio(data precio, int p)
        {
            var rt = false;

            if (p == 1) 
            {
                if (precio.autoEmpaque != fichaPrecioCosto.autoEmp1) { return true; }
                if (precio.contenido != fichaPrecioCosto.contenido1) { return true; }
                if (precio.PrecioNeto_BsF != fichaPrecioCosto.precioNeto1) { return true; }
                if (precio.utilidad != fichaPrecioCosto.utilidad1) { return true; }
            }
            if (p == 2)
            {
                if (precio.autoEmpaque != fichaPrecioCosto.autoEmp2) { return true; }
                if (precio.contenido != fichaPrecioCosto.contenido2) { return true; }
                if (precio.PrecioNeto_BsF != fichaPrecioCosto.precioNeto2) { return true; }
                if (precio.utilidad != fichaPrecioCosto.utilidad2) { return true; }
            }
            if (p == 3)
            {
                if (precio.autoEmpaque != fichaPrecioCosto.autoEmp3) { return true; }
                if (precio.contenido != fichaPrecioCosto.contenido3) { return true; }
                if (precio.PrecioNeto_BsF != fichaPrecioCosto.precioNeto3) { return true; }
                if (precio.utilidad != fichaPrecioCosto.utilidad3) { return true; }
            }
            if (p == 4)
            {
                if (precio.autoEmpaque != fichaPrecioCosto.autoEmp4) { return true; }
                if (precio.contenido != fichaPrecioCosto.contenido4) { return true; }
                if (precio.PrecioNeto_BsF != fichaPrecioCosto.precioNeto4) { return true; }
                if (precio.utilidad != fichaPrecioCosto.utilidad4) { return true; }
            }
            if (p == 5)
            {
                if (precio.autoEmpaque != fichaPrecioCosto.autoEmp5) { return true; }
                if (precio.contenido != fichaPrecioCosto.contenido5) { return true; }
                if (precio.PrecioNeto_BsF != fichaPrecioCosto.precioNeto5) { return true; }
                if (precio.utilidad != fichaPrecioCosto.utilidad5) { return true; }
            }
            if (p == 6) // MAYOR 1
            {
                if (precio.autoEmpaque != fichaPrecioCosto.autoEmpMay1) { return true; }
                if (precio.contenido != fichaPrecioCosto.contenidoMay1) { return true; }
                if (precio.PrecioNeto_BsF != fichaPrecioCosto.precioNetoMay1) { return true; }
                if (precio.utilidad != fichaPrecioCosto.utilidadMay1) { return true; }
            }
            if (p == 7) // MAYOR 2
            {
                if (precio.autoEmpaque != fichaPrecioCosto.autoEmpMay2) { return true; }
                if (precio.contenido != fichaPrecioCosto.contenidoMay2) { return true; }
                if (precio.PrecioNeto_BsF != fichaPrecioCosto.precioNetoMay2) { return true; }
                if (precio.utilidad != fichaPrecioCosto.utilidadMay2) { return true; }
            }

            return rt;
        }

        public void InicializarIsCerrarHabilitado()
        {
            _isCerrarHabilitado = true;
        }

        public void Limpiar()
        {
            editarPrecioIsOk = false;

            precio_1.Limpiar();
            precio_2.Limpiar();
            precio_3.Limpiar();
            precio_4.Limpiar();
            precio_5.Limpiar();
            _may_1.Limpiar();
            _may_2.Limpiar();

            producto="";
            costoUnit="";
            admDivisa="";
            tasaIva="";
            _tasaIvaValor = 0.0m;

        //private data.enumModo modoUtilidad;
        //private decimal tasaCambioActual;
        //private string fechaUltActCosto;
        //private bool isModoActualDivisa;
        //private decimal costoUnd;
        //private decimal costoUndDivisa;
        //private bool _isCerrarHabilitado;
        //private OOB.LibInventario.Precio.PrecioCosto.Ficha fichaPrecioCosto; 
        }

        public void setEmpaqueMayor_1(string auto)
        {
            _may_1.setEmpaque(auto);

            var n = "";
            var ent = _empaqueMay_1.FirstOrDefault(f => f.auto == auto);
            if (ent != null)
            {
                n = ent.nombre;
            }
            _may_1.setNombreEmpaque(n);
        }

        public void setContenidoMayor_1(int p)
        {
            _may_1.setContenido(p);
        }

        public void setUtilidadMayor_1(decimal p)
        {
            _may_1.setUtilidad(p);
        }

        public void setNetoMayor_1(decimal p)
        {
            _may_1.setNeto(p);
        }

        public void setFullMayor_1(decimal p)
        {
            _may_1.setFull(p);
        }

        public void setEmpaqueMayor_2(string auto)
        {
            _may_2.setEmpaque(auto);

            var n = "";
            var ent = _empaqueMay_2.FirstOrDefault(f => f.auto == auto);
            if (ent != null)
            {
                n = ent.nombre;
            }
            _may_2.setNombreEmpaque(n);
        }

        public void setContenidoMayor_2(int p)
        {
            _may_2.setContenido(p);
        }

        public void setUtilidadMayor_2(decimal p)
        {
            _may_2.setUtilidad(p);
        }

        public void setNetoMayor_2(decimal p)
        {
            _may_2.setNeto(p);
        }

        public void setFullMayor_2(decimal p)
        {
            _may_2.setFull(p);
        }

        public string CostoEmpaqueCompra
        {
            get { return "Costo $: "+fichaPrecioCosto.costoDivisa.ToString("n2"); }
        }

        public string EmpaqueCompra
        {
            get { return "Empaque: "+fichaPrecioCosto.empCompra.Trim() + "/" + fichaPrecioCosto.contempCompra.ToString().Trim(); }
        }

    }

}