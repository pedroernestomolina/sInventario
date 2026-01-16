using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.VisualizarMovimiento.vm
{
    public class VisualizarImpl: IVisualizar
    {
        private Domain.UseCase.IUseCase _uc;
        //
        public VisualizarImpl()
        {
            _uc = new Domain.UseCase.UseCaseImpl();
        }
        public void VerDocumento(string idDoc)
        {
            try
            {
                var ficha = _uc.CargarDocumentoVisualizar(idDoc);
                Visualizar(ficha);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        private void Visualizar(Domain.Model.Entidad.Ficha xficha)
        {
            var ficha = new Reportes.Documentos.data();
            ficha.documentoNro = xficha.encabezado.movNumero;
            ficha.fecha = xficha.encabezado.movFecha;
            ficha.notas = xficha.encabezado.movNotas;
            ficha.autorizadoPor = xficha.encabezado.movPersonaAutoriza;
            ficha.depositoOrigen = xficha.encabezado.depositoOrigenDesc;
            ficha.codigoDepositoOrigen = xficha.encabezado.depositoOrigenCodigo;
            ficha.depositoDestino = xficha.encabezado.depositoDestinoDesc ;
            ficha.codigoDepositoDestino = xficha.encabezado.depositoDestinoCodigo;
            ficha.tipoDocumento = xficha.encabezado.docCodigo ;
            ficha.nombreDocumento = xficha.encabezado.docNombre ;
            ficha.codigoConcepto = xficha.encabezado.conceptoCodigo ;
            ficha.concepto = xficha.encabezado.conceptoDesc;
            ficha.estacion = xficha.encabezado.movEstacionEquipo;
            ficha.usuario = xficha.encabezado.usuarioNombre ;
            ficha.usuarioCodigo = xficha.encabezado.usuarioCodigo ;
            ficha.estatusActivo = !xficha.encabezado.isMovAnulado;
            //
            var det = new List<Reportes.Documentos.dataDetalle>();
            foreach (var it in xficha.detalles)
            {
                var nr = new Reportes.Documentos.dataDetalle()
                {
                    cantidad = it.cantidadEmp,
                    codigo = it.prdCodigo,
                    costoUnd = it.costoUndMonedaRef,
                    descripcion = it.prdDesc,
                    importe = it.importeMonedaRef,
                    signo = it.signoMov,
                    cantidadUnd = it.cantidadUnd,
                    contenido = it.empqContenido,
                    empaque = it.empqDesc,
                    //esUnidad = it.esUnidad,
                };
                det.Add(nr);
            };
            ficha.detalles = det;
            //
            var rp1 = new Reportes.Documentos.Movimiento(ficha);
            rp1.Generar();
        }
    }
}