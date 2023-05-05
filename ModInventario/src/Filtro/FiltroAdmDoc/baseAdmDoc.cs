using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Filtro.FiltroAdmDoc
{
    abstract public class baseAdmDoc: IAdmDoc
    {
        protected Utils.Filtros.IFiltro _depositoOrigen;
        protected Utils.Filtros.IFiltro _depositoDestino;
        protected Utils.Filtros.IFiltro _estatus;
        protected Utils.Filtros.IFiltro _concepto;
        protected Utils.Filtros.IFiltro _tipoDoc;
        protected Utils.Filtros.IFiltro _sucursal;
        protected Utils.Filtros.DesdeHasta.IFiltro _desdeHasta;
        protected Utils.Filtros.BuscarPor.IFiltro _porProducto;


        public LibUtilitis.CtrlCB.ICtrl DepositoOrigen { get { return _depositoOrigen.Ctrl; } }
        public LibUtilitis.CtrlCB.ICtrl DepositoDestino { get { return _depositoDestino.Ctrl; } }
        public LibUtilitis.CtrlCB.ICtrl Estatus { get { return _estatus.Ctrl; } }
        public LibUtilitis.CtrlCB.ICtrl Concepto { get { return _concepto.Ctrl; } }
        public LibUtilitis.CtrlCB.ICtrl TipoDoc { get { return _tipoDoc.Ctrl; } }
        public LibUtilitis.CtrlCB.ICtrl Sucursal { get { return _sucursal.Ctrl; } }
        public Utils.Filtros.DesdeHasta.IFiltro DesdeHasta { get { return _desdeHasta; } }
        public Utils.Filtros.BuscarPor.IFiltro PorProducto { get { return _porProducto; } }
        abstract public IDataExportar DataExportar { get; }


        abstract public void Inicia();


        virtual public void Inicializa()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _depositoOrigen.Ctrl.Inicializa();
            _depositoDestino.Ctrl.Inicializa();
            _estatus.Ctrl.Inicializa();
            _concepto.Ctrl.Inicializa();
            _tipoDoc.Ctrl.Inicializa();
            _sucursal.Ctrl.Inicializa();
            _desdeHasta.Inicializa();
            _porProducto.Inicializa();
        }


        public virtual bool CargarData() 
        {
            try
            {
                _depositoOrigen.CargarData();
                _depositoDestino.CargarData();
                _estatus.CargarData();
                _concepto.CargarData();
                _tipoDoc.CargarData();
                _sucursal.CargarData();
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }


        private bool _abandonarIsOk;
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = true;
        }

        private bool _procesarIsOk;
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public void ProcesarFicha()
        {
            _procesarIsOk = true;
        }

        public void LimpiarFiltros()
        {
            _desdeHasta.LimpiarOpcion();
            _depositoOrigen.Ctrl.LimpiarOpcion();
            _depositoDestino.Ctrl.LimpiarOpcion();
            _estatus.Ctrl.LimpiarOpcion();
            _concepto.Ctrl.LimpiarOpcion();
            _tipoDoc.Ctrl.LimpiarOpcion();
            _sucursal.Ctrl.LimpiarOpcion();
            _porProducto.Limpiar();
        }
    }
}