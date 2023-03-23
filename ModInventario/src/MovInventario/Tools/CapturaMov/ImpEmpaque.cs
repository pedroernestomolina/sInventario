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
        public void CargarData()
        {
            var _lst = new List<ficha>();
            _lst.Add(new ficha("1", "", "POR EMPQ/COMPRA"));
            _lst.Add(new ficha("3", "", "POR EMPQ/INV"));
            _lst.Add(new ficha("2", "", "POR UNIDAD"));
            _empaque.setData(_lst);
        }
    }
}