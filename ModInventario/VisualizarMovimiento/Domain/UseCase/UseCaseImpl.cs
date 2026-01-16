using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.VisualizarMovimiento.Domain.UseCase
{
    public class UseCaseImpl: IUseCase
    {
        public Model.Entidad.Ficha
            CargarDocumentoVisualizar(string idDoc)
        {
            try
            {
                var rt = new Model.Entidad.Ficha();
                var rst = Sistema.MyData.movimientoRecuperarFicha(idDoc);
                if (rst.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    throw new Exception(rst.Mensaje);
                }
                var f = rst.Entidad;
                var s= f.encabezado;
                var tipoDoc = Model.Entidad.enumerado.TipoDocumento.SinDefinir;
                switch (s.docCodigo)
                {
                    case "01":
                        tipoDoc = Model.Entidad.enumerado.TipoDocumento.Cargo;  
                        break;
                    case "02":
                        tipoDoc = Model.Entidad.enumerado.TipoDocumento.Descargo;  
                        break;
                    case "03":
                        tipoDoc = Model.Entidad.enumerado.TipoDocumento.Traslado;  
                        break;
                    case "04":
                        tipoDoc = Model.Entidad.enumerado.TipoDocumento.Ajuste;  
                        break;
                }
                rt.encabezado = new Model.Entidad.Encabezado()
                {
                    conceptoCodigo = s.conceptoCodigo,
                    conceptoDesc = s.conceptoDesc,
                    depositoDestinoCodigo = s.depositoDestinoCodigo,
                    depositoDestinoDesc = s.depositoDestinoDesc,
                    depositoOrigenCodigo = s.depositoOrigenCodigo,
                    depositoOrigenDesc = s.depositoOrigenDesc,
                    docCodigo = s.docCodigo,
                    docNombre = s.docNombre,
                    isMovAnulado = s.isMovAnulado,
                    movEstacionEquipo = s.movEstacionEquipo,
                    movFactorCambio = s.movFactorCambio,
                    movFecha = s.movFecha,
                    movHora = s.movHora,
                    movId = s.movId,
                    movNotas = s.movNotas,
                    movNumero = s.movNumero,
                    movPersonaAutoriza = s.movPersonaAutoriza,
                    movTotalMonedaLocal = s.movTotalMonedaLocal,
                    movTotalMonedaRef = s.movTotalMonedaRef,
                    sucursalCodigo = s.sucursalCodigo,
                    sucursalDesc = s.sucursalDesc,
                    usuarioCodigo = s.usuarioCodigo,
                    usuarioNombre = s.usuarioNombre,
                    docTipo = tipoDoc,
                };
                rt.detalles= f.detalles.Select(ss =>
                {
                    var _costoUndMonRef = 0m;
                    var _importeMonRef = 0m;
                    if (s.movFactorCambio > 0m) 
                    {
                        _costoUndMonRef = ss.costoUndMonedaLocal / s.movFactorCambio;
                        _importeMonRef = ss.importeMonedaLocal / s.movFactorCambio;
                    } 
                    var dt = new  Model.Entidad.Detalle()
                    {
                        cantidadEmp = ss.cantidadEmp,
                        cantidadUnd = ss.cantidadUnd,
                        cntDecimales = ss.cntDecimales,
                        costoUndMonedaLocal = ss.costoUndMonedaLocal,
                        costoUndMonedaRef = _costoUndMonRef ,
                        empqContenido = ss.empqContenido,
                        empqDesc = ss.empqDesc,
                        importeMonedaLocal = ss.importeMonedaLocal,
                        importeMonedaRef = _importeMonRef ,
                        prdCodigo = ss.prdCodigo,
                        prdDesc = ss.prdDesc,
                        signoMov = ss.signoMov,
                    };
                    return dt;
                }).ToList();
                return rt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}