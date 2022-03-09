using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Maestros
{
    
    public class data
    {

        public string id { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }


        public data(OOB.LibInventario.Concepto.Ficha it)
        {
            id = it.auto;
            codigo = it.codigo;
            descripcion = it.nombre;
        }

        public data(OOB.LibInventario.Departamento.Ficha it)
        {
            id = it.auto;
            codigo = it.codigo;
            descripcion = it.nombre;
        }

        public data(OOB.LibInventario.Grupo.Ficha it)
        {
            id = it.auto;
            codigo = it.codigo;
            descripcion = it.nombre;
        }

        public data(OOB.LibInventario.Marca.Ficha it)
        {
            id = it.auto;
            descripcion = it.nombre;
        }

        public data(OOB.LibInventario.EmpaqueMedida.Ficha it)
        {
            id = it.auto;
            codigo = it.decimales;
            descripcion = it.nombre;
        }

    }

}