using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.Filtros.Fecha
{
    public class ImpFiltro: IFiltro
    {
        private DateTime _fecha;
        private bool _habilitarFecha;


        public DateTime? Valor { get { return _habilitarFecha ? _fecha : (DateTime?)null; } }
        public DateTime GetFecha { get { return _fecha; } }


        public ImpFiltro()
        {
            limpiarOpcion();
        }


        public void setFecha(DateTime fecha)
        {
            _fecha= fecha;
            _habilitarFecha = true;
        }
        public void setHabilitarFecha(bool bl)
        {
            _habilitarFecha = bl;
        }


        public void Inicializa()
        {
            limpiarOpcion();
        }
        public void LimpiarOpcion()
        {
            limpiarOpcion();
        }
        public void setHabilitarOff()
        {
            setHabilitarFecha(false);
        }


        private void limpiarOpcion()
        {
            _fecha= DateTime.Now.Date;
            _habilitarFecha = true;
        }
    }
}