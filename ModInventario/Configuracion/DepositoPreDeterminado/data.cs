using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Configuracion.DepositoPreDeterminado
{
    
    public class data
    {

        private OOB.LibInventario.Deposito.Ficha _dep;


        public bool isPreDet { get; set; }
        public string depNombre { get { return _dep.nombre; } }
        public string depCodigo { get { return _dep.codigo; } }
        public OOB.LibInventario.Deposito.Ficha  depositoFicha { get { return _dep; } }


        public data() 
        {
            isPreDet = false;
        }

        public data(OOB.LibInventario.Deposito.Ficha dep)
            :this()
        {
            this._dep = dep;
            isPreDet = dep.IsPerDeterminado;
        }

    }

}