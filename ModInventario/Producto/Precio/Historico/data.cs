using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Precio.Historico
{
    
    public class data
    {


        public string nota { get; set; }
        public string usuarioEstacion { get; set; }
        public string fechaHora { get; set; }
        public string precioNeto { get; set; }
        public string etqPrecio { get; set; }


        public data(OOB.LibInventario.Precio.Historico.Data it)
        {
            nota = it.nota;
            usuarioEstacion = it.usuario.Trim() + " / " + it.estacion.Trim();
            fechaHora = it.fecha.ToShortDateString() + ", " + it.hora;
            precioNeto = it.precio.ToString("n2");
            etqPrecio = it.etqPrecio;
        }

    }

}