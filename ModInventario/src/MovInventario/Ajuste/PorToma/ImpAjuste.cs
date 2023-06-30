
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Ajuste.PorToma
{
    public class ImpAjuste : ImpMov, IAjuste
    {
        private bool _procesarIsOk;
        private string _idToma;
        private List<OOB.LibInventario.TomaInv.Resumen.Resultado.Ficha> _resultadoToma;

        
        public override bool ProcesarIsOk { get { return _procesarIsOk; } }
        public override string GetInf_TipoMovimiento { get { return "AJUSTE POR TOMA DE INV"; } }


        public ImpAjuste(ISeguridadAccesoSistema ctrSeguridad)
            : base(ctrSeguridad)
        {
        }


        public override void Inicializa()
        {
            base.Inicializa();
            _idToma = "";
            _resultadoToma = null;
        }
        private MovFrm frm;
        public override void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new MovFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public void SucOrigenSetId(string id)
        {
            base.setSucOrigen(id);
            if (id != "")
            {
                _depOrigen.CargarDataByIdLink(id);
            }
            else
            {
                _depOrigen.Inicializa();
            }
        }
        public void BuscarTomas()
        {
            BuscaryMostrarTomas();
        }


        protected override bool ValidarDoc()
        {
            return base.ValidarDoc();
        }
        protected override void RegistrarDocumento()
        {
            _procesarIsOk = false;
            Registrar();
        }


        private void Registrar()
        {
            var concepto = (ficha)_concepto.GetItem;
            var depOrigen = (ficha)_depOrigen.GetItem;
            var sucOrigen = (ficha)_sucOrigen.GetItem;

            var r00 = Sistema.MyData.Sistema_TipoDocumento_GetFichaByTipo(OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.AJUSTE);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                throw new Exception(r00.Mensaje);
            }
            var _docTipo = r00.Entidad;
            var _mDivisa = _listaMov.GetImporte_MonedaOtra;

            var movOOB = new OOB.LibInventario.Movimiento.AjustePorToma.Insertar.FichaMov()
            {
                autoConcepto = concepto.id,
                autoDepositoDestino = depOrigen.id,
                autoDepositoOrigen = depOrigen.id,
                autoRemision = "",
                autorizado = GetEnt_AutorizadoPor,
                autoUsuario = Sistema.UsuarioP.autoUsu,
                cierreFtp = "",
                codConcepto = concepto.codigo,
                codDepositoDestino = depOrigen.codigo,
                codDepositoOrigen = depOrigen.codigo,
                codigoSucursal = sucOrigen.codigo,
                codUsuario = Sistema.UsuarioP.codigoUsu,
                desConcepto = concepto.desc,
                desDepositoDestino = depOrigen.desc,
                desDepositoOrigen = depOrigen.desc,
                documentoNombre = _docTipo.nombre,
                estacion = Environment.MachineName,
                estatusAnulado = "0",
                estatusCierreContable = "0",
                nota = GetEnt_Motivo,
                renglones = _listaMov.GetCtnItems,
                situacion = "Procesado",
                tipo = _docTipo.codigo,
                total = _listaMov.GetImporte_MonedaLocal,
                usuario = Sistema.UsuarioP.nombreUsu,
                factorCambio = _tasaCambio,
                montoDivisa = _mDivisa,
            };
            var _items = (List<dataItem>)_listaMov.GetItems;
            var detOOB = _items.Select(s =>
            {
                var it = s;
                var rg = new OOB.LibInventario.Movimiento.AjustePorToma.Insertar.FichaMovDetalle()
                {
                    autoDepartamento = it.FichaPrd.autoDepart,
                    autoGrupo = it.FichaPrd.autoGrupo,
                    autoProducto = it.FichaPrd.autoPrd,
                    cantidad = it.Cantidad,
                    cantidadBono = 0,
                    cantidadUnd = it.CntUnd,
                    categoria = it.FichaPrd.catPrd,
                    codigoProducto = it.FichaPrd.codigoPrd,
                    costoCompra = it.CostoEmpSelMonedaLocal,
                    costoUnd = it.CostoEmpUndMonedaLocal,
                    decimales = it.FichaPrd.decimales,
                    estatusAnulado = "0",
                    estatusUnidad = it.EmpaqueSel_EsPorUnidad ? "1" : "0",
                    nombreProducto = it.FichaPrd.nombrePrd,
                    signo = it.Signo,
                    tipo = _docTipo.codigo,
                    total = Math.Abs(it.ImporteMonedaLocal),
                    contEmpaque = it.ContEmpaqueSel,
                    empaque = it.DescEmpaqueSel,
                };
                return rg;
            }).ToList();
            var gr3 = _items.GroupBy
                (g => new { g.FichaPrd.autoPrd, g.FichaPrd.nombrePrd }).
                Select(g2 => new { id = g2.Key.autoPrd, desc = g2.Key.nombrePrd, cnt = g2.Sum(s => s.CntUnd*s.Signo) }).
                ToList();
            var depOOB = gr3.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.AjustePorToma.Insertar.FichaMovDeposito()
                {
                    autoDeposito = depOrigen.id,
                    autoProducto = s.id,
                    nombreProducto = s.desc,
                    nombreDeposito = depOrigen.desc,
                    cantidadUnd = s.cnt,
                };
                return rg;
            }).ToList();
            var KardexOOB = _items.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.AjustePorToma.Insertar.FichaMovKardex()
                {
                    autoConcepto = concepto.id,
                    autoDeposito = depOrigen.id,
                    autoProducto = s.FichaPrd.autoPrd,
                    cantidad = s.Cantidad,
                    cantidadBono = 0.0m,
                    cantidadUnd = s.CntUnd,
                    codigoMov = _docTipo.codigo,
                    codigoConcepto = concepto.codigo,
                    codigoDeposito = depOrigen.codigo,
                    codigoSucursal = sucOrigen.codigo,
                    costoUnd = s.CostoEmpUndMonedaLocal,
                    entidad = "",
                    estatusAnulado = "0",
                    modulo = _docTipo.tipo,
                    nombreConcepto = concepto.desc,
                    nombreDeposito = depOrigen.desc,
                    nota = "",
                    precioUnd = 0.0m,
                    siglasMov = _docTipo.siglas,
                    signoMov = s.Signo,
                    total = Math.Abs(s.ImporteMonedaLocal),
                    factorCambio = _tasaCambio,
                };
                return rg;
            }).ToList();

            var _lstToma = new List<OOB.LibInventario.Movimiento.AjustePorToma.Insertar.FichaPrdToma>();
            foreach (var rg in _items)
            {
                var ent= _resultadoToma.First(f => f.autoPrd == rg.FichaPrd.autoPrd);
                if (ent != null) 
                {
                    var nr = new OOB.LibInventario.Movimiento.AjustePorToma.Insertar.FichaPrdToma()
                    {
                        autoDeposito = depOrigen.id,
                        autoProducto = ent.autoPrd,
                        resultadoConteo = ent.conteo,
                    };
                    _lstToma.Add(nr);
                }
            }

            var ficha = new OOB.LibInventario.Movimiento.AjustePorToma.Insertar.Ficha()
            {
                idToma = _idToma,
                prdToma = _lstToma,
                mov = movOOB,
                movDeposito = depOOB,
                movDetalles = detOOB,
                movKardex = KardexOOB,
            };
            this.NotificarDocGenerado += VisualizarDocGenerado;
            try
            {
                var r01 = Sistema.MyData.Producto_Movimiento_AjustePorToma_Insertar(ficha);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    this.NotificarDocGenerado -= VisualizarDocGenerado;
                    _procesarIsOk = false;
                    throw new Exception(r01.Mensaje);
                }
                NotificarDocumentoGenerado(r01.Auto);
                _procesarIsOk = true;
                limpiarTodo();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }

        
        protected override bool CargarData()
        {
            try
            {
                base.CargarData();
                _pendiente.setTipoDocumentoTrabajar(MovInventario.Pendiente.enumerados.enumTipoDocAbrirPend.Ajuste);
                _pendiente.setTipoMovTrasladoAjuste(MovInventario.Pendiente.enumerados.enumTipoMovTraslado.AjusteInventario);
                _pendiente.CargarData();
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        protected override void limpiarTodo()
        {
            base.limpiarTodo();
        }
        private void BuscaryMostrarTomas()
        {
            if (_sucOrigen.GetItem == null) 
            {
                Helpers.Msg.Alerta("CAMPO [ SUCURSAL ] NO PUEDE ESTAR VACIO");
                return;
            }
            if (_depOrigen.GetItem == null)
            {
                Helpers.Msg.Alerta("CAMPO [ DEPOSITO ] NO PUEDE ESTAR VACIO");
                return;
            }
            if (_listaMov.GetCtnItems > 0)
            {
                Helpers.Msg.Alerta("EXISTEN MOVIMIENTOS EN LISTA");
                return;
            }
            try
            {
                var filtroOOB= new OOB.LibInventario.TomaInv.Resumen.PorMovAjuste.Filtro()
                {
                     idDeposito=_depOrigen.GetId, 
                     idSucursal=_sucOrigen.GetId,
                };
                var r01 = Sistema.MyData.TomaInv_GetLista_PorMovAjuste(filtroOOB);
                if (r01.Lista.Count > 0) 
                {
                    _idToma = r01.Lista.First().idToma;
                    var r02 = Sistema.MyData.TomaInv_GetToma_Resultado(_idToma);
                    _resultadoToma = r02.Lista;

                    foreach (var r in r02.Lista.OrderBy(o => o.nombrePrd).ToList())
                    {
                        var _costoDivisaUnd = 0m;
                        var _costoUnd = 0m;
                        if (r.contEmp > 0) 
                        {
                            _costoDivisaUnd = r.costoDivisa / r.contEmp;
                            _costoUnd = r.costo / r.contEmp;
                        }
                        var dat = new data()
                        {
                            autoDepart = r.autoDepart,
                            autoGrupo = r.autoGrupo,
                            autoPrd = r.autoPrd,
                            autoTasa = r.autoTasa,
                            catPrd = r.catPrd,
                            codigoPrd = r.codigoPrd,
                            contEmp = r.contEmp,
                            costo = r.costo,
                            costoDivisa = r.costoDivisa,
                            costoDivisaUnd = _costoDivisaUnd,
                            costoUnd = _costoUnd,
                            decimales = "",
                            descTasa = r.descTasa,
                            esAdmDivisa = r.estatusDivisa=="1",
                            exFisica = 0m,
                            nombreEmp = "",
                            nombrePrd = r.nombrePrd,
                            valorTasa = r.valorTasa,
                            fechaUltimaActCosto = "",
                            exFisicaDepDestino = 0m,
                            nivelMinimoDepDestino = 0m,
                            nivelOptimoDepDestino = 0m,
                            contEmpInv = 0,
                            nombreEmpInv = "",
                        };
                        var _cnt = r.cantidadAjustar;
                        var _empSel = "2";//UNIDAD
                        var _tipMovAj = "1";
                        if (r.signo == 1)
                        {
                            _tipMovAj = "1"; //CARGO
                        } else if (r.signo==-1) {
                            _tipMovAj = "2"; //DESCARGO
                        }

                        Tools.CapturaMov.IDataCaptura _dataCapture = _dataCapture = new Tools.CapturaMov.ImpDataCaptura();
                        _dataCapture.CargarEmpaques();
                        _dataCapture.CargarTipoMovAjuste();
                        _dataCapture.setFicha(dat);
                        _dataCapture.setCantidad(_cnt);
                        _dataCapture.setCosto(r.costo);
                        _dataCapture.setEmpaque(_empSel);
                        _dataCapture.setTipoMov(_tipMovAj);
                        _dataCapture.setTasaCambio(_tasaCambio);
                        _listaMov.AgregarItem(_dataCapture);
                    }
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }

        public void EliminarCargosMayoresCero()
        {
            if (_listaMov.GetItems.Count > 0) 
            {
                var xmsg = @"Esta Opción Eliminara Todos Aquellos Items Donde Exista Un Cargo Mayor A Cero (0). 
                            Estas De acuerdo En Realizar Dicho Movimiento ?";
                var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    foreach (var rg in _listaMov.GetListaItems)
                    {
                        var item = (Tools.CapturaMov.IDataCaptura)rg;
                        if (item.Cantidad > 0 && item.Signo == 1) 
                        {
                            _listaMov.EliminarItem(item.Id);
                        }
                    }
                }
            }
        }
        public void EliminarDesCargosMayoresCero()
        {
            if (_listaMov.GetItems.Count > 0)
            {
                var xmsg = @"Esta Opción Eliminara Todos Aquellos Items Donde Exista Un Descargo Mayor A Cero (0). 
                            Estas De acuerdo En Realizar Dicho Movimiento ?";
                var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    foreach (var rg in _listaMov.GetListaItems)
                    {
                        var item = (Tools.CapturaMov.IDataCaptura)rg;
                        if (item.Cantidad > 0 && item.Signo ==-1)
                        {
                            _listaMov.EliminarItem(item.Id);
                        }
                    }
                }
            }
        }


        // NO SE IMPLEMENTAN / USAN
        public override void CapturarMovimiento(string idPrd)
        {
        }
        public override void EditarMovimiento(Tools.CapturaMov.IDataCaptura it)
        {
        }
        public override void BuscarProducto()
        {
        }
    }
}