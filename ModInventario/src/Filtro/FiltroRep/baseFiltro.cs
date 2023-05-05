using ModInventario.FiltrosGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Filtro.FiltroRep
{
    
    abstract public class baseFiltro: IFiltro
    {

        protected baseData _data;
        protected ModInventario.Reportes.Filtros.IFiltros _filtros;

        protected IOpcion _gDeposito;
        protected IOpcion _gDepartamento;
        protected IOpcion _gGrupo;
        protected IOpcion _gMarca;
        protected IOpcion _gDivisa;
        protected IOpcion _gImpuesto;
        protected IOpcion _gEstatus;
        protected IOpcion _gPesado;
        protected IFecha _gDesde;
        protected IFecha _gHasta;


        public baseFiltro(baseData data)
        {
            _data = data;
        }


        public BindingSource GetDepartamento_Source { get { return _gDepartamento.Source; } }
        public BindingSource GetDeposito_Source { get { return _gDeposito.Source; } }
        public BindingSource GetGrupo_Source { get { return _gGrupo.Source; } }
        public BindingSource GetMarca_Source { get { return _gMarca.Source; } }
        public BindingSource GetAdmDivisa_Source { get { return _gDivisa.Source; } }
        public BindingSource GetImpuesto_Source { get { return _gImpuesto.Source; } }
        public BindingSource GetEstatus_Source { get { return _gEstatus.Source; } }
        public BindingSource GetPesado_Source { get { return _gPesado.Source; } }


        public string GetDepartamento_Id { get { return _gDepartamento.GetId; } }
        public string GetDeposito_Id { get { return _gDeposito.GetId; } }
        public string GetGrupo_Id { get { return _gGrupo.GetId; } }
        public string GetMarca_Id { get { return _gMarca.GetId; } }
        public string GetAdmDivisa_Id { get { return _gDivisa.GetId;} }
        public string GetImpuesto_Id { get { return _gImpuesto.GetId; } }
        public string GetEstatus_Id { get { return _gEstatus.GetId; } }
        public string GetPesado_Id { get { return _gPesado.GetId; } }
        public DateTime GetDesde { get { return _gDesde.GetFecha; } }
        public DateTime GetHasta { get { return _gHasta.GetFecha; } }


        virtual public void Inicializa()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _gDeposito.Inicializa();
            _gDepartamento.Inicializa();
            _gGrupo.Inicializa();
            _gMarca.Inicializa();
            _gDivisa.Inicializa();
            _gImpuesto.Inicializa();
            _gEstatus.Inicializa();
            _gPesado.Inicializa();
            _gDesde.Inicializa();
            _gHasta.Inicializa();
        }
        abstract public void Inicia();

        
        virtual public bool CargarData()
        {
            try
            {
                var lDepart = new List<ficha>();
                var r01 = Sistema.MyData.Departamento_GetLista();
                foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
                {
                    lDepart.Add(new ficha(rg.auto, "", rg.nombre));
                }
                _gDepartamento.setData(lDepart);

                var lDeposito = new List<ficha>();
                var r02 = Sistema.MyData.Deposito_GetLista();
                foreach (var rg in r02.Lista.OrderBy(o => o.nombre).ToList())
                {
                    lDeposito.Add(new ficha(rg.auto, "", rg.nombre));
                }
                _gDeposito.setData(lDeposito);

                var lMarca = new List<ficha>();
                var r03 = Sistema.MyData.Marca_GetLista();
                foreach (var rg in r03.Lista.OrderBy(o => o.nombre).ToList())
                {
                    lMarca.Add(new ficha(rg.auto, "", rg.nombre));
                }
                _gMarca.setData(lMarca);

                var lDivisa = new List<ficha>();
                var r04 = Sistema.MyData.Producto_AdmDivisa_Lista();
                foreach (var rg in r04.Lista.OrderBy(o => o.Descripcion).ToList())
                {
                    lDivisa.Add(new ficha(rg.Id, "", rg.Descripcion));
                }
                _gDivisa.setData(lDivisa);

                var lImpuesto= new List<ficha>();
                var r05 = Sistema.MyData.TasaImpuesto_GetLista();
                foreach (var rg in r05.Lista.OrderBy(o => o.tasa).ToList())
                {
                    lImpuesto.Add(new ficha(rg.auto, "", rg.ToString()));
                }
                _gImpuesto.setData(lImpuesto);

                var lEstatus = new List<ficha>();
                lEstatus.Add(new ficha("01", "", "ACTIVO"));
                lEstatus.Add(new ficha("03", "", "INACTIVO"));
                _gEstatus.setData(lEstatus);

                var lPesado= new List<ficha>();
                lPesado.Add(new ficha("01", "", "Si"));
                lPesado.Add(new ficha("02", "", "No"));
                _gPesado.setData(lPesado);

                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }


        public void setGestion(ModInventario.Reportes.Filtros.IFiltros filtros)
        {
            this._filtros = filtros;
            if (_filtros != null)
            {
                if (!_filtros.ActivarDesde)
                    _gDesde.setEstatusOff();
                if (!_filtros.ActivarHasta)
                    _gHasta.setEstatusOff();
            }
        }


        public void setDeposito(string id)
        {
            _gDeposito.setFicha(id);
            _data.Deposito = _gDeposito.Item;
        }
        public void setDepartamento(string id)
        {
            _gDepartamento.setFicha(id);
            _data.Departamento = _gDepartamento.Item;
            var lst = new List<ficha>();
            _gGrupo.setFicha("");
            _gGrupo.setData(lst);
            if (id == "") { return; }

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
        public void setGrupo(string id)
        {
            _gGrupo.setFicha(id);
            _data.Grupo = _gGrupo.Item;
        }
        public void setMarca(string id)
        {
            _gMarca.setFicha(id);
            _data.Marca= _gMarca.Item;
        }
        public void setAdmDivisa(string id)
        {
            _gDivisa.setFicha(id);
            _data.Divisa = _gDivisa.Item;
        }
        public void setImpuesto(string id)
        {
            _gImpuesto.setFicha(id);
            _data.Impuesto = _gImpuesto.Item;
        }
        public void setEstatus(string id)
        {
            _gEstatus.setFicha(id);
            _data.Estatus = _gEstatus.Item;
        }
        public void setPesado(string id)
        {
            _gPesado.setFicha(id);
            _data.Pesado = _gPesado.Item;
        }
        public void setDesde(DateTime fecha)
        {
            _gDesde.setFecha(fecha);
            _data.Desde = _gDesde.GetFecha;
        }
        public void setHasta(DateTime fecha)
        {
            _gHasta.setFecha(fecha);
            _data.Hasta = _gHasta.GetFecha;
        }


        public bool GetHabilitarDeposito { get { return _filtros.ActivarDeposito; } }
        public bool GetHabilitarDepartamento { get { return _filtros.ActivarDepartamento; } }
        //public bool GetHabilitarGrupo { get { return _filtros.ActivarGrupo; } }
        public bool GetHabilitarMarca { get { return _filtros.ActivarMarca; } }
        public bool GetHabilitarAdmDivisa { get { return _filtros.ActivarAdmDivisa; } }
        public bool GetHabilitarImpuesto { get { return _filtros.ActivarTasaIva; } }
        public bool GetHabilitarEstatus { get { return _filtros.ActivarEstatus; } }
        public bool GetHabilitarPesado { get { return _filtros.ActivarPesado; } }
        public bool GetHabilitarFecha { get { return _filtros.ActivarEntreFechas; } }
        public bool GetHabilitarFechaDesde { get { return _filtros.ActivarDesde; } }
        public bool GetHabilitarFechaHasta { get { return _filtros.ActivarHasta; } }


        public bool LimpiarOpcionesIsOk { get { return true; } }
        virtual public void LimpiarOpciones()
        {
            _data.Limpiar();
            limpiar();
        }


        private void limpiar()
        {
            _gDeposito.Inicializa();
            _gDepartamento.Inicializa();
            _gGrupo.Inicializa();
            _gMarca.Inicializa();
            _gDivisa.Inicializa();
            _gImpuesto.Inicializa();
            _gEstatus.Inicializa();
            _gPesado.Inicializa();
            _gDesde.Inicializa();
            _gHasta.Inicializa();
            if (_filtros != null)
            {
                if (!_filtros.ActivarEntreFechas)
                    _gDesde.setEstatusOff();
                if (!_filtros.ActivarEntreFechas)
                    _gHasta.setEstatusOff();
            }
        }


        abstract public bool FiltrosIsOK { get; }
        abstract public FiltrosGen.Reportes.data dataFiltrar { get; }
        abstract public void setValidarData(bool p);


        private bool _abandonarIsOk;
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _procesarIsOk = false;
            _abandonarIsOk = true;
        }


        private bool _procesarIsOk;
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public void ProcesarFicha()
        {
            _abandonarIsOk = false;
            _procesarIsOk = true;
        }

    }

}