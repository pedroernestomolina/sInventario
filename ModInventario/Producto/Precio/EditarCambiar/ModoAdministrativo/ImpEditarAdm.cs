using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Precio.EditarCambiar.ModoAdministrativo
{
    public class ImpEditarAdm: IEditarAdm
    {
        private bool _isProcesarIsOk;
        private bool _isAbandonarIsOk;
        private string _idProducto;
        private dataProducto _dataPrd;
        private IVta _vta1;
        private IVta _vta2;
        private IVta _vta3;


        public IVta Vta1 { get { return _vta1; } }
        public IVta Vta2 { get { return _vta2; } }
        public IVta Vta3 { get { return _vta3; } }
        public string GetInfProducto { get { return _dataPrd.InfPrd; } }
        public string GetInfEmpCompraPrd { get { return _dataPrd.InfEmpCompra; } }
        public decimal GetInfCostoEmpCompraPrd { get { return _dataPrd.InfCostoEmpCompra; } }
        public string GetInfMetodoCalculoUt { get { return _dataPrd.InfMetodoCalculoUt; } }
        public decimal GetInfTasaCambioPrd { get { return _dataPrd.InfTasaCambio; } }
        public string GetInfAdmDivisaPrd { get { return _dataPrd.InfAdmDivisaDesc; } }
        public decimal GetInfTasaIvaPrd { get { return _dataPrd.InfTasaIva; } }
        public decimal GetInfCostoUndPrd { get { return _dataPrd.InfCostoUnd; } }
        public string GetInfFechaUltActPrd { get { return _dataPrd.InfFechaUltAct; } }
        public bool GetEsAdmDivisaPrd { get { return _dataPrd.InfEsAdmDivisa; } }


        public ImpEditarAdm() 
        {
            _isAbandonarIsOk = false;
            _isProcesarIsOk = false;
            _idProducto = "";
            _dataPrd = new dataProducto();
            _vta1 = new ImpVta();
            _vta2 = new ImpVta();
            _vta3 = new ImpVta(); 
        }


        public void Inicializa()
        {
            _idProducto = "";
            _isAbandonarIsOk = false;
            _isProcesarIsOk = false;
            _dataPrd.Inicializa();
            _vta1.Inicializa();
            _vta2.Inicializa();
            _vta3.Inicializa();
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
            var _tasaCambio = 0m;
            var _metodoCalculoDesc = "";
            var _metodoCalculo = dataPrecio.enumMetCalUtilidad.SinDefinir;

            try
            {
                var xr1 = Sistema.MyData.Producto_ModoAdm_GetPrecio_By(_idProducto, "1");
                var xr2 = Sistema.MyData.Producto_ModoAdm_GetCosto_By(_idProducto);
                var r03 = Sistema.MyData.Configuracion_TasaCambioActual();
                if (r03.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r03.Mensaje);
                }
                var r04 = Sistema.MyData.Configuracion_MetodoCalculoUtilidad();
                if (r04.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r04.Mensaje);
                }

                _tasaCambio = r03.Entidad;
                if (r04.Entidad == OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad.Lineal)
                {
                    _metodoCalculoDesc = "LINEAL";
                    _metodoCalculo = dataPrecio.enumMetCalUtilidad.Lineal;
                }
                else if (r04.Entidad == OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad.Financiero)
                {
                    _metodoCalculoDesc = "FINANCIERO";
                    _metodoCalculo = dataPrecio.enumMetCalUtilidad.Financiero;
                }

                var _esDivisa = xr1.Entidad.entidad.esDivisa;
                var _tasaIva = xr1.Entidad.entidad.tasaIva;
                var _codigoPrd = xr1.Entidad.entidad.codigo;
                var _descPrd = xr1.Entidad.entidad.descripcion;
                var _autoPrd = xr1.Entidad.entidad.auto;
                var _costo = _esDivisa ? xr2.Entidad.costoMonedaDivisa : xr2.Entidad.costoMonedaLocal;
                var _contEmpCompra = xr2.Entidad.contEmpCompra;
                var _descEmpCompra = xr2.Entidad.descEmpCompra;

                _dataPrd.setCodigo(_codigoPrd);
                _dataPrd.setDescripcion(_descPrd);
                _dataPrd.setAuto(_autoPrd);
                _dataPrd.setEmpaqueCompraDesc(_descEmpCompra);
                _dataPrd.setContEmpaqueCompraDesc(_contEmpCompra);
                _dataPrd.setCostoEmpCompra(_costo);
                _dataPrd.setMetodoCalculoUt(_metodoCalculoDesc);
                _dataPrd.setTasaCambioPrd(_tasaCambio);
                _dataPrd.setTasaIvaPrd(_tasaIva);
                _dataPrd.setFechaUltActPrd(new DateTime(2022, 05, 03).ToShortDateString());
                _dataPrd.setEsAdmDivisa(_esDivisa);
                             
                foreach (var xr in xr1.Entidad.precios)
                {
                    var rg = new data()
                    {
                        contEmpVenta = xr.contEmp,
                        contEmpCompra = _contEmpCompra,
                        costo = _costo,
                        esDivisa = xr1.Entidad.entidad.esDivisa,
                        metodoCalculoUt = (enumMetCalUtilidad)_metodoCalculo,
                        neto = _esDivisa ? CalculaNeto(xr.pfdEmp, _tasaIva) : xr.pnEmp,
                        tasaCambio = _tasaCambio,
                        tasaIva = _tasaIva,
                        utilidad = xr.utEmp,
                        descEmpVenta = xr.descEmp,
                        idPrecio=xr.idHndPrecioVenta
                    };
                    switch (xr.tipoEmp) 
                    {
                        case "1":
                            _vta1.setData(rg);
                            break;
                        case "2":
                            _vta2.setData(rg);
                            break;
                        case "3":
                            _vta3.setData(rg);
                            break;
                    }
                }

                var r05 = Sistema.MyData.Configuracion_ForzarRedondeoPrecioVenta();
                if (r05.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r05.Mensaje);
                }
                var r06 = Sistema.MyData.Configuracion_PreferenciaRegistroPrecio();
                if (r06.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r06.Mensaje);
                }
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }


        public bool EditarPrecioIsOk { get { return _isProcesarIsOk; } }
        public bool AbandonarIsOk { get { return _isAbandonarIsOk; } }
        public bool ProcesarIsOk { get { return _isProcesarIsOk; } }
        public void AbandonarFicha()
        {
            _isAbandonarIsOk = Helpers.Msg.Abandonar();
        }
        public void ProcesarFicha()
        {
            _isProcesarIsOk = false;
            var msg = "Procesar Cambios Efectuados ?";
            var rt = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (rt == DialogResult.Yes)
            {
                Guardar();
            }
        }


        private decimal CalculaNeto(decimal monto, decimal tasa)
        {
            var rt = 0m;
            rt = monto / ((tasa / 100) + 1);
            rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            return rt;
        }
        private void Guardar()
        {
            if (!Vta1.IsOk())
            {
                Helpers.Msg.Error("PRECIO (1)," + Vta1.msgError);
                return;
            }
            if (!Vta2.IsOk())
            {
                Helpers.Msg.Error("PRECIO (2)," + Vta2.msgError);
                return;
            }
            if (!Vta3.IsOk())
            {
                Helpers.Msg.Error("PRECIO (3)," + Vta3.msgError);
                return;
            }
            var _lstPrecio = new List<OOB.LibInventario.Producto.ActualizarPrecio.ModoAdm.Precio>();
            var _lstHistoria = new List<OOB.LibInventario.Producto.ActualizarPrecio.ModoAdm.Historia>();
            var p1 = new OOB.LibInventario.Producto.ActualizarPrecio.ModoAdm.Precio()
            {
                fullDivisa = Vta1.FullDivisaGrabar,
                id = Vta1.IdPrecioVentaRef,
                netoMonedaLocal = Vta1.NetoGrabar,
                utilidad = Vta1.UtilidadGrabar,
            };
            var p2 = new OOB.LibInventario.Producto.ActualizarPrecio.ModoAdm.Precio()
            {
                fullDivisa = Vta2.FullDivisaGrabar,
                id = Vta2.IdPrecioVentaRef,
                netoMonedaLocal = Vta2.NetoGrabar,
                utilidad = Vta2.UtilidadGrabar,
            };
            var p3 = new OOB.LibInventario.Producto.ActualizarPrecio.ModoAdm.Precio()
            {
                fullDivisa = Vta3.FullDivisaGrabar,
                id = Vta3.IdPrecioVentaRef,
                netoMonedaLocal = Vta3.NetoGrabar,
                utilidad = Vta3.UtilidadGrabar,
            };
            _lstPrecio.Add(p1);
            _lstPrecio.Add(p2);
            _lstPrecio.Add(p3);
            var h1 = new OOB.LibInventario.Producto.ActualizarPrecio.ModoAdm.Historia()
            {
                empCont = Vta1.Get_EmpaqueCont,
                empDesc = Vta1.Get_EmpaqueDesc,
                fullDivisa = Vta1.FullDivisaGrabar,
                netoMonLocal = Vta1.NetoGrabar,
                tipoEmpaqueVenta = "1",
                tipoPrecioVenta = "1",
            };
            var h2 = new OOB.LibInventario.Producto.ActualizarPrecio.ModoAdm.Historia()
            {
                empCont = Vta2.Get_EmpaqueCont,
                empDesc = Vta2.Get_EmpaqueDesc,
                fullDivisa = Vta2.FullDivisaGrabar,
                netoMonLocal = Vta2.NetoGrabar,
                tipoEmpaqueVenta = "2",
                tipoPrecioVenta = "1",
            };
            var h3 = new OOB.LibInventario.Producto.ActualizarPrecio.ModoAdm.Historia()
            {
                empCont = Vta3.Get_EmpaqueCont,
                empDesc = Vta3.Get_EmpaqueDesc,
                fullDivisa = Vta3.FullDivisaGrabar,
                netoMonLocal = Vta3.NetoGrabar,
                tipoEmpaqueVenta = "3",
                tipoPrecioVenta = "1",
            };
            _lstHistoria.Add(h1);
            _lstHistoria.Add(h2);
            _lstHistoria.Add(h3);
            var ficha = new OOB.LibInventario.Producto.ActualizarPrecio.ModoAdm.Ficha()
            {
                autoPrd = _idProducto,
                factorCambio = GetInfTasaCambioPrd,
                nota = "",
                prdCodigo = _dataPrd.prdCodigo,
                prdDesc = _dataPrd.prdDescripcion,
                usuCodigo = Sistema.UsuarioP.codigoUsu,
                usuNombre = Sistema.UsuarioP.nombreUsu,
                estacion = Environment.MachineName,
                precios = _lstPrecio,
                historia = _lstHistoria,
            };
            try
            {
                var r01 = Sistema.MyData.Producto_ModoAdm_ActualizarPrecio(ficha);
                _isProcesarIsOk = true;
                Helpers.Msg.EditarOk();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
    }
}