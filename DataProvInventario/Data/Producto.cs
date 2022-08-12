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

        public OOB.ResultadoLista<OOB.LibInventario.Producto.Data.Ficha>
            Producto_GetLista(OOB.LibInventario.Producto.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Producto.Data.Ficha>();

            var filtroDto = new DtoLibInventario.Producto.Filtro()
            {
                autoProducto = filtro.autoProducto,
                admPorDivisa = (DtoLibInventario.Producto.Enumerados.EnumAdministradorPorDivisa)filtro.admPorDivisa,
                autoDepartamento = filtro.autoDepartamento,
                autoDeposito = filtro.autoDeposito,
                autoGrupo = filtro.autoGrupo,
                autoMarca = filtro.autoMarca,
                autoProveedor = filtro.autoProveedor,
                autoTasa = filtro.autoTasa,
                cadena = filtro.cadena,
                categoria = (DtoLibInventario.Producto.Enumerados.EnumCategoria)filtro.categoria,
                estatus = (DtoLibInventario.Producto.Enumerados.EnumEstatus)filtro.estatus,
                MetodoBusqueda = (DtoLibInventario.Producto.Enumerados.EnumMetodoBusqueda)filtro.MetodoBusqueda,
                oferta = (DtoLibInventario.Producto.Enumerados.EnumOferta)filtro.oferta,
                origen = (DtoLibInventario.Producto.Enumerados.EnumOrigen)filtro.origen,
                pesado = (DtoLibInventario.Producto.Enumerados.EnumPesado)filtro.pesado,
                catalogo = (DtoLibInventario.Producto.Enumerados.EnumCatalogo)filtro.catalogo,
                activarBusquedaPorTrasalado = filtro.activarBusquedaParaMovTraslado,
                autoDepOrigen = filtro.autoDepOrigen,
                autoDepDestino = filtro.autoDepDestino,
            };
            var r01 = MyData.Producto_GetLista(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Producto.Data.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        var ex = 0.0m;
                        if (s.existencia.HasValue) 
                            ex=s.existencia.Value;

                        var nr = new OOB.LibInventario.Producto.Data.Ficha();
                        nr.CostoDivisa = s.costoDivisa;
                        nr.ExistenciaTotal = ex;
                        nr.PDivisaFull_1 = s.pDivisaFull_1;
                        nr.PDivisaFull_2 = s.pDivisaFull_2;
                        nr.PDivisaFull_3 = s.pDivisaFull_3;
                        nr.PDivisaFull_4 = s.pDivisaFull_4;
                        nr.PDivisaFull_5 = s.pDivisaFull_5;

                        nr.Costo = s.costo;
                        nr.PNeto_1 = s.pNeto1;
                        nr.PNeto_2 = s.pNeto2;
                        nr.PNeto_3 = s.pNeto3;
                        nr.PNeto_4 = s.pNeto4;
                        nr.PNeto_5 = s.pNeto5;

                        nr.PDivisaFullMay_1 = s.pDivisaFullMay_1;
                        nr.PDivisaFullMay_2 = s.pDivisaFullMay_2;
                        nr.PNetoMay_1 = s.pNetoMay1;
                        nr.PNetoMay_2 = s.pNetoMay2;
                        nr.ContenidoEmpMay_1 = s.contMay1;
                        nr.ContenidoEmpMay_2 = s.contMay2;

                        var id = nr.identidad;
                        id.auto = s.auto;
                        id.codigo = s.codigo;
                        id.nombre = s.nombre;
                        id.descripcion = s.descripcion;
                        id.empaqueCompra =s.empaque;
                        id.contenidoCompra =s.contenido;
                        id.contEmpInv = s.contEmpInv;
                        id.Decimales = s.decimales;
                        id.departamento=s.departamento;
                        id.grupo = s.grupo;
                        id.marca = s.marca;
                        id.referencia= s.referencia;
                        id.modelo = s.modelo;
                        id.tasaIva =s.tasaIva;
                        id.nombreTasaIva = s.tasaIvaDescripcion;
                        id.estatus = (OOB.LibInventario.Producto.Enumerados.EnumEstatus) s.estatus;
                        id.origen = (OOB.LibInventario.Producto.Enumerados.EnumOrigen)s.origen;
                        id.categoria = (OOB.LibInventario.Producto.Enumerados.EnumCategoria) s.categoria;
                        id.AdmPorDivisa = (OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa) s.admPorDivisa;
                        id.fechaAlta=s.fechaAlta.Value;
                        id.fechaUltActualizacion = s.fechaUltActualizacion;
                        id.activarCatalogo = (OOB.LibInventario.Producto.Enumerados.EnumCatalogo) s.activarCatalogo;

                        var fechaV = "";
                        if (s.fechaUltCambioCosto.HasValue) 
                        {
                            fechaV = s.fechaUltCambioCosto.Value.ToShortDateString();
                        }

                        nr.costo.fechaUltCambio = fechaV;
                        nr.extra.esPesado= (OOB.LibInventario.Producto.Enumerados.EnumPesado) s.esPesado;
                        nr.precio.estatusOferta = (OOB.LibInventario.Producto.Enumerados.EnumOferta) s.enOferta;
                        
                        return nr;
                    }).ToList();
                }
            }
            switch (filtro.existencia)
            {
                case OOB.LibInventario.Producto.Filtro.Existencia.IgualCero:
                    list = list.Where(w => w.ExistenciaTotal == 0m).ToList();
                    break;
                case OOB.LibInventario.Producto.Filtro.Existencia.MayorQueCero:
                    list = list.Where(w => w.ExistenciaTotal > 0m).ToList();
                    break;
                case OOB.LibInventario.Producto.Filtro.Existencia.MenorQueCero:
                    list = list.Where(w => w.ExistenciaTotal < 0m).ToList();
                    break;
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibInventario.Producto.Origen.Ficha> 
            Producto_Origen_Lista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Producto.Origen.Ficha>();

            var r01 = MyData.Producto_Origen_Lista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Producto.Origen.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Producto.Origen.Ficha ()
                        {
                             Id=s.Id.ToString(),
                             Descripcion=s.Descripcion,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }
        public OOB.ResultadoLista<OOB.LibInventario.Producto.Categoria.Ficha> 
            Producto_Categoria_Lista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Producto.Categoria.Ficha>();

            var r01 = MyData.Producto_Categoria_Lista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Producto.Categoria.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Producto.Categoria.Ficha()
                        {
                            Id = s.Id.ToString(),
                            Descripcion = s.Descripcion,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.Existencia> 
            Producto_GetExistencia(string autoPrd)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.Existencia>();

            var r01 = MyData.Producto_GetExistencia(autoPrd);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var nr = new OOB.LibInventario.Producto.Data.Existencia();
            var e = r01.Entidad;
            if (e != null)
            {
                nr.codigoPrd= e.codigoPrd;
                nr.nombrePrd = e.nombrePrd;
                nr.decimales = e.decimales;
                nr.empaque = e.empaqueCompra;
                nr.empaqueContenido = e.empaqueCompraCont;

                var list = new List<OOB.LibInventario.Producto.Data.Deposito>();
                if (e.depositos != null)
                {
                    if (e.depositos.Count > 0)
                    {
                        list = e.depositos.Select(s =>
                        {
                            return new OOB.LibInventario.Producto.Data.Deposito()
                            {
                                autoId= s.autoId,
                                codigo = s.codigo,
                                exDisponible = s.exDisponible,
                                exFisica = s.exFisica,
                                exReserva = s.exReserva,
                                nombre = s.nombre,
                            };
                        }).ToList();
                    }
                }
                nr.depositos = list;
            }
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoLista<OOB.LibInventario.Producto.Estatus.Lista.Ficha> 
            Producto_Estatus_Lista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Producto.Estatus.Lista.Ficha>();

            var r01 = MyData.Producto_Estatus_Lista ();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Producto.Estatus.Lista.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Producto.Estatus.Lista.Ficha()
                        {
                            Id = s.Id.ToString(),
                            Descripcion = s.Descripcion,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }
        public OOB.ResultadoLista<OOB.LibInventario.Producto.AdmDivisa.Ficha> 
            Producto_AdmDivisa_Lista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Producto.AdmDivisa.Ficha>();

            var r01 = MyData.Producto_AdmDivisa_Lista ();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Producto.AdmDivisa.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Producto.AdmDivisa.Ficha()
                        {
                            Id = s.Id.ToString(),
                            Descripcion = s.Descripcion,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }
        public OOB.ResultadoLista<OOB.LibInventario.Producto.Pesado.Ficha> 
            Producto_Pesado_Lista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Producto.Pesado.Ficha>();

            var r01 = MyData.Producto_Pesado_Lista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Producto.Pesado.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Producto.Pesado.Ficha()
                        {
                            Id = s.Id,
                            Descripcion = s.Descripcion,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }
        public OOB.ResultadoLista<OOB.LibInventario.Producto.Oferta.Ficha> 
            Producto_Oferta_Lista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Producto.Oferta.Ficha>();

            var r01 = MyData.Producto_Oferta_Lista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Producto.Oferta.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Producto.Oferta.Ficha()
                        {
                            Id = s.Id,
                            Descripcion = s.Descripcion,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.Precio> 
            Producto_GetPrecio(string autoPrd)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.Precio>();

            var r01 = MyData.Producto_GetPrecio (autoPrd);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var nr = new OOB.LibInventario.Producto.Data.Precio();
            var e = r01.Entidad;
            if (e != null)
            {
                nr.codigo=e.codigo;
                nr.nombre=e.nombre;
                nr.descripcion=e.descripcion;
                nr.nombreTasaIva=e.nombreTasaIva;
                nr.tasaIva = e.tasaIva;
                nr.estatus = (OOB.LibInventario.Producto.Enumerados.EnumEstatus) e.estatus;

                nr.etiqueta1 = e.etiqueta1;
                nr.etiqueta2 = e.etiqueta2;
                nr.etiqueta3 = e.etiqueta3;
                nr.etiqueta4 = e.etiqueta4;
                nr.etiqueta5 = e.etiqueta5;
                nr.etiquetaMay1 = e.etiquetaMay1;
                nr.etiquetaMay2 = e.etiquetaMay2;

                nr.contenido1 = e.contenido1;
                nr.contenido2 = e.contenido2;
                nr.contenido3 = e.contenido3;
                nr.contenido4 = e.contenido4;
                nr.contenido5 = e.contenido5;
                nr.contenidoMay1 = e.contenidoMay1;
                nr.contenidoMay2 = e.contenidoMay2;

                nr.empaque1 = e.empaque1;
                nr.empaque2 = e.empaque2;
                nr.empaque3 = e.empaque3;
                nr.empaque4 = e.empaque4;
                nr.empaque5 = e.empaque5;
                nr.empaqueMay1 = e.empaqueMay1;
                nr.empaqueMay2 = e.empaqueMay2;

                nr.precioNeto1 = e.precioNeto1;
                nr.precioNeto2 = e.precioNeto2;
                nr.precioNeto3 = e.precioNeto3;
                nr.precioNeto4 = e.precioNeto4;
                nr.precioNeto5 = e.precioNeto5;
                nr.precioNetoMay1 = e.precioNetoMay1;
                nr.precioNetoMay2 = e.precioNetoMay2;

                nr.precioFullDivisa1 = e.precioFullDivisa1;
                nr.precioFullDivisa2 = e.precioFullDivisa2;
                nr.precioFullDivisa3 = e.precioFullDivisa3;
                nr.precioFullDivisa4 = e.precioFullDivisa4;
                nr.precioFullDivisa5 = e.precioFullDivisa5;
                nr.precioFullDivisaMay1 = e.precioFullDivisaMay1;
                nr.precioFullDivisaMay2 = e.precioFullDivisaMay2;

                nr.utilidad1 = e.utilidad1;
                nr.utilidad2 = e.utilidad2;
                nr.utilidad3 = e.utilidad3;
                nr.utilidad4 = e.utilidad4;
                nr.utilidad5 = e.utilidad5;
                nr.utilidadMay1 = e.utilidadMay1;
                nr.utilidadMay2 = e.utilidadMay2;

                nr.admDivisa = (OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa)e.admDivisa;
                nr.estatusOferta = (OOB.LibInventario.Producto.Enumerados.EnumOferta) e.estatusOferta;
                nr.inicioOferta = e.inicioOferta;
                nr.finOferta = e.finOferta;
                nr.ofertaActiva = (OOB.LibInventario.Producto.Enumerados.EnumOferta) e.ofertaActiva;
                nr.precioOferta = e.precioOferta;
                nr.precioSugerido = e.precioSugerido;
            }
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.Costo> 
            Producto_GetCosto(string autoPrd)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.Costo>();

            var r01 = MyData.Producto_GetCosto(autoPrd);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var nr = new OOB.LibInventario.Producto.Data.Costo();
            var e = r01.Entidad;
            if (e != null)
            {
                nr.codigo = e.codigo;
                nr.nombre = e.nombre;
                nr.descripcion = e.descripcion;
                nr.nombreTasaIva = e.nombreTasaIva;
                nr.tasaIva = e.tasaIva;
                nr.empaqueCompra = e.empaqueCompra;
                nr.contEmpaqueCompra = e.contEmpaqueCompra;
                nr.estatus = (OOB.LibInventario.Producto.Enumerados.EnumEstatus)e.estatus;
                nr.admDivisa = (OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa)e.admDivisa;

                nr.costoDivisaUnd= e.costoDivisa/e.contEmpaqueCompra ;
                nr.costoImportacionUnd = e.costoImportacionUnd;
                nr.costoPromedioUnd =e.costoPromedioUnd;
                nr.costoProveedorUnd = e.costoProveedorUnd;
                nr.costoUnd = e.costoUnd;
                nr.costoVarioUnd = e.costoVarioUnd;
                var fechaV="";
                if (e.fechaUltCambio.HasValue && e.fechaUltCambio.Value>new DateTime(200,01,01)) { fechaV = e.fechaUltCambio.Value.ToShortDateString(); }
                nr.fechaUltCambio = fechaV;
                nr.Edad = e.Edad;
            }
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Producto.Depositos.Lista.Ficha> 
            Producto_GetDepositos(string autoPrd)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Producto.Depositos.Lista.Ficha>();

            var r01 = MyData.Producto_GetDepositos(autoPrd);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var nr = new OOB.LibInventario.Producto.Depositos.Lista.Ficha();
            var e = r01.Entidad;
            if (e != null)
            {
                nr.autoPrd=e.autoPrd;
                nr.codigoPrd=e.codigoPrd;
                nr.descripcionPrd=e.descripcionPrd;
                nr.nombrePrd=e.nombrePrd;
                nr.referenciaPrd=e.referenciaPrd;

                var list = new List<OOB.LibInventario.Producto.Depositos.Lista.Deposito>();
                if (e.depositos != null)
                {
                    if (e.depositos.Count > 0)
                    {
                        list = e.depositos.Select(s =>
                        {
                            return new OOB.LibInventario.Producto.Depositos.Lista.Deposito()
                            {
                                auto = s.autoDeposito,
                                codigo = s.codigoDeposito,
                                nombre = s.nombreDeposito,
                            };
                        }).ToList();
                    }
                }
                nr.depositos = list;
            }
            rt.Entidad = nr;

            return rt;
        }

        public OOB.Resultado 
            Producto_AsignarRemoverDepositos(OOB.LibInventario.Producto.Depositos.Asignar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var listDTO = new List<DtoLibInventario.Producto.Depositos.Asignar.DepAsignar>();
            foreach (var it in ficha.depAsignar) 
            {
                var nr = new DtoLibInventario.Producto.Depositos.Asignar.DepAsignar()
                {
                    autoDeposito = it.autoDeposito,
                    averia = it.averia,
                    disponible = it.disponible,
                    fechaUltConteo = it.fechaUltConteo,
                    fisica = it.fisica,
                    nivel_minimo = it.nivel_minimo,
                    nivel_optimo = it.nivel_optimo,
                    pto_pedido = it.pto_pedido,
                    reservada = it.reservada,
                    resultadoUltConteo = it.resultadoUltConteo,
                    ubicacion_1 = it.ubicacion_1,
                    ubicacion_2 = it.ubicacion_2,
                    ubicacion_3 = it.ubicacion_3,
                    ubicacion_4 = it.ubicacion_4,
                };
                listDTO.Add(nr);
            }
            var listRemoverDTO = new List<DtoLibInventario.Producto.Depositos.Asignar.DepRemover>();
            foreach (var it in ficha.depRemover)
            {
                var nr = new DtoLibInventario.Producto.Depositos.Asignar.DepRemover()
                {
                    autoDeposito = it.autoDeposito,
                };
                listRemoverDTO.Add(nr);
            }

            var fichaDTO = new DtoLibInventario.Producto.Depositos.Asignar.Ficha() 
            {
                 autoProducto= ficha.autoProducto,
                 depAsignar=listDTO,
                 depRemover=listRemoverDTO,
            };
            var r01 = MyData.Producto_AsignarRemoverDepositos(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }
        public OOB.ResultadoLista<OOB.LibInventario.Producto.ClasificacionAbc.Ficha> 
            Producto_Clasificacion_Lista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Producto.ClasificacionAbc.Ficha>();

            var r01 = MyData.Producto_Clasificacion_Lista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Producto.ClasificacionAbc.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Producto.ClasificacionAbc.Ficha()
                        {
                            Id = s.Id.ToString(),
                            Descripcion = s.Descripcion,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibInventario.Producto.Editar.Obtener.Ficha> 
            Producto_Editar_GetFicha(string autoPrd)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Producto.Editar.Obtener.Ficha>();

            var r01 = MyData.Producto_Editar_GetFicha(autoPrd);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var nr = new OOB.LibInventario.Producto.Editar.Obtener.Ficha();
            var codigosAlt = new List<OOB.LibInventario.Producto.Editar.Obtener.FichaAlterno>();
            var e = r01.Entidad;
            if (e != null)
            {
                nr.auto=e.auto;
                nr.autoDepartamento = e.autoDepartamento;
                nr.autoGrupo = e.autoGrupo;
                nr.autoMarca = e.autoMarca;
                nr.autoEmpCompra = e.autoEmpCompra;
                nr.autoTasaImpuesto = e.autoTasaImpuesto;
                nr.codigo = e.codigo;
                nr.nombre = e.nombre;
                nr.descripcion = e.descripcion;
                nr.modelo = e.modelo;
                nr.referencia = e.referencia;
                nr.contenidoCompra = e.contenidoCompra;
                nr.imagen = e.imagen;
                nr.esPesado = (OOB.LibInventario.Producto.Enumerados.EnumPesado) e.esPesado;
                nr.plu = e.plu;
                nr.diasEmpaque = e.diasEmpaque;
                nr.origen= (OOB.LibInventario.Producto.Enumerados.EnumOrigen) e.origen;
                nr.categoria= (OOB.LibInventario.Producto.Enumerados.EnumCategoria) e.categoria;
                nr.AdmPorDivisa= (OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa)  e.AdmPorDivisa;
                nr.Clasificacion= (OOB.LibInventario.Producto.Enumerados.EnumClasificacionABC) e.Clasificacion;
                nr.activarCatalogo = (OOB.LibInventario.Producto.Enumerados.EnumCatalogo)e.activarCatalogo;
                nr.autoEmpInv = e.autoEmpInv;
                nr.contEmpInv = e.contEmpInv;
                nr.peso = e.peso;
                nr.volumen = e.volumen;
                nr.alto = e.alto;
                nr.largo = e.largo;
                nr.ancho = e.ancho;

                foreach (var rg in e.CodigosAlterno)
                {
                    codigosAlt.Add(new OOB.LibInventario.Producto.Editar.Obtener.FichaAlterno() { Codigo = rg.Codigo });
                }
            }

            nr.CodigosAlterno = codigosAlt;
            rt.Entidad = nr;

            return rt;
        }
        public OOB.Resultado 
            Producto_Editar_Actualizar(OOB.LibInventario.Producto.Editar.Actualizar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibInventario.Producto.Editar.Actualizar.Ficha()
            {
                auto = ficha.auto,
                abc = ficha.abc,
                autoDepartamento = ficha.autoDepartamento,
                autoEmpCompra = ficha.autoEmpCompra,
                autoEmpInv=ficha.autoEmpInv,
                autoGrupo = ficha.autoGrupo,
                autoMarca = ficha.autoMarca,
                autoTasaImpuesto = ficha.autoTasaImpuesto,
                categoria = ficha.categoria,
                codigo = ficha.codigo,
                contenidoCompra = ficha.contenidoCompra,
                contenidoInv=ficha.contenidoInv,
                descripcion = ficha.descripcion,
                estatusDivisa = ficha.estatusDivisa,
                modelo = ficha.modelo,
                nombre = ficha.nombre,
                origen = ficha.origen,
                referencia = ficha.referencia,
                imagen = ficha.imagen,
                diasEmpaque = ficha.diasEmpaque,
                esPesado = ficha.esPesado,
                plu = ficha.plu,
                estatusCatalogo=ficha.estatusCatalogo,
                tasaImpuesto=ficha.tasaImpuesto,
                peso=ficha.peso,
                volumen=ficha.volumen,
                alto=ficha.alto,
                largo=ficha.largo,
                ancho=ficha.ancho,
            };
            //if (ficha.precio_1 != null) 
            //{
            //    fichaDTO.precio_1 = new DtoLibInventario.Producto.Editar.Actualizar.FichaPrecio()
            //    {
            //        divisaFull = ficha.precio_1.divisaFull,
            //        neto = ficha.precio_1.neto,
            //    };
            //}
            //if (ficha.precio_2 != null)
            //{
            //    fichaDTO.precio_2 = new DtoLibInventario.Producto.Editar.Actualizar.FichaPrecio()
            //    {
            //        divisaFull = ficha.precio_2.divisaFull,
            //        neto = ficha.precio_2.neto,
            //    };
            //}
            //if (ficha.precio_3 != null)
            //{
            //    fichaDTO.precio_3 = new DtoLibInventario.Producto.Editar.Actualizar.FichaPrecio()
            //    {
            //        divisaFull = ficha.precio_3.divisaFull,
            //        neto = ficha.precio_3.neto,
            //    };
            //}
            //if (ficha.precio_4 != null)
            //{
            //    fichaDTO.precio_4 = new DtoLibInventario.Producto.Editar.Actualizar.FichaPrecio()
            //    {
            //        divisaFull = ficha.precio_4.divisaFull,
            //        neto = ficha.precio_4.neto,
            //    };
            //}
            //if (ficha.precio_5 != null)
            //{
            //    fichaDTO.precio_5 = new DtoLibInventario.Producto.Editar.Actualizar.FichaPrecio()
            //    {
            //        divisaFull = ficha.precio_5.divisaFull,
            //        neto = ficha.precio_5.neto,
            //    };
            //}
            var codAlterno = new List<DtoLibInventario.Producto.Editar.Actualizar.FichaCodAlterno>();
            foreach (var rg in ficha.codigosAlterno) 
            {
                codAlterno.Add(new DtoLibInventario.Producto.Editar.Actualizar.FichaCodAlterno() { codigo = rg.Codigo });
            }
            fichaDTO.codigosAlterno = codAlterno;

            var r01 = MyData.Producto_Editar_Actualizar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }
        public OOB.ResultadoAuto 
            Producto_Nuevo_Agregar(OOB.LibInventario.Producto.Agregar.Ficha ficha)
        {
            var rt = new OOB.ResultadoAuto();

            var fichaDTO = new DtoLibInventario.Producto.Agregar.Ficha()
            {
                abc = ficha.abc,
                autoDepartamento = ficha.autoDepartamento,
                autoEmpCompra = ficha.autoEmpCompra,
                autoGrupo = ficha.autoGrupo,
                autoMarca = ficha.autoMarca,
                autoTasaImpuesto = ficha.autoTasaImpuesto,
                categoria = ficha.categoria,
                codigo = ficha.codigo,
                contenidoCompra = ficha.contenidoCompra,
                descripcion = ficha.descripcion,
                estatusDivisa = ficha.estatusDivisa,
                modelo = ficha.modelo,
                nombre = ficha.nombre,
                origen = ficha.origen,
                referencia = ficha.referencia,
                estatus = ficha.estatus,
                tasa = ficha.tasa,
                imagen = ficha.imagen,
                diasEmpaque = ficha.diasEmpaque,
                esPesado = ficha.esPesado,
                plu = ficha.plu,
                estatusCatalogo = ficha.estatusCatalogo,
                autoEmpInv = ficha.autoEmpInv,
                contEmpInv = ficha.contEmpInv,
                peso = ficha.peso,
                volumen = ficha.volumen,
                alto=ficha.alto,
                largo=ficha.largo,
                ancho=ficha.ancho,
            };
            var codAlterno = new List<DtoLibInventario.Producto.Agregar.FichaCodAlterno>();
            foreach (var rg in ficha.codigosAlterno)
            {
                codAlterno.Add(new DtoLibInventario.Producto.Agregar.FichaCodAlterno() { codigo = rg.Codigo });
            }
            fichaDTO.codigosAlterno = codAlterno;

            var r01 = MyData.Producto_Nuevo_Agregar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Auto = r01.Auto;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Producto.Depositos.Ver.Ficha> 
            Producto_GetDeposito(OOB.LibInventario.Producto.Depositos.Ver.Filtro filtro)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Producto.Depositos.Ver.Ficha>();

            var filtroDTO = new DtoLibInventario.Producto.Depositos.Ver.Filtro()
            {
                autoDeposito = filtro.autoDeposito,
                autoProducto = filtro.autoProducto,
            };
            var r01 = MyData.Producto_GetDeposito(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s= r01.Entidad;
            var nr = new OOB.LibInventario.Producto.Depositos.Ver.Ficha()
            {
                autoDeposito = s.autoDeposito,
                autoProducto = s.autoProducto,
                averia = s.averia,
                codigoDeposito = s.codigoDeposito,
                codigoProducto = s.codigoProducto,
                contenidoCompra = s.contenidoCompra,
                disponible = s.disponible,
                empaqueCompra = s.empaqueCompra,
                fechaUltConteo = s.fechaUltConteo.HasValue ? s.fechaUltConteo.Value.ToShortDateString(): "",
                fisica = s.fisica,
                nivelMinimo = (int)s.nivelMinimo,
                nivelOptimo = (int)s.nivelOptimo,
                nombreDeposito = s.nombreDeposito,
                nombreProducto = s.nombreProducto,
                ptoPedido = (int)s.ptoPedido,
                referenciaProducto = s.referenciaProducto,
                reservada = s.reservada,
                resultadoUltConteo = s.resultadoUltConteo,
                ubicacion_1 = s.ubicacion_1,
                ubicacion_2 = s.ubicacion_2,
                ubicacion_3 = s.ubicacion_3,
                ubicacion_4 = s.ubicacion_4,
            };
            rt.Entidad=nr;

            return rt;
        }
        public OOB.Resultado
            Producto_EditarDeposito(OOB.LibInventario.Producto.Depositos.Editar.Ficha ficha)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Producto.Depositos.Editar.Ficha>();

            var fichaDTO = new DtoLibInventario.Producto.Depositos.Editar.Ficha()
            {
                autoDeposito = ficha.autoDeposito,
                autoProducto = ficha.autoProducto,
                nivelMinimo = ficha.nivelMinimo,
                nivelOptimo = ficha.nivelOptimo,
                ptoPedido = ficha.ptoPedido,
                ubicacion_1 = ficha.ubicacion_1,
                ubicacion_2 = ficha.ubicacion_2,
                ubicacion_3 = ficha.ubicacion_3,
                ubicacion_4 = ficha.ubicacion_4,
            };
            var r01 = MyData.Producto_DepositoEditar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError) 
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }
        public OOB.Resultado 
            Producto_CambiarEstatusA_Activo(string auto)
        {
            var rt = new OOB.Resultado();

            var r01 = MyData.Producto_CambiarEstatusA_Activo(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }
        public OOB.Resultado 
            Producto_CambiarEstatusA_Inactivo(string auto)
        {
            var rt = new OOB.Resultado();

            var r01 = MyData.Producto_CambiarEstatusA_Inactivo(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }
        public OOB.Resultado 
            Producto_CambiarEstatusA_Suspendido(string auto)
        {
            var rt = new OOB.Resultado();

            var r01 = MyData.Producto_CambiarEstatusA_Suspendido(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibInventario.Producto.Estatus.Actual.Ficha> 
            Producto_Estatus_GetFicha(string autoPrd)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Producto.Estatus.Actual.Ficha>();

            var r01 = MyData.Producto_Estatus_GetFicha(autoPrd);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s= r01.Entidad;
            var nr = new OOB.LibInventario.Producto.Estatus.Actual.Ficha()
            {
                autoProducto = s.autoProducto,
                codigoProducto = s.codigoProducto,
                estatus = (OOB.LibInventario.Producto.Enumerados.EnumEstatus)s.estatus,
                nombreProducto = s.nombreProducto,
                referenciaProducto = s.referenciaProducto,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.Imagen> 
            Producto_GetImagen(string autoPrd)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.Imagen >();

            var r01 = MyData.Producto_GetImagen(autoPrd);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Producto.Data.Imagen()
            {
                codigo = s.codigo,
                descripcion = s.descripcion,
                imagen = s.imagen,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoLista<OOB.LibInventario.Producto.Plu.Lista.Ficha> 
            Producto_Plu_Lista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Producto.Plu.Lista.Ficha>();

            var r01 = MyData.Producto_Plu_Lista ();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Producto.Plu.Lista.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Producto.Plu.Lista.Ficha()
                        {
                            autoId = s.autoId,
                            codigo = s.codigo,
                            descripcion = s.descripcion,
                            nombre = s.nombre,
                            plu = s.plu,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.Identificacion> 
            Producto_GetIdentificacion(string autoPrd)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.Identificacion>();

            var r01 = MyData.Producto_GetIdentificacion(autoPrd);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            if (r01.Entidad != null)
            {
                var s=r01.Entidad;
                var id = new OOB.LibInventario.Producto.Data.Identificacion()
                {
                    AdmPorDivisa = (OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa)s.AdmPorDivisa,
                    advertencia = s.advertencia,
                    auto = s.auto,
                    autoDepartamento = s.autoDepartamento,
                    autoGrupo = s.autoGrupo,
                    autoMarca = s.autoMarca,
                    categoria = (OOB.LibInventario.Producto.Enumerados.EnumCategoria)s.categoria,
                    codigo = s.codigo,
                    codigoDepartamento = s.codigoDepartamento,
                    codigoGrupo = s.codigoGrupo,
                    comentarios = s.comentarios,
                    contenidoCompra = s.contenidoCompra,
                    Decimales = s.decimales,
                    departamento = s.departamento,
                    descripcion = s.descripcion,
                    empaqueCompra = s.empaqueCompra,
                    estatus = (OOB.LibInventario.Producto.Enumerados.EnumEstatus)s.estatus,
                    fechaAlta = s.fechaAlta,
                    fechaBaja = s.fechaBaja,
                    fechaUltActualizacion = s.fechaUltActualizacion,
                    grupo = s.grupo,
                    marca = s.marca,
                    modelo = s.modelo,
                    nombre = s.nombre,
                    nombreTasaIva = s.nombreTasaIva,
                    origen = (OOB.LibInventario.Producto.Enumerados.EnumOrigen)s.origen,
                    presentacion = s.presentacion,
                    referencia = s.referencia,
                    tasaIva = s.tasaIva,
                    tipoABC = s.tipoABC,
                    activarCatalogo = (OOB.LibInventario.Producto.Enumerados.EnumCatalogo)s.activarCatalogo,
                    estatusPesado = s.estatusPesado,
                    plu = s.plu,
                    diasEmpaque = s.diasEmpaque,
                    empInv=s.empInventario,
                    contEmpInv=s.contEmpInv,
                    codAlterno = s.codAlterno.Select(ss =>
                    {
                        var nr = new OOB.LibInventario.Producto.Data.CodAlterno()
                        {
                            codigo = ss.codigo,
                        };
                        return nr;
                    }).ToList(),
                };
                rt.Entidad = id;
            }
            else
                rt = new OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.Identificacion>();

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.Proveedor.Ficha> 
            Producto_GetProveedores(string autoPrd)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.Proveedor.Ficha>();

            var r01 = MyData.Producto_GetProveedores(autoPrd);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            if (r01.Entidad != null)
            {
                var s = r01.Entidad;
                var id = new OOB.LibInventario.Producto.Data.Proveedor.Ficha()
                {
                    autoProducto = s.autoProducto,
                    codigoProducto = s.codigoProducto,
                    nombreProducto = s.nombreProducto,
                    referenciaProducto = s.referenciaProducto,
                };
                var list = new List<OOB.LibInventario.Producto.Data.Proveedor.Detalle>();
                if (s.proveedores != null) 
                {
                    if (s.proveedores.Count > 0) 
                    {
                        list = s.proveedores.Select(ss =>
                        {
                            var rg = new OOB.LibInventario.Producto.Data.Proveedor.Detalle()
                            {
                                ciRif = ss.ciRif,
                                codigo = ss.codigo,
                                codigoRefPrd = ss.codigoRefPrd,
                                direccionFiscal = ss.direccionFiscal,
                                idAuto = ss.idAuto,
                                razonSocial = ss.razonSocial,
                                telefonos = ss.telefonos,
                            };
                            return rg;
                        }).ToList();
                    }
                }
                id.proveedores = list;
                rt.Entidad = id;
            }
            else
                rt = new OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.Proveedor.Ficha>(); 

            return rt;
        }
        public OOB.Resultado 
            Producto_Deposito_AsignacionMasiva(OOB.LibInventario.Producto.Depositos.AsignacionMasiva.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDto = new DtoLibInventario.Producto.Depositos.AsignacionMasiva.Ficha()
            {
                depositoDestino = new DtoLibInventario.Producto.Depositos.AsignacionMasiva.FichaDepositoDestino()
                {
                    autoDeposito = ficha.depositoDestino.autoDeposito,
                },
                departamentosNoIncluir = ficha.departamentosNoIncluir.Select(s =>
                {
                    var nr = new DtoLibInventario.Producto.Depositos.AsignacionMasiva.FichaDepartamentos()
                    {
                        auto = s.auto,
                    };
                    return nr;
                }).ToList(),
            };
            var r01 = MyData.Producto_Deposito_AsignacionMasiva(fichaDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.ResultadoEntidad<string> 
            Producto_GetId_ByCodigoBarra(string codBarra)
        {
            var rt = new OOB.ResultadoEntidad<string>();

            var r01 = MyData.Producto_GetId_ByCodigoBarra(codBarra);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Entidad = r01.Entidad;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Producto.Precio.Ficha> 
            Producto_Precio_GetById(string idPrd)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Producto.Precio.Ficha>();

            var r01 = MyData.Producto_Precio_GetById(idPrd);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            var s= r01.Entidad;
            var ent = new OOB.LibInventario.Producto.Precio.Ficha()
            {
                auto = s.auto,
                codigo = s.codigo,
                descripcion = s.descripcion,
                tasaIva = s.tasaIva,
                estatusDivisa = s.estatusDivisa,
                contEmp1_1 = s.contEmp1_1,
                contEmp1_2 = s.contEmp1_2,
                contEmp1_3 = s.contEmp1_3,
                contEmp1_4 = s.contEmp1_4,
                contEmp1_5 = s.contEmp1_5,
                contEmp2_1 = s.contEmp2_1,
                contEmp2_2 = s.contEmp2_2,
                contEmp2_3 = s.contEmp2_3,
                contEmp2_4 = s.contEmp2_4,
                contEmp2_5 = s.contEmp2_5,
                contEmp3_1 = s.contEmp3_1,
                contEmp3_2 = s.contEmp3_2,
                contEmp3_3 = s.contEmp3_3,
                contEmp3_4 = s.contEmp3_4,
                contEmp3_5 = s.contEmp3_5,
                descEmp1_1 = s.descEmp1_1,
                descEmp1_2 = s.descEmp1_2,
                descEmp1_3 = s.descEmp1_3,
                descEmp1_4 = s.descEmp1_4,
                descEmp1_5 = s.descEmp1_5,
                descEmp2_1 = s.descEmp2_1,
                descEmp2_2 = s.descEmp2_2,
                descEmp2_3 = s.descEmp2_3,
                descEmp2_4 = s.descEmp2_4,
                descEmp2_5 = s.descEmp2_5,
                descEmp3_1 = s.descEmp3_1,
                descEmp3_2 = s.descEmp3_2,
                descEmp3_3 = s.descEmp3_3,
                descEmp3_4 = s.descEmp3_4,
                descEmp3_5 = s.descEmp3_5,
                pfdEmp1_1 = s.pfdEmp1_1,
                pfdEmp1_2 = s.pfdEmp1_2,
                pfdEmp1_3 = s.pfdEmp1_3,
                pfdEmp1_4 = s.pfdEmp1_4,
                pfdEmp1_5 = s.pfdEmp1_5,
                pfdEmp2_1 = s.pfdEmp2_1,
                pfdEmp2_2 = s.pfdEmp2_2,
                pfdEmp2_3 = s.pfdEmp2_3,
                pfdEmp2_4 = s.pfdEmp2_4,
                pfdEmp2_5 = s.pfdEmp2_5,
                pfdEmp3_1 = s.pfdEmp3_1,
                pfdEmp3_2 = s.pfdEmp3_2,
                pfdEmp3_3 = s.pfdEmp3_3,
                pfdEmp3_4 = s.pfdEmp3_4,
                pfdEmp3_5 = s.pfdEmp3_5,
                pnEmp1_1 = s.pnEmp1_1,
                pnEmp1_2 = s.pnEmp1_2,
                pnEmp1_3 = s.pnEmp1_3,
                pnEmp1_4 = s.pnEmp1_4,
                pnEmp1_5 = s.pnEmp1_5,
                pnEmp2_1 = s.pnEmp2_1,
                pnEmp2_2 = s.pnEmp2_2,
                pnEmp2_3 = s.pnEmp2_3,
                pnEmp2_4 = s.pnEmp2_4,
                pnEmp2_5 = s.pnEmp2_5,
                pnEmp3_1 = s.pnEmp3_1,
                pnEmp3_2 = s.pnEmp3_2,
                pnEmp3_3 = s.pnEmp3_3,
                pnEmp3_4 = s.pnEmp3_4,
                pnEmp3_5 = s.pnEmp3_5,
                utEmp1_1 = s.utEmp1_1,
                utEmp1_2 = s.utEmp1_2,
                utEmp1_3 = s.utEmp1_3,
                utEmp1_4 = s.utEmp1_4,
                utEmp1_5 = s.utEmp1_5,
                utEmp2_1 = s.utEmp2_1,
                utEmp2_2 = s.utEmp2_2,
                utEmp2_3 = s.utEmp2_3,
                utEmp2_4 = s.utEmp2_4,
                utEmp2_5 = s.utEmp2_5,
                utEmp3_1 = s.utEmp3_1,
                utEmp3_2 = s.utEmp3_2,
                utEmp3_3 = s.utEmp3_3,
                utEmp3_4 = s.utEmp3_4,
                utEmp3_5 = s.utEmp3_5,
            };
            rt.Entidad = ent;

            return rt;
        }

    }

}