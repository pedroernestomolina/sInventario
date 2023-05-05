using LibUtilitis.CtrlCB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.Filtros
{
    public class Sucursal : IFiltro
    {
        private ICtrl _ctrl;


        public ICtrl Ctrl { get { return _ctrl; } }


        public Sucursal()
        {
            _ctrl = new ImpCB();
        }


        public void CargarData()
        {
            var _lst = new List<LibUtilitis.Opcion.IData>();
            var xr1 = Sistema.MyData.Sucursal_GetLista(new OOB.LibInventario.Sucursal.Filtro());
            foreach (var rg in xr1.Lista.OrderBy(o => o.nombre).ToList())
            {
                _lst.Add(new dataFiltro() { id = rg.auto, codigo = rg.codigo, desc = rg.nombre });
            }
            _ctrl.CargarData(_lst);
        }
    }
}