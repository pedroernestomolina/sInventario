using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Precio.VerVisualizar.ModoBasico
{
    
    public class data
    {

        public string Producto { get; set; }
        public dataEmp emp1_1 { get; set; }
        public dataEmp emp1_2 { get; set; }
        public dataEmp emp1_3 { get; set; }


        public data() 
        {
            emp1_1 = new dataEmp();
            emp1_2 = new dataEmp();
            emp1_3 = new dataEmp();
        }


        public void Inicializa()
        {
            Producto = "";
            //
            emp1_1.Limpiar();
            emp1_2.Limpiar();
            emp1_3.Limpiar();
        }


        public decimal TasaIva { get; set; }
        public string AdmDivisa { get; set; }
        public string ProductoAdmDivisa { get { return AdmDivisa.Trim().ToUpper() == "1" ? "Si" : "No"; } }
        public string ProductoIva { get { return TasaIva > 0m ? TasaIva.ToString("n2") + "%" : "Exento"; } }

    }

}