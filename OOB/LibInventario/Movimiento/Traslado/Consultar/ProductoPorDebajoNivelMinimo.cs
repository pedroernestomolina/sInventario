using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Movimiento.Traslado.Consultar
{

    public class ProductoPorDebajoNivelMinimo
    {

        public string autoProducto { get; set; }
        public string autoDepartamento { get; set; }
        public string autoGrupo { get; set; }
        public string codigoProducto { get; set; }
        public string nombreProducto { get; set; }
        public decimal cntUndReponer { get; set; }
        public string categoria { get; set; }
        public string empaqueCompra { get; set; }
        public int contenidEmpCompra { get; set; }
        public string decimales { get; set; }
        public decimal costoFinalUnd { get; set; }
        public decimal costoFinalCompra { get; set; }


        public ProductoPorDebajoNivelMinimo()
        {

            autoDepartamento = "";
            autoGrupo = "";
            autoProducto = "";
            codigoProducto = "";
            nombreProducto = "";
            cntUndReponer = 0.0m;
            categoria = "";
            empaqueCompra = "";
            contenidEmpCompra = 0;
            decimales = "";
            costoFinalUnd = 0.0m;
            costoFinalCompra = 0.0m;
        }

    }

}