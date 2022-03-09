using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.HistoricoPrecio
{
    
    public class data
    {

        private OOB.LibInventario.Precio.Historico.Data _it;


        public string nota { get { return _it.nota; } }
        public string usuarioEstacion { get { return _it.usuario.Trim() + " / " + _it.estacion.Trim(); } }
        public string fechaHora { get { return _it.fecha.ToShortDateString() + ", " + _it.hora; } }
        public string precioNeto { get { return _it.precio.ToString("n2"); } }
        public string etqPrecio { get { return _it.etqPrecio; } }


        public data(OOB.LibInventario.Precio.Historico.Data it)
        {
            _it = it;
        }

    }

}