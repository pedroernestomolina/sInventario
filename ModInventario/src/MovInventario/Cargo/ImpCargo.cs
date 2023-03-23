using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Cargo
{
    public class ImpCargo : ImpMov, ICargo
    {
        private bool _productoSeleccionadoIsOk;
        private Tools.CapturaMov.ICapturaMov _capturaMov;


        public bool ProductoSeleccionadoIsOk { get { return _productoSeleccionadoIsOk; } }
        public override string GetInf_TipoMovimiento { get { return "CARGO"; } }


        public ImpCargo(ISeguridadAccesoSistema ctrSeguridad)
            : base(ctrSeguridad)
        {
            _productoSeleccionadoIsOk = false;
            _capturaMov = new CapturaMov.ImpCapturaMovCargo();
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

            var r00 = Sistema.MyData.Sistema_TipoDocumento_GetFichaByTipo(OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.CARGO);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                throw new Exception(r00.Mensaje);
            }
            var _docTipo = r00.Entidad;
            var _mDivisa = _listaMov.GetImporte_MonedaOtra;
            var movOOB = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaMov()
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
                var rg = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaMovDetalle()
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
                    signo = _docTipo.signo,
                    tipo = _docTipo.codigo,
                    total = it.ImporteMonedaLocal,
                    contEmpaque = it.ContEmpaqueSel,
                    empaque = it.DescEmpaqueSel,
                };
                return rg;
            }).ToList();
            var gr3 = _items.GroupBy
                (g => new { g.FichaPrd.autoPrd, g.FichaPrd.nombrePrd }).
                Select(g2 => new { id = g2.Key.autoPrd, desc = g2.Key.nombrePrd, cnt = g2.Sum(s => s.CntUnd) }).
                ToList();
            var depOOB = gr3.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaMovDeposito()
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
                var rg = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaMovKardex()
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
                    signoMov = _docTipo.signo,
                    total = s.ImporteMonedaLocal,
                    factorCambio = _tasaCambio,
                };
                return rg;
            }).ToList();
            var ficha = new OOB.LibInventario.Movimiento.Cargo.Insertar.Ficha()
            {
                mov = movOOB,
                movDeposito = depOOB,
                movDetalles = detOOB,
                movKardex = KardexOOB,
            };
            this.NotificarDocGenerado += VisualizarDocGenerado;
            var r01 = Sistema.MyData.Producto_Movimiento_Cargo_Insertar (ficha);
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
    }
}