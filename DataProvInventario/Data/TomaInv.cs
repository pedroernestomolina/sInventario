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
        public OOB.ResultadoLista<OOB.LibInventario.TomaInv.ObtenerToma.Ficha> 
            TomaInv_GetListaPrd(OOB.LibInventario.TomaInv.ObtenerToma.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.TomaInv.ObtenerToma.Ficha>();
            var filtroDTO = new DtoLibInventario.TomaInv.ObtenerToma.Filtro()
            {
                idDepartExcluir = filtro.idDepartExcluir,
                idDeposito = filtro.idDeposito,
                periodoDias = filtro.periodoDias,
            };
            var r01 = MyData.TomaInv_GetListaPrd(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var list = new List<OOB.LibInventario.TomaInv.ObtenerToma.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.TomaInv.ObtenerToma.Ficha()
                        {
                            cnt = s.cnt.HasValue ? s.cnt.Value : 0m,
                            codigoPrd = s.codigoPrd,
                            costoPrd = s.costoPrd.HasValue ? s.costoPrd.Value : 0m,
                            descPrd = s.descPrd,
                            idPrd = s.idPrd,
                            margen = s.margen.HasValue ? s.margen.Value : 0m,
                            cntMov = s.cntMov.HasValue ? s.cntMov.Value:0m,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;
            return rt;
        }
        public OOB.Resultado 
            TomaInv_GenerarToma(OOB.LibInventario.TomaInv.GenerarToma.Ficha ficha)
        {
            var rt = new OOB.Resultado();
            var lstPrd= new List<DtoLibInventario.TomaInv.GenerarToma.PrdToma>();
            foreach (var r in ficha.ProductosTomaInv)
            {
                var nr = new DtoLibInventario.TomaInv.GenerarToma.PrdToma()
                {
                    idPrd = r.IdPrd,
                };
                lstPrd.Add(nr);
            }
            var fichaDTO = new DtoLibInventario.TomaInv.GenerarToma.Ficha()
            {
                autorizadoPor = ficha.autorizadoPor,
                cantItems = ficha.cantItems,
                codigoDeposito = ficha.codigoDeposito,
                codigoSucursal = ficha.codigoSucursal,
                descDeposito = ficha.descDeposito,
                descSucursal = ficha.descSucursal,
                idDeposito = ficha.idDeposito,
                idSucursal = ficha.idSucursal,
                motivo = ficha.motivo,
                ProductosTomarInv = lstPrd,
            };
            var r01 = MyData.TomaInv_GenerarToma (fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.TomaInv.Analisis.Ficha> 
            TomaInv_Analisis(string idToma)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.TomaInv.Analisis.Ficha>();
            var r01 = MyData.TomaInv_AnalizarToma(idToma);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var _lst = new List<OOB.LibInventario.TomaInv.Analisis.Item>();
            if (r01.Entidad != null) 
            {
                if (r01.Entidad.Items != null) 
                {
                    if (r01.Entidad.Items.Count > 0) 
                    {
                        _lst = r01.Entidad.Items.Select(s =>
                        {
                            var nr = new OOB.LibInventario.TomaInv.Analisis.Item()
                            {
                                codPrd = s.codPrd,
                                cntCompra = s.cntCompra.HasValue ? s.cntCompra.Value : 0m,
                                conteo = s.conteo,
                                descPrd = s.descPrd,
                                fisico = s.fisico,
                                exDeposito = s.exDeposito.HasValue ? s.exDeposito.Value : 0m,
                                idPrd = s.idPrd,
                                cntMovInv = s.cntMovInv.HasValue ? s.cntMovInv.Value : 0m,
                                cntVenta = s.cntVenta.HasValue ? s.cntVenta.Value : 0m,
                                cntPorDespachar = s.cntPorDespachar.HasValue ? s.cntPorDespachar.Value : 0m,
                                costoMonDivisa = s.costoMonDivisa,
                                costoMonLocal = s.costoMonLocal,
                                contEmpCompra = s.contEmpCompra,
                                estatusDivisa = s.estatusDivisa,
                            };
                            return nr;
                        }).ToList();
                    };
                };
            };
            rt.Entidad = new OOB.LibInventario.TomaInv.Analisis.Ficha()
            {
                Items = _lst
            };
            return rt;
        }
        public OOB.Resultado 
            TomaInv_RechazarItemToma(OOB.LibInventario.TomaInv.RechazarItem.Ficha ficha)
        {
            var rt = new OOB.Resultado();
            var fichaDTO = new DtoLibInventario.TomaInv.RechazarItem.Ficha()
            {
                IdToma = ficha.IdToma,
                Items = ficha.Items.Select(s =>
                {
                    var nr = new DtoLibInventario.TomaInv.RechazarItem.Item()
                    {
                        IdPrd = s.IdPrd,
                    };
                    return nr;
                }).ToList(),
            };
            var r01 = MyData.TomaInv_RechazarItemsToma (fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            return rt;
        }
        public OOB.Resultado 
            TomaInv_Procesar(OOB.LibInventario.TomaInv.Procesar.Ficha ficha)
        {
            var rt = new OOB.Resultado();
            var fichaDTO = new DtoLibInventario.TomaInv.Procesar.Ficha()
            {
                autoriza = ficha.autoriza,
                cntItems = ficha.cntItems,
                idToma = ficha.idToma,
                observaciones = ficha.observaciones,
                items = ficha.items.Select(s =>
            {
                var nr = new DtoLibInventario.TomaInv.Procesar.Item()
                {
                    diferencia = s.diferencia,
                    estadoDesc = s.estadoDesc,
                    idProducto = s.idProducto,
                    signo = s.signo,
                    contEmpCompra = s.contEmpCompra,
                    costoMonDivisa = s.costoMonDivisa,
                    costoMonLocal = s.costoMonLocal,
                    estatusDivisa = s.estatusDivisa,
                };
                return nr;
            }).ToList(),
            };
            var r01 = MyData.TomaInv_ProcesarToma(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            return rt;
        }
        //
        public OOB.Resultado 
            TomaInv_GenerarSolcitud(OOB.LibInventario.TomaInv.Solicitud.Generar.Ficha ficha)
        {
            var rt = new OOB.Resultado();
            var lstPrd = new List<DtoLibInventario.TomaInv.Solicitud.Generar.PrdToma>();
            foreach (var r in ficha.ProductosTomaInv)
            {
                var nr = new DtoLibInventario.TomaInv.Solicitud.Generar.PrdToma()
                {
                    idPrd = r.IdPrd,
                };
                lstPrd.Add(nr);
            }
            var fichaDTO = new DtoLibInventario.TomaInv.Solicitud.Generar.Ficha()
            {
                autorizadoPor = ficha.autorizadoPor,
                cantItems = ficha.cantItems,
                codigoDeposito = ficha.codigoDeposito,
                codigoSucursal = ficha.codigoSucursal,
                descDeposito = ficha.descDeposito,
                descSucursal = ficha.descSucursal,
                idDeposito = ficha.idDeposito,
                idSucursal = ficha.idSucursal,
                motivo = ficha.motivo,
                ProductosTomarInv = lstPrd,
            };
            var r01 = MyData.TomaInv_GenerarSolicitud (fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            return rt;
        }
        public OOB.ResultadoEntidad<string> 
            TomaInv_EncontrarSolicitudActiva(string codigoEmpSuc)
        {
            var rt = new OOB.ResultadoEntidad<string>();
            var r01 = MyData.TomaInv_EncontrarSolicitudActiva(codigoEmpSuc);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            rt.Entidad = r01.Entidad;
            return rt;
        }
        public OOB.Resultado 
            TomaInv_ConvertirSolicitud_EnToma(string autoSolic, string codEmpSuc)
        {
            var rt = new OOB.Resultado();
            var ficha = new DtoLibInventario.TomaInv.ConvertirSolicitud.Ficha()
            {
                autoSolicitud = autoSolic,
                codigoEmpSuc = codEmpSuc,
            };
            var r01 = MyData.TomaInv_ConvertirSolicitud_EnToma(ficha);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            return rt;
        }
        public OOB.ResultadoEntidad<string> 
            TomaInv_Analizar_TomaDisponible()
        {
            var rt = new OOB.ResultadoEntidad<string>();
            var r01 = MyData.TomaInv_Analizar_TomaDisponible();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            rt.Entidad = r01.Entidad;
            return rt;
        }
    }
}