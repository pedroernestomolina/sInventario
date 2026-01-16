using DataProvInventario.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.Data
{
    public partial class DataProv : IData
    {
        public OOB.ResultadoEntidad<OOB.LibInventario.MovimientoRecuperar.Entidad.Ficha>
            movimientoRecuperarFicha(string idDoc)
        {
            try
            {
                var rt = new OOB.ResultadoEntidad<OOB.LibInventario.MovimientoRecuperar.Entidad.Ficha>();
                //
                var rst = MyData.recuperarMovimientoFicha(idDoc);
                if (rst.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rst.Mensaje);
                }
                if (rst.Entidad == null)
                {
                    throw new Exception("DATA NO CARGADA");
                }
                if (rst.Entidad.encabezado == null) 
                {
                    throw new Exception("ENCABEZADO DEL MOVIMIENTO NO CARGADO");
                }
                var f = rst.Entidad;
                var s = f.encabezado;
                var enc = new OOB.LibInventario.MovimientoRecuperar.Entidad.Encabezado()
                {
                    conceptoCodigo = s.conceptoCodigo,
                    conceptoDesc = s.conceptoDesc,
                    depositoDestinoCodigo = s.depositoDestinoCodigo,
                    depositoDestinoDesc = s.depositoDestinoDesc,
                    depositoOrigenCodigo = s.depositoOrigenCodigo,
                    depositoOrigenDesc = s.depositoOrigenDesc,
                    docCodigo = s.docCodigo,
                    docNombre = s.docNombre,
                    isMovAnulado = s.movEstatusAnulado.Trim().ToUpper() == "1",
                    movEstacionEquipo = s.movEstacionEquipo,
                    movFactorCambio = s.movFactorCambio.HasValue ? s.movFactorCambio.Value: 0m,
                    movFecha = s.movFecha,
                    movHora = s.movHora,
                    movId = s.movId,
                    movNotas = s.movNotas,
                    movNumero = s.movNumero,
                    movPersonaAutoriza = s.movPersonaAutoriza,
                    movTotalMonedaLocal = s.movTotalMonedaLocal,
                    movTotalMonedaRef = s.movTotalMonedaRef.HasValue ? s.movTotalMonedaRef.Value: 0m ,
                    sucursalCodigo = s.sucursalCodigo,
                    sucursalDesc = s.sucursalDesc,
                    usuarioCodigo = s.usuarioCodigo,
                    usuarioNombre = s.usuarioNombre,
                };
                var det = f.detalles.Select(ss =>
                {
                    var dt = new OOB.LibInventario.MovimientoRecuperar.Entidad.Detalle()
                    {
                        cantidadEmp = ss.cantidadEmp,
                        cantidadUnd = ss.cantidadUnd,
                        cntDecimales = ss.cntDecimales,
                        costoUndMonedaLocal = ss.costoUndMonedaLocal,
                        costoUndMonedaRef = ss.costoUndMonedaRef,
                        empqContenido = ss.empqContenido,
                        empqDesc = ss.empqDesc,
                        importeMonedaLocal = ss.importeMonedaLocal,
                        importeMonedaRef = ss.importeMonedaRef,
                        prdCodigo = ss.prdCodigo,
                        prdDesc = ss.prdDesc,
                        signoMov = ss.signoMov,
                    };
                    return dt;
                }).ToList();
                rt.Entidad = new OOB.LibInventario.MovimientoRecuperar.Entidad.Ficha()
                {
                    detalles = det,
                    encabezado = enc,
                };
                //
                return rt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}