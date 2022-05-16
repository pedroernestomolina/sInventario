using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Precio.ModoSucursal.Editar
{
    
    public class Editar: IEditar 
    {


        private bool _isProcesarIsOk;
        private bool _isAbandonarIsOk;
        private string _idProducto;
        private string _descPrecio1;
        private string _descPrecio2;
        private string _descPrecio3;
        private string _descPrecio4;
        private string _descPrecio5;
        private FiltrosGen.IOpcion _gEmp1;
        private FiltrosGen.IOpcion _gEmp2;
        private FiltrosGen.IOpcion _gEmp3;
        private FiltrosGen.IOpcion _gEmp4;
        private FiltrosGen.IOpcion _gEmp5;
        private FiltrosGen.IOpcion _gEmpM1;
        private FiltrosGen.IOpcion _gEmpM2;
        private FiltrosGen.IOpcion _gEmpM3;
        private FiltrosGen.IOpcion _gEmpM4;
        private FiltrosGen.IOpcion _gEmpD1;
        private FiltrosGen.IOpcion _gEmpD2;
        private FiltrosGen.IOpcion _gEmpD3;
        private FiltrosGen.IOpcion _gEmpD4;
        private dataPrecio _precio1;
        private dataPrecio _precio2;
        private dataPrecio _precio3;
        private dataPrecio _precio4;
        private dataPrecio _precio5;
        private dataPrecio _precioM1;
        private dataPrecio _precioM2;
        private dataPrecio _precioM3;
        private dataPrecio _precioM4;
        private dataPrecio _precioD1;
        private dataPrecio _precioD2;
        private dataPrecio _precioD3;
        private dataPrecio _precioD4;
        private dataProducto _dataPrd;


        public bool IsProcesarIsOk { get { return _isProcesarIsOk; } }
        public bool IsAbandonarIsOk { get { return _isAbandonarIsOk; } }
        public bool IsEditarPrecioIsOk { get { return _isProcesarIsOk; } }


        public Editar() 
        {
            _gEmp1 = new FiltrosGen.Opcion.Gestion();
            _gEmp2 = new FiltrosGen.Opcion.Gestion();
            _gEmp3 = new FiltrosGen.Opcion.Gestion();
            _gEmp4 = new FiltrosGen.Opcion.Gestion();
            _gEmp5 = new FiltrosGen.Opcion.Gestion();
            _gEmpM1 = new FiltrosGen.Opcion.Gestion();
            _gEmpM2 = new FiltrosGen.Opcion.Gestion();
            _gEmpM3 = new FiltrosGen.Opcion.Gestion();
            _gEmpM4 = new FiltrosGen.Opcion.Gestion();
            _gEmpD1 = new FiltrosGen.Opcion.Gestion();
            _gEmpD2 = new FiltrosGen.Opcion.Gestion();
            _gEmpD3 = new FiltrosGen.Opcion.Gestion();
            _gEmpD4 = new FiltrosGen.Opcion.Gestion();
            //
            _isAbandonarIsOk = false;
            _isProcesarIsOk = false;
            _idProducto = "";
            //
            _descPrecio1 = "";
            _descPrecio2 = "";
            _descPrecio3 = "";
            _descPrecio4 = "";
            _descPrecio5 = "";
            //
            _precio1 = new dataPrecio();
            _precio2 = new dataPrecio();
            _precio3 = new dataPrecio();
            _precio4 = new dataPrecio();
            _precio5 = new dataPrecio();
            //
            _precioM1 = new dataPrecio();
            _precioM2 = new dataPrecio();
            _precioM3 = new dataPrecio();
            _precioM4 = new dataPrecio();
            //
            _precioD1 = new dataPrecio();
            _precioD2 = new dataPrecio();
            _precioD3 = new dataPrecio();
            _precioD4 = new dataPrecio();
            //
            _dataPrd = new dataProducto();
        }


        public void Inicializa()
        {
            _isAbandonarIsOk = false;
            _isProcesarIsOk = false;
            _idProducto="";
            _descPrecio1 = "";
            _descPrecio2 = "";
            _descPrecio3 = "";
            _descPrecio4 = "";
            _descPrecio5 = "";
            //
            _gEmp1.Inicializa();
            _gEmp2.Inicializa();
            _gEmp3.Inicializa();
            _gEmp4.Inicializa();
            _gEmp5.Inicializa();
            //
            _gEmpM1.Inicializa();
            _gEmpM2.Inicializa();
            _gEmpM3.Inicializa();
            _gEmpM4.Inicializa();
            //
            _gEmpD1.Inicializa();
            _gEmpD2.Inicializa();
            _gEmpD3.Inicializa();
            _gEmpD4.Inicializa();
            //
            _precio1.Inicializa();
            _precio2.Inicializa();
            _precio3.Inicializa();
            _precio4.Inicializa();
            _precio5.Inicializa();
            //
            _precioM1.Inicializa();
            _precioM2.Inicializa();
            _precioM3.Inicializa();
            _precioM4.Inicializa();
            //
            _precioD1.Inicializa();
            _precioD2.Inicializa();
            _precioD3.Inicializa();
            _precioD4.Inicializa();
            //
            _dataPrd.Inicializa();
        }
        PrecioEditarFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new PrecioEditarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public void setIdItemEditar(string idAuto)
        {
            _idProducto = idAuto;
        }


        private bool CargarData()
        {
            var rt = true;
            var _tasaCambio = 0m;
            var _metodoCalculoDesc = "";
            var _metodoCalculo = dataPrecio.enumMetCalUtilidad.SinDefinir;

            var r01 = Sistema.MyData.PrecioCosto_GetData(_idProducto);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            var r03 = Sistema.MyData.Configuracion_TasaCambioActual();
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            _tasaCambio = r03.Entidad;
            var r04 = Sistema.MyData.Configuracion_MetodoCalculoUtilidad();
            if (r04.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r04.Mensaje);
                return false;
            }
            if (r04.Entidad== OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad.Lineal)
            {
                _metodoCalculoDesc="LINEAL";
                _metodoCalculo = dataPrecio.enumMetCalUtilidad.Lineal;
            }
            else if (r04.Entidad== OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad.Financiero)
            {
                _metodoCalculoDesc="FINANCIERO";
                _metodoCalculo = dataPrecio.enumMetCalUtilidad.Financiero;
            }

            var prd = r01.Entidad;
            var costo = prd.costoMonedaLocal;
            var admDivisa = "NO";
            var pneto_1 = prd.pNeto_1;
            var pneto_2 = prd.pNeto_2;
            var pneto_3 = prd.pNeto_3;
            var pneto_4 = prd.pNeto_4;
            var pneto_5 = prd.pNeto_5;
            var pneto_M1 = prd.pNeto_M1;
            var pneto_M2 = prd.pNeto_M2;
            var pneto_M3 = prd.pNeto_M3;
            var pneto_M4 = prd.pNeto_M4;
            //
            var pneto_D1 = prd.pNeto_M1;
            var pneto_D2 = prd.pNeto_M2;
            var pneto_D3 = prd.pNeto_M3;
            var pneto_D4 = prd.pNeto_M4;
            if (prd.EsAdmDivisa) 
            {
                admDivisa = "SI";
                costo = prd.costoMonedaDivisa;
                pneto_1 = CalculaNeto(prd.pfd_1, prd.tasaIva);
                pneto_2 = CalculaNeto(prd.pfd_2, prd.tasaIva);
                pneto_3 = CalculaNeto(prd.pfd_3, prd.tasaIva);
                pneto_4 = CalculaNeto(prd.pfd_4, prd.tasaIva);
                pneto_5 = CalculaNeto(prd.pfd_5, prd.tasaIva);
                pneto_M1 = CalculaNeto(prd.pfd_M1, prd.tasaIva);
                pneto_M2 = CalculaNeto(prd.pfd_M2, prd.tasaIva);
                pneto_M3 = CalculaNeto(prd.pfd_M3, prd.tasaIva);
                pneto_M4 = CalculaNeto(prd.pfd_M4, prd.tasaIva);
                //
                pneto_D1 = CalculaNeto(prd.pfd_M1, prd.tasaIva);
                pneto_D2 = CalculaNeto(prd.pfd_M2, prd.tasaIva);
                pneto_D3 = CalculaNeto(prd.pfd_M3, prd.tasaIva);
                pneto_D4 = CalculaNeto(prd.pfd_M4, prd.tasaIva);
            }

            _dataPrd.setCodigo(prd.codigo);
            _dataPrd.setDescripcion(prd.descripcion);
            _dataPrd.setAuto(prd.auto);
            _dataPrd.setEmpaqueCompraDesc(prd.empCompraDesc);
            _dataPrd.setContEmpaqueCompraDesc(prd.contEmpCompra);
            _dataPrd.setCostoEmpCompra(costo);
            _dataPrd.setMetodoCalculoUt(_metodoCalculoDesc);
            _dataPrd.setTasaCambioPrd(_tasaCambio);
            _dataPrd.setAdmDivisaDesc(admDivisa);
            _dataPrd.setTasaIvaPrd(prd.tasaIva);
            _dataPrd.setFechaUltActPrd(new DateTime(2022, 05, 03).ToShortDateString());
            _dataPrd.setEsAdmDivisa(prd.EsAdmDivisa);


            _descPrecio1 = "PRECIO 1";
            _descPrecio2 = "PRECIO 2";
            _descPrecio3 = "PRECIO 3";
            _descPrecio4 = "PRECIO 4";
            _descPrecio5 = "PRECIO 5";

            var r02 = Sistema.MyData.EmpaqueMedida_GetLista();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            var lst = new List<ficha>();
            foreach (var rg in r02.Lista.OrderBy(o => o.nombre).ToList()) 
            {
                var nr = new ficha(rg.auto, "", rg.nombre);
                lst.Add(nr);
            }
            _gEmp1.setData(lst);
            _gEmp2.setData(lst);
            _gEmp3.setData(lst);
            _gEmp4.setData(lst);
            _gEmp5.setData(lst);
            _gEmpM1.setData(lst);
            _gEmpM2.setData(lst);
            _gEmpM3.setData(lst);
            _gEmpM4.setData(lst);
            _gEmpD1.setData(lst);
            _gEmpD2.setData(lst);
            _gEmpD3.setData(lst);
            _gEmpD4.setData(lst);

            _precio1.setContenido(prd.cont_1);
            _precio1.setUtilidadActual(prd.utilidad_1 );
            _precio1.setCostoEmpCompra(costo);
            _precio1.setContEmpCompra(prd.contEmpCompra);
            _precio1.setAdmDivisa(prd.EsAdmDivisa);
            _precio1.setTasaCambio(_tasaCambio);
            _precio1.setTasaIva(prd.tasaIva);
            _precio1.setMetodoCalculoUtilidad(_metodoCalculo);
            _precio1.setNeto(pneto_1);
            _gEmp1.setFicha(prd.autoEmp_1);

            _precio2.setContenido(prd.cont_2);
            _precio2.setUtilidadActual(prd.utilidad_2);
            _precio2.setCostoEmpCompra(costo);
            _precio2.setContEmpCompra(prd.contEmpCompra);
            _precio2.setAdmDivisa(prd.EsAdmDivisa);
            _precio2.setTasaCambio(_tasaCambio);
            _precio2.setTasaIva(prd.tasaIva);
            _precio2.setMetodoCalculoUtilidad(_metodoCalculo);
            _precio2.setNeto(pneto_2);
            _gEmp2.setFicha(prd.autoEmp_2);

            _precio3.setContenido(prd.cont_3);
            _precio3.setUtilidadActual(prd.utilidad_3);
            _precio3.setCostoEmpCompra(costo);
            _precio3.setContEmpCompra(prd.contEmpCompra);
            _precio3.setAdmDivisa(prd.EsAdmDivisa);
            _precio3.setTasaCambio(_tasaCambio);
            _precio3.setTasaIva(prd.tasaIva);
            _precio3.setMetodoCalculoUtilidad(_metodoCalculo);
            _precio3.setNeto(pneto_3);
            _gEmp3.setFicha(prd.autoEmp_3);

            _precio4.setContenido(prd.cont_4);
            _precio4.setUtilidadActual(prd.utilidad_4);
            _precio4.setCostoEmpCompra(costo);
            _precio4.setContEmpCompra(prd.contEmpCompra);
            _precio4.setAdmDivisa(prd.EsAdmDivisa);
            _precio4.setTasaCambio(_tasaCambio);
            _precio4.setTasaIva(prd.tasaIva);
            _precio4.setMetodoCalculoUtilidad(_metodoCalculo);
            _precio4.setNeto(pneto_4);
            _gEmp4.setFicha(prd.autoEmp_4);

            _precio5.setContenido(prd.cont_5);
            _precio5.setUtilidadActual(prd.utilidad_5);
            _precio5.setCostoEmpCompra(costo);
            _precio5.setContEmpCompra(prd.contEmpCompra);
            _precio5.setAdmDivisa(prd.EsAdmDivisa);
            _precio5.setTasaCambio(_tasaCambio);
            _precio5.setTasaIva(prd.tasaIva);
            _precio5.setMetodoCalculoUtilidad(_metodoCalculo);
            _precio5.setNeto(pneto_5);
            _gEmp5.setFicha(prd.autoEmp_5);


            _precioM1.setContenido(prd.cont_M1);
            _precioM1.setUtilidadActual(prd.utilidad_M1);
            _precioM1.setCostoEmpCompra(costo);
            _precioM1.setContEmpCompra(prd.contEmpCompra);
            _precioM1.setAdmDivisa(prd.EsAdmDivisa);
            _precioM1.setTasaCambio(_tasaCambio);
            _precioM1.setTasaIva(prd.tasaIva);
            _precioM1.setMetodoCalculoUtilidad(_metodoCalculo);
            _precioM1.setNeto(pneto_M1);
            _gEmpM1.setFicha(prd.autoEmp_M1);

            _precioM2.setContenido(prd.cont_M2);
            _precioM2.setUtilidadActual(prd.utilidad_M2);
            _precioM2.setCostoEmpCompra(costo);
            _precioM2.setContEmpCompra(prd.contEmpCompra);
            _precioM2.setAdmDivisa(prd.EsAdmDivisa);
            _precioM2.setTasaCambio(_tasaCambio);
            _precioM2.setTasaIva(prd.tasaIva);
            _precioM2.setMetodoCalculoUtilidad(_metodoCalculo);
            _precioM2.setNeto(pneto_M2);
            _gEmpM2.setFicha(prd.autoEmp_M2);

            _precioM3.setContenido(prd.cont_M3);
            _precioM3.setUtilidadActual(prd.utilidad_M3);
            _precioM3.setCostoEmpCompra(costo);
            _precioM3.setContEmpCompra(prd.contEmpCompra);
            _precioM3.setAdmDivisa(prd.EsAdmDivisa);
            _precioM3.setTasaCambio(_tasaCambio);
            _precioM3.setTasaIva(prd.tasaIva);
            _precioM3.setMetodoCalculoUtilidad(_metodoCalculo);
            _precioM3.setNeto(pneto_M3);
            _gEmpM3.setFicha(prd.autoEmp_M3);

            _precioM4.setContenido(prd.cont_M4);
            _precioM4.setUtilidadActual(prd.utilidad_M4);
            _precioM4.setCostoEmpCompra(costo);
            _precioM4.setContEmpCompra(prd.contEmpCompra);
            _precioM4.setAdmDivisa(prd.EsAdmDivisa);
            _precioM4.setTasaCambio(_tasaCambio);
            _precioM4.setTasaIva(prd.tasaIva);
            _precioM4.setMetodoCalculoUtilidad(_metodoCalculo);
            _precioM4.setNeto(pneto_M4);
            _gEmpM4.setFicha(prd.autoEmp_M4);


            _precioD1.setContenido(prd.cont_M1);
            _precioD1.setUtilidadActual(prd.utilidad_M1);
            _precioD1.setCostoEmpCompra(costo);
            _precioD1.setContEmpCompra(prd.contEmpCompra);
            _precioD1.setAdmDivisa(prd.EsAdmDivisa);
            _precioD1.setTasaCambio(_tasaCambio);
            _precioD1.setTasaIva(prd.tasaIva);
            _precioD1.setMetodoCalculoUtilidad(_metodoCalculo);
            _precioD1.setNeto(pneto_D1);
            _gEmpD1.setFicha(prd.autoEmp_M1);

            _precioD2.setContenido(prd.cont_M2);
            _precioD2.setUtilidadActual(prd.utilidad_M2);
            _precioD2.setCostoEmpCompra(costo);
            _precioD2.setContEmpCompra(prd.contEmpCompra);
            _precioD2.setAdmDivisa(prd.EsAdmDivisa);
            _precioD2.setTasaCambio(_tasaCambio);
            _precioD2.setTasaIva(prd.tasaIva);
            _precioD2.setMetodoCalculoUtilidad(_metodoCalculo);
            _precioD2.setNeto(pneto_D2);
            _gEmpD2.setFicha(prd.autoEmp_M2);

            _precioD3.setContenido(prd.cont_M3);
            _precioD3.setUtilidadActual(prd.utilidad_M3);
            _precioD3.setCostoEmpCompra(costo);
            _precioD3.setContEmpCompra(prd.contEmpCompra);
            _precioD3.setAdmDivisa(prd.EsAdmDivisa);
            _precioD3.setTasaCambio(_tasaCambio);
            _precioD3.setTasaIva(prd.tasaIva);
            _precioD3.setMetodoCalculoUtilidad(_metodoCalculo);
            _precioD3.setNeto(pneto_D3);
            _gEmpD3.setFicha(prd.autoEmp_M3);

            _precioD4.setContenido(prd.cont_M4);
            _precioD4.setUtilidadActual(prd.utilidad_M4);
            _precioD4.setCostoEmpCompra(costo);
            _precioD4.setContEmpCompra(prd.contEmpCompra);
            _precioD4.setAdmDivisa(prd.EsAdmDivisa);
            _precioD4.setTasaCambio(_tasaCambio);
            _precioD4.setTasaIva(prd.tasaIva);
            _precioD4.setMetodoCalculoUtilidad(_metodoCalculo);
            _precioD4.setNeto(pneto_D4);
            _gEmpD4.setFicha(prd.autoEmp_M4);


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
            ////prefRegistroPrecioIsNeto = (r06.Entidad == OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio.Neto);

            ////PREFERENCIA PRECIO
            //var preferenciaPrecio = data.enumPreferenciaPrecio.Neto;
            //if (r06.Entidad == OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio.Full)
            //{
            //    preferenciaPrecio = data.enumPreferenciaPrecio.Full;
            //}

            ////REDONDEO
            //var redondeo = data.enumModoRedondeo.SinRedondeo;
            //switch (r05.Entidad)
            //{
            //    case OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.Unidad:
            //        redondeo = data.enumModoRedondeo.Unidad;
            //        break;
            //    case OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.Decena:
            //        redondeo = data.enumModoRedondeo.Decena;
            //        break;
            //}

            ////TASA CAMBIO ACTUAL
            //tasaCambioActual = r03.Entidad;

            ////UTILIDAD METODO
            //modoUtilidad = data.enumModo.Lineal;
            //if (r04.Entidad == OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad.Financiero)
            //{
            //    modoUtilidad = data.enumModo.Financiero;
            //}

            ////FICHA PRODUCTO
            //producto = r01.Entidad.codigo + Environment.NewLine + r01.Entidad.descripcion;
            //admDivisa = r01.Entidad.admDivisa.ToString();
            //tasaIva = "EXENTO";
            //fechaUltActCosto = r01.Entidad.fechaUltimaActCosto;
            //costoUnd = r01.Entidad.costoUnd;
            //costoUndDivisa = r01.Entidad.costoUndDivisa;

            //if (r01.Entidad.tasaIva > 0)
            //{
            //    tasaIva = r01.Entidad.tasaIva.ToString("n2").Trim().PadLeft(5, '0') + "%";
            //    _tasaIvaValor = r01.Entidad.tasaIva;
            //}

            //var _modoDivisa = false;
            //var _costoUnd = r01.Entidad.costoUnd;
            //var _p1 = r01.Entidad.precioNeto1;
            //var _p2 = r01.Entidad.precioNeto2;
            //var _p3 = r01.Entidad.precioNeto3;
            //var _p4 = r01.Entidad.precioNeto4;
            //var _p5 = r01.Entidad.precioNeto5;
            //var _pMay1 = r01.Entidad.precioNetoMay1;
            //var _pMay2 = r01.Entidad.precioNetoMay2;
            //costoUnit = r01.Entidad.costoUnd.ToString("N2");
            //if (r01.Entidad.admDivisa == OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa.Si)
            //{
            //    isModoActualDivisa = true;
            //    _p1 = r01.Entidad.precioFullDivisa1;
            //    _p2 = r01.Entidad.precioFullDivisa2;
            //    _p3 = r01.Entidad.precioFullDivisa3;
            //    _p4 = r01.Entidad.precioFullDivisa4;
            //    _p5 = r01.Entidad.precioFullDivisa5;
            //    _pMay1 = r01.Entidad.precioFullDivisaMay1;
            //    _pMay2 = r01.Entidad.precioFullDivisaMay2;
            //    _modoDivisa = true;
            //    _costoUnd = r01.Entidad.costoUndDivisa;
            //    costoUnit = r01.Entidad.costoUndDivisa.ToString("N2");
            //}
            //var _tasaIva = r01.Entidad.tasaIva;
            //precio_1.setData(r01.Entidad.contenido1, _costoUnd, _tasaIva, r01.Entidad.utilidad1, _p1, modoUtilidad, r01.Entidad.etiqueta1, "0000000001", _modoDivisa, tasaCambioActual, redondeo, preferenciaPrecio, r01.Entidad.costoUndDivisa, r01.Entidad.costoUnd);
            //precio_2.setData(r01.Entidad.contenido2, _costoUnd, _tasaIva, r01.Entidad.utilidad2, _p2, modoUtilidad, r01.Entidad.etiqueta2, "0000000001", _modoDivisa, tasaCambioActual, redondeo, preferenciaPrecio, r01.Entidad.costoUndDivisa, r01.Entidad.costoUnd);
            //precio_3.setData(r01.Entidad.contenido3, _costoUnd, _tasaIva, r01.Entidad.utilidad3, _p3, modoUtilidad, r01.Entidad.etiqueta3, "0000000001", _modoDivisa, tasaCambioActual, redondeo, preferenciaPrecio, r01.Entidad.costoUndDivisa, r01.Entidad.costoUnd);
            //precio_4.setData(r01.Entidad.contenido4, _costoUnd, _tasaIva, r01.Entidad.utilidad4, _p4, modoUtilidad, r01.Entidad.etiqueta4, "0000000001", _modoDivisa, tasaCambioActual, redondeo, preferenciaPrecio, r01.Entidad.costoUndDivisa, r01.Entidad.costoUnd);
            //precio_5.setData(r01.Entidad.contenido5, _costoUnd, _tasaIva, r01.Entidad.utilidad5, _p5, modoUtilidad, r01.Entidad.etiqueta5, "0000000001", _modoDivisa, tasaCambioActual, redondeo, preferenciaPrecio, r01.Entidad.costoUndDivisa, r01.Entidad.costoUnd);
            //_may_1.setData(r01.Entidad.contenidoMay1, _costoUnd, _tasaIva, r01.Entidad.utilidadMay1, _pMay1, modoUtilidad, "MAYOR 1", r01.Entidad.autoEmpMay1, _modoDivisa, tasaCambioActual, redondeo, preferenciaPrecio, r01.Entidad.costoUndDivisa, r01.Entidad.costoUnd);
            //_may_2.setData(r01.Entidad.contenidoMay2, _costoUnd, _tasaIva, r01.Entidad.utilidadMay2, _pMay2, modoUtilidad, "MAYOR 2", r01.Entidad.autoEmpMay2, _modoDivisa, tasaCambioActual, redondeo, preferenciaPrecio, r01.Entidad.costoUndDivisa, r01.Entidad.costoUnd);

            return rt;
        }

        public void AbandonarFicha()
        {
            _isAbandonarIsOk = false;
            var xmsg = "Abandonar Cambios Realizados ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes) 
            {
                _isAbandonarIsOk = true;
            }
            
        }


        public BindingSource GetEmp1_Source { get { return _gEmp1.Source; } }
        public BindingSource GetEmp2_Source { get { return _gEmp2.Source; } }
        public BindingSource GetEmp3_Source { get { return _gEmp3.Source; } }
        public BindingSource GetEmp4_Source { get { return _gEmp4.Source; } }
        public BindingSource GetEmp5_Source { get { return _gEmp5.Source; } }
        //
        public BindingSource GetEmpM1_Source { get { return _gEmpM1.Source; } }
        public BindingSource GetEmpM2_Source { get { return _gEmpM2.Source; } }
        public BindingSource GetEmpM3_Source { get { return _gEmpM3.Source; } }
        public BindingSource GetEmpM4_Source { get { return _gEmpM4.Source; } }
        //
        public BindingSource GetEmpD1_Source { get { return _gEmpD1.Source; } }
        public BindingSource GetEmpD2_Source { get { return _gEmpD2.Source; } }
        public BindingSource GetEmpD3_Source { get { return _gEmpD3.Source; } }
        public BindingSource GetEmpD4_Source { get { return _gEmpD4.Source; } }


        public void setEmp1(string id)
        {
            _gEmp1.setFicha(id);
        }
        public void setEmp2(string id)
        {
            _gEmp2.setFicha(id);
        }
        public void setEmp3(string id)
        {
            _gEmp3.setFicha(id);
        }
        public void setEmp4(string id)
        {
            _gEmp4.setFicha(id);
        }
        public void setEmp5(string id)
        {
            _gEmp5.setFicha(id);
        }
        //
        public void setEmpM1(string id)
        {
            _gEmpM1.setFicha(id);
        }
        public void setEmpM2(string id)
        {
            _gEmpM2.setFicha(id);
        }
        public void setEmpM3(string id)
        {
            _gEmpM3.setFicha(id);
        }
        public void setEmpM4(string id)
        {
            _gEmpM4.setFicha(id);
        }
        //
        public void setEmpD1(string id)
        {
            _gEmpD1.setFicha(id);
        }
        public void setEmpD2(string id)
        {
            _gEmpD2.setFicha(id);
        }
        public void setEmpD3(string id)
        {
            _gEmpD3.setFicha(id);
        }
        public void setEmpD4(string id)
        {
            _gEmpD4.setFicha(id);
        }


        public string GetDescPrecio1 { get { return _descPrecio1; } }
        public string GetDescPrecio2 { get { return _descPrecio2; } }
        public string GetDescPrecio3 { get { return _descPrecio3; } }
        public string GetDescPrecio4 { get { return _descPrecio4; } }
        public string GetDescPrecio5 { get { return _descPrecio5; } }
        //
        public string GetDescPrecioM1 { get { return _descPrecio1; } }
        public string GetDescPrecioM2 { get { return _descPrecio2; } }
        public string GetDescPrecioM3 { get { return _descPrecio3; } }
        public string GetDescPrecioM4 { get { return _descPrecio4; } }


        public string GetEmp1_Id { get { return _gEmp1.GetId; } }
        public string GetEmp2_Id { get { return _gEmp2.GetId; } }
        public string GetEmp3_Id { get { return _gEmp3.GetId; } }
        public string GetEmp4_Id { get { return _gEmp4.GetId; } }
        public string GetEmp5_Id { get { return _gEmp5.GetId; } }
        //
        public string GetEmpM1_Id { get { return _gEmpM1.GetId; } }
        public string GetEmpM2_Id { get { return _gEmpM2.GetId; } }
        public string GetEmpM3_Id { get { return _gEmpM3.GetId; } }
        public string GetEmpM4_Id { get { return _gEmpM4.GetId; } }
        //
        public string GetEmpD1_Id { get { return _gEmpD1.GetId; } }
        public string GetEmpD2_Id { get { return _gEmpD2.GetId; } }
        public string GetEmpD3_Id { get { return _gEmpD3.GetId; } }
        public string GetEmpD4_Id { get { return _gEmpD4.GetId; } }


        public void setContEmp_1(int cont)
        {
            _precio1.setContenido(cont);
        }
        public void setUt_1(decimal ut)
        {
            _precio1.setUtilidadNueva(ut);
        }
        public void setPN_1(decimal monto)
        {
            _precio1.setNeto(monto);
        }
        public void setPF_1(decimal monto)
        {
            _precio1.setFull(monto);
        }
        public int GetCont1 { get { return _precio1.Contenido; } }
        public decimal GetUt1 { get { return _precio1.Utilidad; } }
        public decimal GetPN1 { get { return _precio1.Neto; } }
        public decimal GetPF1 { get { return _precio1.Full; } }
        public decimal GetUtActual1 { get { return _precio1.UtilidadActual; } }
        public bool ERR_1 { get { return _precio1.IsError; } }


        public void setContEmp_2(int cont)
        {
            _precio2.setContenido(cont);
        }
        public void setUt_2(decimal ut)
        {
            _precio2.setUtilidadNueva(ut);
        }
        public void setPN_2(decimal monto)
        {
            _precio2.setNeto(monto);
        }
        public void setPF_2(decimal monto)
        {
            _precio2.setFull(monto);
        }
        public int GetCont2 { get { return _precio2.Contenido; } }
        public decimal GetUt2 { get { return _precio2.Utilidad; } }
        public decimal GetPN2 { get { return _precio2.Neto; } }
        public decimal GetPF2 { get { return _precio2.Full; } }
        public decimal GetUtActual2 { get { return _precio2.UtilidadActual; } }
        public bool ERR_2 { get { return _precio2.IsError; } }


        public void setContEmp_3(int cont)
        {
            _precio3.setContenido(cont);
        }
        public void setUt_3(decimal ut)
        {
            _precio3.setUtilidadNueva(ut);
        }
        public void setPN_3(decimal monto)
        {
            _precio3.setNeto(monto);
        }
        public void setPF_3(decimal monto)
        {
            _precio3.setFull(monto);
        }
        public int GetCont3 { get { return _precio3.Contenido; } }
        public decimal GetUt3 { get { return _precio3.Utilidad; } }
        public decimal GetPN3 { get { return _precio3.Neto; } }
        public decimal GetPF3 { get { return _precio3.Full; } }
        public decimal GetUtActual3 { get { return _precio3.UtilidadActual; } }
        public bool ERR_3 { get { return _precio3.IsError; } }


        public void setContEmp_4(int cont)
        {
            _precio4.setContenido(cont);
        }
        public void setUt_4(decimal ut)
        {
            _precio4.setUtilidadNueva(ut);
        }
        public void setPN_4(decimal monto)
        {
            _precio4.setNeto(monto);
        }
        public void setPF_4(decimal monto)
        {
            _precio4.setFull(monto);
        }
        public int GetCont4 { get { return _precio4.Contenido; } }
        public decimal GetUt4 { get { return _precio4.Utilidad; } }
        public decimal GetPN4 { get { return _precio4.Neto; } }
        public decimal GetPF4 { get { return _precio4.Full; } }
        public decimal GetUtActual4 { get { return _precio4.UtilidadActual; } }
        public bool ERR_4 { get { return _precio4.IsError; } }


        public void setContEmp_5(int cont)
        {
            _precio5.setContenido(cont);
        }
        public void setUt_5(decimal ut)
        {
            _precio5.setUtilidadNueva(ut);
        }
        public void setPN_5(decimal monto)
        {
            _precio5.setNeto(monto);
        }
        public void setPF_5(decimal monto)
        {
            _precio5.setFull(monto);
        }
        public int GetCont5 { get { return _precio5.Contenido; } }
        public decimal GetUt5 { get { return _precio5.Utilidad; } }
        public decimal GetPN5 { get { return _precio5.Neto; } }
        public decimal GetPF5 { get { return _precio5.Full; } }
        public decimal GetUtActual5 { get { return _precio5.UtilidadActual; } }
        public bool ERR_5 { get { return _precio5.IsError; } }


        public void setContEmp_M1(int cont)
        {
            _precioM1.setContenido(cont);
        }
        public void setUt_M1(decimal ut)
        {
            _precioM1.setUtilidadNueva(ut);
        }
        public void setPN_M1(decimal monto)
        {
            _precioM1.setNeto(monto);
        }
        public void setPF_M1(decimal monto)
        {
            _precioM1.setFull(monto);
        }
        public int GetContM1 { get { return _precioM1.Contenido; } }
        public decimal GetUtM1 { get { return _precioM1.Utilidad; } }
        public decimal GetPNM1 { get { return _precioM1.Neto; } }
        public decimal GetPFM1 { get { return _precioM1.Full; } }
        public decimal GetUtActualM1 { get { return _precioM1.UtilidadActual; } }
        public bool ERR_M1 { get { return _precioM1.IsError; } }


        public void setContEmp_M2(int cont)
        {
            _precioM2.setContenido(cont);
        }
        public void setUt_M2(decimal ut)
        {
            _precioM2.setUtilidadNueva(ut);
        }
        public void setPN_M2(decimal monto)
        {
            _precioM2.setNeto(monto);
        }
        public void setPF_M2(decimal monto)
        {
            _precioM2.setFull(monto);
        }
        public int GetContM2 { get { return _precioM2.Contenido; } }
        public decimal GetUtM2 { get { return _precioM2.Utilidad; } }
        public decimal GetPNM2 { get { return _precioM2.Neto; } }
        public decimal GetPFM2 { get { return _precioM2.Full; } }
        public decimal GetUtActualM2 { get { return _precioM2.UtilidadActual; } }
        public bool ERR_M2 { get { return _precioM2.IsError; } }


        public void setContEmp_M3(int cont)
        {
            _precioM3.setContenido(cont);
        }
        public void setUt_M3(decimal ut)
        {
            _precioM3.setUtilidadNueva(ut);
        }
        public void setPN_M3(decimal monto)
        {
            _precioM3.setNeto(monto);
        }
        public void setPF_M3(decimal monto)
        {
            _precioM3.setFull(monto);
        }
        public int GetContM3 { get { return _precioM3.Contenido; } }
        public decimal GetUtM3 { get { return _precioM3.Utilidad; } }
        public decimal GetPNM3 { get { return _precioM3.Neto; } }
        public decimal GetPFM3 { get { return _precioM3.Full; } }
        public decimal GetUtActualM3 { get { return _precioM3.UtilidadActual; } }
        public bool ERR_M3 { get { return _precioM3.IsError; } }


        public void setContEmp_M4(int cont)
        {
            _precioM4.setContenido(cont);
        }
        public void setUt_M4(decimal ut)
        {
            _precioM4.setUtilidadNueva(ut);
        }
        public void setPN_M4(decimal monto)
        {
            _precioM4.setNeto(monto);
        }
        public void setPF_M4(decimal monto)
        {
            _precioM4.setFull(monto);
        }
        public int GetContM4 { get { return _precioM4.Contenido; } }
        public decimal GetUtM4 { get { return _precioM4.Utilidad; } }
        public decimal GetPNM4 { get { return _precioM4.Neto; } }
        public decimal GetPFM4 { get { return _precioM4.Full; } }
        public decimal GetUtActualM4 { get { return _precioM4.UtilidadActual; } }
        public bool ERR_M4 { get { return _precioM4.IsError; } }


        public string GetInfProducto { get { return _dataPrd.InfPrd; } }
        public string GetInfEmpCompraPrd { get { return _dataPrd.InfEmpCompra; } }
        public decimal GetInfCostoEmpCompraPrd { get { return _dataPrd.InfCostoEmpCompra; } }
        public string GetInfMetodoCalculoUt { get { return _dataPrd.InfMetodoCalculoUt; } }
        public decimal GetInfTasaCambioPrd { get { return _dataPrd.InfTasaCambio ; } }
        public string GetInfAdmDivisaPrd { get { return _dataPrd.InfAdmDivisaDesc; } }
        public decimal GetInfTasaIvaPrd { get { return _dataPrd.InfTasaIva; } }
        public decimal GetInfCostoUndPrd { get { return _dataPrd.InfCostoUnd; } }
        public string GetInfFechaUltActPrd { get { return _dataPrd.InfFechaUltAct; } }
        public bool GetEsAdmDivisaPrd { get { return _dataPrd.InfEsAdmDivisa; } }


        public void Procesar()
        {
            _isProcesarIsOk = false;
            var msg = "Procesar Cambios Efectuados ?";
            var rt = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (rt == DialogResult.Yes)
            {
                Guardar();
            }
        }

        private void Guardar()
        {
            var rt = true;

            if (_gEmp1.GetId == "") 
            {
                Helpers.Msg.Error("[ EMPAQUE PRECIO TIPO(1) PARA PRECIO (1) INCORRECTO");
                return;
            }
            if (_gEmp2.GetId == "")
            {
                Helpers.Msg.Error("[ EMPAQUE PRECIO TIPO(1) PARA PRECIO (2) INCORRECTO");
                return;
            }
            if (_gEmp3.GetId == "")
            {
                Helpers.Msg.Error("[ EMPAQUE PRECIO TIPO(1) PARA PRECIO (3) INCORRECTO");
                return;
            }
            if (_gEmp4.GetId == "")
            {
                Helpers.Msg.Error("[ EMPAQUE PRECIO TIPO(1) PARA PRECIO (4) INCORRECTO");
                return;
            }
            if (_gEmp5.GetId == "")
            {
                Helpers.Msg.Error("[ EMPAQUE PRECIO (5) INCORRECTO");
                return;
            }

            if (_gEmpM1.GetId == "")
            {
                Helpers.Msg.Error("[ EMPAQUE PRECIO TIPO(2) PARA PRECIO (1) INCORRECTO");
                return;
            }
            if (_gEmpM2.GetId == "")
            {
                Helpers.Msg.Error("[ EMPAQUE PRECIO TIPO(2) PARA PRECIO (2) INCORRECTO");
                return;
            }
            if (_gEmpM3.GetId == "")
            {
                Helpers.Msg.Error("[ EMPAQUE PRECIO TIPO(2) PARA PRECIO (3) INCORRECTO");
                return;
            }
            if (_gEmpM4.GetId == "")
            {
                Helpers.Msg.Error("[ EMPAQUE PRECIO TIPO(2) PARA PRECIO (4) INCORRECTO");
                return;
            }

            if (_gEmpD1.GetId == "")
            {
                Helpers.Msg.Error("[ EMPAQUE PRECIO TIPO(3) PARA PRECIO (1) INCORRECTO");
                return;
            }
            if (_gEmpD2.GetId == "")
            {
                Helpers.Msg.Error("[ EMPAQUE PRECIO TIPO(3) PARA PRECIO (2) INCORRECTO");
                return;
            }
            if (_gEmpD3.GetId == "")
            {
                Helpers.Msg.Error("[ EMPAQUE PRECIO TIPO(3) PARA PRECIO (3) INCORRECTO");
                return;
            }
            if (_gEmpD4.GetId == "")
            {
                Helpers.Msg.Error("[ EMPAQUE PRECIO TIPO(3) PARA PRECIO (4) INCORRECTO");
                return;
            }


            if (!_precio1.IsOk())
            {
                Helpers.Msg.Error("PRECIO (1)," + _precio1.msgError);
                return;
            }
            if (!_precio2.IsOk())
            {
                Helpers.Msg.Error("PRECIO (2)," + _precio2.msgError);
                return;
            }
            if (!_precio3.IsOk())
            {
                Helpers.Msg.Error("PRECIO (3)," + _precio3.msgError);
                return;
            }
            if (!_precio4.IsOk())
            {
                Helpers.Msg.Error("PRECIO (4)," + _precio4.msgError);
                return;
            }
            if (!_precio5.IsOk())
            {
                Helpers.Msg.Error("PRECIO (5)," + _precio5.msgError);
                return;
            }

            if (!_precioM1.IsOk())
            {
                Helpers.Msg.Error("PRECIO EMPAQUE TIPO(2) PARA PRECIO (1)," + _precioM1.msgError);
                return;
            }
            if (!_precioM2.IsOk())
            {
                Helpers.Msg.Error("PRECIO EMPAQUE TIPO(2) PARA PRECIO (2)," + _precioM2.msgError);
                return;
            }
            if (!_precioM3.IsOk())
            {
                Helpers.Msg.Error("PRECIO EMPAQUE TIPO(2) PARA PRECIO (3)," + _precioM3.msgError);
                return;
            }
            if (!_precioM4.IsOk())
            {
                Helpers.Msg.Error("PRECIO EMPAQUE TIPO(2) PARA PRECIO (4)," + _precioM4.msgError);
                return;
            }

            if (!_precioD1.IsOk())
            {
                Helpers.Msg.Error("PRECIO EMPAQUE TIPO(3) PARA PRECIO (1)," + _precioM1.msgError);
                return;
            }
            if (!_precioD2.IsOk())
            {
                Helpers.Msg.Error("PRECIO EMPAQUE TIPO(3) PARA PRECIO (2)," + _precioM2.msgError);
                return;
            }
            if (!_precioD3.IsOk())
            {
                Helpers.Msg.Error("PRECIO EMPAQUE TIPO(3) PARA PRECIO (3)," + _precioM3.msgError);
                return;
            }
            if (!_precioD4.IsOk())
            {
                Helpers.Msg.Error("PRECIO EMPAQUE TIPO(3) PARA PRECIO (4)," + _precioM4.msgError);
                return;
            }


            //if (!precio_2.IsOk())
            //{
            //    Helpers.Msg.Error("[ UTILIDAD/CONTENIDO EMPAQUE ] PRECIO VENTA ( 2 ) INCORRECTO");
            //    return false;
            //}
            //if (!precio_3.IsOk())
            //{
            //    Helpers.Msg.Error("[ UTILIDAD/CONTENIDO EMPAQUE ] PRECIO VENTA ( 3 ) INCORRECTO");
            //    return false;
            //}
            //if (!precio_4.IsOk())
            //{
            //    Helpers.Msg.Error("[ UTILIDAD/CONTENIDO EMPAQUE ] PRECIO VENTA ( 4 ) INCORRECTO");
            //    return false;
            //}
            //if (!precio_5.IsOk())
            //{
            //    Helpers.Msg.Error("[ UTILIDAD/CONTENIDO EMPAQUE ] PRECIO VENTA ( 5 ) INCORRECTO");
            //    return false;
            //}
            ////
            //if (!May_1.IsOk())
            //{
            //    Helpers.Msg.Error("[ UTILIDAD/CONTENIDO EMPAQUE ] PRECIO MAYOR ( 1 ) INCORRECTO");
            //    return false;
            //}
            //if (!May_2.IsOk())
            //{
            //    Helpers.Msg.Error("[ UTILIDAD/CONTENIDO EMPAQUE ] PRECIO MAYOR ( 2 ) INCORRECTO");
            //    return false;
            //}

            var ficha = new OOB.LibInventario.Precio.Editar.Ficha()
            {
                autoProducto = _idProducto,
                autoUsuario = Sistema.UsuarioP.autoUsu,
                codigoUsuario = Sistema.UsuarioP.codigoUsu,
                estacion = Environment.MachineName,
                nombreUsuario = Sistema.UsuarioP.nombreUsu,
            };
            var p1 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = _gEmp1.GetId,
                contenido = _precio1.Contenido ,
                precio_divisa_Neto = _precio1.Full_Divisa,
                precioNeto = _precio1.Neto_MonedaLocal,
                utilidad = _precio1.Utilidad,
            };
            ficha.precio_1= p1;
            var h1 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            {
                nota = "",
                precio = _precio1.Neto_MonedaLocal,
                precio_id = "1",
                empaque = "UNIDAD",
                contenido = _precio1.Contenido,
            };

            var p2 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = _gEmp2.GetId,
                contenido = _precio2.Contenido,
                precio_divisa_Neto = _precio2.Full_Divisa,
                precioNeto = _precio2.Neto_MonedaLocal,
                utilidad = _precio2.Utilidad,
            };
            ficha.precio_2 = p2;
            var h2 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            {
                nota = "",
                precio = _precio2.Neto_MonedaLocal,
                precio_id = "2",
                empaque = "UNIDAD",
                contenido = _precio2.Contenido,
            };

            var p3 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = _gEmp3.GetId,
                contenido = _precio3.Contenido,
                precio_divisa_Neto = _precio3.Full_Divisa,
                precioNeto = _precio3.Neto_MonedaLocal,
                utilidad = _precio3.Utilidad ,
            };
            ficha.precio_3 = p3;
            var h3 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            {
                nota = "",
                precio = _precio3.Neto_MonedaLocal,
                precio_id = "3",
                empaque = "UNIDAD",
                contenido = _precio3.Contenido,
            };

            var p4 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = _gEmp4.GetId,
                contenido = _precio4.Contenido,
                precio_divisa_Neto = _precio4.Full_Divisa,
                precioNeto = _precio4.Neto_MonedaLocal,
                utilidad = _precio4.Utilidad,
            };
            ficha.precio_4 = p4;
            var h4 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            {
                nota = "",
                precio = _precio4.Neto_MonedaLocal,
                precio_id = "4",
                empaque = "UNIDAD",
                contenido = _precio4.Contenido,
            };

            var p5 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = _gEmp5.GetId,
                contenido = _precio5.Contenido,
                precio_divisa_Neto = _precio5.Full_Divisa,
                precioNeto = _precio5.Neto_MonedaLocal,
                utilidad = _precio5.Utilidad,
            };
            ficha.precio_5 = p5;
            var h5 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            {
                nota = "",
                precio = _precio5.Neto_MonedaLocal,
                precio_id = "PTO",
                empaque = "UNIDAD",
                contenido = _precio5.Contenido,
            };

            //
            var m1 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = _gEmpM1.GetId,
                contenido = _precioM1.Contenido,
                precio_divisa_Neto = _precioM1.Full_Divisa,
                precioNeto = _precioM1.Neto_MonedaLocal,
                utilidad = _precioM1.Utilidad,
            };
            ficha.may_1 = m1;
            var hM1 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            {
                nota = "",
                precio = _precioM1.Neto_MonedaLocal,
                precio_id = "MY1",
                empaque = _gEmpM1.Item.desc,
                contenido = _precioM1.Contenido,
            };

            var m2 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = _gEmpM2.GetId,
                contenido = _precioM2.Contenido,
                precio_divisa_Neto = _precioM2.Full_Divisa,
                precioNeto = _precioM2.Neto_MonedaLocal,
                utilidad = _precioM2.Utilidad,
            };
            ficha.may_2 = m2;
            var hM2 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            {
                nota = "",
                precio = _precioM2.Neto_MonedaLocal,
                precio_id = "MY2",
                empaque = _gEmpM2.Item.desc,
                contenido = _precioM2.Contenido,
            };

            var m3 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = _gEmpM3.GetId,
                contenido = _precioM3.Contenido,
                precio_divisa_Neto = _precioM3.Full_Divisa,
                precioNeto = _precioM3.Neto_MonedaLocal,
                utilidad = _precioM3.Utilidad,
            };
            ficha.may_3 = m3;
            var hM3 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            {
                nota = "",
                precio = _precioM3.Neto_MonedaLocal,
                precio_id = "MY3",
                empaque = _gEmpM3.Item.desc,
                contenido = _precioM3.Contenido,
            };

            var m4 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = _gEmpM4.GetId,
                contenido = _precioM4.Contenido,
                precio_divisa_Neto = _precioM4.Full_Divisa,
                precioNeto = _precioM4.Neto_MonedaLocal,
                utilidad = _precioM4.Utilidad,
            };
            ficha.may_4 = m4;
            var hM4 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            {
                nota = "",
                precio = _precioM4.Neto_MonedaLocal,
                precio_id = "MY4",
                empaque = _gEmpM4.Item.desc,
                contenido = _precioM4.Contenido,
            };


            //
            var d1 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = _gEmpD1.GetId,
                contenido = _precioD1.Contenido,
                precio_divisa_Neto = _precioD1.Full_Divisa,
                precioNeto = _precioD1.Neto_MonedaLocal,
                utilidad = _precioD1.Utilidad,
            };
            ficha.dsp_1  = d1;
            var hD1 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            {
                nota = "",
                precio = _precioD1.Neto_MonedaLocal,
                precio_id = "DS1",
                empaque = _gEmpD1.Item.desc,
                contenido = _precioD1.Contenido,
            };

            var d2 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = _gEmpD2.GetId,
                contenido = _precioD2.Contenido,
                precio_divisa_Neto = _precioD2.Full_Divisa,
                precioNeto = _precioD2.Neto_MonedaLocal,
                utilidad = _precioD2.Utilidad,
            };
            ficha.dsp_2 = d2;
            var hD2 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            {
                nota = "",
                precio = _precioD2.Neto_MonedaLocal,
                precio_id = "DS2",
                empaque = _gEmpD2.Item.desc,
                contenido = _precioD2.Contenido,
            };

            var d3 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = _gEmpD3.GetId,
                contenido = _precioD3.Contenido,
                precio_divisa_Neto = _precioD3.Full_Divisa,
                precioNeto = _precioD3.Neto_MonedaLocal,
                utilidad = _precioD3.Utilidad,
            };
            ficha.dsp_3 = d3;
            var hD3 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            {
                nota = "",
                precio = _precioD3.Neto_MonedaLocal,
                precio_id = "DS3",
                empaque = _gEmpD3.Item.desc,
                contenido = _precioD3.Contenido,
            };

            var d4 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = _gEmpD4.GetId,
                contenido = _precioD4.Contenido,
                precio_divisa_Neto = _precioD4.Full_Divisa,
                precioNeto = _precioD4.Neto_MonedaLocal,
                utilidad = _precioD4.Utilidad,
            };
            ficha.dsp_4 = d4;
            var hD4 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            {
                nota = "",
                precio = _precioD4.Neto_MonedaLocal,
                precio_id = "DS4",
                empaque = _gEmpD4.Item.desc,
                contenido = _precioD4.Contenido,
            };


            var historia = new List<OOB.LibInventario.Precio.Editar.FichaHistorica>();
            historia.Add(h1);
            historia.Add(h2);
            historia.Add(h3);
            historia.Add(h4);
            historia.Add(h5);
            //
            historia.Add(hM1);
            historia.Add(hM2);
            historia.Add(hM3);
            historia.Add(hM4);
            //
            historia.Add(hD1);
            historia.Add(hD2);
            historia.Add(hD3);
            historia.Add(hD4); 


            ficha.historia = historia;
            var r01 = Sistema.MyData.PrecioProducto_Actualizar(ficha);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return ;
            }
            _isProcesarIsOk = true;
        }


        private decimal CalculaNeto(decimal monto, decimal tasa)
        {
            var rt = 0m;
            rt = monto / ((tasa / 100) + 1);
            return rt;
        }


        public void setContEmp_D1(int cont)
        {
            _precioD1.setContenido(cont);
        }
        public void setUt_D1(decimal ut)
        {
            _precioD1.setUtilidadNueva(ut);
        }
        public void setPN_D1(decimal monto)
        {
            _precioD1.setNeto(monto);
        }
        public void setPF_D1(decimal monto)
        {
            _precioD1.setFull(monto);
        }
        public int GetContD1 { get { return _precioD1.Contenido; } }
        public decimal GetUtD1 { get { return _precioD1.Utilidad; } }
        public decimal GetPND1 { get { return _precioD1.Neto; } }
        public decimal GetPFD1 { get { return _precioD1.Full; } }
        public decimal GetUtActualD1 { get { return _precioD1.UtilidadActual; } }
        public bool ERR_D1 { get { return _precioD1.IsError; } }


        public void setContEmp_D2(int cont)
        {
            _precioD2.setContenido(cont);
        }
        public void setUt_D2(decimal ut)
        {
            _precioD2.setUtilidadNueva(ut);
        }
        public void setPN_D2(decimal monto)
        {
            _precioD2.setNeto(monto);
        }
        public void setPF_D2(decimal monto)
        {
            _precioD2.setFull(monto);
        }
        public int GetContD2 { get { return _precioD2.Contenido; } }
        public decimal GetUtD2 { get { return _precioD2.Utilidad; } }
        public decimal GetPND2 { get { return _precioD2.Neto; } }
        public decimal GetPFD2 { get { return _precioD2.Full; } }
        public decimal GetUtActualD2 { get { return _precioD2.UtilidadActual; } }
        public bool ERR_D2 { get { return _precioD2.IsError; } }


        public void setContEmp_D3(int cont)
        {
            _precioD3.setContenido(cont);
        }
        public void setUt_D3(decimal ut)
        {
            _precioD3.setUtilidadNueva(ut);
        }
        public void setPN_D3(decimal monto)
        {
            _precioD3.setNeto(monto);
        }
        public void setPF_D3(decimal monto)
        {
            _precioD3.setFull(monto);
        }
        public int GetContD3 { get { return _precioD3.Contenido; } }
        public decimal GetUtD3 { get { return _precioD3.Utilidad; } }
        public decimal GetPND3 { get { return _precioD3.Neto; } }
        public decimal GetPFD3 { get { return _precioD3.Full; } }
        public decimal GetUtActualD3 { get { return _precioD3.UtilidadActual; } }
        public bool ERR_D3 { get { return _precioD3.IsError; } }


        public void setContEmp_D4(int cont)
        {
            _precioD4.setContenido(cont);
        }
        public void setUt_D4(decimal ut)
        {
            _precioD4.setUtilidadNueva(ut);
        }
        public void setPN_D4(decimal monto)
        {
            _precioD4.setNeto(monto);
        }
        public void setPF_D4(decimal monto)
        {
            _precioD4.setFull(monto);
        }
        public int GetContD4 { get { return _precioD4.Contenido; } }
        public decimal GetUtD4 { get { return _precioD4.Utilidad; } }
        public decimal GetPND4 { get { return _precioD4.Neto; } }
        public decimal GetPFD4 { get { return _precioD4.Full; } }
        public decimal GetUtActualD4 { get { return _precioD4.UtilidadActual; } }
        public bool ERR_D4 { get { return _precioD4.IsError; } }

    }

}