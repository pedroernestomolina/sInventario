using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Movimiento
{
    
    public class enumerados
    {

        public enum enumTipoEmpaque { PorEmpaqueCompra = 1, PorUnidad };
        public enum enumTipoMovimientoAjuste { SinDefinir=-1, PorEntrada = 1, PorSalida };
        public enum enumTipoMovimiento { SinDefinir = -1, Cargo=1, Descargo, Traslado, Ajuste };

    }

}