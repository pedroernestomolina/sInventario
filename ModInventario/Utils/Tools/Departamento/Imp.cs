using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Utils.Tools.Departamento
{
    public class Imp: ICtrl
    {
        private Utils.Filtros.Departamento _ctrl;


        public BindingSource GetSource { get { return _ctrl.Ctrl.GetSource; } }
        public string GetId { get { return _ctrl.Ctrl.GetId; } }
        public object GetItem { get { return _ctrl.Ctrl.GetItem != null ? new ficha(_ctrl.Ctrl.GetItem) : null; } }


        public Imp()
        {
            _ctrl = new Utils.Filtros.Departamento();
        }


        public void Inicializa()
        {
            _ctrl.Ctrl.Inicializa();
        }

        public void setId(string id)
        {
            _ctrl.Ctrl.setFichaById(id);
        }
        public void CargarData()
        {
            _ctrl.CargarData();
        }
        public void LimpiarItemSeleccion()
        {
            _ctrl.Ctrl.LimpiarOpcion();
        }
    }
}