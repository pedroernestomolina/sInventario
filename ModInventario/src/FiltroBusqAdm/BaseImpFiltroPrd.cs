using ModInventario.FiltrosGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.FiltroBusqAdm
{
    abstract public class BaseImpFiltroPrd : IFiltroPrd
    {

        protected dataFiltro _data;
        protected IOpcion _gDepartamento;
        protected IOpcion _gGrupo;
        protected IOpcion _gMarca;
        protected IOpcion _gOrigen;
        protected IOpcion _gTasaIva;
        protected IOpcion _gEstatus;
        protected IOpcion _gDivisa;
        protected IOpcion _gPesado;


        public int MetBusqueda { get { return (int)_data.MetBusqueda; } }
        public string CadenaBusq { get { return _data.CadenaBusq; } }


        public void Inicializa()
        {
            _habiltarDeposito = true;
            _data.Limpiar();
            reset();
        }
        abstract public void Inicia();

        protected void reset()
        {
            _limpiarOpcionesIsOk = false;
            _abandonarIsOk = false;
            limpiarEntradas();
        }

        virtual protected bool CargarData()
        {
            var rt = true;

            try
            {
                var lstDepart = new List<ficha>();
                var r01 = Sistema.MyData.Departamento_GetLista();
                foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
                {
                    lstDepart.Add(new ficha(rg.auto, "", rg.nombre));
                }
                _gDepartamento.setData(lstDepart);

                var lstOrigen = new List<ficha>();
                var r04 = Sistema.MyData.Producto_Origen_Lista();
                foreach (var rg in r04.Lista.OrderBy(o => o.Descripcion).ToList())
                {
                    lstOrigen.Add(new ficha(rg.Id, "", rg.Descripcion));
                }
                _gOrigen.setData(lstOrigen);

                var lstTasa = new List<ficha>();
                var r05 = Sistema.MyData.TasaImpuesto_GetLista();
                foreach (var rg in r05.Lista.OrderBy(o => o.tasa).ToList())
                {
                    lstTasa.Add(new ficha(rg.auto, "", rg.ToString()));
                }
                _gTasaIva.setData(lstTasa);

                var lstMarca = new List<ficha>();
                var r06 = Sistema.MyData.Marca_GetLista();
                foreach (var rg in r06.Lista.OrderBy(o => o.nombre).ToList())
                {
                    lstMarca.Add(new ficha(rg.auto, "", rg.nombre));
                }
                _gMarca.setData(lstMarca);

                var lstDivisa = new List<ficha>();
                var r09 = Sistema.MyData.Producto_AdmDivisa_Lista();
                foreach (var rg in r09.Lista.OrderBy(o => o.Descripcion).ToList())
                {
                    lstDivisa.Add(new ficha(rg.Id, "", rg.Descripcion));
                }
                _gDivisa.setData(lstDivisa);

                var r0A = Sistema.MyData.Producto_Pesado_Lista();
                if (r0A.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r0A.Mensaje);
                    return false;
                }
                var lstPesado = new List<ficha>();
                foreach (var rg in r0A.Lista.OrderBy(o => o.Descripcion).ToList())
                {
                    lstPesado.Add(new ficha(rg.Id.ToString().Trim(), "", rg.Descripcion));
                }
                _gPesado.setData(lstPesado);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
            return rt;
        }

        public void setDepartamento(string id)
        {
            _gDepartamento.setFicha(id);
            _gGrupo.setFicha("");
            if (id == "") return;
            var lst = new List<ficha>();
            try
            {
                if (id == "") return;
                var r01 = Sistema.MyData.Grupo_GetListaByIdDepartamento(id);
                foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
                {
                    lst.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
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
        }
        public void setEstatus(string id)
        {
            _gEstatus.setFicha(id);
        }
        public void setMarca(string id)
        {
            _gMarca.setFicha(id);
        }
        public void setOrigen(string id)
        {
            _gOrigen.setFicha(id);
        }
        public void setTasaIva(string id)
        {
            _gTasaIva.setFicha(id);
        }
        public void setAdmDivisa(string id)
        {
            _gDivisa.setFicha(id);
        }
        public void setPesado(string id)
        {
            _gPesado.setFicha(id);
        }
        public void setCadenaBusc(string cadena)
        {
            _data.setCadenaBusq(cadena);
        }
        public void setMetBusqByCodigo()
        {
            _data.setMetBusqByCodigo();
        }
        public void setMetBusqByNombre()
        {
            _data.setMetBusqByNombre();
        }
        public void setMetBusqByReferencia()
        {
            _data.setMetBusqByReferencia();
        }
        public void setMetBusqByCodigoBarra()
        {
            _data.setMetBusqByCodigoBarra();
        }


        public void LimpiarFiltros()
        {
            _limpiarOpcionesIsOk = true;
            _data.Limpiar();
            limpiarEntradas();
        }
        virtual protected void limpiarEntradas()
        {
            _gMarca.Inicializa();
            _gOrigen.Inicializa();
            _gTasaIva.Inicializa();
            _gEstatus.Inicializa();
            _gDivisa.Inicializa();
            _gPesado.Inicializa();
            _gDepartamento.Inicializa();
            _gGrupo.Inicializa();
        }


        public BindingSource GetDepartamentoSource { get { return _gDepartamento.Source; } }
        public BindingSource GetGrupoSource { get { return _gGrupo.Source; } }
        public BindingSource GetMarcaSource { get { return _gMarca.Source; } }
        public BindingSource GetOrigenSource { get { return _gOrigen.Source; } }
        public BindingSource GetImpuestoSource { get { return _gTasaIva.Source; } }
        public BindingSource GetEstatusSource { get { return _gEstatus.Source; } }
        public BindingSource GetAdmDivisaSource { get { return _gDivisa.Source; } }
        public BindingSource GetPesadoSource { get { return _gPesado.Source; } }

        public string GetDepartamentoId { get { return _gDepartamento.GetId; } }
        public string GetGrupoId { get { return _gGrupo.GetId; } }
        public string GetMarcaId { get { return _gMarca.GetId; } }
        public string GetOrigenId { get { return _gOrigen.GetId; } }
        public string GetImpuestoId { get { return _gTasaIva.GetId; } }
        public string GetEstatusId { get { return _gEstatus.GetId; } }
        public string GetAdmDivisaId { get { return _gDivisa.GetId; } }
        public string GetPesadoId { get { return _gPesado.GetId; } }


        private bool _abandonarIsOk;
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = true;
        }


        private bool _limpiarOpcionesIsOk;
        public bool LimpiarOpcionesIsOk { get { return _limpiarOpcionesIsOk; } }
        public void LimpiarOpciones()
        {
            _limpiarOpcionesIsOk = false;
            var msg = MessageBox.Show("Limpiar Filtros ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _limpiarOpcionesIsOk = true;
                limpiarEntradas();
            }
        }


        object ModInventario.FiltrosGen.AdmProducto.IAdmProducto.FiltrosExportar { get { return _data; } }
        virtual public bool DataFiltrarIsOk()
        {
            _data.Departamento = _gDepartamento.Item;
            _data.Grupo = _gGrupo.Item;
            _data.Marca = _gMarca.Item;
            _data.Origen = _gOrigen.Item;
            _data.TasaIva = _gTasaIva.Item;
            _data.Estatus = _gEstatus.Item;
            _data.AdmDivisa = _gDivisa.Item;
            _data.Pesado = _gPesado.Item;
            return _data.FiltrarIsOk();
        }


        private bool _habiltarDeposito;
        public void HabilitaDeposito(bool act)
        {
            _habiltarDeposito = act;
        }
    }
}