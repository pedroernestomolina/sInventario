using LibUtilitis.CtrlCB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.Filtros
{
    public class Marca: IFiltro
    {
        private ICtrl _ctrl;


        public ICtrl Ctrl { get { return _ctrl; } }


        public Marca()
        {
            _ctrl = new ImpCB();
        }


        public void CargarData()
        {
            var _lst = new List<LibUtilitis.Opcion.IData>();
            var xr1 = Sistema.MyData.Marca_GetLista();
            foreach (var rg in xr1.Lista.OrderBy(o => o.nombre).ToList())
            {
                _lst.Add(new dataFiltro() { id = rg.auto, codigo = "", desc = rg.nombre });
            }
            _ctrl.CargarData(_lst);
        }
    }
}