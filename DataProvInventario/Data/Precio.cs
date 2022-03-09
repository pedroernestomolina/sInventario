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

        public OOB.ResultadoEntidad<OOB.LibInventario.Precio.Historico.Ficha> HistoricoPrecio_GetLista(OOB.LibInventario.Precio.Historico.Filtro filtro)
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

        public OOB.ResultadoEntidad<OOB.LibInventario.Precio.PrecioCosto.Ficha> PrecioCosto_GetFicha(string autoPrd)
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

        public OOB.Resultado PrecioProducto_Actualizar(OOB.LibInventario.Precio.Editar.Ficha ficha)
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
            fichaDTO.historia = historia;

            var precio_1 = new DtoLibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = ficha.precio_1.autoEmp,
                contenido = ficha.precio_1.contenido,
                precioNeto = ficha.precio_1.precioNeto,
                precio_divisa_Neto = ficha.precio_1.precio_divisa_Neto,
                utilidad = ficha.precio_1.utilidad,
            };
            fichaDTO.precio_1 = precio_1;
            var precio_2 = new DtoLibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = ficha.precio_2.autoEmp,
                contenido = ficha.precio_2.contenido,
                precioNeto = ficha.precio_2.precioNeto,
                precio_divisa_Neto = ficha.precio_2.precio_divisa_Neto,
                utilidad = ficha.precio_2.utilidad,
            };
            fichaDTO.precio_2 = precio_2;
            var precio_3 = new DtoLibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = ficha.precio_3.autoEmp,
                contenido = ficha.precio_3.contenido,
                precioNeto = ficha.precio_3.precioNeto,
                precio_divisa_Neto = ficha.precio_3.precio_divisa_Neto,
                utilidad = ficha.precio_3.utilidad,
            };
            fichaDTO.precio_3 = precio_3;
            var precio_4 = new DtoLibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = ficha.precio_4.autoEmp,
                contenido = ficha.precio_4.contenido,
                precioNeto = ficha.precio_4.precioNeto,
                precio_divisa_Neto = ficha.precio_4.precio_divisa_Neto,
                utilidad = ficha.precio_4.utilidad,
            };
            fichaDTO.precio_4 = precio_4;
            var precio_5 = new DtoLibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = ficha.precio_5.autoEmp,
                contenido = ficha.precio_5.contenido,
                precioNeto = ficha.precio_5.precioNeto,
                precio_divisa_Neto = ficha.precio_5.precio_divisa_Neto,
                utilidad = ficha.precio_5.utilidad,
            };
            fichaDTO.precio_5 = precio_5;
            //
            var may_1= new DtoLibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = ficha.may_1.autoEmp,
                contenido = ficha.may_1.contenido,
                precioNeto = ficha.may_1.precioNeto,
                precio_divisa_Neto = ficha.may_1.precio_divisa_Neto,
                utilidad = ficha.may_1.utilidad,
            };
            fichaDTO.may_1 = may_1;
            //
            var may_2 = new DtoLibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = ficha.may_2.autoEmp,
                contenido = ficha.may_2.contenido,
                precioNeto = ficha.may_2.precioNeto,
                precio_divisa_Neto = ficha.may_2.precio_divisa_Neto,
                utilidad = ficha.may_2.utilidad,
            };
            fichaDTO.may_2 = may_2;

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