using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Precio.EditarCambiar.ModoBasico
{
    
    public class Editar: IEditarBasico
    {

        private bool _isProcesarIsOk;
        private bool _isAbandonarIsOk;
        private string _idProducto;
        private FiltrosGen.IOpcion _gEmp1;
        private FiltrosGen.IOpcion _gEmp2;
        private FiltrosGen.IOpcion _gEmp3;
        private dataPrecio _precio1;
        private dataPrecio _precio2;
        private dataPrecio _precio3;
        private dataProducto _dataPrd;


        public Editar() 
        {
            _isAbandonarIsOk = false;
            _isProcesarIsOk = false;
            _idProducto = "";
            _precio1 = new dataPrecio();
            _precio2 = new dataPrecio();
            _precio3 = new dataPrecio();
            _dataPrd = new dataProducto();
            _gEmp1 = new FiltrosGen.Opcion.Gestion();
            _gEmp2 = new FiltrosGen.Opcion.Gestion();
            _gEmp3 = new FiltrosGen.Opcion.Gestion();
        }


        public void Inicializa()
        {
            _idProducto = "";
            _isAbandonarIsOk = false;
            _isProcesarIsOk = false;
            _gEmp1.Inicializa();
            _gEmp2.Inicializa();
            _gEmp3.Inicializa();
            _precio1.Inicializa();
            _precio2.Inicializa();
            _precio3.Inicializa();
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
            var _tasaCambio = 0m;
            var _metodoCalculoDesc = "";
            var _metodoCalculo = dataPrecio.enumMetCalUtilidad.SinDefinir;

            try
            {
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
                var pneto_D1 = prd.pNeto_D1;
                var pneto_D2 = prd.pNeto_D2;
                var pneto_D3 = prd.pNeto_D3;
                var pneto_D4 = prd.pNeto_D4;
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
                    pneto_D1 = CalculaNeto(prd.pfd_D1, prd.tasaIva);
                    pneto_D2 = CalculaNeto(prd.pfd_D2, prd.tasaIva);
                    pneto_D3 = CalculaNeto(prd.pfd_D3, prd.tasaIva);
                    pneto_D4 = CalculaNeto(prd.pfd_D4, prd.tasaIva);
                }

                _dataPrd.setCodigo(prd.codigo);
                _dataPrd.setDescripcion(prd.descripcion);
                _dataPrd.setAuto(prd.auto);
                _dataPrd.setEmpaqueCompraDesc(prd.empCompraDesc);
                _dataPrd.setContEmpaqueCompraDesc(prd.contEmpCompra);
                _dataPrd.setCostoEmpCompra(costo);
                _dataPrd.setMetodoCalculoUt(_metodoCalculoDesc);
                _dataPrd.setTasaCambioPrd(_tasaCambio);
                _dataPrd.setTasaIvaPrd(prd.tasaIva);
                _dataPrd.setFechaUltActPrd(new DateTime(2022, 05, 03).ToShortDateString());
                _dataPrd.setEsAdmDivisa(prd.EsAdmDivisa);

                var lst = new List<ficha>();
                var r02 = Sistema.MyData.EmpaqueMedida_GetLista();
                foreach (var rg in r02.Lista.OrderBy(o => o.nombre).ToList())
                {
                    lst.Add(new ficha(rg.auto, "", rg.nombre));
                }
                _gEmp1.setData(lst);
                _gEmp2.setData(lst);
                _gEmp3.setData(lst);

                _precio1.setContenido(prd.cont_1);
                _precio1.setUtilidadActual(prd.utilidad_1);
                _precio1.setCostoEmpCompra(costo);
                _precio1.setContEmpCompra(prd.contEmpCompra);
                _precio1.setAdmDivisa(prd.EsAdmDivisa);
                _precio1.setTasaCambio(_tasaCambio);
                _precio1.setTasaIva(prd.tasaIva);
                _precio1.setMetodoCalculoUtilidad(_metodoCalculo);
                _precio1.setNeto(pneto_1);
                _gEmp1.setFicha(prd.autoEmp_1);

                _precio2.setContenido(prd.cont_M1);
                _precio2.setUtilidadActual(prd.utilidad_M1);
                _precio2.setCostoEmpCompra(costo);
                _precio2.setContEmpCompra(prd.contEmpCompra);
                _precio2.setAdmDivisa(prd.EsAdmDivisa);
                _precio2.setTasaCambio(_tasaCambio);
                _precio2.setTasaIva(prd.tasaIva);
                _precio2.setMetodoCalculoUtilidad(_metodoCalculo);
                _precio2.setNeto(pneto_M1);
                _gEmp2.setFicha(prd.autoEmp_M1);

                _precio3.setContenido(prd.cont_D1);
                _precio3.setUtilidadActual(prd.utilidad_D1);
                _precio3.setCostoEmpCompra(costo);
                _precio3.setContEmpCompra(prd.contEmpCompra);
                _precio3.setAdmDivisa(prd.EsAdmDivisa);
                _precio3.setTasaCambio(_tasaCambio);
                _precio3.setTasaIva(prd.tasaIva);
                _precio3.setMetodoCalculoUtilidad(_metodoCalculo);
                _precio3.setNeto(pneto_D1);
                _gEmp3.setFicha(prd.autoEmp_D1);

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
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
            return true;
        }


        public BindingSource GetEmp1_Source { get { return _gEmp1.Source; } }
        public BindingSource GetEmp2_Source { get { return _gEmp2.Source; } }
        public BindingSource GetEmp3_Source { get { return _gEmp3.Source; } }
        //


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


        public string GetEmp1_Id { get { return _gEmp1.GetId; } }
        public string GetEmp2_Id { get { return _gEmp2.GetId; } }
        public string GetEmp3_Id { get { return _gEmp3.GetId; } }


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
                contenido = _precio1.Contenido,
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
                empaque = _gEmp1.Item.desc,
                contenido = _precio1.Contenido,
                factorCambio = _precio1.TasaCambio,
            };
            var p2 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = _gEmp2.GetId,
                contenido = _precio2.Contenido,
                precio_divisa_Neto = _precio2.Full_Divisa,
                precioNeto = _precio2.Neto_MonedaLocal,
                utilidad = _precio2.Utilidad,
            };
            ficha.may_1 = p2;
            var h2 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            {
                nota = "",
                precio = _precio2.Neto_MonedaLocal,
                precio_id = "MY1",
                empaque = _gEmp2.Item.desc,
                contenido = _precio2.Contenido,
                factorCambio = _precio1.TasaCambio,
            };
            var p3 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = _gEmp3.GetId,
                contenido = _precio3.Contenido,
                precio_divisa_Neto = _precio3.Full_Divisa,
                precioNeto = _precio3.Neto_MonedaLocal,
                utilidad = _precio3.Utilidad ,
            };
            ficha.dsp_1 = p3;
            var h3 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            {
                nota = "",
                precio = _precio3.Neto_MonedaLocal,
                precio_id = "DS1",
                empaque = _gEmp3.Item.desc,
                contenido = _precio3.Contenido,
                factorCambio = _precio1.TasaCambio,
            };
            var historia = new List<OOB.LibInventario.Precio.Editar.FichaHistorica>();
            historia.Add(h1);
            historia.Add(h2);
            historia.Add(h3);

            ficha.historia = historia;
            var r01 = Sistema.MyData.PrecioProducto_Actualizar(ficha);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return ;
            }
            _isProcesarIsOk = true;
            Helpers.Msg.EditarOk();
        }


        private decimal CalculaNeto(decimal monto, decimal tasa)
        {
            var rt = 0m;
            rt = monto / ((tasa / 100) + 1);
            return rt;
        }


        public bool EditarPrecioIsOk { get { return _isProcesarIsOk; } }
        public bool AbandonarIsOk { get { return _isAbandonarIsOk; } }
        public bool ProcesarIsOk { get { return _isProcesarIsOk; } }
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

    }

}