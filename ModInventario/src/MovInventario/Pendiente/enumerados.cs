using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.MovInventario.Pendiente
{
    public class enumerados
    {
        public enum enumTipoMovTraslado { SinDefinir = -1, TrasladoEntreDepositos = 1, TrasladoPorDevolucion, TrasladoPorNivelMinimo };
        public enum enumTipoDocAbrirPend { SinDefinir = -1, Cargo = 1, Descargo, Trasalado, Ajuste };
    }
}