using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Producto.Depositos.Ver
{
    
    public class Ficha
    {

        public string autoProducto { get; set; }
        public string codigoProducto { get; set; }
        public string nombreProducto { get; set; }
        public string referenciaProducto { get; set; }
        public int contenidoCompra { get; set; }
        public string empaqueCompra { get; set; }

        public string autoDeposito { get; set; }
        public string codigoDeposito { get; set; }
        public string nombreDeposito { get; set; }

        public decimal fisica { get; set; }
        public decimal reservada { get; set; }
        public decimal disponible { get; set; }
        public decimal averia { get; set; }
        public string ubicacion_1 { get; set; }
        public string ubicacion_2 { get; set; }
        public string ubicacion_3 { get; set; }
        public string ubicacion_4 { get; set; }
        public int nivelMinimo { get; set; }
        public int nivelOptimo { get; set; }
        public int ptoPedido { get; set; }
        public string fechaUltConteo { get; set; }
        public decimal resultadoUltConteo { get; set; }


        public void Limpiar()
        {
            autoDeposito = "";
            autoProducto = "";
            codigoDeposito = "";
            codigoProducto = "";
            nombreDeposito = "";
            nombreProducto = "";

            ubicacion_1 = "";
            ubicacion_2 = "";
            ubicacion_3 = "";
            ubicacion_4 = "";

            fisica = 0.0m;
            disponible = 0.0m;
            reservada = 0.0m;
            averia = 0.0m;

            nivelMinimo = 0;
            nivelOptimo = 0;
            ptoPedido = 0;
        }

    }

}