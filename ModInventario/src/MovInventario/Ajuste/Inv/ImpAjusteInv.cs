
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Ajuste.Inv
{
    public class ImpAjusteInv : ImpMov, IAjusteInv
    {
        private bool _productoSeleccionadoIsOk;
        private Tools.CapturaMov.ICapturaMov _capturaMov;


        public bool ProductoSeleccionadoIsOk { get { return _productoSeleccionadoIsOk; } }
        public override string GetInf_TipoMovimiento { get { return "AJUSTE INVENTARIO"; } }


        public ImpAjusteInv(ISeguridadAccesoSistema ctrSeguridad)
            : base(ctrSeguridad)
        {
            _productoSeleccionadoIsOk = false;
            _capturaMov = new CapturaMov.ImpCapturaMov();
        }


        public override void Inicializa()
        {
            base.Inicializa();
            _productoSeleccionadoIsOk = false;
            _busqPrd.setHabilitarFiltroDeposito(false);
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
        public override void BuscarProducto()
        {
            _productoSeleccionadoIsOk = false;
            CargarSeleccionarProducto(CargarFiltros());
            _busqPrd.setCadenaBusqueda("");
        }


        private bool _procesarIsOk;
        public override bool ProcesarIsOk { get { return _procesarIsOk; } }


        public void SucOrigenSetId(string id)
        {
            base.setSucOrigen(id);
            if (id != "")
            {
                _depOrigen.CargarDataByIdSucursal(id);
            }
            else
            {
                _depOrigen.Inicializa();
            }
        }


        private OOB.LibInventario.Producto.Filtro CargarFiltros()
        {
            var filtros = _busqPrd.BuscarFiltros();
            if (filtros != null)
            {
                if (DepOrigen.GetId == "")
                {
                    Helpers.Msg.Alerta("DEPOSITO NO DEFINIDO");
                    return null;
                }
                filtros.autoDepOrigen = DepOrigen.GetId;
                return filtros;
            }
            return null;
        }

        public override void CapturarMovimiento(string idPrd)
        {
            try
            {
                var _continuar = true;
                if (_listaMov.VerificaItemRegistradoLista(idPrd)) 
                {
                    var xmsg = "Producto Ya Aparece Registrado En La Lista, " + Environment.NewLine + "Deseas Agregar Uno Nuevo ?";
                    var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msg == DialogResult.No)
                    {
                        _continuar = false;
                    }
                }
                if (_continuar)
                {
                    var filtroOOB = new OOB.LibInventario.Movimiento.Cargo.CapturaMov.Filtro()
                    {
                        idDeposito = _depOrigen.GetId,
                        idProducto = idPrd,
                    };
                    var r01 = Sistema.MyData.Producto_Movimiento_Cargo_CaptureMov(filtroOOB);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        throw new Exception(r01.Mensaje);
                    }
                    var r = r01.Entidad.data;
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
                        costoDivisaUnd = r.costoDivisaUnd,
                        costoUnd = r.costoUnd,
                        decimales = r.decimales,
                        descTasa = r.descTasa,
                        esAdmDivisa = r.esAdmDivisa,
                        exFisica = r.exFisica,
                        nombreEmp = r.nombreEmp,
                        nombrePrd = r.nombrePrd,
                        valorTasa = r.valorTasa,
                        fechaUltimaActCosto = r.fechaUltActualizacionCosto,
                        contEmpInv = r.contEmpInv,
                        nombreEmpInv = r.nombreEmpInv,
                    };
                    _capturaMov.ItemCapturado += _capturaMov_ItemCapturado;
                    _capturaMov.Inicializa();
                    _capturaMov.setData(dat);
                    _capturaMov.setTasaCambio(_tasaCambio);
                    _capturaMov.Inicia();
                    _capturaMov.ItemCapturado -= _capturaMov_ItemCapturado;
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return;
            }
        }
        private int _itemEditar = -1;
        public override void EditarMovimiento(Tools.CapturaMov.IDataCaptura it)
        {
            _itemEditar = it.Id;
            _capturaMov.ItemCapturado += _capturaMov_ItemEditadoCapturado;
            _capturaMov.Inicializa();
            _capturaMov.setDataEditar(it);
            _capturaMov.Inicia();
            _capturaMov.ItemCapturado -= _capturaMov_ItemEditadoCapturado;
        }

        void _capturaMov_ItemCapturado(object sender, EventArgs e)
        {
            _listaMov.AgregarItem(_capturaMov.Captura);
        }
        private void _capturaMov_ItemEditadoCapturado(object sender, EventArgs e)
        {
            _listaMov.EliminarItem(_itemEditar);
            _listaMov.AgregarItem(_capturaMov.Captura);
            _itemEditar = -1;
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

            var movOOB = new OOB.LibInventario.Movimiento.Ajuste.Insertar.FichaMov()
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
                var rg = new OOB.LibInventario.Movimiento.Ajuste.Insertar.FichaMovDetalle()
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
                var rg = new OOB.LibInventario.Movimiento.Ajuste.Insertar.FichaMovDeposito()
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
                var rg = new OOB.LibInventario.Movimiento.Ajuste.Insertar.FichaMovKardex()
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
            var ficha = new OOB.LibInventario.Movimiento.Ajuste.Insertar.Ficha()
            {
                mov = movOOB,
                movDeposito = depOOB,
                movDetalles = detOOB,
                movKardex = KardexOOB,
            };
            this.NotificarDocGenerado += VisualizarDocGenerado;
            var r01 = Sistema.MyData.Producto_Movimiento_Ajuste_Insertar(ficha);
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


        public void ListaPendienteVisualizar()
        {
            _pendiente.ListaVisualizar();
            if (_pendiente.SeleccionItemIsOk)
            {
                AbrirDocumentoPend(_pendiente.IdItemSeleccionado);
                _pendiente.ActualizarContador();
            }
        }
        public bool DejarEnPendienteIsOk { get { return _pendiente.DejarEnPendienteIsOk; } }
        public void DejarEnPendiente()
        {
            if (ValidarDoc())
            {
                var xmsg = "Dejar Documento En Pendiente ?";
                var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    RegistrarPendiente();
                    if (DejarEnPendienteIsOk)
                    {
                        _pendiente.ActualizarContador();
                    }
                }
            }
        }


        private void AbrirDocumentoPend(int idMov)
        {
            try
            {
                if (_listaMov.GetCtnItems > 0)
                {
                    throw new Exception("HAY ITEMS CARGADOS ACTUALMENTE, VERIFIQUE POR FAVOR");
                }

                //CAPTURO MOVIMIENTO
                var r01 = Sistema.MyData.Transito_Movimiento_GetById(idMov);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                var _lst = new List<dataItem>();
                var mov = r01.Entidad.mov;
                setAutorizadoPor(mov.autoriza);
                setMotivo(mov.motivo);
                Concepto.setId(mov.idConcepto);
                SucOrigenSetId(mov.idSucOrigen);
                DepOrigen.setId(mov.idDeOrigen);
                foreach (var r in r01.Entidad.detalles.OrderBy(o => o.nombreProd).ToList())
                {
                    var dat = new data()
                    {
                        autoDepart = r.autoDepart,
                        autoGrupo = r.autoGrupo,
                        autoPrd = r.autoProd,
                        autoTasa = r.autoTasa,
                        catPrd = r.categoriaProd,
                        codigoPrd = r.codigoProd,
                        contEmp = r.contEmpaque,
                        costo = r.costo,
                        costoDivisa = r.costoDivisa,
                        costoDivisaUnd = r.costoDivisaUnd,
                        costoUnd = r.costoUnd,
                        decimales = r.decimales,
                        descTasa = r.descTasa,
                        esAdmDivisa = r.esAdmDivisa == "1" ? true : false,
                        exFisica = r.exFisica,
                        nombreEmp = r.descEmpaque,
                        nombrePrd = r.nombreProd,
                        valorTasa = r.valorTasa,
                        fechaUltimaActCosto = r.fechaUltActCosto,
                        exFisicaDepDestino = r.exFisicaDestino,
                        nivelMinimoDepDestino = r.nivelMinimo,
                        nivelOptimoDepDestino = r.nivelOptimo,
                        contEmpInv = r.contEmpaqueInv,
                        nombreEmpInv = r.descEmpaqueInv,
                    };
                    Tools.CapturaMov.IDataCaptura _dataCapture = _dataCapture = new Tools.CapturaMov.ImpDataCaptura();
                    _dataCapture.CargarEmpaques();
                    _dataCapture.setFicha(dat);
                    _dataCapture.setCantidad(r.cantSolicitada);
                    _dataCapture.setCosto(r.costo);
                    _dataCapture.setEmpaque(r.empaqueIdSolicitado);
                    _dataCapture.setTasaCambio(_tasaCambio);
                    _listaMov.AgregarItem(_dataCapture);
                }
                //ELIMINO MOVIMIENTO
                var r02 = Sistema.MyData.Transito_Movimiento_AnularById(idMov);
                if (r02.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r02.Mensaje);
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return;
            }
        }
        private void RegistrarPendiente()
        {
            var r00 = Sistema.MyData.Sistema_TipoDocumento_GetFichaByTipo(OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.AJUSTE);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            var docTipo = r00.Entidad;
            var concepto = (ficha)_concepto.GetItem;
            var depOrigen = (ficha)_depOrigen.GetItem;
            var sucOrigen = (ficha)_sucOrigen.GetItem;

            var movOOB = new OOB.LibInventario.Transito.Movimiento.Agregar.Mov()
            {
                autoriza = GetEnt_AutorizadoPor,
                cntRenglones = _listaMov.GetCtnItems,
                codigoMov = docTipo.codigo,
                descConcepto = concepto.desc,
                descDepOrigen = depOrigen.desc,
                descMov = docTipo.nombre,
                descSucDestino = "",
                descSucOrigen = sucOrigen.desc,
                descUsuario = Sistema.UsuarioP.nombreUsu,
                estacionEquipo = Environment.MachineName,
                factorCambio = _tasaCambio,
                idConcepto = concepto.id,
                idDeOrigen = depOrigen.id,
                idSucDestino = "",
                idSucOrigen = sucOrigen.id,
                monto = _listaMov.GetImporte_MonedaLocal,
                montoDivisa = _listaMov.GetImporte_MonedaOtra,
                motivo = GetEnt_Motivo,
                tipoMov = "",
            };

            var detallesOOB = new List<OOB.LibInventario.Transito.Movimiento.Agregar.Detalle>();
            var _items = (List<dataItem>)_listaMov.GetItems;
            foreach (var det in _items)
            {
                var idTipoMovFicha = "";
                var rg = new OOB.LibInventario.Transito.Movimiento.Agregar.Detalle()
                {
                    autoDepart = det.FichaPrd.autoDepart,
                    autoGrupo = det.FichaPrd.autoGrupo,
                    autoPrd = det.FichaPrd.autoPrd,
                    autoTasa = det.FichaPrd.autoTasa,
                    catPrd = det.FichaPrd.catPrd,
                    codigoPrd = det.FichaPrd.codigoPrd,
                    costo = det.FichaPrd.costo,
                    costoDivisa = det.FichaPrd.costoDivisa,
                    costoDivisaUnd = det.FichaPrd.costoDivisaUnd,
                    costoUnd = det.FichaPrd.costoUnd,
                    decimales = det.FichaPrd.decimales,
                    descTasa = det.FichaPrd.descTasa,
                    estatusDivisa = det.FichaPrd.esAdmDivisa ? "1" : "0",
                    exFisica = det.FichaPrd.exFisica,
                    fechaUltActCosto = det.FichaPrd.fechaUltimaActCosto,
                    nombrePrd = det.FichaPrd.nombrePrd,
                    valorTasa = det.FichaPrd.valorTasa,
                    nivelMinimo = det.FichaPrd.nivelMinimoDepDestino,
                    nivelOptimo = det.FichaPrd.nivelOptimoDepDestino,
                    exFisicaDestino = det.FichaPrd.exFisicaDepDestino,
                    //
                    cantidadSolicitada = det.Cantidad,
                    costoSolicitada = det.Costo,
                    ajusteIdSolicitada = idTipoMovFicha,
                    empaqueIdSolicitada = det.EmpaqueSelGetId,
                    //
                    contEmp = det.FichaPrd.contEmp,
                    nombreEmp = det.FichaPrd.nombreEmp,
                    contEmpInv = det.FichaPrd.contEmpInv,
                    nombreEmpInv = det.FichaPrd.nombreEmpInv,
                };
                detallesOOB.Add(rg);
            }
            var fichaOOB = new OOB.LibInventario.Transito.Movimiento.Agregar.Ficha()
            {
                mov = movOOB,
                detalles = detallesOOB,
            };
            _pendiente.DejarEnPendiente(fichaOOB);
            limpiarTodo();
        }
    }
}