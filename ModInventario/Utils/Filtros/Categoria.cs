using LibUtilitis.CtrlCB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.Filtros
{
    public class Categoria: IFiltro
    {
        private ICtrl _ctrl;


        public ICtrl Ctrl { get { return _ctrl; } }


        public Categoria()
        {
            _ctrl = new ImpCB();
        }


        public void CargarData()
        {
            var _lst = new List<LibUtilitis.Opcion.IData>();
            var r01 = Sistema.MyData.Producto_Categoria_Lista();
            foreach (var rg in r01.Lista.OrderBy(o => o.Descripcion).ToList())
            {
                _lst.Add(new dataFiltro() { id = rg.Id, codigo = "", desc = rg.Descripcion });
            }
            _ctrl.CargarData(_lst);
        }
    }
}
