using ModInventario.FiltrosGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Tools.Filtros.Estatus
{
    public class ImpEstatus: IEstatus
    {
        private IOpcion _op;


        public BindingSource GetSource { get { return _op.Source; } }
        public string GetId { get { return _op.GetId; } }
        public ficha GetItem { get { return _op.Item; } }


        public ImpEstatus()
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
            var _list= new List<ficha>();
            _list.Add(new ficha("01", "", "ACTIVO"));
            _list.Add(new ficha("03", "", "INACTIVO"));
            _op.setData(_list);
        }

        public bool GetHabilitar { get { return true; } }
        public void setHabilitar(bool hab)
        {
        }
    }
}