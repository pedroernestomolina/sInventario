using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Tools.CapturaMov
{
    public class ImpTipMov: ITipMov
    {
        private FiltrosGen.IOpcion _tipMov;


        public BindingSource GetSource { get { return _tipMov.Source; } }
        public string GetId { get { return _tipMov.GetId; } }
        public ficha GetItem { get { return _tipMov.Item; } }


        public ImpTipMov()
        {
            _tipMov = new FiltrosGen.Opcion.Gestion();
        }


        public void setTipMov(string id)
        {
            _tipMov.setFicha(id);
        }
        public void Inicializa()
        {
            _tipMov.Inicializa();
        }
        public void CargarData()
        {
            var _lst = new List<ficha>();
            _lst.Add(new ficha("1", "", "CARGO"));
            _lst.Add(new ficha("2", "", "DESCARGO"));
            _tipMov.setData(_lst);
        }
    }
}