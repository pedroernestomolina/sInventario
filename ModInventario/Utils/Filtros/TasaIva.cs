using LibUtilitis.CtrlCB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.Filtros
{
    public class TasaIva: IFiltro
    {
        private ICtrl _ctrl;


        public ICtrl Ctrl { get { return _ctrl; } }


        public TasaIva()
        {
            _ctrl = new ImpCB();
        }


        public void CargarData()
        {
            var _lst = new List<LibUtilitis.Opcion.IData>();
            var r01 = Sistema.MyData.TasaImpuesto_GetLista();
            foreach (var rg in r01.Lista.OrderBy(o => o.tasa).ToList())
            {
                _lst.Add(new dataFiltro() { id = rg.auto, codigo = "", desc = rg.ToString() });
            }
            _ctrl.CargarData(_lst);
        }
    }
}