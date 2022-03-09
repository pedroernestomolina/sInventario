using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Concepto
{

    public class Ficha
    {
        public string auto { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }


        public Ficha()
        {
            limpiar();
        }


        private void limpiar()
        {
            auto = "";
            codigo = "";
            nombre = "";
        }

        public Ficha(Ficha it)
            : this()            
        {
            auto = it.auto;
            codigo = it.codigo;
            nombre=it.nombre;
        }

    }

}