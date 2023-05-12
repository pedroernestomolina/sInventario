using ModInventario.FiltrosGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario
{
    abstract public class ImpMov: BaseMov, IMov
    {
        public event EventHandler<string> NotificarDocGenerado;


        private string _motivo;
        private string _autorizadoPor;
        private DateTime _fechaServidor;
        private bool _limpiezaGeneralIsOk;
        private ModInventario.MaestrosInv.Concepto.IAgregarEditar _nuevoConcepto;


        protected decimal _tasaCambio;
        //protected src.Tools.BusqProducto.IBusqProducto _busqPrd;
        protected Tools.Sucursal.ISucursal _sucOrigen;
        protected Tools.Deposito.IDeposito _depOrigen;
        protected Tools.Concepto.IConcepto _concepto;
        protected Tools.ListaMov.IListaMov _listaMov;
        protected src.Tools.ListaSelProducto.IListaSelProducto _listaSelPrd;
        protected ISeguridadAccesoSistema _seguridad;
        protected src.MovInventario.Pendiente.IPendiente _pendiente;


        abstract public string GetInf_TipoMovimiento { get; }
        public string GetEnt_Motivo { get { return _motivo; } }
        public string GetEnt_AutorizadoPor { get { return _autorizadoPor; } }
        public DateTime GetFechaSistema { get { return _fechaServidor; } }
        //
        public Tools.Sucursal.ISucursal SucOrigen { get { return _sucOrigen; } }
        public Tools.Deposito.IDeposito DepOrigen { get { return _depOrigen; } }
        public Tools.Concepto.IConcepto Concepto { get { return _concepto; } }
        public Tools.ListaMov.IListaMov ListaItems { get { return _listaMov; } }
        //public src.Tools.BusqProducto.IBusqProducto MetBusProducto { get { return _busqPrd; } }
        public Pendiente.IPendiente Pendiente { get { return _pendiente; } }
        //
        public object ItemActual { get { return _listaMov.ItemActual; } }


        public ImpMov(ISeguridadAccesoSistema ctrSeguridad)
            :base()
        {
            _motivo = "";
            _autorizadoPor = "";
            _tasaCambio = 0m;
            _fechaServidor = DateTime.Now.Date;
            _limpiezaGeneralIsOk=false;
            _concepto = new Tools.Concepto.ImpConcepto();
            _sucOrigen = new Tools.Sucursal.ImpSucursal();
            _depOrigen = new Tools.Deposito.ImpDeposito();
            //_busqPrd = new src.Tools.BusqProducto.ImpBusqProducto();
            _listaMov = new Tools.ListaMov.ImpListaMov();
            _listaSelPrd = new src.Tools.ListaSelProducto.ImpListaSelProducto();
            _nuevoConcepto = new ModInventario.MaestrosInv.Concepto.Agregar.Gestion();
            _pendiente = new src.MovInventario.Pendiente.ImpPend();
            _seguridad = ctrSeguridad;
        }


        public override void Inicializa()
        {
            _motivo = "";
            _autorizadoPor = "";
            _tasaCambio = 0m;
            _fechaServidor = DateTime.Now.Date;
            _limpiezaGeneralIsOk = false;
            _concepto.Inicializa();
            _depOrigen.Inicializa();
            _sucOrigen.Inicializa();
            _listaMov.Inicializa();
            //_busqPrd.Inicializa();
            _pendiente.Inicializa();
        }


        public void setAutorizadoPor(string aut)
        {
            _autorizadoPor = aut;
        }
        public void setMotivo(string mot)
        {
            _motivo = mot;
        }
        public virtual void setSucOrigen(string id)
        {
            _sucOrigen.setId(id);
        }


        protected virtual bool CargarData()
        {
            try
            {
                var r01 = Sistema.MyData.FechaServidor();
                var r02 = Sistema.MyData.Configuracion_TasaCambioActual();
                if (r02.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    throw new Exception(r02.Mensaje);
                }
                _tasaCambio = r02.Entidad;
                _fechaServidor = r01.Entidad;
                _sucOrigen.CargarData();
                //_busqPrd.CargarData();
                _concepto.CargarData();
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        protected bool VerificarEstatusProducto(string idPrd)
        {
            try
            {
                var r01 = Sistema.MyData.Producto_Estatus_GetFicha(idPrd);
                if (r01.Entidad.estatus != OOB.LibInventario.Producto.Enumerados.EnumEstatus.Activo)
                {
                    throw new Exception("ESTATUS DEL PRODUCTO INCORRECTO, VERIFIQUE POR FAVOR");
                }
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        protected void CargarSeleccionarProducto(OOB.LibInventario.Producto.Filtro filtros)
        {
            if (filtros != null)
            {
                try
                {
                    var r01 = Sistema.MyData.Producto_GetLista(filtros);
                    var lst = new List<fichaSeleccion>();
                    foreach (var rg in r01.Lista.OrderBy(o => o.DescripcionPrd).ToList())
                    {
                        lst.Add(new fichaSeleccion(rg.AutoId, rg.CodigoPrd, rg.DescripcionPrd, rg.IsInactivo));
                    }
                    _listaSelPrd.Notificar += _listaSelPrd_Notificar;
                    _listaSelPrd.Inicializa();
                    _listaSelPrd.setLista(lst);
                    _listaSelPrd.setCerrarVentanaAlSeleccionar(false);
                    _listaSelPrd.Inicia();
                    _listaSelPrd.Notificar -= _listaSelPrd_Notificar;
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                    return;
                }
            }
        }
        void _listaSelPrd_Notificar(object sender, EventArgs e)
        {
            if (_listaSelPrd.ItemSeleccionadoIsOk)
            {
                if (VerificarEstatusProducto(_listaSelPrd.GetItemSeleccionado.id))
                {
                    CapturarMovimiento(_listaSelPrd.GetItemSeleccionado.id);
                }
            }
        }
        public abstract void CapturarMovimiento(string idPrd);


        public void AgregarConcepto()
        {
            _nuevoConcepto.Inicializa();
            _nuevoConcepto.Inicia();
            _concepto.CargarData();
        }
        public bool LImpiezaGenerarIsOk { get { return _limpiezaGeneralIsOk; } }
        public void LimpiezaGeneral()
        {
            _limpiezaGeneralIsOk = false;
            var xmsg = "Desechar Cambios Al Documento Actual ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _limpiezaGeneralIsOk = true;
                limpiarTodo();
            }
        }
        public void EditarItem()
        {
            if (ItemActual != null)
            {
                var it = (Tools.CapturaMov.IDataCaptura)ItemActual;
                EditarMovimiento(it);
            }
        }
        public abstract void EditarMovimiento(Tools.CapturaMov.IDataCaptura it);

        public void EliminarItem()
        {
            if (ItemActual != null)
            {
                var it = (Tools.CapturaMov.IDataCaptura)ItemActual;
                var xmsg = "Eliminar Item ?";
                var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    _listaMov.EliminarItem(it.Id);
                }
            }
        }


        public override void ProcesarFicha()
        {
            if (ValidarDoc())
            {
                var xmsg = "Procesar / Generar Movimiento ?";
                var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    RegistrarDocumento();
                }
            }
        }
        protected virtual bool ValidarDoc() 
        {
            if (GetEnt_AutorizadoPor.Trim() == "")
            {
                Helpers.Msg.Alerta("CAMPO [ AUTORIZADO POR ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (GetEnt_Motivo.Trim() == "")
            {
                Helpers.Msg.Alerta("CAMPO [ MOTIVO ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_sucOrigen.GetItem == null)
            {
                Helpers.Msg.Alerta("CAMPO [ SUCURSAL ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_concepto.GetItem == null)
            {
                Helpers.Msg.Alerta("CAMPO [ CONCEPTO ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_depOrigen.GetItem == null)
            {
                Helpers.Msg.Alerta("CAMPO [ DEPOSITO ORIGEN ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_listaMov.GetCtnItems<=0)
            {
                Helpers.Msg.Alerta("NO HAY ITEMS QUE PROCESAR");
                return false;
            }
            return true;
        }
        abstract protected void RegistrarDocumento();

        protected virtual void limpiarTodo()
        {
            _motivo = "";
            _autorizadoPor = "";
            _concepto.Inicializa();
            _depOrigen.Inicializa();
            _sucOrigen.Inicializa();
            _listaMov.Inicializa();
            //_busqPrd.LimpiarCargarMetBusPreferido();
            _depOrigen.LimpiarLista();
        }


        protected void NotificarDocumentoGenerado(string id)
        {
            EventHandler<string> hnd = NotificarDocGenerado;
            if (hnd != null) 
            {
                hnd.Invoke(this, id);
            }
        }
        protected void VisualizarDocGenerado(object sender, string idDoc)
        {
            Helpers.VisualizarDocumento.CargarVisualizarDocumento(idDoc);
        }
    }
}