using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Movimiento
{
    
    public class data
    {

        private ficha _sucursal;
        private ficha _depositoOrigen;
        private ficha _depositoDestino;
        private ficha _concepto;


        public string IdSucursal { get; set; }
        public string IdConcepto { get; set; }
        public string IdDepOrigen { get; set; }
        public string IdDepDestino { get; set; }
        public string AutorizadoPor { get; set; }
        public string Motivo { get; set; }
        public DateTime Fecha { get; set; }
        public dataDetalle detalle { get; set; }
        //
        public ficha GetSucursal { get { return _sucursal; } }
        public ficha GetDepositoOrigen { get { return _depositoOrigen; } }
        public ficha GetDepositoDestino { get { return _depositoDestino; } }
        public ficha GetConcepto { get { return _concepto; } }


        public data() 
        {
            Limpiar();
        }


        public void Limpiar()
        {
            IdSucursal = "";
            IdConcepto = "";
            IdDepDestino = "";
            IdDepOrigen = "";
            AutorizadoPor = "";
            Motivo = "";
            Fecha = DateTime.Now.Date;
            //
            _sucursal = null;
            _depositoOrigen = null;
            _concepto = null;
            _depositoDestino = null;
        }

        public bool Verificar()
        {
            var rt = true;

            if (AutorizadoPor.Trim() == "") 
            {
                Helpers.Msg.Error("Campo [ Autorizado ] Falta Por LLenar");
                return false;
            }

            if (Motivo.Trim() == "")
            {
                Helpers.Msg.Error("Campo [ Motivo ] Falta Por LLenar");
                return false;
            }
           
            if (detalle.ListaItems.Count == 0) 
            {
                Helpers.Msg.Error("No Hay Items En El Documento ");
                return false;
            }

            if (detalle.ListaItems.Count(c=>c.Importe==0.0m)>0)
            {
                Helpers.Msg.Error("Hay Items En El Documento Con Importe En Cero (0)");
                return false;
            }

            return rt;
        }

        public void setSucursal(ficha ficha)
        {
            _sucursal = ficha;
        }

        public void setDepositoOrigen(ficha ficha)
        {
            _depositoOrigen= ficha;
        }

        public void setDepositoDestino(ficha ficha)
        {
            _depositoDestino = ficha;
        }

        public void setConcepto(ficha ficha)
        {
            _concepto= ficha;
        }

    }

}