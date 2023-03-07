using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Tools.CapturaMov
{
    public class ImpEmpaque: IEmpaque
    {
        private FiltrosGen.IOpcion _empaque;


        public BindingSource GetSource { get { return _empaque.Source; } }
        public string GetId { get { return _empaque.GetId; } }
        public ficha GetItem { get { return _empaque.Item; } }


        public ImpEmpaque()
        {
            _empaque = new FiltrosGen.Opcion.Gestion();
        }


        public void setEmpaque(string id)
        {
            _empaque.setFicha(id);
        }

        public void Inicializa()
        {
            _empaque.Inicializa();
        }
        public void CargarData(List<ficha> lst)
        {
            _empaque.setData(lst);
        }
    }
}