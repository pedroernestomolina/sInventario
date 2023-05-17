using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Tools.Deposito
{
    public class Imp: ICtrlLink
    {
        private Utils.Filtros.Deposito _ctrl;


        public BindingSource GetSource { get { return _ctrl.Ctrl.GetSource; } }
        public string GetId { get { return _ctrl.Ctrl.GetId; } }
        public object GetItem { get { return _ctrl.Ctrl.GetItem != null ? new ficha(_ctrl.Ctrl.GetItem) : null; } }


        public Imp()
        {
            _ctrl = new Utils.Filtros.Deposito();
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
            _ctrl.CargarData();
        }
        public void CargarDataByIdLink(string id)
        {
            try
            {
                var r01 = Sistema.MyData.Sucursal_GetFicha(id);
                var r02 = Sistema.MyData.Deposito_GetListaBySucursal(r01.Entidad.codigo);
                var _list = new List<LibUtilitis.Opcion.IData>();
                foreach (var rg in r02.Lista.OrderBy(o => o.nombre).ToList())
                {
                    _list.Add(new dataUtils() { id = rg.auto, codigo = rg.codigo, desc = rg.nombre });
                }
                _ctrl.Ctrl.CargarData(_list);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
    }
}