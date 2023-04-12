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
        public OOB.ResultadoLista<OOB.LibInventario.Producto.Data.EmpaqueVenta> 
            Producto_ModoAdm_GetEmpaqueVenta_By(string autoPrd)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Producto.Data.EmpaqueVenta>();
            var r01 = MyData.Producto_ModoAdm_GetEmpaqueVenta_By (autoPrd);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var _lst = new List<OOB.LibInventario.Producto.Data.EmpaqueVenta>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    _lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibInventario.Producto.Data.EmpaqueVenta()
                        {
                            autoEmp = s.autoEmp,
                            contEmp = s.contEmp,
                            id = s.id,
                            tipoEmp = s.tipoEmp,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = _lst;
            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.ModoAdm.Precio.Ficha> 
            Producto_ModoAdm_GetPrecio_By(string autoPrd, string tipoPrecio)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.ModoAdm.Precio.Ficha>();
            var r01 = MyData.Producto_ModoAdm_GetPrecio_By(autoPrd, tipoPrecio);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var p= r01.Entidad.entidad;
            var _ent = new OOB.LibInventario.Producto.Data.ModoAdm.Precio.Entidad()
            {
                auto = p.auto,
                codigo = p.codigo,
                descripcion = p.descripcion,
                estatusDivisa = p.estatusDivisa,
                tasaIva = p.tasaIva,
            };
            var _lst = new List<OOB.LibInventario.Producto.Data.ModoAdm.Precio.Precio>();
            if (r01.Entidad.precios != null) 
            {
                if (r01.Entidad.precios.Count > 0) 
                {
                    _lst = r01.Entidad.precios.Select(s =>
                    {
                        var nr = new OOB.LibInventario.Producto.Data.ModoAdm.Precio.Precio()
                        {
                            idHndEmpresaPrecio = s.idHndEmpresaPrecio,
                            idHndEmpVenta = s.idHndEmpVenta,
                            idHndPrecioVenta = s.idHndPrecioVenta,
                            autoEmp = s.autoEmp,
                            contEmp = s.contEmp,
                            descEmp = s.descEmp,
                            ofertaDesde = s.ofertaDesde,
                            ofertaEstatus = s.ofertaEstatus,
                            ofertaHasta = s.ofertaHasta,
                            ofertaPorct = s.ofertaPorct,
                            pfdEmp = s.pfdEmp,
                            pnEmp = s.pnEmp,
                            tipoEmp = s.tipoEmp,
                            utEmp = s.utEmp,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Entidad = new OOB.LibInventario.Producto.Data.ModoAdm.Precio.Ficha()
            {
                entidad = _ent,
                precios = _lst,
            };
            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.ModoAdm.Costo.Ficha> 
            Producto_ModoAdm_GetCosto_By(string autoPrd)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.ModoAdm.Costo.Ficha>();
            var r01 = MyData.Producto_ModoAdm_GetCosto_By(autoPrd);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var p = r01.Entidad;
            rt.Entidad = new OOB.LibInventario.Producto.Data.ModoAdm.Costo.Ficha()
            {
                auto = p.auto,
                codigo = p.codigo,
                descripcion = p.descripcion,
                estatusDivisa = p.estatusDivisa,
                tasaIva = p.tasaIva,
                autoEmpCompra = p.autoEmpCompra,
                contEmpCompra = p.contEmpCompra,
                costoMonedaDivisa = p.costoMonedaDivisa,
                costoMonedaLocal = p.costoMonedaLocal,
                descEmpCompra = p.descEmpCompra,
            };
            return rt;
        }
        public OOB.Resultado 
            Producto_ModoAdm_ActualizarPrecio(OOB.LibInventario.Producto.ActualizarPrecio.ModoAdm.Ficha ficha)
        {
            var rt = new OOB.Resultado();
            var fichaDTO = new DtoLibInventario.Producto.ActualizarPrecio.ModoAdm.Ficha()
            {
                autoPrd = ficha.autoPrd,
                estacion = ficha.estacion,
                factorCambio = ficha.factorCambio,
                nota = ficha.nota,
                prdCodigo = ficha.prdCodigo,
                prdDesc = ficha.prdDesc,
                usuCodigo = ficha.usuCodigo,
                usuNombre = ficha.usuNombre,
                precios = ficha.precios.Select(s =>
                {
                    var nr = new DtoLibInventario.Producto.ActualizarPrecio.ModoAdm.Precio()
                    {
                        fullDivisa = s.fullDivisa,
                        id = s.id,
                        netoMonedaLocal = s.netoMonedaLocal,
                        utilidad = s.utilidad,
                    };
                    return nr;
                }).ToList(),
                historia = ficha.historia.Select(s =>
                {
                    var nr = new DtoLibInventario.Producto.ActualizarPrecio.ModoAdm.Historia()
                    {
                        empCont = s.empCont,
                        empDesc = s.empDesc,
                        fullDivisa = s.fullDivisa,
                        netoMonLocal = s.netoMonLocal,
                        tipoEmpaqueVenta = s.tipoEmpaqueVenta,
                        tipoPrecioVenta = s.tipoPrecioVenta,
                    };
                    return nr;
                }).ToList(),
            };
            var r01 = MyData.Producto_ModoAdm_ActualizarPrecio(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Producto.HistoricoPrecio.ModoAdm.Ficha> 
            Producto_ModoAdm_HistoricoPrecio_By(OOB.LibInventario.Producto.HistoricoPrecio.Filtro filtro)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Producto.HistoricoPrecio.ModoAdm.Ficha>();
            var filtroDTO = new DtoLibInventario.Producto.HistoricoPrecio.Filtro()
            {
                autoProducto = filtro.autoPrd,
            };
            var r01 = MyData.Producto_ModoAdm_HistoricoPrecio_By(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var ficha = new OOB.LibInventario.Producto.HistoricoPrecio.ModoAdm.Ficha()
            {
                prdCodigo = r01.Entidad.prdCodigo,
                prdDescripcion = r01.Entidad.prdDescripcion,
            };
            var list = new List<OOB.LibInventario.Producto.HistoricoPrecio.ModoAdm.Data>();
            if (r01.Entidad.data != null)
            {
                if (r01.Entidad.data.Count > 0)
                {
                    list = r01.Entidad.data.Select(s =>
                    {
                        return new OOB.LibInventario.Producto.HistoricoPrecio.ModoAdm.Data()
                        {
                            empCont = s.empCont,
                            empDescripcion = s.empDescripcion,
                            factorCambio = s.factorCambio,
                            fullDivisa = s.fullDivisa,
                            netoMonLocal = s.netoMonLocal,
                            tipoEmpVta = s.tipoEmpVta,
                            tipoPrecioVta = s.tipoPrecioVta,
                            usuCodigo = s.usuCodigo,
                            usuNombre = s.usuNombre,
                            estacion = s.estacion,
                            fecha = s.fecha,
                            hora = s.hora,
                            nota = s.nota,
                        };
                    }).ToList();
                }
            }
            ficha.data = list;
            rt.Entidad = ficha;
            return rt;
        }
        public OOB.Resultado 
            Producto_ModoAdm_ActualizarOferta(OOB.LibInventario.Producto.ActualizarOferta.ModoAdm.Actualizar.Ficha ficha)
        {
            var rt = new OOB.Resultado();
            var fichaDTO = new DtoLibInventario.Producto.ActualizarOferta.ModoAdm.Actualizar.Ficha()
            {
                autoPrd = ficha.autoPrd,
                estatusOferta = ficha.estatusOferta,
                ofertas = ficha.ofertas.Select(s =>
               {
                   var nr = new DtoLibInventario.Producto.ActualizarOferta.ModoAdm.Actualizar.Precio()
                   {
                       desde = s.desde,
                       estatus = s.estatus,
                       hasta = s.hasta,
                       idPrecioVta = s.idPrecioVta,
                       portc = s.portc,
                   };
                   return nr;
               }).ToList(),
            };
            var r01 = MyData.Producto_ModoAdm_ActualizarOferta(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            return rt;
        }
        public OOB.ResultadoLista<OOB.LibInventario.Producto.ActualizarOfertaMasiva.ModoAdm.Capturar.Ficha> 
            Producto_ModoAdm_OfertaMasiva_Capturar(OOB.LibInventario.Producto.ActualizarOfertaMasiva.ModoAdm.Capturar.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Producto.ActualizarOfertaMasiva.ModoAdm.Capturar.Ficha >();
            var filtroDTO = new DtoLibInventario.Producto.ActualizarOfertaMasiva.ModoAdm.Capturar.Filtro()
            {
                tipoEmpaque = filtro.tipoEmpaque,
                tipoPrecio = filtro.tipoPrecio,
                listadPrd = filtro.listadPrd,
            };
            var r01 = MyData.Producto_ModoAdm_OfertaMasiva_Capturar(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var _lst = new List<OOB.LibInventario.Producto.ActualizarOfertaMasiva.ModoAdm.Capturar.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    _lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibInventario.Producto.ActualizarOfertaMasiva.ModoAdm.Capturar.Ficha()
                        {
                            contEmpVta = s.contEmpVta,
                            costoUnd = s.costoUnd,
                            idPrd = s.idPrd,
                            pnetoVtaUnd = s.pnetoVtaUnd,
                            idPrecioVta=s.idPrecio,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = _lst;
            return rt;
        }
        public OOB.Resultado 
            Producto_ModoAdm_OfertaMasiva_Actualizar(OOB.LibInventario.Producto.ActualizarOfertaMasiva.ModoAdm.Actualizar.Ficha ficha)
        {
            var rt = new OOB.Resultado();
            var fichaDTO = new DtoLibInventario.Producto.ActualizarOfertaMasiva.ModoAdm.Actualizar.Ficha()
            {
                ofertas = ficha.ofertas.Select(s =>
                {
                    var nr = new DtoLibInventario.Producto.ActualizarOfertaMasiva.ModoAdm.Actualizar.Oferta()
                    {
                        desde = s.desde,
                        estatus = s.estatus,
                        hasta = s.hasta,
                        idPrecioVta = s.idPrecioVta,
                        portc = s.portc,
                        autoPrd = s.autoPrd,
                        estatusOferta = s.estatusOferta,
                    };
                    return nr;
                }).ToList(),
            };
            var r01 = MyData.Producto_ModoAdm_OfertaMasiva_Actualizar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            return rt;
        }
    }
}