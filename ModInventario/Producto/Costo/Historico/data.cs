using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Costo.Historico
{
    
    public class data
    {

        public string nota { get; set; }
        public string usuarioEstacion { get; set; }
        public string fechaHora { get; set; }
        public string serie { get; set; }
        public decimal costoNeto { get; set; }
        public decimal costoDivisa { get; set; }
        public decimal divisa { get; set; }


        public data(OOB.LibInventario.Costo.Historico.Data it)
        {
            nota = it.nota;
            usuarioEstacion = it.usuario.Trim() + " / " + it.estacion.Trim();
            fechaHora = it.fecha.ToShortDateString() + ", " + it.hora;
            serie = it.serie;
            costoNeto = it.costo;
            divisa = it.tasaDivisa;
            costoDivisa = it.costoDivisa;
        }

    }

}
