using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.FiltrosGen.Reportes
{
    
    public class Gestion: IGestion, IGestionRep
    {

        private data _data;
        private bool _limpiarFiltrosIsOK;
        private bool _abandonarIsOk;
        private bool _procesarIsOk;
        private bool _validarData;
        private ModInventario.Reportes.Filtros.IFiltros _filtros;
        private IOpcion _gDeposito;
        private IOpcion _gMarca;
        private IOpcion _gDepart;
        private IOpcion _gSucursal;
        private IOpcion _gDivisa;
        private IOpcion _gCategoria;
        private IOpcion _gTasaIva;
        private IOpcion _gEstatus;
        private IOpcion _gOrigen;
        private IOpcion _gGrupo;
        private IBuscar _gPrd;
        private IFecha _gDesde;
        private IFecha _gHasta;


        public ModInventario.Reportes.Filtros.IFiltros Filtros { get { return _filtros; } }
        public BindingSource SourceDeposito { get { return _gDeposito.Source; } }
        public BindingSource SourceMarca { get { return _gMarca.Source; } }
        public BindingSource SourceDepart { get { return _gDepart.Source; } }
        public BindingSource SourceSucursal { get { return _gSucursal.Source; } }
        public BindingSource SourceAdmDivisa { get { return _gDivisa.Source; } }
        public BindingSource SourceCategoria { get { return _gCategoria.Source; } }
        public BindingSource SourceOrigen { get { return _gOrigen.Source; } }
        public BindingSource SourceTasa { get { return _gTasaIva.Source; } }
        public BindingSource SourceEstatus { get { return _gEstatus.Source; } }
        public BindingSource SourceGrupo { get { return _gGrupo.Source; } }
        public string AutoMarca { get { return _gMarca.GetId; } }
        public string AutoDeposito { get { return _gDeposito.GetId; } }
        public string AutoDepartamento { get { return _gDepart.GetId; } }
        public string AutoSucursal { get { return _gSucursal.GetId; } }
        public string IdAdmDivisa { get { return _gDivisa.GetId;} }
        public string IdCategoria { get { return _gCategoria.GetId; } }
        public string AutoTasa { get { return _gTasaIva.GetId; } }
        public string IdEstatus { get { return _gEstatus.GetId; } }
        public string IdOrigen { get { return _gOrigen.GetId; } }
        public string AutoGrupo { get { return _gGrupo.GetId; } }
        public bool ProductoIsOk { get { return _gPrd.ItemIsOk; } }
        public string ProductoAFiltrar { get { return _gPrd.DescItemSeleccionado; } }
        public DateTime Desde { get { return _gDesde.GetFecha; } }
        public DateTime Hasta { get { return _gHasta.GetFecha; } }
        public bool LimpiarFiltrosIsOK { get { return _limpiarFiltrosIsOK; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public bool FiltrosIsOK { get { return _procesarIsOk; } }
        public data dataFiltrar { get { return _data; } }


        public Gestion(IBuscar prd, IOpcion deposito, IOpcion marca, IOpcion sucursal, IOpcion depart,
            IOpcion divisa, IOpcion categoria, IOpcion tasa, IOpcion estatus, IOpcion origen, IOpcion grupo,
            IFecha desde, IFecha hasta)
        {
            _validarData = true;
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _limpiarFiltrosIsOK = false;
            _data = new data();
            _gDeposito = deposito;
            _gMarca = marca;
            _gSucursal = sucursal;
            _gDepart = depart;
            _gDivisa= divisa;
            _gCategoria = categoria;
            _gTasaIva = tasa;
            _gEstatus = estatus;
            _gOrigen = origen;
            _gGrupo= grupo;
            _gPrd = prd;
            _gDesde = desde;
            _gHasta= hasta;
        }

        public void Inicializa() 
        {
            _validarData = true;
            _limpiarFiltrosIsOK = false;
            limpiar();
        }

        FiltrosFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null) 
                {
                    frm = new FiltrosFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            try
            {
                var r00 = Sistema.MyData.Configuracion_VisualizarProductosInactivos();
                if (r00.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r00.Mensaje);
                    return false;
                }
                var _activarProductosInactivos = r00.Entidad;

                var lDepart = new List<ficha>();
                var r01 = Sistema.MyData.Departamento_GetLista();
                foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
                {
                    lDepart.Add(new ficha(rg.auto, "", rg.nombre));
                }
                _gDepart.setData(lDepart);

                var r02 = Sistema.MyData.Deposito_GetLista();
                if (r02.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r02.Mensaje);
                    return false;
                }
                var lDeposito = new List<ficha>();
                foreach (var rg in r02.Lista.OrderBy(o => o.nombre).ToList())
                {
                    lDeposito.Add(new ficha(rg.auto, "", rg.nombre));
                }
                _gDeposito.setData(lDeposito);

                var r03 = Sistema.MyData.Producto_AdmDivisa_Lista();
                if (r03.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r03.Mensaje);
                    return false;
                }
                var lDivisa = new List<ficha>();
                foreach (var rg in r03.Lista.OrderBy(o => o.Descripcion).ToList())
                {
                    lDivisa.Add(new ficha(rg.Id, "", rg.Descripcion));
                }
                _gDivisa.setData(lDivisa);

                var filtroOOb = new OOB.LibInventario.Sucursal.Filtro();
                var r04 = Sistema.MyData.Sucursal_GetLista(filtroOOb);
                if (r04.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r04.Mensaje);
                    return false;
                }
                var lSucursal = new List<ficha>();
                foreach (var rg in r04.Lista.OrderBy(o => o.nombre).ToList())
                {
                    lSucursal.Add(new ficha(rg.auto, "", rg.nombre));
                }
                _gSucursal.setData(lSucursal);

                var r05 = Sistema.MyData.Producto_Categoria_Lista();
                if (r05.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r05.Mensaje);
                    return false;
                }
                var lCategoria = new List<ficha>();
                foreach (var rg in r05.Lista.OrderBy(o => o.Descripcion).ToList())
                {
                    lCategoria.Add(new ficha(rg.Id, "", rg.Descripcion));
                }
                _gCategoria.setData(lCategoria);

                var r06 = Sistema.MyData.Producto_Origen_Lista();
                if (r06.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r06.Mensaje);
                    return false;
                }
                var lOrigen = new List<ficha>();
                foreach (var rg in r06.Lista.OrderBy(o => o.Descripcion).ToList())
                {
                    lOrigen.Add(new ficha(rg.Id, "", rg.Descripcion));
                }
                _gOrigen.setData(lOrigen);

                var r07 = Sistema.MyData.TasaImpuesto_GetLista();
                if (r07.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r07.Mensaje);
                    return false;
                }
                var lTasa = new List<ficha>();
                foreach (var rg in r07.Lista.OrderBy(o => o.tasa).ToList())
                {
                    lTasa.Add(new ficha(rg.auto, "", rg.ToString()));
                }
                _gTasaIva.setData(lTasa);

                var lMarca = new List<ficha>();
                var r09 = Sistema.MyData.Marca_GetLista();
                foreach (var rg in r09.Lista.OrderBy(o => o.nombre).ToList())
                {
                    lMarca.Add(new ficha(rg.auto, "", rg.nombre));
                }
                _gMarca.setData(lMarca);

                var lEstatus = new List<ficha>();
                lEstatus.Add(new ficha("01", "", "ACTIVO"));
                if (_activarProductosInactivos)
                {
                    lEstatus.Add(new ficha("03", "", "INACTIVO"));
                }
                _gEstatus.setData(lEstatus);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }

            return rt;
        }

        public void LimpiarFiltros()
        {
            _limpiarFiltrosIsOK = false;
            var msg = MessageBox.Show("Limpiar Filtros ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _limpiarFiltrosIsOK = true;
                limpiar();
            }
        }

        public void setValidarData(bool p)
        {
            _validarData = p;
        }
        public void setGestion(ModInventario.Reportes.Filtros.IFiltros filtros)
        {
            this._filtros = filtros;
            if (_filtros != null)
            {
                _data.setValidarFecha(false);
                if (_filtros.ActivarDesde || _filtros.ActivarHasta)
                {
                    _data.setValidarFecha(true);
                }
                if (!_filtros.ActivarDesde)
                    _gDesde.setEstatusOff();
                if (!_filtros.ActivarHasta)
                    _gHasta.setEstatusOff();
            }
        }

        public void BuscarProducto()
        {
            _gPrd.Buscar();
        }
        public void LimpiarProducto()
        {
            _gPrd.LimpiarItem();
        }
        public void setProductoBuscar(string cadena)
        {
            _gPrd.setCadenaBuscar(cadena);
        }
        public void setDeposito(string id)
        {
            _gDeposito.setFicha(id);
        }
        public void setMarca(string id)
        {
            _gMarca.setFicha(id);
        }
        public void setSucursal(string id)
        {
            _gSucursal.setFicha(id);
        }
        public void setDepartamento(string id)
        {
            _gDepart.setFicha(id);
            _gGrupo.setFicha("");
            if (id == "") { return; }
            var lst = new List<ficha>();
            try
            {
                var r01 = Sistema.MyData.Grupo_GetListaByIdDepartamento(id);
                foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
                {
                    lst.Add(new ficha(rg.auto, "", rg.nombre));
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
            _gGrupo.setData(lst);
        }
        public void setAdmDivisa(string id)
        {
            _gDivisa.setFicha(id);
        }
        public void setCategoria(string id)
        {
            _gCategoria.setFicha(id);
        }
        public void setTasaIva(string id)
        {
            _gTasaIva.setFicha(id);
        }
        public void setEstatus(string id)
        {
            _gEstatus.setFicha(id);
        }
        public  void setOrigen(string id)
        {
            _gOrigen.setFicha(id);
        }
        public void setGrupo(string id)
        {
            _gGrupo.setFicha(id);
        }
        public void setDesde(DateTime fecha)
        {
            _gDesde.setFecha(fecha);
        }
        public void setHasta(DateTime fecha)
        {
            _gHasta.setFecha(fecha);
        }


        private void limpiar()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _gDeposito.Inicializa();
            _gMarca.Inicializa();
            _gSucursal.Inicializa();
            _gDepart.Inicializa();
            _gDivisa.Inicializa();
            _gCategoria.Inicializa();
            _gTasaIva.Inicializa();
            _gEstatus.Inicializa();
            _gOrigen.Inicializa();
            _gGrupo.Inicializa();
            _gPrd.Inicializa();
            _gDesde.Inicializa();
            _gHasta.Inicializa();

            if (_filtros != null)
            {
                if (!_filtros.ActivarDesde)
                    _gDesde.setEstatusOff();
                if (!_filtros.ActivarHasta)
                    _gHasta.setEstatusOff();
            }

            _data.Limpiar();
        }

        public void ProcesarFiltros()
        {
            _data.Categoria = _gCategoria.Item;
            _data.Depart = _gDepart.Item;
            _data.Deposito= _gDeposito.Item;
            _data.Divisa= _gDivisa.Item;
            _data.Estatus= _gEstatus.Item;
            _data.Grupo= _gGrupo.Item;
            _data.Hasta= _gHasta.FechaFiltro;
            _data.Desde = _gDesde.FechaFiltro;
            _data.Marca= _gMarca.Item;
            _data.Origen= _gOrigen.Item;
            _data.Producto= _gPrd.ItemSeleccionado;
            _data.Sucursal= _gSucursal.Item;
            _data.TasaIva= _gTasaIva.Item;
            if (_validarData)
                _procesarIsOk = _data.IsOk();
            else
                _procesarIsOk = true;
        }

        public void Abandonar()
        {
            _abandonarIsOk = false;
            var xmsg="Abandonar Filtros Cargados ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _abandonarIsOk = true;
            }
        }

    }

}