using ModInventario.FiltrosGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Tools.Filtros.Oferta
{
    public class ImpOferta: IOferta
    {
        private IOpcion _op;


        public BindingSource GetSource { get { return _op.Source; } }
        public ficha GetItem { get { return _op.Item; } }
        public string GetId { get { return _op.GetId; } }


        public ImpOferta()
        {
            _op = new FiltrosGen.Opcion.Gestion();
        }

        public void setId(string id)
        {
            _op.setFicha(id);
        }

        public virtual void Inicializa()
        {
            _op.Inicializa();
        }

        public void CargarData()
        {
            var _lst= new List<ficha>();
            _lst.Add(new ficha("1", "", "SI"));
            _lst.Add(new ficha("2", "", "NO"));
            _op.setData(_lst);
        }
    }
}