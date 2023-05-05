using LibUtilitis.CtrlCB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.Filtros
{
    public class Catalogo: IFiltro
    {
        private ICtrl _ctrl;


        public ICtrl Ctrl { get { return _ctrl; } }


        public Catalogo()
        {
            _ctrl = new ImpCB();
        }


        public void CargarData()
        {
            var _lst = new List<LibUtilitis.Opcion.IData>();
            _lst.Add(new dataFiltro() { id = "1", codigo = "01", desc = "SI" });
            _lst.Add(new dataFiltro() { id = "2", codigo = "02", desc = "NO" });
            _ctrl.CargarData(_lst);
        }
    }
}