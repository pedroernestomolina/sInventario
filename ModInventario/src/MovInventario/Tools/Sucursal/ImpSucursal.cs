using ModInventario.FiltrosGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Tools.Sucursal
{
    public class ImpSucursal : ISucursal
    {
        private IOpcion _sucursal;


        public BindingSource GetSource { get { return _sucursal.Source; } }
        public string GetId { get { return _sucursal.GetId; } }
        public object GetItem { get { return _sucursal.Item; } }


        public ImpSucursal()
        {
            _sucursal = new FiltrosGen.Opcion.Gestion();
        }


        public void Inicializa()
        {
            _sucursal.Inicializa();
        }

        public void setId(string id)
        {
            _sucursal.setFicha(id);
        }
        public void CargarData()
        {
            var filtroOOB = new OOB.LibInventario.Sucursal.Filtro() { };
            var r01 = Sistema.MyData.Sucursal_GetLista(filtroOOB);
            var _list = new List<ficha>();
            foreach (var rg in r01.Lista.Where(w => w.IsActivo).OrderBy(o => o.nombre).ToList())
            {
                _list.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
            }
            _sucursal.setData(_list);
        }
    }
}