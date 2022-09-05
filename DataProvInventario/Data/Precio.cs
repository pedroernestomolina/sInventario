using DataProvInventario.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.Data
{

    public partial class DataProv : IData
    {

        public OOB.ResultadoEntidad<OOB.LibInventario.Precio.Historico.Ficha> 
            HistoricoPrecio_GetLista(OOB.LibInventario.Precio.Historico.Filtro filtro)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Precio.Historico.Ficha>();

            var filtroDTO = new DtoLibInventario.Precio.Historico.Filtro()
            {
                autoProducto = filtro.autoProducto,
            };
            var r01 = MyData.HistoricoPrecio_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Precio.Historico.Data>();
            if (r01.Entidad.data != null)
            {
                if (r01.Entidad.data.Count > 0)
                {
                    list = r01.Entidad.data.Select(s =>
                    {
                        return new OOB.LibInventario.Precio.Historico.Data()
                        {
                            estacion = s.estacion,
                            etqPrecio = s.etqPrecio,
                            fecha = s.fecha,
                            hora = s.hora,
                            idPrecio = s.idPrecio,
                            nota = s.nota,
                            precio = s.precio,
                            usuario = s.usuario
                        };
                    }).ToList();
                }
            }
            rt.Entidad = new OOB.LibInventario.Precio.Historico.Ficha()
            {
                codigo = r01.Entidad.codigo,
                descripcion = r01.Entidad.descripcion,
                data = list,
            };

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Precio.PrecioCosto.Ficha>
            PrecioCosto_GetFicha(string autoPrd)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Precio.PrecioCosto.Ficha>();

            var r01 = MyData.PrecioCosto_GetFicha(autoPrd);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var nr = new OOB.LibInventario.Precio.PrecioCosto.Ficha();
            var e = r01.Entidad;
            if (e != null)
            {
                nr.codigo = e.codigo;
                nr.nombre = e.nombre;
                nr.descripcion = e.descripcion;
                nr.nombreTasaIva = e.nombreTasaIva;
                nr.tasaIva = e.tasaIva;

                nr.admDivisaEstatus = e.admDivisa;
                nr.fechaUltimaActCosto = e.fechaUltActualizacion;
                nr.contempCompra = e.contempCompra;
                nr.empCompra = e.empCompra;
                nr.costoDivisa = e.costoDivisa;
                nr.costo = e.costo;

                nr.etiqueta1 = e.etiqueta1;
                nr.etiqueta2 = e.etiqueta2;
                nr.etiqueta3 = e.etiqueta3;
                nr.etiqueta4 = e.etiqueta4;
                nr.etiqueta5 = e.etiqueta5;
                nr.contenido1 = e.contenido1;
                nr.contenido2 = e.contenido2;
                nr.contenido3 = e.contenido3;
                nr.contenido4 = e.contenido4;
                nr.contenido5 = e.contenido5;
                nr.autoEmp1 = e.autoEmp1;
                nr.autoEmp2 = e.autoEmp2;
                nr.autoEmp3 = e.autoEmp3;
                nr.autoEmp4 = e.autoEmp4;
                nr.autoEmp5 = e.autoEmp5;
                nr.precioNeto1 = e.precioNeto1;
                nr.precioNeto2 = e.precioNeto2;
                nr.precioNeto3 = e.precioNeto3;
                nr.precioNeto4 = e.precioNeto4;
                nr.precioNeto5 = e.precioNeto5;
                nr.precioFullDivisa1 = e.precioFullDivisa1;
                nr.precioFullDivisa2 = e.precioFullDivisa2;
                nr.precioFullDivisa3 = e.precioFullDivisa3;
                nr.precioFullDivisa4 = e.precioFullDivisa4;
                nr.precioFullDivisa5 = e.precioFullDivisa5;
                nr.utilidad1 = e.utilidad1;
                nr.utilidad2 = e.utilidad2;
                nr.utilidad3 = e.utilidad3;
                nr.utilidad4 = e.utilidad4;
                nr.utilidad5 = e.utilidad5;
                // MAYOR
                nr.autoEmpMay1 = e.autoEmpMay1;
                nr.autoEmpMay2 = e.autoEmpMay2;
                nr.autoEmpMay3 = e.autoEmpMay3;
                nr.contenidoMay1 = e.contenidoMay1;
                nr.contenidoMay2 = e.contenidoMay2;
                nr.contenidoMay3 = e.contenidoMay3;
                nr.utilidadMay1 = e.utilidadMay1;
                nr.utilidadMay2 = e.utilidadMay2;
                nr.utilidadMay3 = e.utilidadMay3;
                nr.precioNetoMay1 = e.precioNetoMay1;
                nr.precioNetoMay2 = e.precioNetoMay2;
                nr.precioNetoMay3 = e.precioNetoMay3;
                nr.precioFullDivisaMay1 = e.precioFullDivisaMay1;
                nr.precioFullDivisaMay2 = e.precioFullDivisaMay2;
                nr.precioFullDivisaMay3 = e.precioFullDivisaMay3;
            }
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.PrecioCosto.Entidad.Ficha> 
            PrecioCosto_GetData(string autoPrd)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.PrecioCosto.Entidad.Ficha>();

            var r01 = MyData.PrecioCosto_GetData(autoPrd);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            var nr = new OOB.LibInventario.PrecioCosto.Entidad.Ficha();
            var e = r01.Entidad;
            if (e != null)
            {
                nr.auto = e.auto;
                nr.autoEmp_1 = e.autoEmp_1;
                nr.autoEmp_2 = e.autoEmp_2;
                nr.autoEmp_3 = e.autoEmp_3;
                nr.autoEmp_4 = e.autoEmp_4;
                nr.autoEmp_5 = e.autoEmp_5;
                nr.autoEmp_M1 = e.autoEmp_M1;
                nr.autoEmp_M2 = e.autoEmp_M2;
                nr.autoEmp_M3 = e.autoEmp_M3;
                nr.autoEmp_M4 = e.autoEmp_M4;
                nr.autoEmp_D1 = e.autoEmp_D1;
                nr.autoEmp_D2 = e.autoEmp_D2;
                nr.autoEmp_D3 = e.autoEmp_D3;
                nr.autoEmp_D4 = e.autoEmp_D4;

                nr.codigo = e.codigo;
                nr.cont_1 = e.cont_1;
                nr.cont_2 = e.cont_2;
                nr.cont_3 = e.cont_3;
                nr.cont_4 = e.cont_4;
                nr.cont_5 = e.cont_5;
                nr.cont_M1 = e.cont_M1;
                nr.cont_M2 = e.cont_M2;
                nr.cont_M3 = e.cont_M3;
                nr.cont_M4 = e.cont_M4;
                nr.cont_D1 = e.cont_D1;
                nr.cont_D2 = e.cont_D2;
                nr.cont_D3 = e.cont_D3;
                nr.cont_D4 = e.cont_D4;

                nr.contEmpCompra = e.contEmpCompra;
                nr.costoMonedaDivisa = e.costoMonedaDivisa;
                nr.costoMonedaLocal = e.costoMonedaLocal;
                nr.descripcion = e.descripcion;
                nr.empCompraDesc = e.empCompraDesc;
                nr.estatusDivisa = e.estatusDivisa;

                nr.pfd_1 = e.pfd_1;
                nr.pfd_2 = e.pfd_2;
                nr.pfd_3 = e.pfd_3;
                nr.pfd_4 = e.pfd_4;
                nr.pfd_5 = e.pfd_5;
                nr.pfd_M1 = e.pfd_M1;
                nr.pfd_M2 = e.pfd_M2;
                nr.pfd_M3 = e.pfd_M3;
                nr.pfd_M4 = e.pfd_M4;
                nr.pfd_D1 = e.pfd_D1;
                nr.pfd_D2 = e.pfd_D2;
                nr.pfd_D3 = e.pfd_D3;
                nr.pfd_D4 = e.pfd_D4;

                nr.pNeto_1 = e.pNeto_1;
                nr.pNeto_2 = e.pNeto_2;
                nr.pNeto_3 = e.pNeto_3;
                nr.pNeto_4 = e.pNeto_4;
                nr.pNeto_5 = e.pNeto_5;
                nr.pNeto_M1 = e.pNeto_M1;
                nr.pNeto_M2 = e.pNeto_M2;
                nr.pNeto_M3 = e.pNeto_M3;
                nr.pNeto_M4 = e.pNeto_M4;
                nr.pNeto_D1 = e.pNeto_D1;
                nr.pNeto_D2 = e.pNeto_D2;
                nr.pNeto_D3 = e.pNeto_D3;
                nr.pNeto_D4 = e.pNeto_D4;

                nr.tasaIva = e.tasaIva;
                nr.utilidad_1 = e.utilidad_1;
                nr.utilidad_2 = e.utilidad_2;
                nr.utilidad_3 = e.utilidad_3;
                nr.utilidad_4 = e.utilidad_4;
                nr.utilidad_5 = e.utilidad_5;
                nr.utilidad_M1 = e.utilidad_M1;
                nr.utilidad_M2 = e.utilidad_M2;
                nr.utilidad_M3 = e.utilidad_M3;
                nr.utilidad_M4 = e.utilidad_M4;
                nr.utilidad_D1 = e.utilidad_D1;
                nr.utilidad_D2 = e.utilidad_D2;
                nr.utilidad_D3 = e.utilidad_D3;
                nr.utilidad_D4 = e.utilidad_D4;
            }
            rt.Entidad = nr;

            return rt;
        }
        public OOB.Resultado
            PrecioProducto_Actualizar(OOB.LibInventario.Precio.Editar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibInventario.Precio.Editar.Ficha()
            {
                autoProducto = ficha.autoProducto,
                autoUsuario = ficha.autoUsuario,
                codigoUsuario = ficha.codigoUsuario,
                estacion = ficha.estacion,
                nombreUsuario = ficha.nombreUsuario,
            };
            var historia = new List<DtoLibInventario.Precio.Editar.FichaHistorica>();
            if (ficha.historia != null) 
            {
                foreach (var it in ficha.historia)
                {
                    var nr = new DtoLibInventario.Precio.Editar.FichaHistorica()
                    {
                        nota = it.nota,
                        precio = it.precio,
                        precio_id = it.precio_id,
                        contenido = it.contenido,
                        empaque = it.empaque,
                    };
                    historia.Add(nr);
                }
            }
            fichaDTO.historia = historia;
            if (ficha.precio_1 != null) 
            {
                var precio_1 = new DtoLibInventario.Precio.Editar.FichaPrecio()
                {
                    autoEmp = ficha.precio_1.autoEmp,
                    contenido = ficha.precio_1.contenido,
                    precioNeto = ficha.precio_1.precioNeto,
                    precio_divisa_Neto = ficha.precio_1.precio_divisa_Neto,
                    utilidad = ficha.precio_1.utilidad,
                };
                fichaDTO.precio_1 = precio_1;
            }
            if (ficha.precio_2 != null)
            {
                var precio_2 = new DtoLibInventario.Precio.Editar.FichaPrecio()
                {
                    autoEmp = ficha.precio_2.autoEmp,
                    contenido = ficha.precio_2.contenido,
                    precioNeto = ficha.precio_2.precioNeto,
                    precio_divisa_Neto = ficha.precio_2.precio_divisa_Neto,
                    utilidad = ficha.precio_2.utilidad,
                };
                fichaDTO.precio_2 = precio_2;
            }
            if (ficha.precio_3 != null)
            {
                var precio_3 = new DtoLibInventario.Precio.Editar.FichaPrecio()
                {
                    autoEmp = ficha.precio_3.autoEmp,
                    contenido = ficha.precio_3.contenido,
                    precioNeto = ficha.precio_3.precioNeto,
                    precio_divisa_Neto = ficha.precio_3.precio_divisa_Neto,
                    utilidad = ficha.precio_3.utilidad,
                };
                fichaDTO.precio_3 = precio_3;
            }
            if (ficha.precio_4 != null)
            {
                var precio_4 = new DtoLibInventario.Precio.Editar.FichaPrecio()
                {
                    autoEmp = ficha.precio_4.autoEmp,
                    contenido = ficha.precio_4.contenido,
                    precioNeto = ficha.precio_4.precioNeto,
                    precio_divisa_Neto = ficha.precio_4.precio_divisa_Neto,
                    utilidad = ficha.precio_4.utilidad,
                };
                fichaDTO.precio_4 = precio_4;
            }
            if (ficha.precio_5 != null) 
            {
                var precio_5 = new DtoLibInventario.Precio.Editar.FichaPrecio()
                {
                    autoEmp = ficha.precio_5.autoEmp,
                    contenido = ficha.precio_5.contenido,
                    precioNeto = ficha.precio_5.precioNeto,
                    precio_divisa_Neto = ficha.precio_5.precio_divisa_Neto,
                    utilidad = ficha.precio_5.utilidad,
                };
                fichaDTO.precio_5 = precio_5;
            }
            if (ficha.may_1 != null)
            {
                var may_1 = new DtoLibInventario.Precio.Editar.FichaPrecio()
                {
                    autoEmp = ficha.may_1.autoEmp,
                    contenido = ficha.may_1.contenido,
                    precioNeto = ficha.may_1.precioNeto,
                    precio_divisa_Neto = ficha.may_1.precio_divisa_Neto,
                    utilidad = ficha.may_1.utilidad,
                };
                fichaDTO.may_1 = may_1;
            }
            if (ficha.may_2 != null) 
            {
                var may_2 = new DtoLibInventario.Precio.Editar.FichaPrecio()
                {
                    autoEmp = ficha.may_2.autoEmp,
                    contenido = ficha.may_2.contenido,
                    precioNeto = ficha.may_2.precioNeto,
                    precio_divisa_Neto = ficha.may_2.precio_divisa_Neto,
                    utilidad = ficha.may_2.utilidad,
                };
                fichaDTO.may_2 = may_2;
            }
            if (ficha.may_3 != null)
            {
                var may_3 = new DtoLibInventario.Precio.Editar.FichaPrecio()
                {
                    autoEmp = ficha.may_3.autoEmp,
                    contenido = ficha.may_3.contenido,
                    precioNeto = ficha.may_3.precioNeto,
                    precio_divisa_Neto = ficha.may_3.precio_divisa_Neto,
                    utilidad = ficha.may_3.utilidad,
                };
                fichaDTO.may_3 = may_3;
            }
            if (ficha.may_4 != null)
            {
                var may_4 = new DtoLibInventario.Precio.Editar.FichaPrecio()
                {
                    autoEmp = ficha.may_4.autoEmp,
                    contenido = ficha.may_4.contenido,
                    precioNeto = ficha.may_4.precioNeto,
                    precio_divisa_Neto = ficha.may_4.precio_divisa_Neto,
                    utilidad = ficha.may_4.utilidad,
                };
                fichaDTO.may_4 = may_4;
            }
            if (ficha.dsp_1 != null)
            {
                var dsp_1 = new DtoLibInventario.Precio.Editar.FichaPrecio()
                {
                    autoEmp = ficha.dsp_1.autoEmp,
                    contenido = ficha.dsp_1.contenido,
                    precioNeto = ficha.dsp_1.precioNeto,
                    precio_divisa_Neto = ficha.dsp_1.precio_divisa_Neto,
                    utilidad = ficha.dsp_1.utilidad,
                };
                fichaDTO.dsp_1 = dsp_1;
            }
            if (ficha.dsp_2 != null)
            {
                var dsp_2 = new DtoLibInventario.Precio.Editar.FichaPrecio()
                {
                    autoEmp = ficha.dsp_2.autoEmp,
                    contenido = ficha.dsp_2.contenido,
                    precioNeto = ficha.dsp_2.precioNeto,
                    precio_divisa_Neto = ficha.dsp_2.precio_divisa_Neto,
                    utilidad = ficha.dsp_2.utilidad,
                };
                fichaDTO.dsp_2 = dsp_2;
            }
            if (ficha.dsp_3 != null)
            {
                var dsp_3 = new DtoLibInventario.Precio.Editar.FichaPrecio()
                {
                    autoEmp = ficha.dsp_3.autoEmp,
                    contenido = ficha.dsp_3.contenido,
                    precioNeto = ficha.dsp_3.precioNeto,
                    precio_divisa_Neto = ficha.dsp_3.precio_divisa_Neto,
                    utilidad = ficha.dsp_3.utilidad,
                };
                fichaDTO.dsp_3 = dsp_3;
            }
            if (ficha.dsp_4 != null)
            {
                var dsp_4 = new DtoLibInventario.Precio.Editar.FichaPrecio()
                {
                    autoEmp = ficha.dsp_4.autoEmp,
                    contenido = ficha.dsp_4.contenido,
                    precioNeto = ficha.dsp_4.precioNeto,
                    precio_divisa_Neto = ficha.dsp_4.precio_divisa_Neto,
                    utilidad = ficha.dsp_4.utilidad,
                };
                fichaDTO.dsp_4 = dsp_4;
            }
            var r01 = MyData.PrecioProducto_Actualizar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

    }

}