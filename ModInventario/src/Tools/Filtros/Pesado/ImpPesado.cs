using ModInventario.FiltrosGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Tools.Filtros.Pesado
{
    public class ImpPesado: IPesado
    {
        private IOpcion _op;


        public BindingSource GetSource { get { return _op.Source; } }
        public string GetId { get { return _op.GetId; } }
        public ficha GetItem { get { return _op.Item; } }


        public ImpPesado()
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
            var r01 = Sistema.MyData.Producto_Pesado_Lista();
            foreach (var rg in r01.Lista.OrderBy(o => o.Descripcion).ToList())
            {
                _list.Add(new ficha(rg.Id.ToString().Trim(), "", rg.Descripcion));
            }
            _op.setData(_list);
        }

        public bool GetHabilitar { get { return true; } }
        public void setHabilitar(bool hab)
        {
        }
    }
}