using LibUtilitis.CtrlCB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.Filtros
{
    public class Grupo:IFiltroLink
    {
        private ICtrl _ctrl;


        public ICtrl Ctrl { get { return _ctrl; } }


        public Grupo()
        {
            _ctrl = new ImpCB();
            _habilitar = true;
        }


        public void CargarData()
        {
            var _lst = new List<LibUtilitis.Opcion.IData>();
            var xr1 = Sistema.MyData.Grupo_GetLista();
            foreach (var rg in xr1.Lista.OrderBy(o => o.nombre).ToList())
            {
                _lst.Add(new dataFiltro() { id = rg.auto, codigo = rg.codigo, desc = rg.nombre });
            }
            _ctrl.CargarData(_lst);
        }

        public void CargarDataByIdLink(string id)
        {
            var _lst = new List<LibUtilitis.Opcion.IData>();
            var xr1 = Sistema.MyData.Grupo_GetListaByIdDepartamento(id);
            foreach (var rg in xr1.Lista.OrderBy(o => o.nombre).ToList())
            {
                _lst.Add(new dataFiltro() { id = rg.auto, codigo = rg.codigo, desc = rg.nombre });
            }
            _ctrl.CargarData(_lst);
        }


        private bool _habilitar;
        public bool GetHabilitar { get { return _habilitar; } }
        public void setHabilitar(bool hab)
        {
            _habilitar = hab;
        }
    }
}