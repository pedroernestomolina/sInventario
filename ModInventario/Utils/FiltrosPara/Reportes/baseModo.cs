using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Utils.FiltrosPara.Reportes
{
    abstract public class baseModo : IFiltroRep
    {
        protected ICtrlHabilitar _deposito;
        protected ICtrlHabilitar _marca;
        protected ICtrlHabilitar _estatusDivisa;
        protected ICtrlHabilitar _sucursal;
        protected ICtrlHabilitar _estatusDoc;
        protected ICtrlHabilitar _tasaIva;
        protected ICtrlHabilitar _categoria;
        protected ICtrlHabilitar _origen;
        protected ICtrlHabilitar _oferta;
        protected ICtrlHabilitar _concepto;
        protected ICtrlHabilitar _estatusPesado;
        protected ICtrlHabilitar _empaque;
        protected ICtrlHabilitar _precio;
        protected IDepartamentoGrupo _departGrupo;
        protected ICtrlHabilitarBusqPor _producto;
        protected ICtrlHabilitarFecha _desde;
        protected ICtrlHabilitarFecha _hasta;


        public ICtrlHabilitar Deposito { get { return _deposito; } }
        public ICtrlHabilitar Marca { get { return _marca; } }
        public ICtrlHabilitar Sucursal { get { return _sucursal; } }
        public ICtrlHabilitar EstatusDivisa { get { return _estatusDivisa; } }
        public ICtrlHabilitar EstatusDocumento { get { return _estatusDoc; } }
        public ICtrlHabilitar TasaIva { get { return _tasaIva; } }
        public ICtrlHabilitar Categoria { get { return _categoria; } }
        public ICtrlHabilitar Origen { get { return _origen; } }
        public ICtrlHabilitar Oferta { get { return _oferta; } }
        public ICtrlHabilitar Concepto { get { return _concepto; } }
        public ICtrlHabilitar EstatusPesado { get { return _estatusPesado; } }
        public ICtrlHabilitar Precio { get { return _precio; } }
        public ICtrlHabilitar Empaque { get { return _empaque; } }
        public IDepartamentoGrupo DepartGrupo { get { return _departGrupo; } }
        public ICtrlHabilitarBusqPor Producto { get { return _producto; } }
        public ICtrlHabilitarFecha Desde { get { return _desde; } }
        public ICtrlHabilitarFecha Hasta { get { return _hasta; } }
        public ModInventario.src.Reporte.IData DataExportar { get { return exportarData(); } }


        virtual public void Inicializa()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _deposito.Ctrl.Inicializa();
            _marca.Ctrl.Inicializa();
            _estatusDivisa.Ctrl.Inicializa();
            _sucursal.Ctrl.Inicializa();
            _estatusDoc.Ctrl.Inicializa();
            _tasaIva.Ctrl.Inicializa();
            _categoria.Ctrl.Inicializa();
            _origen.Ctrl.Inicializa();
            _oferta.Ctrl.Inicializa();
            _concepto.Ctrl.Inicializa();
            _estatusPesado.Ctrl.Inicializa();
            _precio.Ctrl.Inicializa();
            _empaque.Ctrl.Inicializa();
            _departGrupo.Inicializa();
            _producto.Inicializa();
            _desde.Inicializa();
            _hasta.Inicializa();
        }
        abstract public void Inicia();


        public void setFiltrosHab(ModInventario.Reportes.Filtros.IFiltros filtHab)
        {
            _deposito.setHabilitar(filtHab.ActivarDeposito);
            _marca.setHabilitar(filtHab.ActivarMarca);
            _estatusDivisa.setHabilitar(filtHab.ActivarAdmDivisa);
            _sucursal.setHabilitar(filtHab.ActivarSucursal);
            _estatusDoc.setHabilitar(filtHab.ActivarEstatus);
            _tasaIva.setHabilitar(filtHab.ActivarTasaIva);
            _categoria.setHabilitar(filtHab.ActivarCategoria);
            _origen.setHabilitar(filtHab.ActivarOrigen);
            _oferta.setHabilitar(filtHab.ActivarOferta);
            _concepto.setHabilitar(filtHab.ActivarConcepto);
            _estatusPesado.setHabilitar(filtHab.ActivarPesado);
            _precio.setHabilitar(filtHab.ActivarPrecio);
            _empaque.setHabilitar(filtHab.ActivarEmpaquePrecio);
            _departGrupo.Departamento.setHabilitar(filtHab.ActivarDepartamento);
            _producto.setHabilitar(filtHab.ActivarProducto);
            _desde.setHabilitar(filtHab.ActivarDesde);
            _hasta.setHabilitar(filtHab.ActivarHasta);
            //
            _deposito.setIsRequerido(filtHab.IsRequeridoDeposito);
            _marca.setIsRequerido(filtHab.IsRequeridoMarca);
            _estatusDivisa.setIsRequerido(filtHab.IsRequeridoAdmDivisa);
            _sucursal.setIsRequerido(filtHab.IsRequeridoSucursal);
            _estatusDoc.setIsRequerido(filtHab.IsRequeridoEstatus);
            _tasaIva.setIsRequerido(filtHab.IsRequeridoTasaIva);
            _categoria.setIsRequerido(filtHab.IsRequeridoCategoria);
            _origen.setIsRequerido(filtHab.IsRequeridoOrigen);
            _oferta.setIsRequerido(filtHab.IsRequeridoOferta);
            _concepto.setIsRequerido(filtHab.IsRequeridoConcepto);
            _estatusPesado.setIsRequerido(filtHab.IsRequeridoPesado);
            _precio.setIsRequerido(filtHab.IsRequeridoPrecio);
            _empaque.setIsRequerido(filtHab.IsRequeridoEmpaquePrecio);
            _producto.setIsRequerido(filtHab.IsRequeridoProducto);
            _departGrupo.Departamento.setIsRequerido(filtHab.IsRequeridoDepartamento);
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


        public void LimpiarFiltros()
        {
            _deposito.Ctrl.LimpiarOpcion();
            _marca.Ctrl.LimpiarOpcion();
            _estatusDivisa.Ctrl.LimpiarOpcion();
            _sucursal.Ctrl.LimpiarOpcion();
            _estatusDoc.Ctrl.LimpiarOpcion();
            _tasaIva.Ctrl.LimpiarOpcion();
            _categoria.Ctrl.LimpiarOpcion();
            _origen.Ctrl.LimpiarOpcion();
            _oferta.Ctrl.LimpiarOpcion();
            _concepto.Ctrl.LimpiarOpcion();
            _estatusPesado.Ctrl.LimpiarOpcion();
            _precio.Ctrl.LimpiarOpcion();
            _empaque.Ctrl.LimpiarOpcion();
            _departGrupo.LimpiarOpcion();
            _producto.Limpiar();
            _desde.LimpiarOpcion();
            _hasta.LimpiarOpcion();
        }


        private bool verificar()
        {
            if (!_deposito.IsOk()) return false;
            if (!_marca.IsOk()) return false;
            if (!_estatusDivisa.IsOk()) return false;
            if (!_sucursal.IsOk()) return false;
            if (!_estatusDoc.IsOk()) return false;
            if (!_tasaIva.IsOk()) return false;
            if (!_categoria.IsOk()) return false;
            if (!_origen.IsOk()) return false;
            if (!_oferta.IsOk()) return false;
            if (!_concepto.IsOk()) return false;
            if (!_estatusPesado.IsOk()) return false;
            if (!_empaque.IsOk()) return false;
            if (!_precio.IsOk()) return false;
            if (!_producto.IsOk()) return false;
            if (!_departGrupo.Departamento.IsOk()) return false;
            if (_desde.GetHabilitar && _hasta.GetHabilitar)
            {
                if (_desde.GetFecha > _hasta.GetFecha)
                {
                    Helpers.Msg.Alerta("Intervalo de Fechas Incorrecta");
                    return false;
                }
            }
            return true;
        }


        private ModInventario.src.Reporte.IData exportarData()
        {
            if (_procesarIsOk)
            {
                return new DataExportar()
                {
                    Categoria = _categoria.Ctrl.GetItem == null ? null : new ficha(_categoria.Ctrl.GetItem),
                    Depart = _departGrupo.Departamento.Ctrl.GetItem == null ? null : new ficha(_departGrupo.Departamento.Ctrl.GetItem),
                    Deposito = _deposito.Ctrl.GetItem == null ? null : new ficha(_deposito.Ctrl.GetItem),
                    Divisa = _estatusDivisa.Ctrl.GetItem == null ? null : new ficha(_estatusDivisa.Ctrl.GetItem),
                    EmpqPrecio = _empaque.Ctrl.GetItem == null ? null : new ficha(_empaque.Ctrl.GetItem),
                    Estatus = _estatusDoc.Ctrl.GetItem == null ? null : new ficha(_estatusDoc.Ctrl.GetItem),
                    Grupo = _departGrupo.Grupo.Ctrl.GetItem == null ? null : new ficha(_departGrupo.Grupo.Ctrl.GetItem),
                    Marca = _marca.Ctrl.GetItem == null ? null : new ficha(_marca.Ctrl.GetItem),
                    Oferta = _oferta.Ctrl.GetItem == null ? null : new ficha(_oferta.Ctrl.GetItem),
                    Origen = _origen.Ctrl.GetItem == null ? null : new ficha(_origen.Ctrl.GetItem),
                    Pesado = _estatusPesado.Ctrl.GetItem == null ? null : new ficha(_estatusPesado.Ctrl.GetItem),
                    Precio = _precio.Ctrl.GetItem == null ? null : new ficha(_precio.Ctrl.GetItem),
                    Sucursal = _sucursal.Ctrl.GetItem == null ? null : new ficha(_sucursal.Ctrl.GetItem),
                    TasaIva = _tasaIva.Ctrl.GetItem == null ? null : new ficha(_tasaIva.Ctrl.GetItem),
                    Concepto = _concepto.Ctrl.GetItem == null ? null : new ficha(_concepto.Ctrl.GetItem),
                    Producto = _producto.ItemSeleccionado == null ? null : new ficha(_producto.ItemSeleccionado),
                    Desde = _desde.GetHabilitar ? _desde.GetFecha : (DateTime?)null,
                    Hasta = _hasta.GetHabilitar ? _hasta.GetFecha : (DateTime?)null,
                };
            }
            return null;
        }
    }
}