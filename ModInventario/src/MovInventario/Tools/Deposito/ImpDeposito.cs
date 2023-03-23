using ModInventario.FiltrosGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Tools.Deposito
{
    public class ImpDeposito: IDeposito
    {
        private IOpcion _deposito;


        public BindingSource GetSource { get { return _deposito.Source; } }
        public string GetId { get { return _deposito.GetId; } }
        public object GetItem { get { return _deposito.Item; } }


        public ImpDeposito()
        {
            _deposito = new FiltrosGen.Opcion.Gestion();
        }


        public void Inicializa()
        {
            _deposito.Inicializa();
        }

        public void setId(string id)
        {
            _deposito.setFicha(id);
        }

        public void CargarData()
        {
            var r01 = Sistema.MyData.Deposito_GetLista();
            var _list = new List<ficha>();
            foreach (var rg in r01.Lista.Where(w=>w.IsActivo).OrderBy(o => o.nombre).ToList())
            {
                _list.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
            }
            _deposito.setData(_list);
        }
        public void CargarDataByIdSucursal(string idSuc)
        {
            try
            {
                var r01 = Sistema.MyData.Sucursal_GetFicha(idSuc);
                var r02 = Sistema.MyData.Deposito_GetListaBySucursal(r01.Entidad.codigo);
                var _list= new List<ficha>();
                foreach (var rg in r02.Lista.OrderBy(o => o.nombre).ToList())
                {
                    _list.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
                }
                _deposito.setData(_list);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
        public void LimpiarLista()
        {
            _deposito.LimpiarLista();
        }
    }
}