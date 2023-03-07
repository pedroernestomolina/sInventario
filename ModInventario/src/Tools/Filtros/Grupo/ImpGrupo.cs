using ModInventario.FiltrosGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Tools.Filtros.Grupo
{
    public class ImpGrupo : IGrupo
    {
        private IOpcion _op;


        public BindingSource GetSource { get { return _op.Source; } }
        public string GetId { get { return _op.GetId; } }
        public ficha GetItem { get { return _op.Item; } }


        public ImpGrupo()
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
        public void CargarDataByIdDepartamento(string idDepart)
        {
            var _list = new List<ficha>();
            var r01 = Sistema.MyData.Grupo_GetListaByIdDepartamento(idDepart);
            foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
            {
                _list.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
            }
            _op.setData(_list);
        }
        public void CargarData()
        {
        }

        public bool GetHabilitar { get { return true; } }
        public void setHabilitar(bool hab)
        {
        }
    }
}