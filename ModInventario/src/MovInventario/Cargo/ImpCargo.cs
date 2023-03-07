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
        public override void ProcesarFicha()
        {
            _procesarIsOk = false;
        }


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
                //_filtros.activarBusquedaParaMovTraslado = _activarBusquedaParaTraslado;
                //_filtros.autoDepDestino = _idDepDestino;
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
            return false;
        }
        protected override void RegistrarDocumento()
        {
        }
    }
}