using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModInventario.FiltrosGen.AdmDoc
{

    public class data
    {

        public ficha Producto { get; set; }
        public ficha DepOrigen { get; set; }
        public ficha DepDestino { get; set; }
        public ficha Concepto { get; set; }
        public ficha Estatus { get; set; }
        public ficha Sucursal { get; set; }
        public ficha TipoDoc { get; set; }
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }


        public data() 
        {
            limpiar();
        }


        public void Inicializa()
        {
            limpiar();
        }

        private void limpiar()
        {
            Producto = null;
            DepDestino = null;
            DepOrigen = null;
            Concepto = null;
            Estatus = null;
            Sucursal = null;
            TipoDoc = null;
            Desde = null;
            Hasta = null;
        }

        public bool FiltrarIsOk()
        {
            if (Desde != null && Hasta != null)
            {
                if (Desde.Value > Hasta.Value) 
                {
                    Helpers.Msg.Error("FECHAS INCORRECTAS, VERIFIQUE POR FAVOR");
                    return false;
                }
            }

            if (Desde!= null) return true;
            if (Hasta != null) return true;
            if (Producto != null) return true;
            if (DepOrigen != null) return true;
            if (DepDestino != null) return true;
            if (Concepto != null) return true;
            if (Estatus != null) return true;
            if (Sucursal!= null) return true;
            if (TipoDoc != null) return true;
            return false;
        }

    }

}