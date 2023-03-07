using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Tools.FiltrosPara.Productos
{
    public abstract class basePrd: IProducto
    {
        private bool _limpiarIsOk;
        protected Filtros.Departamento.IDepartamento _depart;
        protected Filtros.Marca.IMarca _marca;
        protected Filtros.Origen.IOrigen _origen;
        protected Filtros.TasaIva.ITasaIva _tasaIva;
        protected Filtros.Estatus.IEstatus _estatus;
        protected Filtros.Divisa.IDivisa _divisa;
        protected Filtros.Pesado.IPesado _pesado;
        protected Filtros.Deposito.IDeposito _deposito;
        protected Filtros.Catalogo.ICatalogo _catalogo;
        protected Filtros.Categoria.ICategoria _categoria;
        protected Filtros.Existencia.IExistencia _existencia;
        protected Filtros.TCS.ITCS _tcs;
        protected Filtros.Proveedor.IProveedor _proveedor;


        public bool LimpiarFiltrosIsOk { get { return _limpiarIsOk; } }
        public filtrosExportar FiltrosExportar { get { return filtrosExportar(); } }
        public Filtros.Departamento.IDepartamento Departamento { get { return _depart; } }
        public Filtros.Grupo.IGrupo Grupo { get { return _depart.Grupo; } }
        public Filtros.Marca.IMarca Marca { get { return _marca; } }
        public Filtros.Origen.IOrigen Origen { get { return _origen; } }
        public Filtros.TasaIva.ITasaIva TasaIva { get { return _tasaIva; } }
        public Filtros.Estatus.IEstatus Estatus { get { return _estatus; } }
        public Filtros.Divisa.IDivisa Divisa { get { return _divisa; } }
        public Filtros.Pesado.IPesado Pesado { get { return _pesado; } }
        public Filtros.Deposito.IDeposito Deposito { get { return _deposito; } }
        public Filtros.Catalogo.ICatalogo Catalogo { get { return _catalogo; } }
        public Filtros.Categoria.ICategoria Categoria { get { return _categoria; } }
        public Filtros.Existencia.IExistencia Existencia { get { return _existencia; } }
        public Filtros.TCS.ITCS TCS { get { return _tcs; } }
        public Filtros.Proveedor.IProveedor Proveedor { get { return _proveedor; } }


        public virtual void Inicializa()
        {
            _limpiarIsOk = false;
            _depart.Inicializa();
            _marca.Inicializa();
            _origen.Inicializa();
            _tasaIva.Inicializa();
            _estatus.Inicializa();
            _divisa.Inicializa();
            _pesado.Inicializa();
            _deposito.Inicializa();
            _catalogo.Inicializa();
            _categoria.Inicializa();
            _existencia.Inicializa();
            _tcs.Inicializa();
            _proveedor.Inicializa();
        }
        abstract public void Inicia();
        public void LimpiarFiltros()
        {
            limpiar();
        }


        private bool _abandonarIsOk;
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = true;
        }


        protected virtual bool CargarData()
        {
            try
            {
                _depart.CargarData();
                _marca.CargarData();
                _origen.CargarData();
                _tasaIva.CargarData();
                _estatus.CargarData();
                _divisa.CargarData();
                _pesado.CargarData();
                _deposito.CargarData();
                _categoria.CargarData();
                _catalogo.CargarData();
                _existencia.CargarData();
                _tcs.CargarData();
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }


        private void limpiar()
        {
            _limpiarIsOk = true;
            _depart.Inicializa();
            _marca.Inicializa();
            _origen.Inicializa();
            _tasaIva.Inicializa();
            _estatus.Inicializa();
            _divisa.Inicializa();
            _pesado.Inicializa();
            _deposito.Inicializa();
            _catalogo.Inicializa();
            _categoria.Inicializa();
            _existencia.Inicializa();
            _tcs.Inicializa();
            _proveedor.Inicializa();
        }
        private filtrosExportar filtrosExportar()
        {
            return new filtrosExportar()
            {
                AdmDivisa = _divisa.GetItem,
                Catalogo = _catalogo.GetItem,
                Categoria = _categoria.GetItem,
                Departamento = _depart.GetItem,
                Deposito = _deposito.GetItem,
                Estatus = _estatus.GetItem,
                Existencia = _existencia.GetItem,
                Grupo = _depart.Grupo.GetItem,
                Marca = _marca.GetItem,
                Oferta = null,
                Origen = _origen.GetItem,
                Pesado = _pesado.GetItem,
                TasaIva = _tasaIva.GetItem,
                TCS = _tcs.GetItem,
                Proveedor= _proveedor.GetItem,
            };
        }
    }
}