using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.FiltrosPara.Reportes.tools
{
    public class ImpFecha: IFecha
    {
        private DateTime _fecha;


        public DateTime GetFecha { get { return _fecha; } }


        public ImpFecha()
        {
            limpiarOpcion();
        }


        public void Inicializa()
        {
            limpiarOpcion();
        }
        public void setFecha(DateTime fecha)
        {
            _fecha = fecha;
        }
        public void LimpiarOpcion()
        {
            limpiarOpcion();
        }


        private void limpiarOpcion()
        {
            _fecha= DateTime.Now.Date;
        }
    }
}