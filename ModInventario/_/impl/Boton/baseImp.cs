using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.__.impl.Boton
{
    public abstract class baseImp: interfaces.IBoton
    {
        protected bool _result;
        //
        public bool ResultIsOK { get { return _result; } }
        //
        public baseImp()
        {
            _result= false;
        }
        public void Inicializa()
        {
            _result = false;
        }
        public abstract void Execute();
    }
}