using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Visor.Precio
{
    
    public class Gestion
    {

        private List<dataVista> _lDataV;
        private BindingSource _bsDataV;
        private List<general> _lDepart;
        private BindingSource _bsDepart;
        private List<general> _lGrupo;
        private BindingSource _bsGrupo;
        private dataFiltro _data;


        public BindingSource SourceDepartamento { get { return _bsDepart; } }
        public BindingSource SourceGrupo { get { return _bsGrupo; } }
        public BindingSource SourceVista { get { return _bsDataV; } }
        public string ItemsEncontrados { get { return _bsDataV.Count.ToString("n0"); } }


        public Gestion()
        {
            _data = new dataFiltro();
            _lDataV = new List<dataVista>();
            _bsDataV = new BindingSource();
            _bsDataV.DataSource = _lDataV;
            _lDepart = new List<general>();
            _bsDepart = new BindingSource();
            _bsDepart.DataSource = _lDepart;
            _lGrupo= new List<general>();
            _bsGrupo= new BindingSource();
            _bsGrupo.DataSource = _lGrupo;
        }


        public void Inicializa()
        {
            _data.Limpiar();
            _lDataV.Clear();
            _bsDataV.CurrencyManager.Refresh();
        }

        PrecioFrm _frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (_frm == null) 
                {
                    _frm = new PrecioFrm();
                    _frm.setControlador(this);
                }
                _frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            try
            {
                _lDepart.Clear();
                var r01 = Sistema.MyData.Departamento_GetLista();
                foreach (var it in r01.Lista.OrderBy(o => o.nombre).ToList())
                {
                    _lDepart.Add(new general(it.auto, it.nombre));
                }
                _bsDepart.CurrencyManager.Refresh();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
            return true;
        }

        public void setDepartamento(string id)
        {
            _lGrupo.Clear();
            _data.setDepartamento(_lDepart.FirstOrDefault(s => s.id == id));
            if (id != "")
            {
                try
                {
                    var r01 = Sistema.MyData.Grupo_GetListaByIdDepartamento(id);
                    foreach (var it in r01.Lista.OrderBy(o => o.nombre).ToList())
                    {
                        _lGrupo.Add(new general(it.auto, it.nombre));
                    }
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                }
            }
            _bsGrupo.CurrencyManager.Refresh();
        }

        public void Buscar()
        {
            var filtro = new OOB.LibInventario.Visor.Precio.Filtro();
            if (_data.Departamento != null) 
            {
                filtro.autoDepart = _data.Departamento.id;
            }
            if (_data.Grupo != null)
            {
                filtro.autoGrupo = _data.Grupo.id;
            }

            var r00 = Sistema.MyData.Configuracion_TasaCambioActual();
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            var r01 = Sistema.MyData.Visor_Precio(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _lDataV.Clear();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0) 
                {
                    foreach (var it in r01.Lista.OrderBy(o=>o.nombrePrd).ToList()) 
                    {
                        _lDataV.Add(new dataVista(it, r00.Entidad));
                    }
                }
            }
            _bsDataV.CurrencyManager.Refresh();
        }

        public void setGrupo(string id)
        {
            _data.setGrupo(_lGrupo.FirstOrDefault(s => s.id == id));
        }

        public void LimpiarFiltros()
        {
            _data.Limpiar();
            _lDataV.Clear();
            _bsDataV.CurrencyManager.Refresh();
        }

    }

}