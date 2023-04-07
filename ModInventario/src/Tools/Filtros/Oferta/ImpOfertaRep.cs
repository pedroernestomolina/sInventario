using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Tools.Filtros.Oferta
{
    public class ImpOfertaRep: ImpOferta, IOfertaRep
    {
        private bool _activarFiltro;


        public bool GetHabilitar { get { return _activarFiltro; } }


        public ImpOfertaRep()
            :base()
        {
            _activarFiltro = false;
        }


        public void setActivarFiltro(bool act)
        {
            _activarFiltro = act;
        }

        public override void Inicializa()
        {
            base.Inicializa();
            _activarFiltro = false;
        }
    }
}