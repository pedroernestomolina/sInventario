using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Kardex.Movimiento.Resumen
{
    
    public class Ficha
    {

        public string codigoProducto { get; set; }
        public string nombreProducto { get; set; }
        public string referenciaProducto { get; set; }
        public decimal existenciaActual { get; set; }
        public decimal existenciaFecha { get; set; }
        public string fecha { get; set; }
        public int contenidoEmp { get; set; }
        public string empaqueCompra { get; set; }
        public string decimales { get; set; }
        public List<Data> Data { get; set; }


        public Ficha()
        {
            Limpiar();
        }


        public void Limpiar()
        {
            codigoProducto = "";
            nombreProducto = "";
            referenciaProducto = "";
            existenciaActual = 0.0m;
            existenciaFecha = 0.0m;
            fecha = "";
            contenidoEmp = 0;
            empaqueCompra = "";
            decimales = "";
        }

    }

}