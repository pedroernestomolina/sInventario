using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Helpers
{
    
    public static class MetodosExtension
    {

        public static int RoundUnidad(this int i)
        {
            return ((int)Math.Round(i / 10.0)) * 10;
        }

        public static int RoundDecena(this int i)
        {
            return ((int)Math.Round(i / 100.0)) * 100;
        }

    }

}