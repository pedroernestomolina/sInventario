using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.TomaInv.Tools.ExcluirDepart
{
    public class data
    {
        private OOB.LibInventario.Departamento.Ficha _depart;


        public string Descripcion { get { return _depart.nombre; } }
        public bool IsSeleccionado { get; set; }
        public OOB.LibInventario.Departamento.Ficha Departamento { get { return _depart; } }
 

        public data(OOB.LibInventario.Departamento.Ficha depart)
        {
            _depart = depart;
            IsSeleccionado = false;
        }
    }
}