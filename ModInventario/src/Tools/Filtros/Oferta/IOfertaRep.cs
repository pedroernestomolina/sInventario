using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Tools.Filtros.Oferta
{
    public interface IOfertaRep: IOferta
    {
        bool GetHabilitar { get; }
        void setActivarFiltro(bool act);
    }
}
