using ModInventario.FiltrosGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Tools.Filtros.Origen
{
    public class ImpOrigen: IOrigen
    {
        private IOpcion _op;


        public BindingSource GetSource { get { return _op.Source; } }
        public string GetId { get { return _op.GetId; } }
        public ficha GetItem { get { return _op.Item; } }


        public ImpOrigen()
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
            var r01 = Sistema.MyData.Producto_Origen_Lista();
            foreach (var rg in r01.Lista.OrderBy(o => o.Descripcion).ToList())
            {
                _list.Add(new ficha(rg.Id, "", rg.Descripcion));
            }
            _op.setData(_list);
        }

        public bool GetHabilitar { get { return true; } }
        public void setHabilitar(bool hab)
        {
        }
    }
}