using ModInventario.FiltrosGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Tools.Departamento
{
    public class ImpDepartamento: IDepartamento
    {
        private IOpcion _departamento;


        public BindingSource GetSource { get { return _departamento.Source; } }
        public string GetId { get { return _departamento.GetId; } }
        public object GetItem { get { return _departamento.Item; } }


        public ImpDepartamento()
        {
            _departamento = new FiltrosGen.Opcion.Gestion();
        }


        public void Inicializa()
        {
            _departamento.Inicializa();
        }

        public void setId(string id)
        {
            _departamento.setFicha(id);
        }

        public void CargarData()
        {
            var r01 = Sistema.MyData.Departamento_GetLista();
            var _list = new List<ficha>();
            foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
            {
                _list.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
            }
            _departamento.setData(_list);
        }
    }
}