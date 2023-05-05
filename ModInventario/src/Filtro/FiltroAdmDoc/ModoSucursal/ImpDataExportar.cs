using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Filtro.FiltroAdmDoc.ModoSucursal
{
    public class ImpDataExportar : IDataExportar
    {
        public LibUtilitis.Opcion.IData Producto { get; set; }
        public LibUtilitis.Opcion.IData DepOrigen { get; set; }
        public LibUtilitis.Opcion.IData DepDestino { get; set; }
        public LibUtilitis.Opcion.IData Concepto { get; set; }
        public LibUtilitis.Opcion.IData Estatus { get; set; }
        public LibUtilitis.Opcion.IData Sucursal { get; set; }
        public LibUtilitis.Opcion.IData TipoDoc { get; set; }
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }
        public bool IsOk { get { return isOk(); } }
        public string FiltrosDescripcion { get { return filtroDesc(); } }


        private bool isOk()
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
            Helpers.Msg.Error("DEBE SELECCIONAR ALGUNOS FILTROS PARA REALIZAR LA BUSQUEDA !!!");
            return false;
        }
        private string filtroDesc()
        {
            var r = "";
            if (Concepto != null)
                r += ",Concepto: " + Concepto.desc;
            if (DepOrigen != null)
                r += ",Deposito Origen: " + DepOrigen.desc;
            if (DepDestino != null)
                r += ",Deposito Destino: " + DepDestino.desc;
            if (Sucursal != null)
                r += ",Sucursal: " + Sucursal.desc;
            if (Producto != null)
                r += ",Producto: " + Producto.desc;
            if (Estatus != null)
                r += ",Estatus: " + Estatus.desc;
            if (TipoDoc != null)
                r += ",Tipo Documento: " + TipoDoc.desc;
            if (Desde.HasValue)
                r += ",Desde La Fecha: " + Desde.Value.ToShortDateString();
            if (Hasta.HasValue)
                r += ",HastaLa Fecha: " + Hasta.Value.ToShortDateString();
            return r;
        }
    }
}