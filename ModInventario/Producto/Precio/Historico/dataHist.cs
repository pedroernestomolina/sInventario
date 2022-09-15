using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Precio.Historico
{
    
    public class dataHist
    {

        public string nota { get; set; }
        public string usuarioEstacion { get; set; }
        public string fechaHora { get; set; }
        public decimal precioLocalNeto { get; set; }
        public decimal factorCambio { get; set; }
        public string empContenido { get; set; }
        public string idPrecio { get; set; }
        public decimal precioDivisaNeto 
        { 
            get 
            {
                var rt = 0m;
                if (factorCambio >0)
                {
                    rt = precioLocalNeto / factorCambio;
                }
                return rt;
            } 
        }


        public dataHist()
        {
            nota = "";
            usuarioEstacion = "";
            fechaHora = "";
            precioLocalNeto = 0m;
            factorCambio = 0m;
            empContenido = "";
            idPrecio = "";
        }

    }

}
