using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OOB.LibInventario.Producto.Data
{
    
    public class Costo
    {

        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string nombreTasaIva { get; set; }
        public decimal tasaIva { get; set; }
        public Enumerados.EnumEstatus estatus { get; set; }
        public Enumerados.EnumAdministradorPorDivisa admDivisa { get; set; }
        public string empaqueCompra { get; set; }
        public int contEmpaqueCompra { get; set; }

        public decimal costoProveedorUnd { get; set; }
        public decimal costoImportacionUnd { get; set; }
        public decimal costoVarioUnd { get; set; }
        public decimal costoDivisaUnd { get; set; }
        public decimal costoUnd { get; set; }
        public decimal costoPromedioUnd { get; set; }
        public string fechaUltCambio { get; set; }
        public int Edad { get; set; }


        public Costo()
        {
            codigo = "";
            nombre = "";
            descripcion = "";
            nombreTasaIva = "";
            tasaIva = 0;
            empaqueCompra = "";
            contEmpaqueCompra = 1;
            estatus = Enumerados.EnumEstatus.SnDefinir;
            admDivisa = Enumerados.EnumAdministradorPorDivisa.SnDefinir;

            costoDivisaUnd = 0.0m;
            costoImportacionUnd = 0.0m;
            costoPromedioUnd = 0.0m;
            costoProveedorUnd=0.0m;
            costoUnd = 0.0m;
            costoVarioUnd = 0.0m;
            fechaUltCambio = "";
            Edad = 0;
        }

        public Costo(Costo ficha) 
            : this()
        {
            codigo = ficha.codigo;
            nombre = ficha.nombre;
            descripcion = ficha.descripcion;
            nombreTasaIva = ficha.nombreTasaIva;
            tasaIva = ficha.tasaIva;
            empaqueCompra = ficha.empaqueCompra;
            contEmpaqueCompra = ficha.contEmpaqueCompra;
            estatus = ficha.estatus;
            admDivisa = ficha.admDivisa;
            costoDivisaUnd = ficha.costoDivisaUnd;
            costoImportacionUnd = ficha.costoImportacionUnd;
            costoPromedioUnd = ficha.costoPromedioUnd;
            costoProveedorUnd = ficha.costoProveedorUnd;
            costoUnd = ficha.costoUnd;
            costoVarioUnd = ficha.costoVarioUnd;
            fechaUltCambio = ficha.fechaUltCambio;
            Edad = ficha.Edad;
        }

    }

}