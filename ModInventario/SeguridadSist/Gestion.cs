using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.SeguridadSist
{

    public class Gestion : ISeguridad
    {

        private bool _aceptarIsOk;
        private bool _abandonarIsOk;
        private IModo _gestion;


        public string Titulo { get { return _gestion.Titulo; } }
        public bool IsOk { get { return _aceptarIsOk; } }
        public bool AceptarIsOk { get { return _aceptarIsOk; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }


        public Gestion()
        {
            _aceptarIsOk = false;
            _abandonarIsOk = false;
        }


        public void setGestionTipo(IModo modo)
        {
            _gestion = modo;
        }

        public void Inicializa()
        {
            _aceptarIsOk = false;
            _abandonarIsOk = false;
            _gestion.Inicializa();
        }

        SeguridadFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new SeguridadFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return true;
        }

        public void setClave(string p)
        {
            _gestion.setClave(p);
        }

        public void Aceptar()
        {
            _aceptarIsOk = _gestion.AceptarVerificar();
        }

        public void Abandonar()
        {
            _abandonarIsOk = true;
        }

    }

}