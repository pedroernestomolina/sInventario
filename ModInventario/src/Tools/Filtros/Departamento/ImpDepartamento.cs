using ModInventario.FiltrosGen;
using ModInventario.src.Tools.Filtros.Grupo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Tools.Filtros.Departamento
{
    public class ImpDepartamento: IDepartamento
    {
        private IOpcion _op;
        private IGrupo _grupo;


        public BindingSource GetSource { get { return _op.Source; } }
        public string GetId { get { return _op.GetId; } }
        public ficha GetItem { get { return _op.Item; } }
        public IGrupo Grupo { get { return _grupo; } }



        public ImpDepartamento()
        {
            _op = new FiltrosGen.Opcion.Gestion();
            _grupo = new ImpGrupo();
        }


        public void Inicializa()
        {
            _op.Inicializa();
            _grupo.Inicializa();
        }

        public void setId(string id)
        {
            if (id != "")
            {
                _op.setFicha(id);
                _grupo.CargarDataByIdDepartamento(id);
            }
            else 
            {
                _grupo.Inicializa();
            }
        }
        public void CargarData()
        {
            var lstDepart = new List<ficha>();
            var r01 = Sistema.MyData.Departamento_GetLista();
            foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
            {
                lstDepart.Add(new ficha(rg.auto, "", rg.nombre));
            }
            _op.setData(lstDepart);
        }

        public bool GetHabilitar { get { return true; } }
        public void setHabilitar(bool hab)
        {
        }
    }
}