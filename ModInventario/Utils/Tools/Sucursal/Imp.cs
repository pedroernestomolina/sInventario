using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Utils.Tools.Sucursal
{
    public class Imp: ICtrl
    {
        private Utils.Filtros.Sucursal _ctrl;


        public BindingSource GetSource { get { return _ctrl.Ctrl.GetSource; } }
        public string GetId { get { return _ctrl.Ctrl.GetId; } }
        public object GetItem { get { return _ctrl.Ctrl.GetItem != null ? new ficha(_ctrl.Ctrl.GetItem) : null; } }


        public Imp()
        {
            _ctrl = new Utils.Filtros.Sucursal();
        }


        public void Inicializa()
        {
            _ctrl.Ctrl.Inicializa();
        }

        public void setId(string id)
        {
            _ctrl.Ctrl.setFichaById(id);
        }
        public void CargarData()
        {
            var filtroOOB = new OOB.LibInventario.Sucursal.Filtro() { };
            var r01 = Sistema.MyData.Sucursal_GetLista(filtroOOB);
            var _list = new List<LibUtilitis.Opcion.IData>();
            foreach (var rg in r01.Lista.Where(w => w.IsActivo).OrderBy(o => o.nombre).ToList())
            {
                _list.Add(new dataUtils() { id = rg.auto, codigo = rg.codigo, desc = rg.nombre });
            }
            _ctrl.Ctrl.CargarData(_list);
        }
        public void LimpiarItemSeleccion()
        {
            _ctrl.Ctrl.LimpiarOpcion();
        }
    }
}