using ModInventario.FiltrosGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.FiltroBusqAdm.ModoBasico
{

    public class ImpFiltroPrd: IFiltroPrd
    {

        private Data _data;
        private IOpcion _gDepartamento;
        private IOpcion _gGrupo;
        private IOpcion _gMarca;
        private IOpcion _gOrigen;
        private IOpcion _gTasaIva;
        private IOpcion _gEstatus;
        private IOpcion _gDivisa;
        private IOpcion _gPesado;


        public int MetBusqueda { get { return (int)_data.MetBusqueda; } }
        public string CadenaBusq { get { return _data.CadenaBusq; } }
        public Data dataFiltrar { get { return _data; } }


        public ImpFiltroPrd()
        {
            _limpiarIsOk = false;
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _data = new Data();

            _gMarca = new FiltrosGen.Opcion.Gestion();
            _gOrigen = new FiltrosGen.Opcion.Gestion();
            _gTasaIva = new FiltrosGen.Opcion.Gestion();
            _gEstatus = new FiltrosGen.Opcion.Gestion();
            _gDivisa = new FiltrosGen.Opcion.Gestion();
            _gPesado = new FiltrosGen.Opcion.Gestion();
            _gDepartamento = new FiltrosGen.Opcion.Gestion();
            _gGrupo = new FiltrosGen.Opcion.Gestion();
        }


        public void Inicializa() 
        {
            _limpiarIsOk = false;
            _abandonarIsOk = false;
            _procesarIsOk = false;
            limpiarEntradas();
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

            var r01 = Sistema.MyData.Departamento_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            var lstDepart= new List<ficha>();
            foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
            {
                lstDepart.Add(new ficha(rg.auto, "", rg.nombre));
            }
            _gDepartamento.setData(lstDepart);

            var r04 = Sistema.MyData.Producto_Origen_Lista();
            if (r04.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r04.Mensaje);
                return false;
            }
            var lstOrigen = new List<ficha>();
            foreach (var rg in r04.Lista.OrderBy(o => o.Descripcion).ToList())
            {
                lstOrigen.Add(new ficha(rg.Id, "", rg.Descripcion));
            }
            _gOrigen.setData(lstOrigen);

            var r05 = Sistema.MyData.TasaImpuesto_GetLista();
            if (r05.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r05.Mensaje);
                return false;
            }
            var lstTasa = new List<ficha>();
            foreach (var rg in r05.Lista.OrderBy(o => o.tasa).ToList())
            {
                lstTasa.Add(new ficha(rg.auto, "", rg.ToString()));
            }
            _gTasaIva.setData(lstTasa);

            var r06 = Sistema.MyData.Marca_GetLista ();
            if (r06.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r06.Mensaje);
                return false;
            }
            var lstMarca = new List<ficha>();
            foreach (var rg in r06.Lista.OrderBy(o => o.nombre).ToList())
            {
                lstMarca.Add(new ficha(rg.auto, "", rg.nombre));
            }
            _gMarca.setData(lstMarca);

            var lstEstatus = new List<ficha>();
            lstEstatus.Add(new ficha("01", "", "ACTIVO"));
            lstEstatus.Add(new ficha("03", "", "INACTIVO"));
            _gEstatus.setData(lstEstatus);

            var r09 = Sistema.MyData.Producto_AdmDivisa_Lista();
            if (r09.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r09.Mensaje);
                return false;
            }
            var lstDivisa= new List<ficha>();
            foreach (var rg in r09.Lista.OrderBy(o => o.Descripcion).ToList())
            {
                lstDivisa.Add(new ficha(rg.Id, "", rg.Descripcion));
            }
            _gDivisa.setData(lstDivisa);

            var r0A = Sistema.MyData.Producto_Pesado_Lista ();
            if (r0A.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r0A.Mensaje);
                return false;
            }
            var lstPesado= new List<ficha>();
            foreach (var rg in r0A.Lista.OrderBy(o => o.Descripcion).ToList())
            {
                lstPesado.Add(new ficha(rg.Id.ToString().Trim(), "", rg.Descripcion));
            }
            _gPesado.setData(lstPesado);

            return rt;
        }

        public void setDepartamento(string id)
        {
            _gDepartamento.setFicha(id);
            _gGrupo.setFicha("");
            if (id != "")
            {
                var r01 = Sistema.MyData.Grupo_GetListaByIdDepartamento(id);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return ;
                }
                var lst = new List<ficha>();
                foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
                {
                    lst.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
                }
                _gGrupo.setData(lst);
            }
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
            _limpiarIsOk = true;
            limpiarEntradas();
        }


        public bool DataFiltrarIsOk()
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

        private void limpiarEntradas()
        {
            _data.Limpiar();
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

        private bool _procesarIsOk;
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public void ProcesarFicha()
        {
            _procesarIsOk = true;
        }


        private bool _limpiarIsOk;
        public bool LimpiarIsOk { get { return _limpiarIsOk; } }
        public void Limpiar()
        {
            _limpiarIsOk = false;
            var msg = MessageBox.Show("Limpiar Filtros ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _limpiarIsOk = true;
                limpiarEntradas();
            }
        }


        FiltrosGen.AdmProducto.data IAdmProducto.dataFiltrar { get { return dataFiltar(); } }
        private FiltrosGen.AdmProducto.data dataFiltar()
        {
            var _rt = new FiltrosGen.AdmProducto.data()
            {
                AdmDivisa = _data.AdmDivisa,
                Catalogo = null,
                Categoria = null,
                Departamento = _data.Departamento,
                Deposito = null,
                Estatus = _data.Estatus,
                Existencia = null,
                Grupo = _data.Grupo,
                Marca = _data.Marca,
                Oferta = null,
                Origen = _data.Origen,
                Pesado = _data.Pesado,
                PrecioMayor = null,
                Proveedor = null,
                TasaIva = _data.TasaIva,
            };
            _rt.setCadenaBusq(_data.CadenaBusq);
            switch(_data.MetBusqueda)
            {
                case  Enumerados.enumMetBusqueda.PorCodigo:
                    _rt.setMetBusqByCodigo();
                    break;
                case  Enumerados.enumMetBusqueda.PorCodigoBarra:
                    _rt.setMetBusqByCodigoBarra();
                    break;
                case  Enumerados.enumMetBusqueda.PorNombre:
                    _rt.setMetBusqByNombre();
                    break;
                case  Enumerados.enumMetBusqueda.PorReferencia:
                    _rt.setMetBusqByReferencia();
                    break;
            }
            return _rt;
        } 

    }

}