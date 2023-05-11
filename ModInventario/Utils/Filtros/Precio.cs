using LibUtilitis.CtrlCB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.Filtros
{
    public class Precio: IFiltro
    {
        private ICtrl _ctrl;


        public ICtrl Ctrl { get { return _ctrl; } }


        public Precio()
        {
            _ctrl = new ImpCB();
            _habilitar = true;
        }


        public void CargarData()
        {
            var _lst = new List<LibUtilitis.Opcion.IData>();
            _lst.Add(new dataFiltro() { id = "1", codigo = "01", desc = "Precio 1" });
            _lst.Add(new dataFiltro() { id = "2", codigo = "02", desc = "Precio 2" });
            _lst.Add(new dataFiltro() { id = "3", codigo = "03", desc = "Precio 3" });
            _lst.Add(new dataFiltro() { id = "4", codigo = "04", desc = "Precio 4" });
            _lst.Add(new dataFiltro() { id = "5", codigo = "05", desc = "Precio 5" });
            _ctrl.CargarData(_lst);
        }


        protected bool _habilitar;
        public bool GetHabilitar { get { return _habilitar; } }
        public void setHabilitar(bool hab)
        {
            _habilitar = hab;
        }
    }
}