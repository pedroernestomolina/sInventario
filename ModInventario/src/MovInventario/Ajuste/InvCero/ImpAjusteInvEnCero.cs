using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Ajuste.InvCero
{
    public class ImpAjusteInvEnCero: ImpMov, IAjusteInvEnCero
    {
        private bool _productoSeleccionadoIsOk;
        private Tools.CapturaMov.ICapturaMov _capturaMov;
        private SeguridadSist.ISeguridad _gSecurity;


        public bool ProductoSeleccionadoIsOk { get { return _productoSeleccionadoIsOk; } }
        public override string GetInf_TipoMovimiento { get { return "AJUSTE INVENTARIO A CERO"; } }


        public ImpAjusteInvEnCero(ISeguridadAccesoSistema ctrSeguridad)
            : base(ctrSeguridad)
        {
            _productoSeleccionadoIsOk = false;
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


        private bool _capturarDataIsOk;
        public bool CapturarDataAjusteInvCeroIsOk { get { return _capturarDataIsOk; } }
        public void CapturarDataAjusteInvCero()
        {
            _capturarDataIsOk = false;
            if (_sucOrigen.GetItem == null) 
            {
                Helpers.Msg.Alerta("CAMPO [ SUCURSAL ] NO SELECCIONADA");
                return;
            }
            if (_depOrigen.GetItem == null)
            {
                Helpers.Msg.Alerta("CAMPO [ DEPOSITO ] NO SELECCIONADO");
                return;
            }
            if (_listaMov.GetCtnItems>0)
            {
                Helpers.Msg.Alerta("EXISTEN ITEMS YA CARGADOS EN LA FICHA, VERIFIQUE POR FAVOR");
                return;
            }

            CapturarInv();
        }


        protected override bool ValidarDoc()
        {
            return base.ValidarDoc();
        }
        protected override void RegistrarDocumento()
        {
            _procesarIsOk = false;
            if (VerificarUsuario()) 
            {
                Registrar();
            }
        }


        private bool VerificarUsuario()
        {
            _segModo.Inicializa();
            _segModo.Inicia();
            return _segModo.IsOk;
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
                Select(g2 => new { id = g2.Key.autoPrd, desc = g2.Key.nombrePrd, cnt = g2.Sum(s => s.CntUnd * s.Signo) }).
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


        public override void CapturarMovimiento(string idPrd)
        {
        }
        public override void EditarMovimiento(Tools.CapturaMov.IDataCaptura it)
        {
        }
        public override void BuscarProducto()
        {
        }


        private void CapturarInv()
        {
            try
            {
                var filtroOOB = new OOB.LibInventario.Movimiento.AjusteInvCero.Capture.Filtro()
                {
                    idDeposito = _depOrigen.GetId,
                };
                var r01 = Sistema.MyData.Producto_Movimiento_AjusteInventarioCero_Capture(filtroOOB);
                foreach (var r in r01.Entidad.data.OrderBy(o => o.nombrePrd).ToList())
                {
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
                        fechaUltimaActCosto = "",
                        exFisicaDepDestino = 0m,
                        nivelMinimoDepDestino = 0m,
                        nivelOptimoDepDestino = 0m,
                        contEmpInv = 0,
                        nombreEmpInv = "",
                    };
                    var _cnt = Math.Abs(r.exFisica);
                    var _empSel = "2";//UNIDAD
                    var _tipMovAj = "1";//TIPO DE AJUSTE {CARGO, DESCARGO}
                    if (r.exFisica > 0)
                    {
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
                _capturarDataIsOk = true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }

        private SeguridadSist.ISeguridad _segModo;
        public void SeguridadPorUsuario(SeguridadSist.ISeguridad segModo)
        {
            _segModo = segModo;
        }
    }
}