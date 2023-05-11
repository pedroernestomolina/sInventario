using LibUtilitis.CtrlCB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.Filtros
{
    public class TipoDocumento: IFiltro
    {
        private ICtrl _ctrl;


        public ICtrl Ctrl { get { return _ctrl; } }


        public TipoDocumento()
        {
            _ctrl = new ImpCB();
            _habilitar = true;
        }


        public void CargarData()
        {
            var _lst = new List<LibUtilitis.Opcion.IData>();
            _lst.Add(new dataFiltro() { id = "1", codigo = "01", desc = "CARGO" });
            _lst.Add(new dataFiltro() { id = "2", codigo = "02", desc = "DESCARGO" });
            _lst.Add(new dataFiltro() { id = "3", codigo = "03", desc = "TRASLADO" });
            _lst.Add(new dataFiltro() { id = "4", codigo = "04", desc = "AJUSTE" });
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