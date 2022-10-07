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

        public OOB.ResultadoLista<OOB.LibInventario.Reportes.MaestroProducto.Ficha> 
            Reportes_MaestroProducto(OOB.LibInventario.Reportes.MaestroProducto.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Reportes.MaestroProducto.Ficha>();

            var filtroDto = new DtoLibInventario.Reportes.MaestroProducto.Filtro()
            {
                autoDepartamento = filtro.autoDepartamento,
                autoDeposito=filtro.autoDeposito,
                autoTasa = filtro.autoTasa,
                autoGrupo=filtro.autoGrupo,
                admDivisa = (DtoLibInventario.Reportes.enumerados.EnumAdministradorPorDivisa)filtro.admDivisa,
                categoria = (DtoLibInventario.Reportes.enumerados.EnumCategoria)filtro.categoria,
                estatus = (DtoLibInventario.Reportes.enumerados.EnumEstatus)filtro.estatus,
                origen = (DtoLibInventario.Reportes.enumerados.EnumOrigen)filtro.origen,
                pesado = (DtoLibInventario.Reportes.enumerados.EnumPesado)filtro.pesado,
            };
            var r01 = MyData.Reportes_MaestroProducto(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }

            var list = new List<OOB.LibInventario.Reportes.MaestroProducto.Ficha>() ;
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Reportes.MaestroProducto.Ficha()
                        {
                            admDivisa = (OOB.LibInventario.Reportes.enumerados.EnumAdministradorPorDivisa) s.admDivisa,
                            categoria = (OOB.LibInventario.Reportes.enumerados.EnumCategoria) s.categoria,
                            codigoPrd = s.codigoPrd,
                            contenidoPrd = s.contenidoPrd,
                            departamento = s.departamento,
                            grupo= s.grupo,
                            empaque = s.empaque,
                            estatus = (OOB.LibInventario.Reportes.enumerados.EnumEstatus) s.estatus,
                            modeloPrd = s.modeloPrd,
                            nombrePrd = s.nombrePrd,
                            origen = (OOB.LibInventario.Reportes.enumerados.EnumOrigen) s.origen,
                            referenciaPrd = s.referenciaPrd,
                            tasaIva = s.tasaIva,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }
        public OOB.ResultadoLista<OOB.LibInventario.Reportes.MaestroInventario.Ficha> 
            Reportes_MaestroInventario(OOB.LibInventario.Reportes.MaestroInventario.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Reportes.MaestroInventario.Ficha>();

            var filtroDto = new DtoLibInventario.Reportes.MaestroInventario.Filtro()
            {
                autoDepartamento = filtro.autoDepartamento,
                autoDeposito = filtro.autoDeposito,
                autoGrupo = filtro.autoGrupo,
                autoTasa = filtro.autoTasa,
                admDivisa = (DtoLibInventario.Reportes.enumerados.EnumAdministradorPorDivisa)filtro.admDivisa,
                pesado = (DtoLibInventario.Reportes.enumerados.EnumPesado)filtro.pesado,
            };
            var r01 = MyData.Reportes_MaestroInventario(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }

            var list = new List<OOB.LibInventario.Reportes.MaestroInventario.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Reportes.MaestroInventario.Ficha()
                        {
                            admDivisa = (OOB.LibInventario.Reportes.enumerados.EnumAdministradorPorDivisa)s.admDivisa,
                            codigoPrd = s.codigoPrd,
                            departamento = s.departamento,
                            grupo = s.grupo,
                            estatus = (OOB.LibInventario.Reportes.enumerados.EnumEstatus)s.estatus,
                            modeloPrd = s.modeloPrd,
                            nombrePrd = s.nombrePrd,
                            referenciaPrd = s.referenciaPrd,
                            costoDivisaUnd = s.costoDivisaUnd,
                            costoUnd = s.costoUnd,
                            decimales = s.decimales,
                            existencia = s.existencia.HasValue ? s.existencia.Value : 0.0m,
                            pn1 = s.pn1.HasValue ? s.pn1.Value : 0.0m,
                            pn2 = s.pn2.HasValue ? s.pn2.Value : 0.0m,
                            pn3 = s.pn3.HasValue ? s.pn3.Value : 0.0m,
                            pn4 = s.pn4.HasValue ? s.pn4.Value : 0.0m,
                            pn5 = s.pn5.HasValue ? s.pn5.Value : 0.0m,
                            codigoSuc = s.codigoSuc,
                            nombreGrupo = s.nombreGrupo,
                            precioId = s.precioId,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }
        public OOB.ResultadoLista<OOB.LibInventario.Reportes.Top20.Ficha> 
            Reportes_Top20(OOB.LibInventario.Reportes.Top20.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Reportes.Top20.Ficha>();

            var filtroDto = new DtoLibInventario.Reportes.Top20.Filtro()
            {
                Desde = filtro.Desde,
                Hasta = filtro.Hasta,
                Modulo = (DtoLibInventario.Reportes.enumerados.EnumModulo) filtro.Modulo,
                autoDeposito=filtro.autoDeposito,
            };
            var r01 = MyData.Reportes_Top20(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Reportes.Top20.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Reportes.Top20.Ficha()
                        {
                            cntUnd = s.cntUnd,
                            cntDoc = s.cntDoc,
                            nombre = s.nombre,
                            codigo= s.codigo,
                            decimales = s.decimales,
                            esPesado = s.esPesado,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }
        public OOB.ResultadoLista<OOB.LibInventario.Reportes.MaestroExistencia.Ficha> 
            Reportes_MaestroExistencia(OOB.LibInventario.Reportes.MaestroExistencia.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Reportes.MaestroExistencia.Ficha>();

            var filtroDto = new DtoLibInventario.Reportes.MaestroExistencia.Filtro()
            {
                autoDepartamento = filtro.autoDepartamento,
                autoDeposito = filtro.autoDeposito,
                autoGrupo= filtro.autoGrupo,
            };
            var r01 = MyData.Reportes_MaestroExistencia(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Reportes.MaestroExistencia.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        var exFisica = 0.0m;
                        if (s.exFisica.HasValue)
                            exFisica = s.exFisica.Value;
                        return new OOB.LibInventario.Reportes.MaestroExistencia.Ficha()
                        {
                            autoDep = s.autoDep,
                            autoPrd = s.autoPrd,
                            codigoDep = s.codigoDep,
                            codigoPrd = s.codigoPrd,
                            decimales = s.decimales,
                            exFisica = exFisica,
                            nombreDep = s.nombreDep,
                            nombrePrd = s.nombrePrd,
                            codigoSuc = s.codigoSuc,
                            costoUndDivisa = s.costoUndDivisa,
                            pDivisaNeto_1 = s.pDivisaNeto_1,
                            pDivisaNeto_2 = s.pDivisaNeto_2,
                            pDivisaNeto_3 = s.pDivisaNeto_3,
                            pDivisaNeto_4 = s.pDivisaNeto_4,
                            pDivisaNeto_5 = s.pDivisaNeto_5,
                            precioId = s.precioId,
                            departamento=s.departamento,
                            grupo=s.grupo,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }
        public OOB.ResultadoLista<OOB.LibInventario.Reportes.MaestroPrecio.Ficha> 
            Reportes_MaestroPrecio(OOB.LibInventario.Reportes.MaestroPrecio.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Reportes.MaestroPrecio.Ficha>();

            var filtroDto = new DtoLibInventario.Reportes.MaestroPrecio.Filtro()
            {
                autoGrupo = filtro.autoGrupo,
                autoMarca = filtro.autoMarca,
                autoTasa = filtro.autoTasa,
                admDivisa = (DtoLibInventario.Reportes.enumerados.EnumAdministradorPorDivisa) filtro.admDivisa,
                autoDepartamento = filtro.autoDepartamento,
                categoria = (DtoLibInventario.Reportes.enumerados.EnumCategoria) filtro.categoria,
                origen = (DtoLibInventario.Reportes.enumerados.EnumOrigen) filtro.origen,
                precio = (DtoLibInventario.Reportes.enumerados.EnumPrecio) filtro.precio,
                pesado = (DtoLibInventario.Reportes.enumerados.EnumPesado) filtro.pesado,
            };
            var r01 = MyData.Reportes_MaestroPrecio(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }

            var list = new List<OOB.LibInventario.Reportes.MaestroPrecio.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Reportes.MaestroPrecio.Ficha()
                        {
                            codigo = s.codigo,
                            nombre = s.nombre,
                            admDivisa = s.admDivisa,
                            departamento = s.departamento,
                            grupo = s.grupo,
                            tasa = s.tasa,

                            p1_neto=s.p1_neto,
                            p2_neto=s.p2_neto,
                            p3_neto=s.p3_neto,
                            p4_neto=s.p4_neto,
                            p5_neto=s.p5_neto,
                            cont_1=s.cont_1,
                            cont_2=s.cont_2,
                            cont_3=s.cont_3,
                            cont_4=s.cont_4,
                            cont_5=s.cont_5,
                            p1_div_full= s.p1_div_full,
                            p2_div_full= s.p2_div_full,
                            p3_div_full= s.p3_div_full,
                            p4_div_full= s.p4_div_full,
                            p5_div_full= s.p5_div_full,
                            empaque_1=s.empaque_1,
                            empaque_2=s.empaque_2,
                            empaque_3=s.empaque_3,
                            empaque_4=s.empaque_4,
                            empaque_5=s.empaque_5,

                            pM1_neto = s.pM1_neto,
                            pM2_neto = s.pM2_neto,
                            pM3_neto = s.pM3_neto,
                            pM4_neto = s.pM4_neto,
                            cont_M1 = s.cont_M1,
                            cont_M2 = s.cont_M2,
                            cont_M3 = s.cont_M3,
                            cont_M4 = s.cont_M4,
                            pM1_div_full = s.pM1_div_full,
                            pM2_div_full = s.pM2_div_full,
                            pM3_div_full = s.pM3_div_full,
                            pM4_div_full = s.pM4_div_full,
                            empaque_M1 = s.empaque_M1,
                            empaque_M2 = s.empaque_M2,
                            empaque_M3 = s.empaque_M3,
                            empaque_M4 = s.empaque_M4,

                            pD1_neto = s.pD1_neto,
                            pD2_neto = s.pD2_neto,
                            pD3_neto = s.pD3_neto,
                            pD4_neto = s.pD4_neto,
                            cont_D1 = s.cont_D1,
                            cont_D2 = s.cont_D2,
                            cont_D3 = s.cont_D3,
                            cont_D4 = s.cont_D4,
                            pD1_div_full = s.pD1_div_full,
                            pD2_div_full = s.pD2_div_full,
                            pD3_div_full = s.pD3_div_full,
                            pD4_div_full = s.pD4_div_full,
                            empaque_D1 = s.empaque_D1,
                            empaque_D2 = s.empaque_D2,
                            empaque_D3 = s.empaque_D3,
                            empaque_D4 = s.empaque_D4,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Reportes.Kardex.Ficha> 
            Reportes_Kardex(OOB.LibInventario.Reportes.Kardex.Filtro filtro)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Reportes.Kardex.Ficha>();

            var filtroDto = new DtoLibInventario.Reportes.Kardex.Filtro()
            {
                autoDeposito = filtro.autoDeposito,
                autoProducto = filtro.autoProducto,
                desde = filtro.desde,
                hasta = filtro.hasta,
            };
            var r01 = MyData.Reportes_Kardex(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }

            var mov= new List<OOB.LibInventario.Reportes.Kardex.Mov>();
            var ex = new List<OOB.LibInventario.Reportes.Kardex.Existencia>();
            var xmov = r01.Entidad.movimientos;
            if (xmov != null)
            {
                if (xmov.Count > 0)
                {
                    mov = xmov.Select(s =>
                    {
                        return new OOB.LibInventario.Reportes.Kardex.Mov()
                        {
                            autoPrd = s.autoPrd,
                            codigoPrd = s.codigoPrd,
                            modeloPrd = s.modeloPrd,
                            nombrePrd = s.nombrePrd,
                            referenciaPrd = s.referenciaPrd,
                            cantidadUnd = s.cantidadUnd,
                            concepto = s.concepto,
                            decimalesPrd = s.decimalesPrd,
                            deposito = s.deposito,
                            documentoNro = s.documentoNro,
                            entidadMov = s.entidadMov,
                            existenciaInicial = s.existenciaInicial,
                            fechaMov = s.fechaMov,
                            horaMov = s.horaMov,
                            moduloMov = s.moduloMov,
                            siglasMov = s.siglasMov,
                            signoMov = s.signoMov,
                        };
                    }).ToList();
                }
            }
            var xex = r01.Entidad.exInicial;
            if (xex!= null)
            {
                if (xex.Count > 0)
                {
                    ex = xex.Select(s =>
                    {
                        return new OOB.LibInventario.Reportes.Kardex.Existencia()
                        {
                            exInicial = s.exInicial == null ? 0m : s.exInicial.Value,
                            autoPrd = s.autoPrd,
                        };
                    }).ToList();
                }
            }
            rt.Entidad = new OOB.LibInventario.Reportes.Kardex.Ficha()
            {
                exInicial = ex,
                movimientos = mov,
            };
            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Reportes.CompraVentaAlmacen.Ficha> 
            Reportes_CompraVentaAlmacen(OOB.LibInventario.Reportes.CompraVentaAlmacen.Filtro filtro)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Reportes.CompraVentaAlmacen.Ficha>();

            var filtroDto = new DtoLibInventario.Reportes.CompraVentaAlmacen.Filtro()
            {
                autoProducto = filtro.autoProducto,
            };
            var r01 = MyData.Reportes_CompraVentaAlmacen (filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var f = new OOB.LibInventario.Reportes.CompraVentaAlmacen.Ficha()
            {
                contenido = r01.Entidad.contenido,
                empaque = r01.Entidad.empaque,
                exUnd = r01.Entidad.exUnd.HasValue ? r01.Entidad.exUnd.Value : 0.0m,
                prdCodigo = r01.Entidad.prdCodigo,
                prdNombre = r01.Entidad.prdNombre,
                costoDivisaUnd = r01.Entidad.costoDivisaUnd,
            };
            var fCompra = new List<OOB.LibInventario.Reportes.CompraVentaAlmacen.FichaCompra>();
            var fVenta = new List<OOB.LibInventario.Reportes.CompraVentaAlmacen.FichaVenta>();
            var fAlmacen= new List<OOB.LibInventario.Reportes.CompraVentaAlmacen.FichaAlmacen>();
            if (r01.Entidad != null)
            {
                var lcompra = r01.Entidad.compras;
                if (lcompra.Count > 0)
                {
                    fCompra = lcompra.Select(s =>
                    {
                        return new OOB.LibInventario.Reportes.CompraVentaAlmacen.FichaCompra()
                        {
                            cnt = s.cnt,
                            cntUnd = s.cntUnd,
                            contenido = s.contenido,
                            costoDivisaUnd = s.costoDivisaUnd,
                            costoUnd = s.costoUnd,
                            documento = s.documento,
                            empaque = s.empaque,
                            factor = s.factor,
                            fecha = s.fecha,
                            signoDoc = s.signoDoc,
                            tipoDoc = s.tipoDoc,
                            esAnulado=s.isAnulado,
                        };
                    }).ToList();
                }

                var lventa = r01.Entidad.ventas;
                if (lventa.Count > 0)
                {
                    fVenta= lventa.Select(s =>
                    {
                        return new OOB.LibInventario.Reportes.CompraVentaAlmacen.FichaVenta()
                        {
                            cnt = s.cnt,
                            factor = s.factor,
                            montoCosto = s.montoCosto,
                            montoCostoDivisa = s.montoCostoDivisa,
                            montoVenta = s.montoVenta,
                            montoVentaDivisa = s.montoVentaDivisa,
                            tipoDoc = s.tipoDoc,
                        };
                    }).ToList();
                }

                var lalmacen= r01.Entidad.almacen;
                if (lalmacen.Count > 0)
                {
                    fAlmacen = lalmacen.Select(s =>
                    {
                        return new OOB.LibInventario.Reportes.CompraVentaAlmacen.FichaAlmacen()
                        {
                            cantUnd = s.cantUnd,
                            costoUnd = s.costoUnd,
                            documento = s.documento,
                            fecha = s.fecha,
                            isAnulado = s.isAnulado,
                            nombreDoc = s.nombreDoc,
                            nota = s.nota,
                            signo = s.signo,
                        };
                    }).ToList();
                }

            }
            f.compras = fCompra;
            f.ventas = fVenta;
            f.almacen = fAlmacen;
            rt.Entidad = f;

            return rt;
        }
        public OOB.ResultadoLista<OOB.LibInventario.Reportes.DepositoResumen.Ficha> 
            Reportes_DepositoResumen()
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Reportes.DepositoResumen.Ficha>();

            var r01 = MyData.Reportes_DepositoResumen();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Reportes.DepositoResumen.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Reportes.DepositoResumen.Ficha()
                        {
                            cntStock=s.cntStock,
                            autoDeposito=s.autoDeposito,
                            cItem = s.cItem,
                            codigoSuc = s.codigoSuc,
                            costo = s.costo,
                            nombreDeposito = s.nombreDeposito,
                            nombreGrupo = s.nombreGrupo,
                            pn1 = s.pn1,
                            pn2 = s.pn2,
                            pn3 = s.pn3,
                            pn4 = s.pn4,
                            pn5 = s.pn5,
                            precioId = s.precioId,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }
        public OOB.ResultadoLista<OOB.LibInventario.Reportes.NivelMinimo.Ficha> 
            Reportes_NivelMinimo(OOB.LibInventario.Reportes.NivelMinimo.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Reportes.NivelMinimo.Ficha>();

            var filtroDto = new DtoLibInventario.Reportes.MaestroNivelMinimo.Filtro()
            {
                autoDeposito = filtro.autoDeposito,
                autoDepartamento= filtro.autoDepartamento,
                autoGrupo=filtro.autoGrupo,
            };
            var r01 = MyData.Reportes_NivelMinimo(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Reportes.NivelMinimo.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Reportes.NivelMinimo.Ficha()
                        {
                            codigoDep = s.codigoDep,
                            codigoPrd = s.codigoPrd,
                            existencia = s.existencia,
                            nivelMax = s.nivelMax,
                            nivelMin = s.nivelMin,
                            nombreDep = s.nombreDep,
                            nombrePrd = s.nombrePrd,
                            departamento=s.departamento,
                            grupo=s.grupo,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }
        public OOB.ResultadoLista<OOB.LibInventario.Reportes.Valorizacion.Ficha> 
            Reportes_Valorizacion(OOB.LibInventario.Reportes.Valorizacion.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Reportes.Valorizacion.Ficha>();

            var filtroDto = new DtoLibInventario.Reportes.Valorizacion.Filtro()
            {
                hasta = filtro.hasta,
                idDeposito=filtro.idDeposito,
            };
            var r01 = MyData.Reportes_Valorizacion(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Reportes.Valorizacion.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        var costHist = s.divisa/s.contEmpComp;
                        if (s.costoHist.HasValue) { costHist = Math.Round(s.costoHist.Value / s.contEmpComp, 2, MidpointRounding.AwayFromZero); }
                        return new OOB.LibInventario.Reportes.Valorizacion.Ficha()
                        {
                            auto = s.auto,
                            cntUnd = s.cntUnd,
                            codigo = s.codigo,
                            contEmpComp = s.contEmpComp,
                            costoHist = costHist,
                            costoUnd = s.costoUnd,
                            departamento = s.departamento,
                            grupo = s.grupo,
                            nombre = s.nombre,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }
        public OOB.ResultadoLista<OOB.LibInventario.Reportes.KardexResumen.Ficha> 
            Reportes_KardexResumen(OOB.LibInventario.Reportes.Kardex.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Reportes.KardexResumen.Ficha>();

            var filtroDto = new DtoLibInventario.Reportes.Kardex.Filtro()
            {
                autoDeposito = filtro.autoDeposito,
                autoProducto = filtro.autoProducto,
                desde = filtro.desde,
                hasta = filtro.hasta,
            };
            var r01 = MyData.Reportes_KardexResumen(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Reportes.KardexResumen.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Reportes.KardexResumen.Ficha()
                        {
                            cnt = s.cnt,
                            concepto = s.concepto,
                            exInicial = s.exInicial.HasValue ? s.exInicial.Value : 0m,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }
        public OOB.ResultadoLista<OOB.LibInventario.Reportes.MaestroExistenciaInventario.Ficha> 
            Reportes_MaestroExistenciaInventario(OOB.LibInventario.Reportes.MaestroExistenciaInventario.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Reportes.MaestroExistenciaInventario.Ficha>();

            var filtroDto = new DtoLibInventario.Reportes.MaestroExistenciaInventario.Filtro()
            {
                autoDepartamento = filtro.autoDepartamento,
                autoDeposito = filtro.autoDeposito,
                autoGrupo = filtro.autoGrupo,
            };
            var r01 = MyData.Reportes_MaestroExistenciaInventario(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Reportes.MaestroExistenciaInventario.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Reportes.MaestroExistenciaInventario.Ficha()
                        {
                            codigoPrd = s.codigoPrd,
                            contEmpCompra = s.contEmpCompra,
                            contEmpInv = s.contEmpInv,
                            eFisica = s.eFisica,
                            nombreDepart = s.nombreDepart,
                            nombreEmpCompra = s.nombreEmpCompra,
                            nombreEmpInv = s.nombreEmpInv,
                            nombreGrupo = s.nombreGrupo,
                            nombrePrd = s.nombrePrd,
                            nombreDeposito=s.nombreDeposito,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Reportes.ResumenCostoInv.Ficha> 
            Reportes_ResumenCostoInventario(OOB.LibInventario.Reportes.ResumenCostoInv.Filtro filtro)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Reportes.ResumenCostoInv.Ficha>();

            var filtroDto = new DtoLibInventario.Reportes.ResumenCostoInv.Filtro()
            {
                autoDepartamento = filtro.autoDepartamento,
                autoDeposito = filtro.autoDeposito,
                autoGrupo = filtro.autoGrupo,
                desde = filtro.desde,
                hasta = filtro.hasta,
            };
            var r01 = MyData.Reportes_ResumenCostoInventario(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var l_inv = new List<OOB.LibInventario.Reportes.ResumenCostoInv.PorInventario>();
            var lst_inv = r01.Entidad.enInventario;
            if (lst_inv != null)
            {
                if (lst_inv.Count > 0)
                {
                    l_inv = lst_inv.Select(s =>
                    {
                        var _ex = 0m;
                        var _costo = 0m;
                        if (s.exIniUnd.HasValue)
                            _ex = s.exIniUnd.Value;
                        if (s.costoIniEmpDivisa.HasValue)
                            _costo = s.costoIniEmpDivisa.Value;

                        return new OOB.LibInventario.Reportes.ResumenCostoInv.PorInventario()
                        {
                            autoPrd = s.autoPrd,
                            codigoPrd = s.codigoPrd,
                            contEmpPrd = s.contEmpPrd,
                            costoIniEmpDivisa = _costo,
                            exIniUnd = _ex,
                            nombrePrd = s.nombrePrd,
                        };
                    }).ToList();
                }
            }

            var l_movInv = new List<OOB.LibInventario.Reportes.ResumenCostoInv.PorMovInventario>();
            var lst_movInv = r01.Entidad.enMovInv;
            if (lst_movInv  != null)
            {
                if (lst_movInv.Count > 0)
                {
                    l_movInv = lst_movInv.Select(s =>
                    {
                        return new OOB.LibInventario.Reportes.ResumenCostoInv.PorMovInventario()
                        {
                            auto = s.auto,
                            cntUnd = s.cntUnd,
                            costoTotal = s.costoTotal,
                            documento = s.documento,
                            factor = s.factor,
                            siglas = s.siglas,
                        };
                    }).ToList();
                }
            }

            var l_compra = new List<OOB.LibInventario.Reportes.ResumenCostoInv.PorCompras>();
            var lst_compra = r01.Entidad.enCompras;
            if (lst_compra != null)
            {
                if (lst_compra.Count > 0)
                {
                    l_compra= lst_compra.Select(s =>
                    {
                        return new OOB.LibInventario.Reportes.ResumenCostoInv.PorCompras()
                        {
                            auto = s.auto,
                            cntUnd = s.cntUnd,
                            costoTotal = s.costoTotal,
                            documento = s.documento,
                            factor = s.factor,
                            siglas = s.siglas,
                        };
                    }).ToList();
                }
            }

            var l_venta= new List<OOB.LibInventario.Reportes.ResumenCostoInv.PorVentas>();
            var lst_venta= r01.Entidad.enVentas;
            if (lst_venta!= null)
            {
                if (lst_venta.Count > 0)
                {
                    l_venta = lst_venta.Select(s =>
                    {
                        return new OOB.LibInventario.Reportes.ResumenCostoInv.PorVentas()
                        {
                            auto = s.auto,
                            cntUnd = s.cntUnd,
                            costoDivisa = s.costoDivisa,
                            siglas = s.siglas,
                            ventaDivisa = s.ventaDivisa,
                        };
                    }).ToList();
                }
            }
            rt.Entidad = new OOB.LibInventario.Reportes.ResumenCostoInv.Ficha()
            {
                enInventario = l_inv,
                enMovInv= l_movInv,
                enCompras = l_compra,
                enVentas = l_venta,
            };
            return rt;
        }

    }

}