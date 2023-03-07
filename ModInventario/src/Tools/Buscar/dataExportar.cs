using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Tools.Buscar
{
    public class dataExportar
    {
        public string Cadena { get; set; }
        public ficha MetodoBusqueda { get; set; }
        public int MetodoValor 
        { 
            get 
            {
                var r = -1;
                if (MetodoBusqueda != null) 
                {
                    switch (MetodoBusqueda.id) 
                    {
                        case "01":
                            r = 1;
                            break;
                        case "02":
                            r = 2;
                            break;
                        case "03":
                            r = 3;
                            break;
                        case "04":
                            r = 4;
                            break;
                        default:
                            r = -1;
                            break;
                    }
                }
                return r;
            } 
        }
        public bool IsOk() 
        {
            var r = false;
            if (!string.IsNullOrEmpty(Cadena.Trim()) && MetodoBusqueda != null) 
            {
                r = true;
            }
            return r;
        }
    }
}