using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.__.impl.Boton
{
    public class ImpBtSalir: baseImp, interfaces.Boton.IBtSalir
    {
        public ImpBtSalir()
            :base()
        {
        }
        public override void Execute()
        {
            _result = true;
        }
    }
}