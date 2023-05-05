using LibUtilitis.CtrlCB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.Filtros
{
    public class Empaque: IFiltro
    {
        private ICtrl _ctrl;


        public ICtrl Ctrl { get { return _ctrl; } }


        public Empaque()
        {
            _ctrl = new ImpCB();
        }


        public void CargarData()
        {
            var _lst = new List<LibUtilitis.Opcion.IData>();
            _lst.Add(new dataFiltro() { id = "1", codigo = "01", desc = "Empaque Vta 1" });
            _lst.Add(new dataFiltro() { id = "2", codigo = "02", desc = "Empaque Vta 2" });
            _lst.Add(new dataFiltro() { id = "3", codigo = "03", desc = "Empaque Vta 3" });
            _ctrl.CargarData(_lst);
        }
    }
}