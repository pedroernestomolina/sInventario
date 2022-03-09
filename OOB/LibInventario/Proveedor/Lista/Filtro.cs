using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Proveedor.Lista
{
    
    public class Filtro
    {

        public string cadena { get; set; }
        public Enumerados.EnumMetodoBusqueda MetodoBusqueda { get; set; }


        public void Limpiar()
        {
            cadena = "";
            MetodoBusqueda = Enumerados.EnumMetodoBusqueda.SnDefinir;
        }

    }

}