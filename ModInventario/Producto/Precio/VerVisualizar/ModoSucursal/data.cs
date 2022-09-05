using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Precio.VerVisualizar.ModoSucursal
{
    
    public class data
    {

        public string Producto { get; set; }
        public dataEmp emp1_1 { get; set; }
        public dataEmp emp1_2 { get; set; }
        public dataEmp emp1_3 { get; set; }
        public dataEmp emp1_4 { get; set; }
        public dataEmp emp1_5 { get; set; }
        //
        public dataEmp emp2_1 { get; set; }
        public dataEmp emp2_2 { get; set; }
        public dataEmp emp2_3 { get; set; }
        public dataEmp emp2_4 { get; set; }
        public dataEmp emp2_5 { get; set; }
        //
        public dataEmp emp3_1 { get; set; }
        public dataEmp emp3_2 { get; set; }
        public dataEmp emp3_3 { get; set; }
        public dataEmp emp3_4 { get; set; }
        public dataEmp emp3_5 { get; set; }


        public data() 
        {
            emp1_1 = new dataEmp();
            emp1_2 = new dataEmp();
            emp1_3 = new dataEmp();
            emp1_4 = new dataEmp();
            emp1_5 = new dataEmp();
            //
            emp2_1 = new dataEmp();
            emp2_2 = new dataEmp();
            emp2_3 = new dataEmp();
            emp2_4 = new dataEmp();
            emp2_5 = new dataEmp();
            //
            emp3_1 = new dataEmp();
            emp3_2 = new dataEmp();
            emp3_3 = new dataEmp();
            emp3_4 = new dataEmp();
            emp3_5 = new dataEmp();
        }


        public void Inicializa()
        {
            Producto = "";
            //
            emp1_1.Limpiar();
            emp1_2.Limpiar();
            emp1_3.Limpiar();
            emp1_4.Limpiar();
            emp1_5.Limpiar();
            //
            emp2_1.Limpiar();
            emp2_2.Limpiar();
            emp2_3.Limpiar();
            emp2_4.Limpiar();
            emp2_5.Limpiar();
            //
            emp3_1.Limpiar();
            emp3_2.Limpiar();
            emp3_3.Limpiar();
            emp3_4.Limpiar();
            emp3_5.Limpiar();
        }


        public decimal TasaIva { get; set; }
        public string AdmDivisa { get; set; }
        public string ProductoAdmDivisa { get { return AdmDivisa.Trim().ToUpper() == "1" ? "Si" : "No"; } }
        public string ProductoIva { get { return TasaIva > 0m ? TasaIva.ToString("n2") + "%" : "Exento"; } }

    }

}
