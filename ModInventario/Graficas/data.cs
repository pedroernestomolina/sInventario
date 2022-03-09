using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Graficas
{
    
    public class data
    {

        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public string Modulo { get; set; }
        public string AutoDeposito { get; set; }


        public bool IsOk 
        {
            get 
            {
                var rt = true;
                if (Modulo == "") rt = false;
                return rt;
            }
        }


        public data()
        {
            Limpiar();
        }


        public void Limpiar() 
        {
            Desde = DateTime.Now.Date;
            Hasta = DateTime.Now.Date;
            Modulo = "";
            AutoDeposito = "";
        }

    }

}