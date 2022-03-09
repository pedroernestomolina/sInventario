using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OOB.LibInventario.Producto.Data
{
    
    public class Precio
    {

        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string nombreTasaIva { get; set; }
        public decimal tasaIva { get; set; }
        public Enumerados.EnumEstatus estatus { get; set; }

        public string etiqueta1 { get; set; }
        public string etiqueta2 { get; set; }
        public string etiqueta3 { get; set; }
        public string etiqueta4 { get; set; }
        public string etiqueta5 { get; set; }
        public string etiquetaMay1 { get; set; }
        public string etiquetaMay2 { get; set; }

        public decimal precioNeto1 { get; set; }
        public decimal precioNeto2 { get; set; }
        public decimal precioNeto3 { get; set; }
        public decimal precioNeto4 { get; set; }
        public decimal precioNeto5 { get; set; }
        public decimal precioNetoMay1 { get; set; }
        public decimal precioNetoMay2 { get; set; }

        public string empaque1 { get; set; }
        public string empaque2 { get; set; }
        public string empaque3 { get; set; }
        public string empaque4 { get; set; }
        public string empaque5 { get; set; }
        public string empaqueMay1 { get; set; }
        public string empaqueMay2 { get; set; }

        public int contenido1 { get; set; }
        public int contenido2 { get; set; }
        public int contenido3 { get; set; }
        public int contenido4 { get; set; }
        public int contenido5 { get; set; }
        public int contenidoMay1 { get; set; }
        public int contenidoMay2 { get; set; }

        public decimal utilidad1 { get; set; }
        public decimal utilidad2 { get; set; }
        public decimal utilidad3 { get; set; }
        public decimal utilidad4 { get; set; }
        public decimal utilidad5 { get; set; }
        public decimal utilidadMay1 { get; set; }
        public decimal utilidadMay2 { get; set; }

        public decimal precioSugerido { get; set; }

        public Enumerados.EnumOferta estatusOferta { get; set; }
        public Enumerados.EnumOferta ofertaActiva { get; set; }
        public Enumerados.EnumAdministradorPorDivisa admDivisa { get; set; }

        public decimal precioOferta { get; set; }
        public DateTime? inicioOferta { get; set; }
        public DateTime? finOferta { get; set; }

        public decimal precioFullDivisa1 { get; set; }
        public decimal precioFullDivisa2 { get; set; }
        public decimal precioFullDivisa3 { get; set; }
        public decimal precioFullDivisa4 { get; set; }
        public decimal precioFullDivisa5 { get; set; }
        public decimal precioFullDivisaMay1 { get; set; }
        public decimal precioFullDivisaMay2 { get; set; }


        public Precio()
        {
            tasaIva=0.0m;
            estatus = Enumerados.EnumEstatus.SnDefinir;

            etiqueta1 = "Precio 1: ";
            etiqueta2 = "Precio 2: ";
            etiqueta3 = "Precio 3: ";
            etiqueta4 = "Precio 4: ";
            etiqueta5 = "Precio 5: ";
            etiquetaMay1 = "Mayor 1:";
            etiquetaMay2 = "Mayor 2:";

            precioNeto1 = 0.0m;
            precioNeto2 = 0.0m;
            precioNeto3 = 0.0m;
            precioNeto4 = 0.0m;
            precioNeto5 = 0.0m;
            precioNetoMay1 = 0.0m;
            precioNetoMay2 = 0.0m;

            contenido1 = 0;
            contenido2 = 0;
            contenido3 = 0;
            contenido4 = 0;
            contenido5 = 0;
            contenidoMay1 = 0;
            contenidoMay2 = 0;

            utilidad1 = 0.0m;
            utilidad2 = 0.0m;
            utilidad3 = 0.0m;
            utilidad4 = 0.0m;
            utilidad5 = 0.0m;
            utilidadMay1 = 0.0m;
            utilidadMay2 = 0.0m;

            precioSugerido = 0.0m;

            estatusOferta = Enumerados.EnumOferta.SnDefinir;
            ofertaActiva = Enumerados.EnumOferta.SnDefinir;
            admDivisa = Enumerados.EnumAdministradorPorDivisa.SnDefinir;

            precioOferta = 0.0m;
            inicioOferta = null;
            finOferta = null;

            precioFullDivisa1 = 0.0m;
            precioFullDivisa2 = 0.0m;
            precioFullDivisa3 = 0.0m;
            precioFullDivisa4 = 0.0m;
            precioFullDivisa5 = 0.0m;
            precioFullDivisaMay1 = 0.0m;
            precioFullDivisaMay2 = 0.0m;
        }

    }

}