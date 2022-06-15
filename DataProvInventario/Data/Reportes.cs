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
            };
            var r01 = MyData.Reportes_MaestroProducto(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
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
            };
            var r01 = MyData.Reportes_MaestroInventario(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
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
            };
            var r01 = MyData.Reportes_MaestroPrecio(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
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
                            codigoPrd = s.codigoPrd,
                            fechaUltCambioPrd = s.fechaUltCambioPrd,
                            isAdmDivisaPrd = (OOB.LibInventario.Reportes.enumerados.EnumAdministradorPorDivisa) s.isAdmDivisaPrd,
                            modeloPrd = s.modeloPrd,
                            nombrePrd = s.nombrePrd,
                            departamento=s.departamento,
                            precioDivisaFull_1 = s.precioDivisaFull_1,
                            precioDivisaFull_2 = s.precioDivisaFull_2,
                            precioDivisaFull_3 = s.precioDivisaFull_3,
                            precioDivisaFull_4 = s.precioDivisaFull_4,
                            precioDivisaFull_5 = s.precioDivisaFull_5,
                            precioNeto_1 = s.precioNeto_1,
                            precioNeto_2 = s.precioNeto_2,
                            precioNeto_3 = s.precioNeto_3,
                            precioNeto_4 = s.precioNeto_4,
                            precioNeto_5 = s.precioNeto_5,
                            referenciaPrd = s.referenciaPrd,
                            tasaIvaPrd = s.tasaIvaPrd,
                            grupo=s.grupo,
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
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
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

    }

}