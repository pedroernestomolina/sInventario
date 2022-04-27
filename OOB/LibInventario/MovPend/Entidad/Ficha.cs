using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.MovPend.Entidad
{
    
    public class Ficha
    {

        public int id { get; set; }
        public DateTime fecha { get; set; }
        public string autoriza { get; set; }
        public string motivo { get; set; }
        public decimal monto { get; set; }
        public decimal montoDivisa { get; set; }
        public decimal factorCambio { get; set; }
        public int cntRenglones { get; set; }
        public string tipoMov { get; set; }
        public string codigoMov { get; set; }
        public string descripcionMov { get; set; }
        public string sucOrigen { get; set; }
        public string sucDestino { get; set; }
        public string depOrigen { get; set; }
        public string depDestino { get; set; }
        public string concepto { get; set; }
        public string usuario { get; set; }
        public string MovimientoDesc 
        {
            get
            {
                var rt = "";
                switch (codigoMov)
                {
                    case "03":
                        rt = "TRASLADO";
                        switch (tipoMov)
                        {
                            case "1":
                                rt += "";
                                break;
                            case "2":
                                rt += " x Devolucion";
                                break;
                            case "3":
                                rt += " x Nivel Minimo";
                                break;
                        }
                        break;
                    case "04":
                        rt += "AJUSTE";
                        break;
                }
                return rt;
            }
        }


        public Ficha()
        {
            id = -1;
            fecha = DateTime.Now.Date;
            autoriza = "";
            motivo = "";
            monto = 0m;
            montoDivisa = 0m;
            factorCambio = 0m;
            cntRenglones = 0;
            tipoMov = "";
            codigoMov = "";
            descripcionMov = "";
            sucOrigen = "";
            sucDestino = "";
            depOrigen = "";
            depDestino = "";
            concepto = "";
            usuario = "";
        }

    }

}