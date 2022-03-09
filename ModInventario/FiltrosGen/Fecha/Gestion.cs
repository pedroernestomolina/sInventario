using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.FiltrosGen.Fecha
{

    public class Gestion: IFecha
    {

        private DateTime _fecha;
        private bool _isOn;


        public DateTime GetFecha { get { return _fecha; } }
        public DateTime? FechaFiltro { get { return _isOn ? _fecha : (DateTime?) null; } }


        public Gestion() 
        {
            limpiar();
        }


        void IFecha.setFecha(DateTime fecha)
        {
            _fecha = fecha;
            _isOn = true;
        }

        void IFecha.setEstatusOff()
        {
            _isOn = false;
        }

        public void Limpiar()
        {
            limpiar();
        }

        public void Inicializa()
        {
            limpiar();
        }

        private void limpiar()
        {
            _fecha = DateTime.Now.Date;
            _isOn = true;
        }

    }

}