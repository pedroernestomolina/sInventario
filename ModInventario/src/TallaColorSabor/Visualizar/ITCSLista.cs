using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModInventario.src.TallaColorSabor.Visualizar
{
    interface ITCSLista: ILista
    {
        void setLista(List<data> _lst);
        decimal GetCntTotal { get;  }
    }
}
