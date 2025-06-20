using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.__.impl.Boton
{
    public class ImpBtProcesar: baseImp, interfaces.Boton.IBtProcesar
    {
        public ImpBtProcesar()
            :base()
        {
        }
        public override void Execute()
        {
            _result = Helpers.Msg.ProcesarGuardar();
        }
    }
}
