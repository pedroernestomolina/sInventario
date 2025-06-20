using DataProvInventario.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.Data
{
    public partial class DataProv: IData
    {
        public OOB.ResultadoEntidad<OOB.LibInventario.Producto.GestionCosto.CapturarDataPrdEditarCosto.Ficha> 
            Producto_GestionCosto_CapturarDataPrdEditarCosto(string idPrd)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Producto.GestionCosto.CapturarDataPrdEditarCosto.Ficha>();
            //
            var r01 = MyData.Producto_GestionCosto_CapturarDataPrdEditarCosto(idPrd);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            if (r01.Entidad == null) 
            {
                throw new Exception("ERROR: ENTIDAD NO DEFINIDA");
            }
            var prd = r01.Entidad;
            var fechaV = new DateTime(2000, 01, 01);
            var _fechaUltCambio = (
                (prd.fechaUltCambio==fechaV) ? "" : prd.fechaUltCambio.ToShortDateString()
                );
            var ent = new OOB.LibInventario.Producto.GestionCosto.CapturarDataPrdEditarCosto.Ficha()
            {
                codigoPrd = prd.codigoPrd,
                contEmqCompra = prd.contEmqCompra,
                costoDivisaPrd = prd.costoDivisaPrd,
                costoProvPrd = prd.costoProvPrd,
                costoImportacionPrd = prd.costoImportacionPrd,
                costoVarioPrd = prd.costoVarioPrd,
                costoFinalPrd = prd.costoFinalPrd,
                costoPromedioPrd = prd.costoPromedioPrd,
                descEmqCompra = prd.descEmqCompra,
                descPrd = prd.descPrd,
                descTasaIva = prd.descTasaIva,
                esDivisaPrd = prd.estatusDivisaPrd.Trim().ToUpper() == "1",
                fechaUltCambio = _fechaUltCambio,
                idPrd = prd.idPrd,
                nombrePrd = prd.nombrePrd,
                porcTasaIva = prd.porcTasaIva,
            };
            rt.Entidad=ent;
            //
            return rt;
        }
    }
}