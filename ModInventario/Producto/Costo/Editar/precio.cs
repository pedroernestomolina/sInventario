using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Costo.Editar
{

    public class precio
    {

        public enum enumUtilidadMetodo { SinDefinir=-1, Lineal=1, Financiero } ;
        public enum enumModoRedondeo { SinDefinir = -1, SinRedondeo = 1, Unidad, Decena };
        public enum enumPreferenciaPrecio { SinDefinir = -1, Neto = 1, Full };


        private enumUtilidadMetodo  metodoCalculo;
        private enumModoRedondeo modoRedondeo;
        private enumPreferenciaPrecio preferenciaPrecio;
        private decimal utilidad;
        private decimal neto; 
        private decimal tasa;
        private bool recalcular;


        public decimal Neto { get { return neto; } }
        public decimal Utilidad { get { return utilidad; } }
        public bool Recalcular { get { return recalcular; } }


        public precio()
        {
            Limpiar();
        }


        public void Limpiar()
        {
            utilidad = 0.0m;
            neto = 0.0m;
            tasa = 0.0m;
            metodoCalculo = enumUtilidadMetodo.SinDefinir;
            modoRedondeo = enumModoRedondeo.SinDefinir;
            preferenciaPrecio = enumPreferenciaPrecio.SinDefinir;
        }

        public void setFicha(decimal ut, decimal nt, decimal ts, enumUtilidadMetodo metodo, enumModoRedondeo redondeo, enumPreferenciaPrecio prefPrec)
        {
            recalcular = false;
            if (nt > 0)
                recalcular = true;
            utilidad = ut;
            neto = nt;
            tasa = ts;
            metodoCalculo = metodo;
            modoRedondeo=redondeo;
            preferenciaPrecio=prefPrec;
        }

        public void ActualizarPrecio(decimal cost)
        {
            if (metodoCalculo == enumUtilidadMetodo.Lineal) 
            {
                neto = cost + (cost * utilidad / 100);
            }
            if (metodoCalculo == enumUtilidadMetodo.Financiero) 
            {
                if (utilidad >= 100) { utilidad = 0; }
                neto = cost / ((100 - utilidad) / 100);
            }

            if (preferenciaPrecio == enumPreferenciaPrecio.Neto)
            {
                switch (modoRedondeo)
                {
                    case enumModoRedondeo.SinRedondeo:
                        neto = Math.Round(neto, 2, MidpointRounding.AwayFromZero);
                        break;
                    case enumModoRedondeo.Unidad:
                        neto = Helpers.MetodosExtension.RoundUnidad((int)neto);
                        break;
                    case enumModoRedondeo.Decena:
                        neto = Helpers.MetodosExtension.RoundDecena((int)neto);
                        break;
                }
            }

            if (preferenciaPrecio == enumPreferenciaPrecio.Full)
            {
                var full = neto + CalculaIva(neto);
                switch (modoRedondeo)
                {
                    case enumModoRedondeo.SinRedondeo:
                        break;
                    case enumModoRedondeo.Unidad:
                        full = Helpers.MetodosExtension.RoundUnidad((int)full);
                        break;
                    case enumModoRedondeo.Decena:
                        full = Helpers.MetodosExtension.RoundDecena((int)full);
                        break;
                }
                neto = CalculaBase(full);
            }
        }

        private decimal CalculaIva(decimal monto)
        {
            return monto*tasa/100;
        }

        private decimal CalculaBase(decimal monto)
        {
            return monto / ((tasa / 100)+1);
        }


        public void ActualizarUtilidad(decimal cost)
        {
            if (cost == 0.0m || neto == 0.0m)
            {
                utilidad = 0.0m;
            }
            else
            {
                if (metodoCalculo == enumUtilidadMetodo.Lineal)
                {
                    utilidad = ((neto / cost) - 1) * 100;
                }
                if (metodoCalculo == enumUtilidadMetodo.Financiero)
                {
                    utilidad = (1 - (cost / neto)) * 100;
                }
                utilidad = Math.Round(utilidad, 2, MidpointRounding.AwayFromZero);
            }
        }

    }

}