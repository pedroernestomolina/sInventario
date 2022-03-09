using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Maestros
{
    
    public class Gestion
    {


        private IGestion _gestion;


        public string Maestro { get { return _gestion.Maestro; } }
        public int TotalItems { get { return _gestion.TotalItems; } }
        public BindingSource Source { get { return _gestion.Source; } }
        public bool IsMarca { get { return _gestion.IsMarca; } }
        public bool IsEmpaqueMedida { get { return _gestion.IsEmpaqueMedida; } }


        public Gestion()
        {
        }


        public void setGestion(IGestion gestion)
        {
            _gestion = gestion;
        }

        MaestroFrm frm;
        public void Inicia()
        {
            if (_gestion.CargarData())
            {
                frm = new MaestroFrm();
                frm.setControlador(this);
                if (frm == null)
                {
                    frm = new MaestroFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        public void AgregarItem()
        {
            _gestion.AgregarItem();
        }

        public void EditarItem()
        {
            _gestion.EditarItem();
        }

        public void EliminarItem()
        {
            _gestion.EliminarItem();
        }

    }

}