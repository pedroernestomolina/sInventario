using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Costo.Ver
{
    
    public class costo
    {


        private decimal netoUnd;
        private decimal tasaIva;
        private int contenido;


        public decimal EmpNeto 
        {
            get 
            {
                var rt = 0.0m;
                rt = netoUnd * contenido;
                return rt;
            }
        }

        public decimal EmpFull
        {
            get
            {
                var rt = 0.0m;
                rt = EmpNeto + (EmpNeto * tasaIva /100);
                return rt;
            }
        }

        public decimal UndFull
        {
            get
            {
                var rt = 0.0m;
                rt = EmpFull / contenido ;
                return rt;
            }
        }

        public decimal UndNeto
        {
            get
            {
                var rt = 0.0m;
                rt = netoUnd ;
                return rt;
            }
        }


        public void Limpiar()
        {
        }

        public void setFicha(int cont, decimal iva, decimal costoUnd)
        {
            contenido = cont;
            netoUnd = costoUnd;
            tasaIva = iva;
        }

    }

}