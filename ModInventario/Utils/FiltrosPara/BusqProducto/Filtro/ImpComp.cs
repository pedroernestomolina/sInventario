using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.FiltrosPara.BusqProducto.Filtro
{
    public class ImpComp : ICompFiltro
    {
        private bool _dataYaSeCargo;
        protected Filtros.IDepartamentoGrupo _departGrupo;
        protected Utils.Filtros.IFiltro _grupo;
        protected Utils.Filtros.IFiltro _marca;
        protected Utils.Filtros.IFiltro _origen;
        protected Utils.Filtros.IFiltro _tasaIva;
        protected Utils.Filtros.IFiltro _estatus;
        protected Utils.Filtros.IFiltro _estatusDivisa;
        protected Utils.Filtros.IFiltro _estatusPesado;
        protected Utils.Filtros.IFiltro _deposito;
        protected Utils.Filtros.IFiltro _catalogo;
        protected Utils.Filtros.IFiltro _categoria;
        protected Utils.Filtros.IFiltro _existencia;
        protected Utils.Filtros.IFiltro _tcs;
        protected Utils.Filtros.IFiltro _estatusOferta;
        protected Filtros.BuscarPor.IFiltro _proveedor;


        public Filtros.IDepartamentoGrupo DepartamentoGrupo { get { return _departGrupo; } }
        public Utils.Filtros.IFiltro Marca { get { return _marca; } }
        public Utils.Filtros.IFiltro Origen { get { return _origen; } }
        public Utils.Filtros.IFiltro TasaIva { get { return _tasaIva; } }
        public Utils.Filtros.IFiltro Estatus { get { return _estatus; } }
        public Utils.Filtros.IFiltro Divisa { get { return _estatusDivisa; } }
        public Utils.Filtros.IFiltro Pesado { get { return _estatusPesado; } }
        public Utils.Filtros.IFiltro Deposito { get { return _deposito; } }
        public Utils.Filtros.IFiltro Catalogo { get { return _catalogo; } }
        public Utils.Filtros.IFiltro Categoria { get { return _categoria; } }
        public Utils.Filtros.IFiltro Existencia { get { return _existencia; } }
        public Utils.Filtros.IFiltro TCS { get { return _tcs; } }
        public Utils.Filtros.IFiltro Oferta { get { return _estatusOferta; } }
        public Filtros.BuscarPor.IFiltro Proveedor { get { return _proveedor; } }


        public ImpComp()
        {
            _dataYaSeCargo = false;
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _departGrupo = new Utils.Filtros.DepartamentoGrupo();
            _marca = new Utils.Filtros.Marca();
            _origen = new Utils.Filtros.Origen();
            _tasaIva = new Utils.Filtros.TasaIva();
            _estatus = new Utils.Filtros.EstatusProducto();
            _estatusDivisa = new Utils.Filtros.EstatusDivisa();
            _estatusPesado = new Utils.Filtros.EstatusPesado();
            _deposito = new Utils.Filtros.Deposito();
            _catalogo = new Utils.Filtros.Catalogo();
            _categoria = new Utils.Filtros.Categoria();
            _existencia = new Utils.Filtros.Existencia();
            _tcs = new Utils.Filtros.EstatusTallaColorSabor();
            _estatusOferta = new Utils.Filtros.EstatusOferta();
            _proveedor = new Utils.Filtros.BuscarPor.PorProveedor.ImpFiltro();
        }


        public void Inicializa()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _departGrupo.Inicializa();
            _marca.Ctrl.Inicializa();
            _origen.Ctrl.Inicializa();
            _tasaIva.Ctrl.Inicializa();
            _estatus.Ctrl.Inicializa();
            _estatusDivisa.Ctrl.Inicializa();
            _estatusPesado.Ctrl.Inicializa();
            _deposito.Ctrl.Inicializa();
            _catalogo.Ctrl.Inicializa();
            _categoria.Ctrl.Inicializa();
            _existencia.Ctrl.Inicializa();
            _tcs.Ctrl.Inicializa();
            _estatusOferta.Ctrl.Inicializa();
            _proveedor.Inicializa();
        }
        Frm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null) 
                {
                    frm = new Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public void LimpiarFiltros()
        {
            _departGrupo.LimpiarOpcion();
            _marca.Ctrl.LimpiarOpcion();
            _origen.Ctrl.LimpiarOpcion();
            _tasaIva.Ctrl.LimpiarOpcion();
            _estatus.Ctrl.LimpiarOpcion();
            _estatusDivisa.Ctrl.LimpiarOpcion();
            _estatusPesado.Ctrl.LimpiarOpcion();
            _deposito.Ctrl.LimpiarOpcion();
            _catalogo.Ctrl.LimpiarOpcion();
            _categoria.Ctrl.LimpiarOpcion();
            _existencia.Ctrl.LimpiarOpcion();
            _tcs.Ctrl.LimpiarOpcion();
            _estatusOferta.Ctrl.LimpiarOpcion();
            _proveedor.Limpiar();
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
            _procesarIsOk = verificar();
        }


        public void setForzarCargarData(bool forzarCargaData)
        {
            if (forzarCargaData)
            {
                _dataYaSeCargo = false;
            }
        }
        public bool CargarData()
        {
            if (_dataYaSeCargo) { return true; }
            _departGrupo.CargarData();
            _marca.CargarData();
            _origen.CargarData();
            _tasaIva.CargarData();
            _estatus.CargarData();
            _estatusDivisa.CargarData();
            _estatusPesado.CargarData();
            _deposito.CargarData();
            _catalogo.CargarData();
            _categoria.CargarData();
            _existencia.CargarData();
            _tcs.CargarData();
            _estatusOferta.CargarData();
            _dataYaSeCargo = true;
            return true;
        }
        private bool verificar()
        {
            return true;
        }
    }
}