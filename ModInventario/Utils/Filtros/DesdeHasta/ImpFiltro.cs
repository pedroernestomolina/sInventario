using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.Filtros.DesdeHasta
{
    public class ImpFiltro: IFiltro
    {
        private Fecha.IFiltro _desde;
        private Fecha.IFiltro _hasta;


        public Fecha.IFiltro Desde { get { return _desde; } }
        public Fecha.IFiltro Hasta { get { return _hasta; } }


        public ImpFiltro()
        {
            _desde = new Utils.Filtros.Fecha.ImpFiltro();
            _hasta = new Utils.Filtros.Fecha.ImpFiltro(); 
        }


        public void Inicializa()
        {
            _desde.Inicializa();
            _hasta.Inicializa();
        }
        public void LimpiarOpcion()
        {
            _desde.LimpiarOpcion();
            _hasta.LimpiarOpcion();
        }
    }
}
