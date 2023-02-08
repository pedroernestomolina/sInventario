using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Producto.TallaColorSabor
{
    public class data
    {
        public string Descripcion { get; set; }
        public int Id { get; set; }

        public data()
        {
            Descripcion = "";
            Id = -1;
        }
        public data(string desc)
        {
            Descripcion = desc;
            Id = -1;
        }
    }
}