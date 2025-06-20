using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.__.impl.Boton
{
    public class ImpBtAbandonar: baseImp, interfaces.Boton.IBtAbandonar
    {
        public ImpBtAbandonar()
            :base()
        {
        }
        public override void Execute()
        {
            _result= Helpers.Msg.Abandonar();
        }
    }
}
