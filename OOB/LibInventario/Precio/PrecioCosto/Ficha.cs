using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Precio.PrecioCosto
{
    
    public class Ficha
    {

        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string nombreTasaIva { get; set; }
        public decimal tasaIva { get; set; }

        public string etiqueta1 { get; set; }
        public string etiqueta2 { get; set; }
        public string etiqueta3 { get; set; }
        public string etiqueta4 { get; set; }
        public string etiqueta5 { get; set; }

        public decimal precioNeto1 { get; set; }
        public decimal precioFull1 { get { return full(precioNeto1, tasaIva); } }
        public decimal precioNeto2 { get; set; }
        public decimal precioFull2 { get { return full(precioNeto2, tasaIva); } }
        public decimal precioNeto3 { get; set; }
        public decimal precioFull3 { get { return full(precioNeto3, tasaIva); } }
        public decimal precioNeto4 { get; set; }
        public decimal precioFull4 { get { return full(precioNeto4, tasaIva); } }
        public decimal precioNeto5 { get; set; }
        public decimal precioFull5 { get { return full(precioNeto5, tasaIva); } }

        public string autoEmp1 { get; set; }
        public string autoEmp2 { get; set; }
        public string autoEmp3 { get; set; }
        public string autoEmp4 { get; set; }
        public string autoEmp5 { get; set; }

        public int contenido1 { get; set; }
        public int contenido2 { get; set; }
        public int contenido3 { get; set; }
        public int contenido4 { get; set; }
        public int contenido5 { get; set; }

        public decimal utilidad1 { get; set; }
        public decimal utilidad2 { get; set; }
        public decimal utilidad3 { get; set; }
        public decimal utilidad4 { get; set; }
        public decimal utilidad5 { get; set; }

        public string admDivisaEstatus { get; set; }
        public OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa admDivisa 
        {
            get 
            {
                var rt = OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa.No;
                if (admDivisaEstatus == "1")
                {
                    rt= OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa.Si;
                }
                return rt;
            }
        }

        public decimal precioFullDivisa1 { get; set; }
        public decimal precioNetoDivisa1 { get { return neto(precioFullDivisa1, tasaIva); } }
        public decimal precioFullDivisa2 { get; set; }
        public decimal precioNetoDivisa2 { get { return neto(precioFullDivisa2, tasaIva); } }
        public decimal precioFullDivisa3 { get; set; }
        public decimal precioNetoDivisa3 { get { return neto(precioFullDivisa3, tasaIva); } }
        public decimal precioFullDivisa4 { get; set; }
        public decimal precioNetoDivisa4 { get { return neto(precioFullDivisa4, tasaIva); } }
        public decimal precioFullDivisa5 { get; set; }
        public decimal precioNetoDivisa5 { get { return neto(precioFullDivisa5, tasaIva); } }

        public string fechaUltimaActCosto { get; set; }
        public string empCompra { get; set; }
        public int contempCompra { get; set; }
        public decimal costoDivisa { get; set; }
        public decimal costoUndDivisa
        {
            get
            {
                var rt = 0.0m;
                rt = costoDivisa / contempCompra;
                return rt;
            }
        }
        public decimal costo { get; set; }
        public decimal costoUnd 
        { 
            get 
            {
                var rt = 0.0m;
                rt = costo / contempCompra;
                return rt;
            } 
        }

        // MAYOR
        public string autoEmpMay1 { get; set; }
        public string autoEmpMay2 { get; set; }
        public string autoEmpMay3 { get; set; }
        public int contenidoMay1 { get; set; }
        public int contenidoMay2 { get; set; }
        public int contenidoMay3 { get; set; }
        public decimal utilidadMay1 { get; set; }
        public decimal utilidadMay2 { get; set; }
        public decimal utilidadMay3 { get; set; }
        public decimal precioNetoMay1 { get; set; }
        public decimal precioNetoMay2 { get; set; }
        public decimal precioNetoMay3 { get; set; }
        public decimal precioFullDivisaMay1 { get; set; }
        public decimal precioFullDivisaMay2 { get; set; }
        public decimal precioFullDivisaMay3 { get; set; }
        public decimal precioFullMay1 { get { return full(precioNetoMay1, tasaIva); } }
        public decimal precioFullMay2 { get { return full(precioNetoMay2, tasaIva); } }
        public decimal precioFullMay3 { get { return full(precioNetoMay3, tasaIva); } }
        public decimal precioNetoDivisaMay1 { get { return neto(precioFullDivisaMay1, tasaIva); } }
        public decimal precioNetoDivisaMay2 { get { return neto(precioFullDivisaMay2, tasaIva); } }
        public decimal precioNetoDivisaMay3 { get { return neto(precioFullDivisaMay3, tasaIva); } }

        
        public Ficha() 
        {
            codigo = "";
            nombre = "";
            descripcion = "";
            nombreTasaIva = "";
            tasaIva = 0.0m;
            admDivisaEstatus = "";
            fechaUltimaActCosto= "";
            empCompra = "";
            contempCompra = 0;
            costoDivisa = 0.0m;
            costo = 0.0m;

            autoEmp1 = "";
            autoEmp2 = "";
            autoEmp3 = "";
            autoEmp4 = "";
            autoEmp5 = "";
            contenido1 = 0;
            contenido2 = 0;
            contenido3 = 0;
            contenido4 = 0;
            contenido5 = 0;
            utilidad1 = 0.0m;
            utilidad2 = 0.0m;
            utilidad3 = 0.0m;
            utilidad4 = 0.0m;
            utilidad5 = 0.0m;
            precioNeto1 = 0.0m;
            precioNeto2 = 0.0m;
            precioNeto3 = 0.0m;
            precioNeto4 = 0.0m;
            precioNeto5 = 0.0m;
            precioFullDivisa1 = 0.0m;
            precioFullDivisa2 = 0.0m;
            precioFullDivisa3 = 0.0m;
            precioFullDivisa4 = 0.0m;
            precioFullDivisa5 = 0.0m;
            etiqueta1 = "";
            etiqueta2 = "";
            etiqueta3 = "";
            etiqueta4 = "";
            etiqueta5 = "";

            // MAYOR
            autoEmpMay1 = "";
            autoEmpMay2 = "";
            autoEmpMay3 = "";
            contenidoMay1 = 0;
            contenidoMay2 = 0;
            contenidoMay3 = 0;
            utilidadMay1 = 0.0m;
            utilidadMay2 = 0.0m;
            utilidadMay3 = 0.0m;
            precioFullDivisaMay1 = 0.0m;
            precioFullDivisaMay2 = 0.0m;
            precioFullDivisaMay3 = 0.0m;
            precioNetoMay1 = 0.0m;
            precioNetoMay2 = 0.0m;
            precioNetoMay3 = 0.0m;
        }

        public decimal full(decimal pn, decimal tasa)
        {
            var rt = 0.0m;
            rt = pn * ((tasa / 100) + 1);
            return rt;
        }

        public decimal neto(decimal pf, decimal tasa) 
        {
            var rt = 0.0m;
            rt = pf / ((tasa / 100) + 1);
            return rt;
        }

    }

}