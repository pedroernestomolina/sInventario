using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.AgregarEditar.Editar
{
    
    public class precio
    {

        public decimal divisaFull;
        public decimal neto;


        public precio()
        {
            divisaFull = 0.0m;
            neto = 0.0m;
        }


        public void Calculo_AdmDivisa(decimal factorCambio, decimal tasaIva, decimal pFull , decimal pNeto,
            OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio preferenciaRegistroPrecio)
        {
            if ( preferenciaRegistroPrecio == OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio.Full)
            {
                var pdf = pFull ;
                var xn = pdf / ((tasaIva / 100) + 1);
                xn = xn * factorCambio;

                divisaFull = pdf;
                neto = Math.Round(xn, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                var pdn = pNeto ;
                var xf = pdn * ((tasaIva / 100) + 1);

                divisaFull = xf;
                neto = pdn * factorCambio ;
                neto = Math.Round(neto, 2, MidpointRounding.AwayFromZero);
            }
        }

        public void Calculo_NoAdmDivisa(decimal factorCambio, decimal tasaIva, decimal pFull , decimal pNeto,
            OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio preferenciaRegistroPrecio)
        {
            if (preferenciaRegistroPrecio == OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio.Neto)
            {
                var pn = pNeto;
                var xf = pn * ((tasaIva / 100) + 1);

                divisaFull = xf/factorCambio;
                divisaFull = Math.Round(divisaFull, 2, MidpointRounding.AwayFromZero);
                neto =pn ;
            }
            else
            {
                var pdf = pFull;
                var xn1 = pdf / ((tasaIva / 100) + 1);

                divisaFull = pdf/ factorCambio ;
                divisaFull = Math.Round(divisaFull, 2, MidpointRounding.AwayFromZero);
                neto = Math.Round(xn1, 2, MidpointRounding.AwayFromZero);
            }
        }

    }

}
