using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.FiltrosPara.AdmDocumentos
{
    public class dataExportar
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


        public dataExportar()
        {
            limpiar();
        }


        public void Inicializa()
        {
            limpiar();
        }
        public bool IsOk()
        {
            if (Desde != null && Hasta != null)
            {
                if (Desde.Value > Hasta.Value)
                {
                    Helpers.Msg.Error("FECHAS INCORRECTAS, VERIFIQUE POR FAVOR");
                    return false;
                }
            }
            if (Desde != null) return true;
            if (Hasta != null) return true;
            if (Producto != null) return true;
            if (DepOrigen != null) return true;
            if (DepDestino != null) return true;
            if (Concepto != null) return true;
            if (Estatus != null) return true;
            if (Sucursal != null) return true;
            if (TipoDoc != null) return true;
            return false;
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
            Desde = DateTime.Now.Date;
            Hasta = DateTime.Now.Date;
        }


        public string GetConcepto_Id { get { return Concepto == null ? "" : Concepto.id; } }
        public string GetDepOrigen_Id { get { return DepOrigen == null ? "" : DepOrigen.id; } }
        public string GetDepDestino_Id { get { return DepDestino== null ? "" : DepDestino.id; } }
        public string GetSucursal_Id { get { return Sucursal== null ? "" : Sucursal.id; } }
        public string GetSucursal_Codigo { get { return Sucursal == null ? "" : Sucursal.codigo; } }
        public string GetProducto_Id { get { return Producto== null ? "" : Producto.id; } }
        public string GetEstatus_Desc { get { return Estatus == null ? "" : Estatus.desc; } }
        public string GetTipoDoc_Desc { get { return TipoDoc == null ? "" : TipoDoc.desc; } }
        public string FiltrosDesc 
        {
            get
            {
                var r="";
                if (Concepto!=null)
                    r+=",Concepto: "+Concepto.desc;
                if (DepOrigen!= null)
                    r += ",Deposito Origen: " + DepOrigen.desc;
                if (DepDestino!= null)
                    r += ",Deposito Destino: " + DepDestino.desc;
                if (Sucursal!= null)
                    r += ",Sucursal: " + Sucursal.desc;
                if (Producto != null)
                    r += ",Producto: " + Producto.desc;
                if (Estatus!= null)
                    r += ",Estatus: " + Estatus.desc;
                if (TipoDoc != null)
                    r += ",Tipo Documento: " + TipoDoc.desc;
                if (Desde.HasValue!= null)
                    r += ",Desde La Fecha: " + Desde.Value.ToShortDateString();
                if (Hasta.HasValue != null)
                    r += ",HastaLa Fecha: " + Hasta.Value.ToShortDateString();
                return r;
            }
        }
    }
}