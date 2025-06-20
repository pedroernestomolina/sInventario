using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario._CostoProducto.ActualizarCosto.Implementacion.UsesCase
{
    public class ImplUseCase: Interfaces.UsesCase.IUseCase
    {
        public ImplUseCase()
        {
        }
        public Modelo.Producto 
            GetFichaPrdToEditarCostoUseCase(string idPrd)
        {
            try
            {
                var rt = Sistema.MyData.Producto_GestionCosto_CapturarDataPrdEditarCosto(idPrd);
                if (rt.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rt.Mensaje);
                }
                if (rt.Entidad==null)
                {
                    throw new Exception("ERROR: ENTIDAD NO DEFINIDA");
                }
                var prd= rt.Entidad;
                return new Modelo.Producto()
                {
                    codigoPrd = prd.codigoPrd,
                    contEmpqCompra = prd.contEmqCompra,
                    costoProv = prd.costoProvPrd,
                    costoImport = prd.costoImportacionPrd,
                    costoVario = prd.costoVarioPrd,
                    costoFinal = prd.costoFinalPrd,
                    costoDivisa = prd.costoDivisaPrd,
                    costoPromedio = prd.costoPromedioPrd,
                    descEmpqCompra = prd.descEmqCompra,
                    descripcionPrd = prd.descPrd,
                    descTasaIvaPrd = prd.descTasaIva,
                    esAdmDivisa = prd.esDivisaPrd,
                    fechaUltCambio = prd.fechaUltCambio,
                    idPrd = prd.idPrd,
                    nombrePrd = prd.nombrePrd,
                    tasaIvaPrd = prd.porcTasaIva,
                };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}