using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Precio.VerVisualizar
{
    
    public class dataEmp
    {

        public string etiqueta { get; set; }
        public string empaque { get; set; }
        public int contenido { get; set; }
        public decimal utilidad { get; set; }
        public decimal pNeto { get; set; }
        public decimal pFullDiv { get; set; }
        public decimal tasaIva { get; set; }
        public decimal pNetoDiv { get { return Neto(pFullDiv); } }
        public decimal pFull { get { return Full(pNeto); } }


        public dataEmp() 
        {
            limpiar();
        }

        private decimal Neto(decimal _full)
        {
            var rt = _full;
            if (tasaIva > 0) 
            {
                rt = _full / ((tasaIva / 100) + 1);
            }
            return rt;
        }
        private decimal Full(decimal _neto)
        {
            var rt = _neto;
            if (tasaIva > 0)
            {
                rt = _neto + (_neto + tasaIva * 100);
            }
            return rt;
        }

        public void Limpiar()
        {
            limpiar();
        }

        public void setData(string _etiq, 
                            int _cont, 
                            string _desc, 
                            decimal _neto, 
                            decimal _full, 
                            decimal _ut, 
                            decimal _iva)
        {
            etiqueta = _etiq;
            contenido = _cont;
            empaque = _desc;
            pNeto = _neto;
            pFullDiv = _full;
            utilidad = _ut;
            tasaIva = _iva;
        }


        private void limpiar()
        {
            etiqueta = "";
            empaque = "";
            contenido = 0;
            utilidad = 0m;
            pNeto = 0M;
            pFullDiv = 0m;
            tasaIva = 0m;
        }

    }

}