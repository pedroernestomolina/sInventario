using ModInventario.FiltrosGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Tools.Concepto
{
    public class ImpConcepto: IConcepto
    {
        private IOpcion _concepto;


        public BindingSource GetSource { get { return _concepto.Source; } }
        public string GetId { get { return _concepto.GetId; } }
        public object GetItem { get { return _concepto.Item; } }


        public ImpConcepto()
        {
            _concepto = new FiltrosGen.Opcion.Gestion();
        }


        public void Inicializa()
        {
            _concepto.Inicializa();
        }

        public void setId(string id)
        {
            _concepto.setFicha(id);
        }
        public void CargarData()
        {
            var r01 = Sistema.MyData.Concepto_GetLista();
            var _list = new List<ficha>();
            foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
            {
                _list.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
            }
            _concepto.setData(_list);
        }
    }
}