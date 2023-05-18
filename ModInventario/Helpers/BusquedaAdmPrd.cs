using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Helpers
{
    //public class BusquedaAdmPrd
    //{

    //    public static List<OOB.LibInventario.Producto.Data.Ficha>
    //        CargarBusqueda(src.FiltroBusqAdm.dataFiltro data)
    //    {
    //        if (data.MetBusqueda != src.FiltroBusqAdm.Enumerados.enumMetBusqueda.PorCodigoBarra)
    //        {
    //            try
    //            {
    //                var r00 = Sistema.MyData.Configuracion_VisualizarProductosInactivos();
    //                var _activarProductosInactivos = r00.Entidad;

    //                var _filtros = new OOB.LibInventario.Producto.Filtro();
    //                _filtros.cadena = data.CadenaBusq;
    //                _filtros.MetodoBusqueda = (OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda)data.MetBusqueda;
    //                if (data.Proveedor != null) _filtros.autoProveedor = data.Proveedor.id;
    //                if (data.Departamento != null) _filtros.autoDepartamento = data.Departamento.id;
    //                if (data.Grupo != null) _filtros.autoGrupo = data.Grupo.id;
    //                if (data.Marca != null) _filtros.autoMarca = data.Marca.id;
    //                if (data.Deposito != null) _filtros.autoDeposito = data.Deposito.id;
    //                if (data.Categoria != null)
    //                {
    //                    _filtros.categoria = (OOB.LibInventario.Producto.Enumerados.EnumCategoria)int.Parse(data.Categoria.id);
    //                }
    //                if (data.Origen != null)
    //                {
    //                    _filtros.origen = (OOB.LibInventario.Producto.Enumerados.EnumOrigen)int.Parse(data.Origen.id);
    //                }
    //                if (data.TasaIva != null) _filtros.autoTasa = data.TasaIva.id;
    //                if (data.Estatus != null)
    //                {
    //                    _filtros.estatus = (OOB.LibInventario.Producto.Enumerados.EnumEstatus)int.Parse(data.Estatus.id);
    //                }
    //                else
    //                {
    //                    if (!_activarProductosInactivos)
    //                    {
    //                        _filtros.estatus = OOB.LibInventario.Producto.Enumerados.EnumEstatus.Activo;
    //                    }
    //                }
    //                if (data.AdmDivisa != null)
    //                {
    //                    _filtros.admPorDivisa = (OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa)int.Parse(data.AdmDivisa.id);
    //                }
    //                if (data.Pesado != null)
    //                {
    //                    _filtros.pesado = (OOB.LibInventario.Producto.Enumerados.EnumPesado)int.Parse(data.Pesado.id);
    //                }
    //                if (data.Oferta != null)
    //                {
    //                    _filtros.oferta = (OOB.LibInventario.Producto.Enumerados.EnumOferta)int.Parse(data.Oferta.id);
    //                }
    //                if (data.TCS != null)
    //                {
    //                    _filtros.estatusTCS = data.TCS.desc.ToString().ToUpper() == "SI" ? "1" : "0";
    //                }
    //                if (data.Existencia != null)
    //                {
    //                    var xd = OOB.LibInventario.Producto.Filtro.Existencia.SinDefinir;
    //                    switch (data.Existencia.id)
    //                    {
    //                        case "1":
    //                            xd = OOB.LibInventario.Producto.Filtro.Existencia.MayorQueCero;
    //                            break;
    //                        case "2":
    //                            xd = OOB.LibInventario.Producto.Filtro.Existencia.IgualCero;
    //                            break;
    //                        case "3":
    //                            xd = OOB.LibInventario.Producto.Filtro.Existencia.MenorQueCero;
    //                            break;
    //                    }
    //                    _filtros.existencia = xd;
    //                }
    //                if (data.Catalogo != null)
    //                {
    //                    var xd = OOB.LibInventario.Producto.Enumerados.EnumCatalogo.SnDefinir;
    //                    switch (data.Catalogo.id)
    //                    {
    //                        case "1":
    //                            xd = OOB.LibInventario.Producto.Enumerados.EnumCatalogo.No;
    //                            break;
    //                        case "2":
    //                            xd = OOB.LibInventario.Producto.Enumerados.EnumCatalogo.Si;
    //                            break;
    //                    }
    //                    _filtros.catalogo = xd;
    //                }
    //                var r01 = Sistema.MyData.Producto_GetLista(_filtros);
    //                if (r01.Result == OOB.Enumerados.EnumResult.isError)
    //                {
    //                    throw new Exception(r01.Mensaje);
    //                }
    //                return r01.Lista;
    //            }
    //            catch (Exception e)
    //            {
    //                Helpers.Msg.Error(e.Message);
    //                return null;
    //            }
    //        }
    //        else
    //        {
    //            try
    //            {
    //                var r00 = Sistema.MyData.Producto_GetId_ByCodigoBarra(data.CadenaBusq);
    //                if (r00.Entidad.Trim() == "")
    //                {
    //                    throw new Exception("CODIGO DE BARRA NO ENCONTRADO");
    //                }
    //                var _filtros = new OOB.LibInventario.Producto.Filtro()
    //                {
    //                    autoProducto = r00.Entidad,
    //                };
    //                var r01 = Sistema.MyData.Producto_GetLista(_filtros);
    //                if (r01.Result == OOB.Enumerados.EnumResult.isError)
    //                {
    //                    throw new Exception(r01.Mensaje);
    //                }
    //                return r01.Lista;
    //            }
    //            catch (Exception e)
    //            {
    //                Helpers.Msg.Error(e.Message);
    //                return null;
    //            }
    //        }
    //    }
    //}
}