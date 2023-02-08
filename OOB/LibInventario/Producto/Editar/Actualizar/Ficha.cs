using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Producto.Editar.Actualizar
{
    public class Ficha
    {
        public string auto { get; set; }
        public string autoDepartamento { get; set; }
        public string autoGrupo { get; set; }
        public string autoMarca { get; set; }
        public string autoTasaImpuesto { get; set; }
        public string autoEmpCompra { get; set; }
        public string autoEmpInv { get; set; }

        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string modelo { get; set; }
        public string referencia { get; set; }
        public int contenidoCompra { get; set; }
        public int contenidoInv { get; set; }
        public decimal tasaImpuesto { get; set; }

        public string origen { get; set; }
        public string categoria { get; set; }
        public string estatusDivisa { get; set; }
        public string abc { get; set; }
        public byte[] imagen { get; set; }
        public string esPesado { get; set; }
        public string plu { get; set; }
        public int diasEmpaque { get; set; }
        public string estatusCatalogo { get; set; }
        public List<FichaCodigoAlterno> codigosAlterno { get; set; }
        public decimal peso { get; set; }
        public decimal volumen { get; set; }
        public decimal alto { get; set; }
        public decimal largo { get; set; }
        public decimal ancho { get; set; }
        //
        public string autoEmpVentaTipo_1 { get; set; }
        public string autoEmpVentaTipo_2 { get; set; }
        public string autoEmpVentaTipo_3 { get; set; }
        public int contEmpVentaTipo_1 { get; set; }
        public int contEmpVentaTipo_2 { get; set; }
        public int contEmpVentaTipo_3 { get; set; }
        //
        public FichaTallaColorSabor tallaColorSabor { get; set; }


        public Ficha() 
        {
            auto = "";
            autoDepartamento = "";
            autoEmpCompra = "";
            autoEmpInv = "";
            autoGrupo = "";
            autoMarca = "";
            autoTasaImpuesto = "";

            codigo="";
            nombre="";
            descripcion="";
            modelo="";
            referencia="";
            contenidoCompra=1;
            contenidoInv=1;
            tasaImpuesto=0m;

            origen="";
            categoria="";
            estatusDivisa="";
            abc="";
            esPesado="";
            plu="";
            diasEmpaque=0;
            estatusCatalogo="";
            peso=0m;
            volumen=0m;
            alto = 0m;
            largo = 0m;
            ancho = 0m;
            imagen = new byte[] { };
            codigosAlterno=null;

            autoEmpVentaTipo_1 = "";
            autoEmpVentaTipo_2 = "";
            autoEmpVentaTipo_3 = "";
            contEmpVentaTipo_1 = 1;
            contEmpVentaTipo_2 = 1;
            contEmpVentaTipo_3 = 1;
        }
    }
}