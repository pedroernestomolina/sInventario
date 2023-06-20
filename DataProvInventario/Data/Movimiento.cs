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
        //INSERTAR
        public OOB.ResultadoAuto 
            Producto_Movimiento_Ajuste_Insertar(OOB.LibInventario.Movimiento.Ajuste.Insertar.Ficha data)
        {
            var rt = new OOB.ResultadoAuto();

            var mov= data.mov;
            var movDTO = new DtoLibInventario.Movimiento.Ajuste.Insertar.FichaMov()
            {
                autoConcepto = mov.autoConcepto,
                autoDepositoDestino = mov.autoDepositoDestino,
                autoDepositoOrigen = mov.autoDepositoOrigen,
                autoRemision = mov.autoRemision,
                autorizado = mov.autorizado,
                autoUsuario = mov.autoUsuario,
                cierreFtp = mov.cierreFtp,
                codConcepto = mov.codConcepto,
                codDepositoDestino = mov.codDepositoDestino,
                codDepositoOrigen = mov.codDepositoOrigen,
                codigoSucursal = mov.codigoSucursal,
                codUsuario = mov.codUsuario,
                desConcepto = mov.desConcepto,
                desDepositoDestino = mov.desDepositoDestino,
                desDepositoOrigen = mov.desDepositoOrigen,
                documentoNombre = mov.documentoNombre,
                estacion = mov.estacion,
                estatusAnulado = mov.estatusAnulado,
                estatusCierreContable = mov.estatusCierreContable,
                nota = mov.nota,
                renglones = mov.renglones,
                situacion = mov.situacion,
                tipo = mov.tipo,
                total = mov.total,
                usuario = mov.usuario,
                factorCambio = mov.factorCambio,
                montoDivisa = mov.montoDivisa,
            };
            var movDetDTO = data.movDetalles.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.Ajuste.Insertar.FichaMovDetalle()
                {
                    autoDepartamento = s.autoDepartamento,
                    autoGrupo = s.autoGrupo,
                    autoProducto = s.autoProducto,
                    cantidad = s.cantidad,
                    cantidadBono = s.cantidadBono,
                    cantidadUnd = s.cantidadUnd,
                    categoria = s.categoria,
                    codigoProducto = s.codigoProducto,
                    contEmpaque = s.contEmpaque,
                    costoCompra = s.costoCompra,
                    costoUnd = s.costoUnd,
                    decimales = s.decimales,
                    empaque = s.empaque,
                    estatusAnulado = s.estatusAnulado,
                    estatusUnidad = s.estatusUnidad,
                    nombreProducto = s.nombreProducto,
                    signo = s.signo,
                    tipo = s.tipo,
                    total = s.total,
                };
                return dt;
            }).ToList();
            var movKardexDTO = data.movKardex.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.Ajuste.Insertar.FichaMovKardex()
                {
                    autoConcepto = s.autoConcepto,
                    autoDeposito = s.autoDeposito,
                    autoProducto = s.autoProducto,
                    cantidad = s.cantidad,
                    cantidadBono = s.cantidadBono,
                    cantidadUnd = s.cantidadUnd,
                    codigoMov = s.codigoMov,
                    codigoSucursal = s.codigoSucursal,
                    costoUnd = s.costoUnd,
                    entidad = s.entidad,
                    estatusAnulado = s.estatusAnulado,
                    modulo = s.modulo,
                    nota = s.nota,
                    precioUnd = s.precioUnd,
                    siglasMov = s.siglasMov,
                    signoMov = s.signoMov,
                    total = s.total,
                    codigoConcepto = s.codigoConcepto,
                    nombreConcepto = s.nombreConcepto,
                    codigoDeposito = s.codigoDeposito,
                    nombreDeposito = s.nombreDeposito,
                    factorCambio = s.factorCambio,
                };
                return dt;
            }).ToList();
            var movDepDTO = data.movDeposito.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.Ajuste.Insertar.FichaMovDeposito()
                {
                    autoProducto = s.autoProducto,
                    autoDeposito = s.autoDeposito,
                    cantidadUnd = s.cantidadUnd,
                    nombreProducto = s.nombreProducto,
                    nombreDeposito = s.nombreDeposito,
                };
                return dt;
            }).ToList();
            var fichaDto = new DtoLibInventario.Movimiento.Ajuste.Insertar.Ficha()
            {
                mov = movDTO,
                movDeposito = movDepDTO,
                movDetalles = movDetDTO,
                movKardex = movKardexDTO,
            };
            var r01 = MyData.Producto_Movimiento_Ajuste_Insertar(fichaDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Auto = r01.Auto;

            return rt;
        }
        public OOB.ResultadoAuto 
            Producto_Movimiento_Traslado_Insertar(OOB.LibInventario.Movimiento.Traslado.Insertar.Ficha ficha)
        {
            var rt = new OOB.ResultadoAuto();
            var xficha = ficha.mov;
            var movDTO = new DtoLibInventario.Movimiento.Traslado.Insertar.FichaMov()
            {
                autoConcepto = xficha.autoConcepto,
                autoDepositoDestino = xficha.autoDepositoDestino,
                autoDepositoOrigen = xficha.autoDepositoOrigen,
                autoRemision = xficha.autoRemision,
                autorizado = xficha.autorizado,
                autoUsuario = xficha.autoUsuario,
                cierreFtp = xficha.cierreFtp,
                codConcepto = xficha.codConcepto,
                codDepositoDestino = xficha.codDepositoDestino,
                codDepositoOrigen = xficha.codDepositoOrigen,
                codigoSucursal = xficha.codigoSucursal,
                codUsuario = xficha.codUsuario,
                desConcepto = xficha.desConcepto,
                desDepositoDestino = xficha.desDepositoDestino,
                desDepositoOrigen = xficha.desDepositoOrigen,
                documentoNombre = xficha.documentoNombre,
                estacion = xficha.estacion,
                estatusAnulado = xficha.estatusAnulado,
                estatusCierreContable = xficha.estatusCierreContable,
                nota = xficha.nota,
                renglones = xficha.renglones,
                situacion = xficha.situacion,
                tipo = xficha.tipo,
                total = xficha.total,
                usuario = xficha.usuario,
                factorCambio = xficha.factorCambio,
                montoDivisa = xficha.montoDivisa,
            };
            var detDTO = ficha.movDetalles.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.Traslado.Insertar.FichaMovDetalle()
                {
                    autoDepartamento = s.autoDepartamento,
                    autoGrupo = s.autoGrupo,
                    autoProducto = s.autoProducto,
                    cantidad = s.cantidad,
                    cantidadBono = s.cantidadBono,
                    cantidadUnd = s.cantidadUnd,
                    categoria = s.categoria,
                    codigoProducto = s.codigoProducto,
                    contEmpaque = s.contEmpaque,
                    costoCompra = s.costoCompra,
                    costoUnd = s.costoUnd,
                    decimales = s.decimales,
                    empaque = s.empaque,
                    estatusAnulado = s.estatusAnulado,
                    estatusUnidad = s.estatusUnidad,
                    nombreProducto = s.nombreProducto,
                    signo = s.signo,
                    tipo = s.tipo,
                    total = s.total,
                };
                return dt;
            }).ToList();
            var kardexDTO = ficha.movKardex.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.Traslado.Insertar.FichaMovKardex()
                {
                    autoConcepto = s.autoConcepto,
                    autoDeposito = s.autoDeposito,
                    autoProducto = s.autoProducto,
                    cantidad = s.cantidad,
                    cantidadBono = s.cantidadBono,
                    cantidadUnd = s.cantidadUnd,
                    codigoMov = s.codigoMov,
                    codigoSucursal = s.codigoSucursal,
                    costoUnd = s.costoUnd,
                    entidad = s.entidad,
                    estatusAnulado = s.estatusAnulado,
                    modulo = s.modulo,
                    nota = s.nota,
                    precioUnd = s.precioUnd,
                    siglasMov = s.siglasMov,
                    signoMov = s.signoMov,
                    total = s.total,
                    codigoConcepto = s.codigoConcepto,
                    nombreConcepto = s.nombreConcepto,
                    codigoDeposito = s.codigoDeposito,
                    nombreDeposito = s.nombreDeposito,
                    factorCambio = s.factorCambio,
                };
                return dt;
            }).ToList();
            var depDTO = ficha.movDeposito.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.Traslado.Insertar.FichaMovDeposito()
                {
                    autoProducto = s.autoProducto,
                    nombreProducto = s.nombreProducto,
                    autoDepositoDestino = s.autoDepositoDestino,
                    depositoDestino = s.depositoDestino,
                    cantidadUnd = s.cantidadUnd,
                    autoDeposito = s.autoDeposito,
                    nombreDeposito = s.nombreDeposito,
                };
                return dt;
            }).ToList();
            var fichaDTO = new DtoLibInventario.Movimiento.Traslado.Insertar.Ficha()
            {
                mov = movDTO,
                detalles = detDTO,
                movKardex = kardexDTO,
                prdDeposito = depDTO,
            };
            var r01 = MyData.Producto_Movimiento_Traslado_Insertar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Auto = r01.Auto;
            return rt;
        }
        public OOB.ResultadoAuto 
            Producto_Movimiento_Traslado_Devolucion_Insertar(OOB.LibInventario.Movimiento.Traslado.Insertar.Ficha ficha)
        {
            var rt = new OOB.ResultadoAuto();

            var xficha = ficha.mov;
            var movDTO = new DtoLibInventario.Movimiento.Traslado.Insertar.FichaMov()
            {
                autoConcepto = xficha.autoConcepto,
                autoDepositoDestino = xficha.autoDepositoDestino,
                autoDepositoOrigen = xficha.autoDepositoOrigen,
                autoRemision = xficha.autoRemision,
                autorizado = xficha.autorizado,
                autoUsuario = xficha.autoUsuario,
                cierreFtp = xficha.cierreFtp,
                codConcepto = xficha.codConcepto,
                codDepositoDestino = xficha.codDepositoDestino,
                codDepositoOrigen = xficha.codDepositoOrigen,
                codigoSucursal = xficha.codigoSucursal,
                codUsuario = xficha.codUsuario,
                desConcepto = xficha.desConcepto,
                desDepositoDestino = xficha.desDepositoDestino,
                desDepositoOrigen = xficha.desDepositoOrigen,
                documentoNombre = xficha.documentoNombre,
                estacion = xficha.estacion,
                estatusAnulado = xficha.estatusAnulado,
                estatusCierreContable = xficha.estatusCierreContable,
                nota = xficha.nota,
                renglones = xficha.renglones,
                situacion = xficha.situacion,
                tipo = xficha.tipo,
                total = xficha.total,
                usuario = xficha.usuario,
                factorCambio = xficha.factorCambio,
                montoDivisa = xficha.montoDivisa,
            };
            var detDTO= ficha.movDetalles.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.Traslado.Insertar.FichaMovDetalle()
                {
                    autoDepartamento = s.autoDepartamento,
                    autoGrupo = s.autoGrupo,
                    autoProducto = s.autoProducto,
                    cantidad = s.cantidad,
                    cantidadBono = s.cantidadBono,
                    cantidadUnd = s.cantidadUnd,
                    categoria = s.categoria,
                    codigoProducto = s.codigoProducto,
                    contEmpaque = s.contEmpaque,
                    costoCompra = s.costoCompra,
                    costoUnd = s.costoUnd,
                    decimales = s.decimales,
                    empaque = s.empaque,
                    estatusAnulado = s.estatusAnulado,
                    estatusUnidad = s.estatusUnidad,
                    nombreProducto = s.nombreProducto,
                    signo = s.signo,
                    tipo = s.tipo,
                    total = s.total,
                };
                return dt;
            }).ToList();
            var kardexDTO = ficha.movKardex.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.Traslado.Insertar.FichaMovKardex()
                {
                    autoConcepto = s.autoConcepto,
                    autoDeposito = s.autoDeposito,
                    autoProducto = s.autoProducto,
                    cantidad = s.cantidad,
                    cantidadBono = s.cantidadBono,
                    cantidadUnd = s.cantidadUnd,
                    codigoMov = s.codigoMov,
                    codigoSucursal = s.codigoSucursal,
                    costoUnd = s.costoUnd,
                    entidad = s.entidad,
                    estatusAnulado = s.estatusAnulado,
                    modulo = s.modulo,
                    nota = s.nota,
                    precioUnd = s.precioUnd,
                    siglasMov = s.siglasMov,
                    signoMov = s.signoMov,
                    total = s.total,
                    codigoConcepto = s.codigoConcepto,
                    nombreConcepto = s.nombreConcepto,
                    codigoDeposito = s.codigoDeposito,
                    nombreDeposito = s.nombreDeposito,
                    factorCambio = s.factorCambio,
                };
                return dt;
            }).ToList();
            var depDTO = ficha.movDeposito.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.Traslado.Insertar.FichaMovDeposito()
                {
                    autoProducto = s.autoProducto,
                    nombreProducto = s.nombreProducto,
                    autoDeposito = s.autoDeposito,
                    autoDepositoDestino = s.autoDepositoDestino,
                    depositoDestino = s.depositoDestino,
                    nombreDeposito = s.nombreDeposito,
                    cantidadUnd = s.cantidadUnd,
                };
                return dt;
            }).ToList();

            var fichaDTO = new DtoLibInventario.Movimiento.Traslado.Insertar.Ficha()
            {
                mov = movDTO,
                detalles = detDTO,
                movKardex = kardexDTO,
                prdDeposito = depDTO,
            };
            var r01 = MyData.Producto_Movimiento_Traslado_Devolucion_Insertar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Auto = r01.Auto;

            return rt;
        }
        public OOB.ResultadoAuto 
            Producto_Movimiento_DesCargo_Insertar(OOB.LibInventario.Movimiento.DesCargo.Insertar.Ficha ficha)
        {
            var rt = new OOB.ResultadoAuto();

            var xficha = ficha.mov;
            var movDTO = new DtoLibInventario.Movimiento.DesCargo.Insertar.FichaMov()
            {
                autoConcepto = xficha.autoConcepto,
                autoDepositoDestino = xficha.autoDepositoDestino,
                autoDepositoOrigen = xficha.autoDepositoOrigen,
                autoRemision = xficha.autoRemision,
                autorizado = xficha.autorizado,
                autoUsuario = xficha.autoUsuario,
                cierreFtp = xficha.cierreFtp,
                codConcepto = xficha.codConcepto,
                codDepositoDestino = xficha.codDepositoDestino,
                codDepositoOrigen = xficha.codDepositoOrigen,
                codigoSucursal = xficha.codigoSucursal,
                codUsuario = xficha.codUsuario,
                desConcepto = xficha.desConcepto,
                desDepositoDestino = xficha.desDepositoDestino,
                desDepositoOrigen = xficha.desDepositoOrigen,
                documentoNombre = xficha.documentoNombre,
                estacion = xficha.estacion,
                estatusAnulado = xficha.estatusAnulado,
                estatusCierreContable = xficha.estatusCierreContable,
                nota = xficha.nota,
                renglones = xficha.renglones,
                situacion = xficha.situacion,
                tipo = xficha.tipo,
                total = xficha.total,
                usuario = xficha.usuario,
                factorCambio = xficha.factorCambio,
                montoDivisa = xficha.montoDivisa,
            };
            var detDTO = ficha.movDetalles.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.DesCargo.Insertar.FichaMovDetalle()
                {
                    autoDepartamento = s.autoDepartamento,
                    autoGrupo = s.autoGrupo,
                    autoProducto = s.autoProducto,
                    cantidad = s.cantidad,
                    cantidadBono = s.cantidadBono,
                    cantidadUnd = s.cantidadUnd,
                    categoria = s.categoria,
                    codigoProducto = s.codigoProducto,
                    contEmpaque = s.contEmpaque,
                    costoCompra = s.costoCompra,
                    costoUnd = s.costoUnd,
                    decimales = s.decimales,
                    empaque = s.empaque,
                    estatusAnulado = s.estatusAnulado,
                    estatusUnidad = s.estatusUnidad,
                    nombreProducto = s.nombreProducto,
                    signo = s.signo,
                    tipo = s.tipo,
                    total = s.total,
                };
                return dt;
            }).ToList();
            var kardexDTO = ficha.movKardex.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.DesCargo.Insertar.FichaMovKardex()
                {
                    autoConcepto = s.autoConcepto,
                    autoDeposito = s.autoDeposito,
                    autoProducto = s.autoProducto,
                    cantidad = s.cantidad,
                    cantidadBono = s.cantidadBono,
                    cantidadUnd = s.cantidadUnd,
                    codigoMov = s.codigoMov,
                    codigoSucursal = s.codigoSucursal,
                    costoUnd = s.costoUnd,
                    entidad = s.entidad,
                    estatusAnulado = s.estatusAnulado,
                    modulo = s.modulo,
                    nota = s.nota,
                    precioUnd = s.precioUnd,
                    siglasMov = s.siglasMov,
                    signoMov = s.signoMov,
                    total = s.total,
                    codigoConcepto = s.codigoConcepto,
                    nombreConcepto = s.nombreConcepto,
                    codigoDeposito = s.codigoDeposito,
                    nombreDeposito = s.nombreDeposito,
                    factorCambio = s.factorCambio,
                };
                return dt;
            }).ToList();
            var depDTO = ficha.movDeposito.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.DesCargo.Insertar.FichaMovDeposito()
                {
                    autoProducto = s.autoProducto,
                    nombreProducto = s.nombreProducto,
                    autoDeposito = s.autoDeposito,
                    cantidadUnd = s.cantidadUnd,
                    nombreDeposito = s.nombreDeposito,
                };
                return dt;
            }).ToList();

            var fichaDTO = new DtoLibInventario.Movimiento.DesCargo.Insertar.Ficha()
            {
                mov = movDTO,
                movDeposito = depDTO,
                movDetalles = detDTO,
                movKardex = kardexDTO,
            };
            var r01 = MyData.Producto_Movimiento_DesCargo_Insertar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Auto = r01.Auto;

            return rt;
        }
        public OOB.ResultadoAuto 
            Producto_Movimiento_Cargo_Insertar(OOB.LibInventario.Movimiento.Cargo.Insertar.Ficha ficha)
        {
            var rt = new OOB.ResultadoAuto();

            var xficha = ficha.mov;
            var movDTO = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaMov()
            {
                autoConcepto = xficha.autoConcepto,
                autoDepositoDestino = xficha.autoDepositoDestino,
                autoDepositoOrigen = xficha.autoDepositoOrigen,
                autoRemision = xficha.autoRemision,
                autorizado = xficha.autorizado,
                autoUsuario = xficha.autoUsuario,
                cierreFtp = xficha.cierreFtp,
                codConcepto = xficha.codConcepto,
                codDepositoDestino = xficha.codDepositoDestino,
                codDepositoOrigen = xficha.codDepositoOrigen,
                codigoSucursal = xficha.codigoSucursal,
                codUsuario = xficha.codUsuario,
                desConcepto = xficha.desConcepto,
                desDepositoDestino = xficha.desDepositoDestino,
                desDepositoOrigen = xficha.desDepositoOrigen,
                documentoNombre = xficha.documentoNombre,
                estacion = xficha.estacion,
                estatusAnulado = xficha.estatusAnulado,
                estatusCierreContable = xficha.estatusCierreContable,
                nota = xficha.nota,
                renglones = xficha.renglones,
                situacion = xficha.situacion,
                tipo = xficha.tipo,
                total = xficha.total,
                usuario = xficha.usuario,
                factorCambio = xficha.factorCambio,
                montoDivisa = xficha.montoDivisa,
            };
            var detDTO = ficha.movDetalles.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaMovDetalle()
                {
                    autoDepartamento = s.autoDepartamento,
                    autoGrupo = s.autoGrupo,
                    autoProducto = s.autoProducto,
                    cantidad = s.cantidad,
                    cantidadBono = s.cantidadBono,
                    cantidadUnd = s.cantidadUnd,
                    categoria = s.categoria,
                    codigoProducto = s.codigoProducto,
                    contEmpaque = s.contEmpaque,
                    costoCompra = s.costoCompra,
                    costoUnd = s.costoUnd,
                    decimales = s.decimales,
                    empaque = s.empaque,
                    estatusAnulado = s.estatusAnulado,
                    estatusUnidad = s.estatusUnidad,
                    nombreProducto = s.nombreProducto,
                    signo = s.signo,
                    tipo = s.tipo,
                    total = s.total,
                };
                return dt;
            }).ToList();
            var kardexDTO = ficha.movKardex.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaMovKardex()
                {
                    autoConcepto = s.autoConcepto,
                    autoDeposito = s.autoDeposito,
                    autoProducto = s.autoProducto,
                    cantidad = s.cantidad,
                    cantidadBono = s.cantidadBono,
                    cantidadUnd = s.cantidadUnd,
                    codigoMov = s.codigoMov,
                    codigoSucursal = s.codigoSucursal,
                    costoUnd = s.costoUnd,
                    entidad = s.entidad,
                    estatusAnulado = s.estatusAnulado,
                    modulo = s.modulo,
                    nota = s.nota,
                    precioUnd = s.precioUnd,
                    siglasMov = s.siglasMov,
                    signoMov = s.signoMov,
                    total = s.total,
                    codigoConcepto = s.codigoConcepto,
                    nombreConcepto = s.nombreConcepto,
                    codigoDeposito = s.codigoDeposito,
                    nombreDeposito = s.nombreDeposito,
                    factorCambio = s.factorCambio,
                };
                return dt;
            }).ToList();
            var depDTO = ficha.movDeposito.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaMovDeposito()
                {
                    autoProducto = s.autoProducto,
                    nombreProducto = s.nombreProducto,
                    autoDeposito = s.autoDeposito,
                    cantidadUnd = s.cantidadUnd,
                    nombreDeposito = s.nombreDeposito,
                };
                return dt;
            }).ToList();
            var listPrdCosto = ficha.prdCosto.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrdCosto()
                {
                    autoProducto = s.autoProducto,
                    cantidadEntranteUnd = s.cantidadEntranteUnd,
                    costoDivisa = s.costoDivisa,
                    costoFinal = s.costoFinal,
                    costoFinalUnd = s.costoFinalUnd,
                };
                return dt;
            }).ToList();
            var listPrdCostoHistorico = ficha.prdCostoHistorico.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrdCostoHistorico()
                {
                    autoProducto = s.autoProducto,
                    costo = s.costo,
                    divisa = s.divisa,
                    nota = s.nota,
                    tasaCambio = s.tasaCambio,
                    serie = s.serie,
                };
                return dt;
            }).ToList();
            var listPrdPrecio = ficha.prdPrecio.Select(s =>
            {
                DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecio p1 = null;
                DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecio p2 = null;
                DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecio p3 = null;
                DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecio p4 = null;
                DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecio p5 = null;
                if (s.precio_1 != null)
                {
                    p1 = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecio() { precioNeto = s.precio_1.precioNeto, precio_divisa_full = s.precio_1.precio_divisa_full };
                };
                if (s.precio_2 != null)
                {
                    p2 = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecio() { precioNeto = s.precio_2.precioNeto, precio_divisa_full = s.precio_2.precio_divisa_full };
                };
                if (s.precio_3 != null)
                {
                    p3 = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecio() { precioNeto = s.precio_3.precioNeto, precio_divisa_full = s.precio_3.precio_divisa_full };
                };
                if (s.precio_4 != null)
                {
                    p4 = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecio() { precioNeto = s.precio_4.precioNeto, precio_divisa_full = s.precio_4.precio_divisa_full };
                };
                if (s.precio_5 != null)
                {
                    p5 = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecio() { precioNeto = s.precio_5.precioNeto, precio_divisa_full = s.precio_5.precio_divisa_full };
                };
                var dt = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrdPrecio()
                {
                    autoProducto = s.autoProducto,
                    precio_1 = p1,
                    precio_2 = p2,
                    precio_3 = p3,
                    precio_4 = p4,
                    precio_5 = p5,
                };
                return dt;
            }).ToList();
            var listPrdPrecioMargen = ficha.prdPrecioMargen.Select(s =>
            {
                DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen p1 = null;
                DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen p2 = null;
                DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen p3 = null;
                DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen p4 = null;
                DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen p5 = null;
                if (s.precio_1 != null)
                {
                    p1 = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen() { utilidad = s.precio_1.utilidad };
                };
                if (s.precio_2 != null)
                {
                    p2 = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen() { utilidad = s.precio_2.utilidad };
                };
                if (s.precio_3 != null)
                {
                    p3 = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen() { utilidad = s.precio_3.utilidad };
                };
                if (s.precio_4 != null)
                {
                    p4 = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen() { utilidad = s.precio_4.utilidad };
                };
                if (s.precio_5 != null)
                {
                    p5 = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen() { utilidad = s.precio_5.utilidad };
                };
                var dt = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrdPrecioMargen()
                {
                    autoProducto = s.autoProducto,
                    precio_1 = p1,
                    precio_2 = p2,
                    precio_3 = p3,
                    precio_4 = p4,
                    precio_5 = p5,
                };
                return dt;
            }).ToList();
            var listPrdPrecioHistorico = ficha.prdPrecioHistorico.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrdPrecioHistorico()
                {
                    autoProducto = s.autoProducto,
                    precio = s.precio,
                    precio_id = s.precio_id,
                    nota = s.nota,
                };
                return dt;
            }).ToList();

            var fichaDTO = new DtoLibInventario.Movimiento.Cargo.Insertar.Ficha()
            {
                mov = movDTO,
                movDeposito = depDTO,
                movDetalles = detDTO,
                movKardex = kardexDTO,
                prdCosto = listPrdCosto,
                prdCostoHistorico = listPrdCostoHistorico,
                prdPrecio = listPrdPrecio,
                prdPrecioHistorico = listPrdPrecioHistorico,
                prdPrecioMargen = listPrdPrecioMargen,
            };
            var r01 = MyData.Producto_Movimiento_Cargo_Insertar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Auto = r01.Auto;

            return rt;
        }
        public OOB.ResultadoAuto 
            Producto_Movimiento_AjusteInventarioCero_Insertar(OOB.LibInventario.Movimiento.AjusteInvCero.Insertar.Ficha data)
        {
            var rt = new OOB.ResultadoAuto();

            var mov = data.mov;
            var movDTO = new DtoLibInventario.Movimiento.AjusteInvCero.Insertar.FichaMov()
            {
                autoConcepto = mov.autoConcepto,
                autoDepositoDestino = mov.autoDepositoDestino,
                autoDepositoOrigen = mov.autoDepositoOrigen,
                autoRemision = mov.autoRemision,
                autorizado = mov.autorizado,
                autoUsuario = mov.autoUsuario,
                cierreFtp = mov.cierreFtp,
                codConcepto = mov.codConcepto,
                codDepositoDestino = mov.codDepositoDestino,
                codDepositoOrigen = mov.codDepositoOrigen,
                codigoSucursal = mov.codigoSucursal,
                codUsuario = mov.codUsuario,
                desConcepto = mov.desConcepto,
                desDepositoDestino = mov.desDepositoDestino,
                desDepositoOrigen = mov.desDepositoOrigen,
                documentoNombre = mov.documentoNombre,
                estacion = mov.estacion,
                estatusAnulado = mov.estatusAnulado,
                estatusCierreContable = mov.estatusCierreContable,
                nota = mov.nota,
                renglones = mov.renglones,
                situacion = mov.situacion,
                tipo = mov.tipo,
                total = mov.total,
                usuario = mov.usuario,
                factorCambio = mov.factorCambio,
                montoDivisa = mov.montoDivisa,
            };
            var movDetDTO = data.movDetalles.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.AjusteInvCero.Insertar.FichaMovDetalle()
                {
                    autoDepartamento = s.autoDepartamento,
                    autoGrupo = s.autoGrupo,
                    autoProducto = s.autoProducto,
                    cantidad = s.cantidad,
                    cantidadBono = s.cantidadBono,
                    cantidadUnd = s.cantidadUnd,
                    categoria = s.categoria,
                    codigoProducto = s.codigoProducto,
                    contEmpaque = s.contEmpaque,
                    costoCompra = s.costoCompra,
                    costoUnd = s.costoUnd,
                    decimales = s.decimales,
                    empaque = s.empaque,
                    estatusAnulado = s.estatusAnulado,
                    estatusUnidad = s.estatusUnidad,
                    nombreProducto = s.nombreProducto,
                    signo = s.signo,
                    tipo = s.tipo,
                    total = s.total,
                };
                return dt;
            }).ToList();
            var movKardexDTO = data.movKardex.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.AjusteInvCero.Insertar.FichaMovKardex()
                {
                    autoConcepto = s.autoConcepto,
                    autoDeposito = s.autoDeposito,
                    autoProducto = s.autoProducto,
                    cantidad = s.cantidad,
                    cantidadBono = s.cantidadBono,
                    cantidadUnd = s.cantidadUnd,
                    codigoMov = s.codigoMov,
                    codigoSucursal = s.codigoSucursal,
                    costoUnd = s.costoUnd,
                    entidad = s.entidad,
                    estatusAnulado = s.estatusAnulado,
                    modulo = s.modulo,
                    nota = s.nota,
                    precioUnd = s.precioUnd,
                    siglasMov = s.siglasMov,
                    signoMov = s.signoMov,
                    total = s.total,
                    codigoConcepto = s.codigoConcepto,
                    nombreConcepto = s.nombreConcepto,
                    codigoDeposito = s.codigoDeposito,
                    nombreDeposito = s.nombreDeposito,
                    factorCambio = s.factorCambio,
                };
                return dt;
            }).ToList();
            var movDepDTO = data.movDeposito.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.AjusteInvCero.Insertar.FichaMovDeposito()
                {
                    autoProducto = s.autoProducto,
                    autoDeposito = s.autoDeposito,
                    cantidadUnd = s.cantidadUnd,
                    nombreProducto = s.nombreProducto,
                    nombreDeposito = s.nombreDeposito,
                };
                return dt;
            }).ToList();
            var fichaDto = new DtoLibInventario.Movimiento.AjusteInvCero.Insertar.Ficha()
            {
                mov = movDTO,
                movDeposito = movDepDTO,
                movDetalles = movDetDTO,
                movKardex = movKardexDTO,
            };
            var r01 = MyData.Producto_Movimiento_AjusteInvCero_Insertar(fichaDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Auto = r01.Auto;

            return rt;
        }
        //GET
        public OOB.ResultadoEntidad<OOB.LibInventario.Movimiento.Ver.Ficha>
            Producto_Movimiento_GetFicha(string autoDoc)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Movimiento.Ver.Ficha>();

            var r01 = MyData.Producto_Movimiento_GetFicha (autoDoc);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s= r01.Entidad;
            var nr = new OOB.LibInventario.Movimiento.Ver.Ficha()
            {
                autorizadoPor = s.autorizadoPor,
                codigoConcepto = s.codigoConcepto,
                codigoDepositoDestino = s.codigoDepositoDestino,
                codigoDepositoOrigen = s.codigoDepositoOrigen,
                concepto = s.concepto,
                depositoDestino = s.depositoDestino,
                depositoOrigen = s.depositoOrigen,
                documentoNro = s.documentoNro,
                estacion = s.estacion,
                fecha = s.fecha,
                hora = s.hora,
                notas = s.notas,
                tipoDocumento = s.tipoDocumento,
                total = s.total,
                usuario = s.usuario,
                usuarioCodigo = s.usuarioCodigo,
                nombreDocumento = s.nombreDocumento,
                estatusAnulado=s.estatusAnulado,
                docTipo=  (OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento) s.docTipo,
            };
            var det = s.detalles.Select(ss =>
            {
                var dt = new OOB.LibInventario.Movimiento.Ver.Detalle()
                {
                    cantidad = ss.cantidad,
                    codigo = ss.codigo,
                    costoUnd = ss.costoUnd,
                    descripcion = ss.descripcion,
                    importe = ss.importe,
                    signo = ss.signo,
                    cantidadUnd = ss.cantidadUnd,
                    contenido = ss.contenido,
                    empaque = ss.empaque,
                    esUnidad = ss.esUnidad,
                    decimales = ss.decimales,
                };
                return dt;
            }).ToList();
            nr.detalles = det;
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoLista<OOB.LibInventario.Movimiento.Lista.Ficha>
            Producto_Movimiento_GetLista(OOB.LibInventario.Movimiento.Lista.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Movimiento.Lista.Ficha>();

            var filtroDto = new DtoLibInventario.Movimiento.Lista.Filtro()
            {
                Desde = filtro.Desde,
                Hasta = filtro.Hasta,
                TipoDocumento = (DtoLibInventario.Movimiento.enumerados.EnumTipoDocumento)filtro.TipoDocumento,
                IdDepDestino = filtro.IdDepDestino,
                IdDepOrigen = filtro.IdDepOrigen,
                IdConcepto=filtro.IdConcepto,
                Estatus = (DtoLibInventario.Movimiento.enumerados.EnumEstatus)filtro.Estatus,
                IdProducto=filtro.IdProducto,
                IdSucursal = filtro.CodigoSucursal,
            };
            var r01 = MyData.Producto_Movimiento_GetLista(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var list = new List<OOB.LibInventario.Movimiento.Lista.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Movimiento.Lista.Ficha()
                        {
                            autoId = s.autoId,
                            fecha = s.fecha,
                            hora = s.hora,
                            docConcepto = s.docConcepto,
                            docMonto = s.docMonto,
                            docMotivo = s.docMotivo,
                            docNro = s.docNro,
                            docRenglones = s.docRenglones,
                            docSituacion = s.docSituacion,
                            docSucursal = s.docSucursal,
                            docTipo = (OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento)s.docTipo,
                            estacion = s.estacion,
                            isDocAnulado = s.isDocAnulado,
                            usuario = s.usuario,
                            depositoOrigen=s.depositoOrigen,
                            depositoDestino=s.depositoDestino,
                            idDepOrigen=s.idDepOrigen,
                            idDepDestino=s.idDepDestino,
                            montoDivisa= s.montoDivisa.HasValue?s.montoDivisa.Value: 0m,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Movimiento.AjusteInvCero.Capture.Ficha> 
            Producto_Movimiento_AjusteInventarioCero_Capture(OOB.LibInventario.Movimiento.AjusteInvCero.Capture.Filtro filtro)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Movimiento.AjusteInvCero.Capture.Ficha>();
            var filtroDto = new DtoLibInventario.Movimiento.AjusteInvCero.Capture.Filtro()
            {
                idDeposito = filtro.idDeposito,
            };
            var r01 = MyData.Producto_Movimiento_AjusteInventarioCero_Capture(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.LibInventario.Movimiento.AjusteInvCero.Capture.Data>();
            if (r01.Entidad.data != null)
            {
                if (r01.Entidad.data.Count > 0)
                {
                    lst = r01.Entidad.data.Select(s =>
                    {
                        return new OOB.LibInventario.Movimiento.AjusteInvCero.Capture.Data()
                        {
                            autoDepart = s.autoDepart,
                            autoGrupo = s.autoGrupo,
                            autoPrd = s.autoPrd,
                            catPrd = s.catPrd,
                            codigoPrd = s.codigoPrd,
                            contEmp = s.contEmp,
                            costo = s.costo,
                            costoUnd = s.costoUnd,
                            decimales = s.decimales,
                            exFisica = s.exFisica,
                            nombreEmp = s.nombreEmp,
                            nombrePrd = s.nombrePrd,
                            autoTasa = s.autoTasa,
                            costoDivisa = s.costoDivisa,
                            descTasa = s.descTasa,
                            estatusDivisa = s.estatusDivisa,
                            valorTasa = s.valorTasa,
                        };
                    }).ToList();
                }
            }
            rt.Entidad = new OOB.LibInventario.Movimiento.AjusteInvCero.Capture.Ficha()
            {
                data = lst,
            };
            return rt;
        }
        //ANULAR
        public OOB.Resultado 
            Producto_Movimiento_Cargo_Anular(OOB.LibInventario.Movimiento.Anular.Cargo.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibInventario.Movimiento.Anular.Cargo.Ficha()
            {
                autoDocumento = ficha.autoDocumento,
                autoSistemaDocumento = ficha.autoSistemaDocumento,
                autoUsuario = ficha.autoUsuario,
                codigo = ficha.codigoUsuario,
                estacion = ficha.estacion,
                motivo = ficha.motivo,
                usuario = ficha.nombreUsuario,
            };
            var r01 = MyData.Producto_Movimiento_Cargo_Anular(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }

            return rt;
        }
        public OOB.Resultado 
            Producto_Movimiento_Descargo_Anular(OOB.LibInventario.Movimiento.Anular.Descargo.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibInventario.Movimiento.Anular.Descargo.Ficha()
            {
                autoDocumento = ficha.autoDocumento,
                autoSistemaDocumento = ficha.autoSistemaDocumento,
                autoUsuario = ficha.autoUsuario,
                codigo = ficha.codigoUsuario,
                estacion = ficha.estacion,
                motivo = ficha.motivo,
                usuario = ficha.nombreUsuario,
            };
            var r01 = MyData.Producto_Movimiento_Descargo_Anular(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }

            return rt;
        }
        public OOB.Resultado
            Producto_Movimiento_Traslado_Anular(OOB.LibInventario.Movimiento.Anular.Traslado.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibInventario.Movimiento.Anular.Traslado.Ficha()
            {
                autoDocumento = ficha.autoDocumento,
                autoSistemaDocumento = ficha.autoSistemaDocumento,
                autoUsuario = ficha.autoUsuario,
                codigo = ficha.codigoUsuario,
                estacion = ficha.estacion,
                motivo = ficha.motivo,
                usuario = ficha.nombreUsuario,
            };
            var r01 = MyData.Producto_Movimiento_Traslado_Anular(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }

            return rt;
        }
        public OOB.Resultado
            Producto_Movimiento_Ajuste_Anular(OOB.LibInventario.Movimiento.Anular.Ajuste.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibInventario.Movimiento.Anular.Ajuste.Ficha()
            {
                autoDocumento = ficha.autoDocumento,
                autoSistemaDocumento = ficha.autoSistemaDocumento,
                autoUsuario = ficha.autoUsuario,
                codigo = ficha.codigoUsuario,
                estacion = ficha.estacion,
                motivo = ficha.motivo,
                usuario = ficha.nombreUsuario,
            };
            var r01 = MyData.Producto_Movimiento_Ajuste_Anular(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }

            return rt;
        }
        //
        public OOB.ResultadoLista<OOB.LibInventario.Movimiento.Traslado.Capturar.ProductoPorDebajoNivelMinimo.Ficha> 
            Capturar_ProductosPorDebajoNivelMinimo(OOB.LibInventario.Movimiento.Traslado.Capturar.ProductoPorDebajoNivelMinimo.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Movimiento.Traslado.Capturar.ProductoPorDebajoNivelMinimo.Ficha>();
            var filtroDto = new DtoLibInventario.Movimiento.Traslado.Capturar.ProductoPorDebajoNivelMinimo.Filtro()
            {
                autoDepositoVerificarNivel = filtro.autoDepositoVerificarNivel,
                autoDepositoOrigen = filtro.autoDepositoOrigen,
                autoDepartamento = filtro.autoDepartamento,
                autoProducto = filtro.autoProducto,
                verificarNivel = filtro.verificarExistencia, 
            };
            var r01 = MyData.Capturar_ProductosPorDebajoNivelMinimo(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var list = new List<OOB.LibInventario.Movimiento.Traslado.Capturar.ProductoPorDebajoNivelMinimo.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Movimiento.Traslado.Capturar.ProductoPorDebajoNivelMinimo.Ficha()
                        {
                            autoDepartamento = s.autoDepartamento,
                            autoDeposito = s.autoDeposito,
                            autoGrupo = s.autoGrupo,
                            autoPrd = s.autoPrd,
                            categoria = s.categoria,
                            codigoDeposito = s.codigoDeposito,
                            codigoPrd = s.codigoPrd,
                            costoDivisa = s.costoDivisa,
                            costoUnd = s.costoUnd,
                            decimales = s.decimales,
                            empCompra = s.empCompra,
                            empCompraCont = s.empCompraCont,
                            estatusDivisa = s.estatusDivisa,
                            exDisponible = s.exDisponible,
                            exFisica = s.exFisica,
                            exReserva = s.exReserva,
                            nivelMinimo = s.nivelMinimo,
                            nivelOptimo = s.nivelOptimo,
                            nombreDeposito = s.nombreDeposito,
                            nombrePrd = s.nombrePrd,
                            //
                            autoDepositoOrigen = s.autoDepositoOrigen,
                            codigoDepositoOrigen = s.codigoDepositoOrigen,
                            nombreDepositoOrigen = s.nombreDepositoOrigen,
                            exFisicaOrigen = s.exFisicaOrigen,
                            exReservaOrigen = s.exReservaOrigen,
                            exDisponibleOrigen = s.exDisponibleOrigen,
                            //
                            fechaUltActualizacion = s.fechaUltActualizacion.Date,
                            tasaIva = s.tasaIva,
                            tasaIvaNombre = s.tasaIvaNombre,
                            //
                            autoTasa = s.tasaAuto,
                            costo = s.costo,
                            //
                            nombreEmpInv = s.nombreEmpInv,
                            contEmpInv = s.contEmpInv,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;
            return rt;
        }
        public OOB.ResultadoLista<OOB.LibInventario.Movimiento.Traslado.Consultar.ProductoPorDebajoNivelMinimo>
            Producto_Movimiento_Traslado_Consultar_ProductosPorDebajoNivelMinimo(OOB.LibInventario.Movimiento.Traslado.Consultar.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Movimiento.Traslado.Consultar.ProductoPorDebajoNivelMinimo>();
            var filtroDto = new DtoLibInventario.Movimiento.Traslado.Consultar.Filtro()
            {
                autoDepartamento = filtro.autoDepartamento,
                autoDeposito = filtro.autoDeposito,
            };
            var r01 = MyData.Producto_Movimiento_Traslado_Consultar_ProductosPorDebajoNivelMinimo(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Movimiento.Traslado.Consultar.ProductoPorDebajoNivelMinimo>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Movimiento.Traslado.Consultar.ProductoPorDebajoNivelMinimo()
                        {
                            autoDepartamento = s.autoDepartamento,
                            autoGrupo = s.autoGrupo,
                            autoProducto = s.autoProducto,
                            categoria = s.categoria,
                            cntUndReponer = s.cntUndReponer,
                            codigoProducto = s.codigoProducto,
                            contenidEmpCompra = s.contenidEmpCompra,
                            costoFinalCompra = s.costoFinalCompra,
                            costoFinalUnd = s.costoFinalUnd,
                            decimales = s.decimales,
                            empaqueCompra = s.empaqueCompra,
                            nombreProducto = s.nombreProducto,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }
        //
        public OOB.ResultadoEntidad<OOB.LibInventario.Movimiento.DesCargo.CapturaMov.Ficha> 
            Producto_Movimiento_Descargo_CaptureMov(OOB.LibInventario.Movimiento.DesCargo.CapturaMov.Filtro filtro)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Movimiento.DesCargo.CapturaMov.Ficha>();

            var filtroDto = new DtoLibInventario.Movimiento.DesCargo.CapturaMov.Filtro()
            {
                idDeposito = filtro.idDeposito,
                idProducto = filtro.idProducto,
            };
            var r01 = MyData.Producto_Movimiento_Descargo_Capture(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            var s = r01.Entidad.data;
            var _fechaNula=new DateTime(2000,01,01);
            var _fechaUltActCosto = "";
            if (s.fechaUltActCosto == _fechaNula)
            {
                _fechaUltActCosto = "";
            }
            else 
            {
                _fechaUltActCosto = s.fechaUltActCosto.ToShortDateString();
            }

            var ent = new OOB.LibInventario.Movimiento.DesCargo.CapturaMov.Data()
            {
                autoDepart = s.autoDepart,
                autoGrupo = s.autoGrupo,
                autoPrd = s.autoPrd,
                catPrd = s.catPrd,
                codigoPrd = s.codigoPrd,
                contEmp = s.contEmp,
                costo = s.costo,
                costoUnd = s.costoUnd,
                decimales = s.decimales,
                exFisica = s.exFisica,
                nombreEmp = s.nombreEmp,
                nombrePrd = s.nombrePrd,
                autoTasa = s.autoTasa,
                costoDivisa = s.costoDivisa,
                descTasa = s.descTasa,
                estatusDivisa = s.estatusDivisa,
                valorTasa = s.valorTasa,
                fechaUltActualizacionCosto = _fechaUltActCosto,
                nombreEmpInv = s.nombreEmpInv,
                contEmpInv = s.contEmpInv,
            };
            rt.Entidad = new OOB.LibInventario.Movimiento.DesCargo.CapturaMov.Ficha()
            {
                data = ent,
            };
            return rt;
        }
        //
        public OOB.ResultadoEntidad<OOB.LibInventario.Movimiento.Cargo.CapturaMov.Ficha> 
            Producto_Movimiento_Cargo_CaptureMov(OOB.LibInventario.Movimiento.Cargo.CapturaMov.Filtro filtro)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Movimiento.Cargo.CapturaMov.Ficha>();

            var filtroDto = new DtoLibInventario.Movimiento.Cargo.CapturaMov.Filtro()
            {
                idDeposito = filtro.idDeposito,
                idProducto = filtro.idProducto,
            };
            var r01 = MyData.Producto_Movimiento_Cargo_Capture(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            var s = r01.Entidad.data;
            var _fechaNula = new DateTime(2000, 01, 01);
            var _fechaUltActCosto = "";
            if (s.fechaUltActCosto != _fechaNula)
            {
                _fechaUltActCosto = s.fechaUltActCosto.ToShortDateString();
            }
            var ent = new OOB.LibInventario.Movimiento.Cargo.CapturaMov.Data()
            {
                autoDepart = s.autoDepart,
                autoGrupo = s.autoGrupo,
                autoPrd = s.autoPrd,
                catPrd = s.catPrd,
                codigoPrd = s.codigoPrd,
                contEmp = s.contEmp,
                costo = s.costo,
                costoUnd = s.costoUnd,
                decimales = s.decimales,
                exFisica = s.exFisica,
                nombreEmp = s.nombreEmp,
                nombrePrd = s.nombrePrd,
                autoTasa = s.autoTasa,
                costoDivisa = s.costoDivisa,
                descTasa = s.descTasa,
                estatusDivisa = s.estatusDivisa,
                valorTasa = s.valorTasa,
                fechaUltActualizacionCosto = _fechaUltActCosto,
                nombreEmpInv= s.nombreEmpInv,
                contEmpInv= s.contEmpInv,
            };
            rt.Entidad = new OOB.LibInventario.Movimiento.Cargo.CapturaMov.Ficha()
            {
                data = ent,
            };
            return rt;
        }
        //
        public OOB.ResultadoEntidad<OOB.LibInventario.Movimiento.Traslado.CapturaMov.Ficha> 
            Producto_Movimiento_Traslado_CaptureMov(OOB.LibInventario.Movimiento.Traslado.CapturaMov.Filtro filtro)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Movimiento.Traslado.CapturaMov.Ficha>();

            var filtroDto = new DtoLibInventario.Movimiento.Traslado.CapturaMov.Filtro()
            {
                idDepOrigen = filtro.idDeposito,
                idDepDestino = filtro.IdDepDestino,
                idProducto = filtro.idProducto,
            };
            var r01 = MyData.Producto_Movimiento_Traslado_Capture(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            var s = r01.Entidad.data;
            var _fechaNula = new DateTime(2000, 01, 01);
            var _fechaUltActCosto = "";
            if (s.fechaUltActCosto == _fechaNula)
            {
                _fechaUltActCosto = "";
            }
            else
            {
                _fechaUltActCosto = s.fechaUltActCosto.ToShortDateString();
            }

            var ent = new OOB.LibInventario.Movimiento.Traslado.CapturaMov.Data()
            {
                autoDepart = s.autoDepart,
                autoGrupo = s.autoGrupo,
                autoPrd = s.autoPrd,
                catPrd = s.catPrd,
                codigoPrd = s.codigoPrd,
                contEmp = s.contEmp,
                costo = s.costo,
                costoUnd = s.costoUnd,
                decimales = s.decimales,
                exFisica = s.exFisica,
                nombreEmp = s.nombreEmp,
                nombrePrd = s.nombrePrd,
                autoTasa = s.autoTasa,
                costoDivisa = s.costoDivisa,
                descTasa = s.descTasa,
                estatusDivisa = s.estatusDivisa,
                valorTasa = s.valorTasa,
                fechaUltActualizacionCosto = _fechaUltActCosto,
                nombreEmpInv = s.nombreEmpInv,
                contEmpInv = s.contEmpInv,
            };
            rt.Entidad = new OOB.LibInventario.Movimiento.Traslado.CapturaMov.Ficha()
            {
                data = ent,
            };
            return rt;
        }

        //
        public OOB.ResultadoAuto 
            Producto_Movimiento_AjustePorToma_Insertar(OOB.LibInventario.Movimiento.AjustePorToma.Insertar.Ficha data)
        {
            var rt = new OOB.ResultadoAuto();

            var mov = data.mov;
            var movDTO = new DtoLibInventario.Movimiento.AjustePorToma.Insertar.FichaMov()
            {
                autoConcepto = mov.autoConcepto,
                autoDepositoDestino = mov.autoDepositoDestino,
                autoDepositoOrigen = mov.autoDepositoOrigen,
                autoRemision = mov.autoRemision,
                autorizado = mov.autorizado,
                autoUsuario = mov.autoUsuario,
                cierreFtp = mov.cierreFtp,
                codConcepto = mov.codConcepto,
                codDepositoDestino = mov.codDepositoDestino,
                codDepositoOrigen = mov.codDepositoOrigen,
                codigoSucursal = mov.codigoSucursal,
                codUsuario = mov.codUsuario,
                desConcepto = mov.desConcepto,
                desDepositoDestino = mov.desDepositoDestino,
                desDepositoOrigen = mov.desDepositoOrigen,
                documentoNombre = mov.documentoNombre,
                estacion = mov.estacion,
                estatusAnulado = mov.estatusAnulado,
                estatusCierreContable = mov.estatusCierreContable,
                nota = mov.nota,
                renglones = mov.renglones,
                situacion = mov.situacion,
                tipo = mov.tipo,
                total = mov.total,
                usuario = mov.usuario,
                factorCambio = mov.factorCambio,
                montoDivisa = mov.montoDivisa,
            };
            var movDetDTO = data.movDetalles.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.AjustePorToma.Insertar.FichaMovDetalle()
                {
                    autoDepartamento = s.autoDepartamento,
                    autoGrupo = s.autoGrupo,
                    autoProducto = s.autoProducto,
                    cantidad = s.cantidad,
                    cantidadBono = s.cantidadBono,
                    cantidadUnd = s.cantidadUnd,
                    categoria = s.categoria,
                    codigoProducto = s.codigoProducto,
                    contEmpaque = s.contEmpaque,
                    costoCompra = s.costoCompra,
                    costoUnd = s.costoUnd,
                    decimales = s.decimales,
                    empaque = s.empaque,
                    estatusAnulado = s.estatusAnulado,
                    estatusUnidad = s.estatusUnidad,
                    nombreProducto = s.nombreProducto,
                    signo = s.signo,
                    tipo = s.tipo,
                    total = s.total,
                };
                return dt;
            }).ToList();
            var movKardexDTO = data.movKardex.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.AjustePorToma.Insertar.FichaMovKardex()
                {
                    autoConcepto = s.autoConcepto,
                    autoDeposito = s.autoDeposito,
                    autoProducto = s.autoProducto,
                    cantidad = s.cantidad,
                    cantidadBono = s.cantidadBono,
                    cantidadUnd = s.cantidadUnd,
                    codigoMov = s.codigoMov,
                    codigoSucursal = s.codigoSucursal,
                    costoUnd = s.costoUnd,
                    entidad = s.entidad,
                    estatusAnulado = s.estatusAnulado,
                    modulo = s.modulo,
                    nota = s.nota,
                    precioUnd = s.precioUnd,
                    siglasMov = s.siglasMov,
                    signoMov = s.signoMov,
                    total = s.total,
                    codigoConcepto = s.codigoConcepto,
                    nombreConcepto = s.nombreConcepto,
                    codigoDeposito = s.codigoDeposito,
                    nombreDeposito = s.nombreDeposito,
                    factorCambio = s.factorCambio,
                };
                return dt;
            }).ToList();
            var movDepDTO = data.movDeposito.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.AjustePorToma.Insertar.FichaMovDeposito()
                {
                    autoProducto = s.autoProducto,
                    autoDeposito = s.autoDeposito,
                    cantidadUnd = s.cantidadUnd,
                    nombreProducto = s.nombreProducto,
                    nombreDeposito = s.nombreDeposito,
                };
                return dt;
            }).ToList();
            var fichaDto = new DtoLibInventario.Movimiento.AjustePorToma.Insertar.Ficha()
            {
                mov = movDTO,
                movDeposito = movDepDTO,
                movDetalles = movDetDTO,
                movKardex = movKardexDTO,
                idToma = data.idToma,
                prdToma = data.prdToma.Select(s => 
                {
                    var nr = new DtoLibInventario.Movimiento.AjustePorToma.Insertar.FichaPrdToma()
                    {
                        autoDeposito = s.autoDeposito,
                        autoProducto = s.autoProducto,
                        resultadoConteo = s.resultadoConteo,
                    };
                    return nr;
                }).ToList(),
            };
            var r01 = MyData.Producto_Movimiento_AjustePorToma_Insertar(fichaDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Auto = r01.Auto;

            return rt;
        }
    }
}