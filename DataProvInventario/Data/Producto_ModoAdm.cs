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
                nombreUsuario = ficha.nombreUsuario,
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
                        contenido = s.contenido,
                        empaque = s.empaque,
                        factorCambio = s.factorCambio,
                        nota = s.nota,
                        precio = s.precio,
                        precio_id = s.precio_id,
                    };
                    return nr;
                }).ToList(),
            };
            var r01 = MyData.Producto_ModoAdm_ActualizarPrecio(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            return rt;

            //var historia = new List<DtoLibInventario.Precio.Editar.FichaHistorica>();
            //if (ficha.historia != null) 
            //{
            //    foreach (var it in ficha.historia)
            //    {
            //        var nr = new DtoLibInventario.Precio.Editar.FichaHistorica()
            //        {
            //            nota = it.nota,
            //            precio = it.precio,
            //            precio_id = it.precio_id,
            //            contenido = it.contenido,
            //            empaque = it.empaque,
            //            factorCambio= it.factorCambio,
            //        };
            //        historia.Add(nr);
            //    }
            //}
            //fichaDTO.historia = historia;
            //if (ficha.precio_1 != null) 
            //{
            //    var precio_1 = new DtoLibInventario.Precio.Editar.FichaPrecio()
            //    {
            //        autoEmp = ficha.precio_1.autoEmp,
            //        contenido = ficha.precio_1.contenido,
            //        precioNeto = ficha.precio_1.precioNeto,
            //        precio_divisa_Neto = ficha.precio_1.precio_divisa_Neto,
            //        utilidad = ficha.precio_1.utilidad,
            //    };
            //    fichaDTO.precio_1 = precio_1;
            //}
            //if (ficha.precio_2 != null)
            //{
            //    var precio_2 = new DtoLibInventario.Precio.Editar.FichaPrecio()
            //    {
            //        autoEmp = ficha.precio_2.autoEmp,
            //        contenido = ficha.precio_2.contenido,
            //        precioNeto = ficha.precio_2.precioNeto,
            //        precio_divisa_Neto = ficha.precio_2.precio_divisa_Neto,
            //        utilidad = ficha.precio_2.utilidad,
            //    };
            //    fichaDTO.precio_2 = precio_2;
            //}
            //if (ficha.precio_3 != null)
            //{
            //    var precio_3 = new DtoLibInventario.Precio.Editar.FichaPrecio()
            //    {
            //        autoEmp = ficha.precio_3.autoEmp,
            //        contenido = ficha.precio_3.contenido,
            //        precioNeto = ficha.precio_3.precioNeto,
            //        precio_divisa_Neto = ficha.precio_3.precio_divisa_Neto,
            //        utilidad = ficha.precio_3.utilidad,
            //    };
            //    fichaDTO.precio_3 = precio_3;
            //}
            //if (ficha.precio_4 != null)
            //{
            //    var precio_4 = new DtoLibInventario.Precio.Editar.FichaPrecio()
            //    {
            //        autoEmp = ficha.precio_4.autoEmp,
            //        contenido = ficha.precio_4.contenido,
            //        precioNeto = ficha.precio_4.precioNeto,
            //        precio_divisa_Neto = ficha.precio_4.precio_divisa_Neto,
            //        utilidad = ficha.precio_4.utilidad,
            //    };
            //    fichaDTO.precio_4 = precio_4;
            //}
            //if (ficha.precio_5 != null) 
            //{
            //    var precio_5 = new DtoLibInventario.Precio.Editar.FichaPrecio()
            //    {
            //        autoEmp = ficha.precio_5.autoEmp,
            //        contenido = ficha.precio_5.contenido,
            //        precioNeto = ficha.precio_5.precioNeto,
            //        precio_divisa_Neto = ficha.precio_5.precio_divisa_Neto,
            //        utilidad = ficha.precio_5.utilidad,
            //    };
            //    fichaDTO.precio_5 = precio_5;
            //}
            //if (ficha.may_1 != null)
            //{
            //    var may_1 = new DtoLibInventario.Precio.Editar.FichaPrecio()
            //    {
            //        autoEmp = ficha.may_1.autoEmp,
            //        contenido = ficha.may_1.contenido,
            //        precioNeto = ficha.may_1.precioNeto,
            //        precio_divisa_Neto = ficha.may_1.precio_divisa_Neto,
            //        utilidad = ficha.may_1.utilidad,
            //    };
            //    fichaDTO.may_1 = may_1;
            //}
            //if (ficha.may_2 != null) 
            //{
            //    var may_2 = new DtoLibInventario.Precio.Editar.FichaPrecio()
            //    {
            //        autoEmp = ficha.may_2.autoEmp,
            //        contenido = ficha.may_2.contenido,
            //        precioNeto = ficha.may_2.precioNeto,
            //        precio_divisa_Neto = ficha.may_2.precio_divisa_Neto,
            //        utilidad = ficha.may_2.utilidad,
            //    };
            //    fichaDTO.may_2 = may_2;
            //}
            //if (ficha.may_3 != null)
            //{
            //    var may_3 = new DtoLibInventario.Precio.Editar.FichaPrecio()
            //    {
            //        autoEmp = ficha.may_3.autoEmp,
            //        contenido = ficha.may_3.contenido,
            //        precioNeto = ficha.may_3.precioNeto,
            //        precio_divisa_Neto = ficha.may_3.precio_divisa_Neto,
            //        utilidad = ficha.may_3.utilidad,
            //    };
            //    fichaDTO.may_3 = may_3;
            //}
            //if (ficha.may_4 != null)
            //{
            //    var may_4 = new DtoLibInventario.Precio.Editar.FichaPrecio()
            //    {
            //        autoEmp = ficha.may_4.autoEmp,
            //        contenido = ficha.may_4.contenido,
            //        precioNeto = ficha.may_4.precioNeto,
            //        precio_divisa_Neto = ficha.may_4.precio_divisa_Neto,
            //        utilidad = ficha.may_4.utilidad,
            //    };
            //    fichaDTO.may_4 = may_4;
            //}
            //if (ficha.dsp_1 != null)
            //{
            //    var dsp_1 = new DtoLibInventario.Precio.Editar.FichaPrecio()
            //    {
            //        autoEmp = ficha.dsp_1.autoEmp,
            //        contenido = ficha.dsp_1.contenido,
            //        precioNeto = ficha.dsp_1.precioNeto,
            //        precio_divisa_Neto = ficha.dsp_1.precio_divisa_Neto,
            //        utilidad = ficha.dsp_1.utilidad,
            //    };
            //    fichaDTO.dsp_1 = dsp_1;
            //}
            //if (ficha.dsp_2 != null)
            //{
            //    var dsp_2 = new DtoLibInventario.Precio.Editar.FichaPrecio()
            //    {
            //        autoEmp = ficha.dsp_2.autoEmp,
            //        contenido = ficha.dsp_2.contenido,
            //        precioNeto = ficha.dsp_2.precioNeto,
            //        precio_divisa_Neto = ficha.dsp_2.precio_divisa_Neto,
            //        utilidad = ficha.dsp_2.utilidad,
            //    };
            //    fichaDTO.dsp_2 = dsp_2;
            //}
            //if (ficha.dsp_3 != null)
            //{
            //    var dsp_3 = new DtoLibInventario.Precio.Editar.FichaPrecio()
            //    {
            //        autoEmp = ficha.dsp_3.autoEmp,
            //        contenido = ficha.dsp_3.contenido,
            //        precioNeto = ficha.dsp_3.precioNeto,
            //        precio_divisa_Neto = ficha.dsp_3.precio_divisa_Neto,
            //        utilidad = ficha.dsp_3.utilidad,
            //    };
            //    fichaDTO.dsp_3 = dsp_3;
            //}
            //if (ficha.dsp_4 != null)
            //{
            //    var dsp_4 = new DtoLibInventario.Precio.Editar.FichaPrecio()
            //    {
            //        autoEmp = ficha.dsp_4.autoEmp,
            //        contenido = ficha.dsp_4.contenido,
            //        precioNeto = ficha.dsp_4.precioNeto,
            //        precio_divisa_Neto = ficha.dsp_4.precio_divisa_Neto,
            //        utilidad = ficha.dsp_4.utilidad,
            //    };
            //    fichaDTO.dsp_4 = dsp_4;
            //}
        }
    }
}