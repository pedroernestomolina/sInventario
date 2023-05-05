using LibUtilitis.Opcion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.FiltrosPara.AdmDocumentos
{
    public interface IDataExportar
    {
        IData Producto { get; set; }
        IData DepOrigen { get; set; }
        IData DepDestino { get; set; }
        IData Concepto { get; set; }
        IData Estatus { get; set; }
        IData Sucursal { get; set; }
        IData TipoDoc { get; set; }
        DateTime? Desde { get; set; }
        DateTime? Hasta { get; set; }
        bool IsOk { get; }
        string FiltrosDescripcion { get; }
    }
}