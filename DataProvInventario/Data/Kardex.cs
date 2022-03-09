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

        public OOB.ResultadoEntidad<OOB.LibInventario.Kardex.Movimiento.Resumen.Ficha> Producto_Kardex_Movimiento_Lista_Resumen(OOB.LibInventario.Kardex.Movimiento.Resumen.Filtro filtro)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Kardex.Movimiento.Resumen.Ficha>();

            var filtroDTO = new DtoLibInventario.Kardex.Movimiento.Resumen.Filtro()
            {
                autoProducto = filtro.autoProducto,
                ultDias = (DtoLibInventario.Kardex.Enumerados.EnumMovUltDias)filtro.ultDias,
            };
            var r01 = MyData.Producto_Kardex_Movimiento_Lista_Resumen(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Result = OOB.Enumerados.EnumResult.isError;
                rt.Mensaje = r01.Mensaje;
                return rt;
            }

            var s= r01.Entidad;
            var nr = new OOB.LibInventario.Kardex.Movimiento.Resumen.Ficha()
            {
                codigoProducto = s.codigoProducto,
                contenidoEmp = s.contenidoEmp,
                empaqueCompra = s.empaqueCompra,
                decimales=s.decimales,
                existenciaActual = s.existenciaActual,
                existenciaFecha=s.existencaFecha,
                fecha=s.fecha,
                nombreProducto = s.nombreProducto,
                referenciaProducto = s.referenciaProducto,
            };
            var lst = s.Data.Select(ss =>
            {
                var reg = new OOB.LibInventario.Kardex.Movimiento.Resumen.Data()
                {
                    autoConcepto = ss.autoConcepto,
                    autoDeposito = ss.autoDeposito,
                    cntInventario = ss.cntInventario,
                    cntMovimiento = ss.cntMovimiento,
                    codigoConcepto = ss.codigoConcepto,
                    codigoDeposito = ss.codigoDeposito,
                    modulo = ss.modulo,
                    nombreConcepto = ss.nombreConcepto,
                    nombreDeposito = ss.nombreDeposito,
                    siglas=ss.siglas,
                };
                return reg;
            }).ToList();

            nr.Data = lst;
            rt.Entidad = nr;
            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibInventario.Kardex.Movimiento.Detalle.Ficha> Producto_Kardex_Movimiento_Lista_Detalle(OOB.LibInventario.Kardex.Movimiento.Detalle.Filtro filtro)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Kardex.Movimiento.Detalle.Ficha>();

            var filtroDTO = new DtoLibInventario.Kardex.Movimiento.Detalle.Filtro()
            {
                autoProducto = filtro.autoProducto,
                ultDias = (DtoLibInventario.Kardex.Enumerados.EnumMovUltDias)filtro.ultDias,
                autoConcepto = filtro.autoConcepto,
                autoDeposito = filtro.autoDeposito,
                modulo = filtro.modulo,
            };
            var r01 = MyData.Producto_Kardex_Movimiento_Lista_Detalle(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError) 
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s= r01.Entidad;
            var nr = new OOB.LibInventario.Kardex.Movimiento.Detalle.Ficha()
            {
                codigoProducto = s.codigoProducto,
                contenidoEmp = s.contenidoEmp,
                EmpaqueCompra = s.EmpaqueCompra,
                existencia = s.existencia,
                nombreProducto = s.nombreProducto,
                referenciaProducto = s.referenciaProducto,
                decimales = s.decimales,
            };
            var lst = s.Data.Select(ss =>
            {
                var reg = new OOB.LibInventario.Kardex.Movimiento.Detalle.Data()
                {
                    autoConcepto = ss.autoConcepto,
                    autoDeposito = ss.autoDeposito,
                    autoDocumento = ss.autoDocumento,
                    cantidad = ss.cantidad,
                    cantidadBono = ss.cantidadBono,
                    cantidadUnd = ss.cantidadUnd,
                    codigoDoc = ss.codigoDoc,
                    codigoSucursal = ss.codigoSucursal,
                    costoUnd = ss.costoUnd,
                    documento = ss.documento,
                    entidad = ss.entidad,
                    fecha = ss.fecha,
                    hora = ss.hora,
                    isAnulado = ss.isAnulado,
                    Modulo = (OOB.LibInventario.Kardex.Enumerados.EnumModulo) ss.Modulo,
                    moduloDoc = ss.moduloDoc,
                    nota = ss.nota,
                    precioUnd = ss.precioUnd,
                    Siglas = (OOB.LibInventario.Kardex.Enumerados.EnumSiglas) ss.Siglas,
                    siglasDoc = ss.siglasDoc,
                    signoDoc = ss.signoDoc,
                    total = ss.total,
                };
                return reg;
            }).ToList();
            nr.Data = lst;
            rt.Entidad = nr;

            return rt;
        }

    }

}