using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModInventario.Helpers
{

    public static class VisualizarDocumento
    {

        public static void CargarVisualizarDocumento(string idMov)
        {
            var rt1 = Sistema.MyData.Producto_Movimiento_GetFicha(idMov);
            if (rt1.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return;
            }

            var item = rt1.Entidad;
            switch (item.docTipo)
            {
                case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Cargo:
                case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Descargo:
                case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Traslado:
                    Visualizar(rt1.Entidad);
                    break;
                case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Ajuste:
                    VisualizarAjuste(rt1.Entidad);
                    break;
            }
        }

        static private void Visualizar(OOB.LibInventario.Movimiento.Ver.Ficha xficha)
        {
            var ficha = new Reportes.Documentos.data();
            ficha.documentoNro = xficha.documentoNro;
            ficha.fecha = xficha.fecha;
            ficha.notas = xficha.notas;
            ficha.autorizadoPor = xficha.autorizadoPor;
            ficha.depositoOrigen = xficha.depositoOrigen;
            ficha.codigoDepositoOrigen = xficha.codigoDepositoOrigen;
            ficha.depositoDestino = xficha.depositoDestino;
            ficha.codigoDepositoDestino = xficha.codigoDepositoDestino;
            ficha.tipoDocumento = xficha.tipoDocumento;
            ficha.nombreDocumento = xficha.nombreDocumento;
            ficha.codigoConcepto = xficha.codigoConcepto;
            ficha.concepto = xficha.concepto;
            ficha.estacion = xficha.estacion;
            ficha.usuario = xficha.usuario;
            ficha.usuarioCodigo = xficha.usuarioCodigo;

            var det = new List<Reportes.Documentos.dataDetalle>();
            foreach (var it in xficha.detalles)
            {
                var nr = new Reportes.Documentos.dataDetalle()
                {
                    cantidad = it.cantidad,
                    codigo = it.codigo,
                    costoUnd = it.costoUnd,
                    descripcion = it.descripcion,
                    importe = it.importe,
                    signo = 1,
                    cantidadUnd = it.cantidadUnd,
                    contenido = it.contenido,
                    empaque = it.empaque,
                    esUnidad = it.esUnidad,
                };
                det.Add(nr);
            };
            ficha.detalles = det;

            var rp1 = new Reportes.Documentos.Movimiento(ficha);
            rp1.Generar();
        }

        static private void VisualizarAjuste(OOB.LibInventario.Movimiento.Ver.Ficha xficha)
        {
            var ficha = new Reportes.Documentos.data();
            ficha.documentoNro = xficha.documentoNro;
            ficha.fecha = xficha.fecha;
            ficha.notas = xficha.notas;
            ficha.autorizadoPor = xficha.autorizadoPor;
            ficha.depositoOrigen = xficha.depositoOrigen;
            ficha.codigoDepositoOrigen = xficha.codigoDepositoOrigen;
            ficha.depositoDestino = xficha.depositoDestino;
            ficha.codigoDepositoDestino = xficha.codigoDepositoDestino;
            ficha.tipoDocumento = xficha.tipoDocumento;
            ficha.nombreDocumento = xficha.nombreDocumento;
            ficha.codigoConcepto = xficha.codigoConcepto;
            ficha.concepto = xficha.concepto;
            ficha.estacion = xficha.estacion;
            ficha.usuario = xficha.usuario;
            ficha.usuarioCodigo = xficha.usuarioCodigo;

            var det = new List<Reportes.Documentos.dataDetalle>();
            foreach (var it in xficha.detalles)
            {
                var nr = new Reportes.Documentos.dataDetalle()
                {
                    cantidad = it.cantidad,
                    codigo = it.codigo,
                    costoUnd = it.costoUnd,
                    descripcion = it.descripcion,
                    importe = it.importe,
                    signo = it.signo,
                    cantidadUnd = it.cantidadUnd,
                    contenido = it.contenido,
                    empaque = it.empaque,
                    esUnidad = it.esUnidad,
                    decimales = it.decimales,
                };
                det.Add(nr);
            };
            ficha.detalles = det;

            var rp1 = new Reportes.Documentos.Movimiento(ficha);
            rp1.Generar();
        }

    }

}
