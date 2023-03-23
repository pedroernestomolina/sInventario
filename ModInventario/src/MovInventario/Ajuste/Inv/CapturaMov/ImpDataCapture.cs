using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModInventario.src.MovInventario.Ajuste.Inv.CapturaMov
{
    public class ImpDataCapture: MovInventario.Tools.CapturaMov.ImpDataCaptura 
    {
        public override bool ValidarParaProcesarIsOk()
        {
            if (_tipMov.GetId == "")
            {
                Helpers.Msg.Alerta("CAMPO [ TIPO MOVIMIENTO ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_empaque.GetId == "")
            {
                Helpers.Msg.Alerta("CAMPO [ EMPAQUE ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (Math.Abs(_item.Importe)== 0m)
            {
                Helpers.Msg.Alerta("MONTO MOVIMIENTO NO PUEDE SER CERO (0)");
                return false;
            }
            return true;
        }
    }
}
