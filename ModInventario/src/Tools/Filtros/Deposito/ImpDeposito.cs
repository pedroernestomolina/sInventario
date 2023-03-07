using ModInventario.FiltrosGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Tools.Filtros.Deposito
{
    public class ImpDeposito: IDeposito
    {
        private IOpcion _op;


        public BindingSource GetSource { get { return _op.Source; } }
        public string GetId { get { return _op.GetId; } }
        public ficha GetItem { get { return _op.Item; } }


        public ImpDeposito()
        {
            _op = new FiltrosGen.Opcion.Gestion();
        }


        public void Inicializa()
        {
            _op.Inicializa();
        }

        public void setId(string id)
        {
            _op.setFicha(id);
        }
        public void CargarData()
        {
            var _list = new List<ficha>();
            var r01 = Sistema.MyData.Deposito_GetLista();
            foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
            {
                _list.Add(new ficha(rg.auto, "", rg.nombre));
            }
            _op.setData(_list);
        }

        private bool _habilitar = true;
        public bool GetHabilitar { get { return _habilitar; } }
        public void setHabilitar(bool hab)
        {
            _habilitar = hab;
        }
    }
}