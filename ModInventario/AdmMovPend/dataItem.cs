using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.AdmMovPend
{
    
    public class dataItem
    {

        public int id { get; set; }
        public DateTime fecha { get; set; }
        public decimal montoDivisa { get; set; }
        public decimal monto { get; set; }
        public int cntRenglones { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public string usuarioEstacion { get; set; }
        public string tipoDoc { get; set; }
        public string codigoMov { get; set; }
        public string tipoMov { get; set; }


        public dataItem() 
        {
            id = -1;
            fecha = DateTime.Now.Date;
            montoDivisa = 0m;
            monto = 0m;
            cntRenglones = 0;
            origen = "";
            destino = "";
            usuarioEstacion = "";
            tipoDoc = "";
            codigoMov = "";
            tipoMov = "";
        }

        public dataItem(dataItem rg)
            :this()
        {
            id = rg.id;
            fecha = rg.fecha;
            montoDivisa = rg.montoDivisa;
            monto=rg.monto;
            cntRenglones = rg.cntRenglones;
            origen = rg.origen;
            destino = rg.destino;
            usuarioEstacion = rg.usuarioEstacion;
            tipoDoc = rg.tipoDoc ;
            codigoMov = rg.codigoMov;
            tipoMov = rg.tipoMov;
        }

    }

}