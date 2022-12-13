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
        public OOB.ResultadoLista<OOB.LibInventario.Visor.Existencia.Ficha> 
            Visor_Existencia(OOB.LibInventario.Visor.Existencia.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Visor.Existencia.Ficha>();

            var filtroDto = new DtoLibInventario.Visor.Existencia.Filtro();
            filtroDto.autoDepartamento = filtro.autoDepartamento;
            filtroDto.autoDeposito = filtro.autoDeposito;
            filtroDto.filtrarPor = (DtoLibInventario.Visor.Existencia.Enumerados.enumFiltrarPor)filtro.filtrarPor;

            var r01 = MyData.Visor_Existencia(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Visor.Existencia.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        var estatus = "Activo";
                        if (s.estatusActivo == "1")
                            estatus = "Inactivo";
                        else
                            if (s.estatusSuspendido == "1")
                                estatus = "Suspendido";

                        return new OOB.LibInventario.Visor.Existencia.Ficha()
                        {
                            autoDepart = s.autoDepart,
                            autoDeposito = s.autoDeposito,
                            autoPrd = s.autoPrd,
                            cntFisica = s.cntFisica,
                            cntReserva = s.cntReserva,
                            cntDisponible = s.cntDisponible,
                            codigoDepart = s.codigoDepart,
                            codigoDeposito = s.codigoDeposito,
                            codigoPrd = s.codigoPrd,
                            decimales = s.decimales,
                            nivelMinimo = s.nivelMinimo,
                            nivelOptimo = s.nivelOptimo,
                            nombreDepart = s.nombreDepart,
                            nombreDeposito = s.nombreDeposito,
                            nombrePrd = s.nombrePrd,
                            esPesado = s.esPesado,
                            estatus = estatus,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Visor.CostoEdad.Ficha> 
            Visor_CostoEdad(OOB.LibInventario.Visor.CostoEdad.Filtro filtro)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Visor.CostoEdad.Ficha>();

            var filtroDto = new DtoLibInventario.Visor.CostoEddad.Filtro();
            filtroDto.autoDepartamento = filtro.autoDepartamento;
            filtroDto.autoDeposito = filtro.autoDeposito;

            var r01 = MyData.Visor_CostoEdad(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            rt.Entidad = new OOB.LibInventario.Visor.CostoEdad.Ficha();
            rt.Entidad.fechaServidor = DateTime.Now.Date;
            var list = new List<OOB.LibInventario.Visor.CostoEdad.FichaDetalle>();
            if (r01.Entidad != null)
            {
                var se = r01.Entidad;
                if (se.detalles != null)
                {
                    if (se.detalles.Count > 0)
                    {
                        list = se.detalles.Select(s =>
                        {
                            var estatus = "Activo";
                            if (s.estatusActivo == "1")
                                estatus = "Inactivo";
                            else
                                if (s.estatusSuspendido == "1")
                                    estatus = "Suspendido";

                            return new OOB.LibInventario.Visor.CostoEdad.FichaDetalle()
                            {
                                autoDepart = s.autoDepart,
                                autoDeposito = s.autoDeposito,
                                autoPrd = s.autoPrd,
                                cntFisica = s.cntFisica,
                                codigoDepart = s.codigoDepart,
                                codigoDeposito = s.codigoDeposito,
                                codigoPrd = s.codigoPrd,
                                decimales = s.decimales,
                                nivelMinimo = s.nivelMinimo,
                                nivelOptimo = s.nivelOptimo,
                                nombreDepart = s.nombreDepart,
                                nombreDeposito = s.nombreDeposito,
                                nombrePrd = s.nombrePrd,
                                costoUnd = s.costoUnd,
                                fechaUltActCosto = s.fechaUltActCosto,
                                fechaUltVenta = s.fechaUltVenta,
                                costoDivisaUnd = s.costoDivisaUnd,
                                esAdmDivisa = s.esAdmDivisa,
                                esPesado = s.esPesado,
                                estatus=estatus,
                            };
                        }).ToList();
                    }
                }
                rt.Entidad.fechaServidor = se.fechaServidor;
            }
            rt.Entidad.detalles = list;

            return rt;
        }
        public OOB.ResultadoLista<OOB.LibInventario.Visor.Traslado.Ficha> 
            Visor_Traslado(OOB.LibInventario.Visor.Traslado.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Visor.Traslado.Ficha>();
            var filtroDto = new DtoLibInventario.Visor.Traslado.Filtro();
            filtroDto.ano = filtro.ano;
            filtroDto.mes = filtro.mes;
            var r01 = MyData.Visor_Traslado(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var list = new List<OOB.LibInventario.Visor.Traslado.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Visor.Traslado.Ficha()
                        {
                            autoDepositoDestino = s.autoDepositoDestino,
                            autoDepositoOrigen = s.autoDepositoOrigen,
                            autoPrd = s.autoPrd,
                            autoUsuario = s.autoUsuario,
                            cantidad = s.cantidad,
                            codigoDepositoDestino = s.codigoDepositoDestino,
                            codigoDepositoOrigen = s.codigoDepositoOrigen,
                            codigoPrd = s.codigoPrd,
                            codigoUsuario = s.codigoUsuario,
                            decimales = s.decimales,
                            documentoNombre = s.documentoNombre,
                            documentoNro = s.documentoNro,
                            fecha = s.fecha,
                            hora = s.hora,
                            nombreDepositoDestino = s.nombreDepositoDestino,
                            nombreDepositoOrigen = s.nombreDepositoOrigen,
                            nombrePrd = s.nombrePrd,
                            nombreUsuario = s.nombreUsuario,
                            nota = s.nota,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;
            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Visor.Ajuste.Ficha> 
            Visor_Ajuste(OOB.LibInventario.Visor.Ajuste.Filtro filtro)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Visor.Ajuste.Ficha>();
            var filtroDto = new DtoLibInventario.Visor.Ajuste.Filtro();
            filtroDto.ano = filtro.ano;
            filtroDto.mes = filtro.mes;
            var r01 = MyData.Visor_Ajuste(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            rt.Entidad = new OOB.LibInventario.Visor.Ajuste.Ficha();
            var list = new List<OOB.LibInventario.Visor.Ajuste.FichaDetalle>();
            rt.Entidad.montoVentaNeto = 0.0m;
            if (r01.Entidad != null)
            {
                var se = r01.Entidad;
                if (se.detalles != null)
                {
                    if (se.detalles.Count > 0)
                    {
                        list = se.detalles.Select(s =>
                        {
                            return new OOB.LibInventario.Visor.Ajuste.FichaDetalle()
                            {
                                autoDepositoOrigen = s.autoDepositoOrigen,
                                autoPrd = s.autoPrd,
                                autoUsuario = s.autoUsuario,
                                cantidadUnd = s.cantidadUnd,
                                codigoDepositoOrigen = s.codigoDepositoOrigen,
                                codigoPrd = s.codigoPrd,
                                codigoUsuario = s.codigoUsuario,
                                costoUnd = s.costoUnd,
                                decimales = s.decimales,
                                documentoNro = s.documentoNro,
                                fecha = s.fecha,
                                hora = s.hora,
                                importe = s.importe,
                                nombreDepositoOrigen = s.nombreDepositoOrigen,
                                nombrePrd = s.nombrePrd,
                                nombreUsuario = s.nombreUsuario,
                                nota = s.nota,
                                signo = s.signo,
                            };
                        }).ToList();
                    }
                }
                rt.Entidad.montoVentaNeto = se.montoVentaNeto;
            }
            rt.Entidad.detalles = list;
            return rt;
        }
        public OOB.ResultadoLista<OOB.LibInventario.Visor.CostoExistencia.Ficha> 
            Visor_CostoExistencia(OOB.LibInventario.Visor.CostoExistencia.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Visor.CostoExistencia.Ficha>();

            var filtroDto = new DtoLibInventario.Visor.CostoExistencia.Filtro();
            filtroDto.autoDepartamento = filtro.autoDepartamento;
            filtroDto.autoDeposito = filtro.autoDeposito;
            var r01 = MyData.Visor_CostoExistencia(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Visor.CostoExistencia.Ficha>();
            if (r01.Lista != null)
            {
                var se = r01.Lista;
                if (se.Count > 0)
                {
                    list = se.Select(s =>
                    {
                        var estatus = "Activo";
                        if (s.estatusActivo == "1")
                            estatus = "Inactivo";
                        else
                            if (s.estatusSuspendido == "1")
                                estatus = "Suspendido";

                        return new OOB.LibInventario.Visor.CostoExistencia.Ficha()
                        {
                            autoDepart = s.autoDepart,
                            autoDeposito = s.autoDeposito,
                            autoPrd = s.autoPrd,
                            cntFisica = s.cntFisica,
                            codigoDepart = s.codigoDepart,
                            codigoDeposito = s.codigoDeposito,
                            codigoPrd = s.codigoPrd,
                            decimales = s.decimales,
                            nombreDepart = s.nombreDepart,
                            nombreDeposito = s.nombreDeposito,
                            nombrePrd = s.nombrePrd,
                            costoUnd = s.costoUnd,
                            fechaUltActCosto = s.fechaUltActCosto,
                            costoDivisaUnd = s.costoDivisaUnd,
                            esAdmDivisa = s.esAdmDivisa,
                            esPesado = s.esPesado,
                            estatus=estatus,
                        };
                    }).ToList();
                }
                rt.Lista =list;
            }

            return rt;
        }
        public OOB.ResultadoLista<OOB.LibInventario.Visor.Precio.Ficha> 
            Visor_Precio(OOB.LibInventario.Visor.Precio.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Visor.Precio.Ficha>();

            var filtroDto = new DtoLibInventario.Visor.Precio.Filtro();
            filtroDto.autoDepart = filtro.autoDepart;
            filtroDto.autoGrupo= filtro.autoGrupo;
            var r01 = MyData.Visor_Precio(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Visor.Precio.Ficha>();
            if (r01.Lista != null)
            {
                var se = r01.Lista;
                if (se.Count > 0)
                {
                    list = se.Select(s =>
                    {
                        return new OOB.LibInventario.Visor.Precio.Ficha()
                        {
                            autoPrd = s.autoPrd,
                            codigoDep = s.codigoDep,
                            codigoGrupo = s.codigoGrupo,
                            codigoPrd = s.codigoPrd,
                            costoUnd = s.costoUnd,
                            estatus = s.estatus,
                            estatusDivisa = s.estatusDivisa,
                            fechaUltCosto = s.fechaUltCosto,
                            nombreDep = s.nombreDep,
                            nombreGrupo = s.nombreGrupo,
                            nombrePrd = s.nombrePrd,
                            contEmpCompra = s.contEmpCompra,
                            costoDivisa = s.costoDivisa,
                            precio_1 = s.precio_1,
                            precio_2 = s.precio_2,
                            precio_3 = s.precio_3,
                            precio_4 = s.precio_4,
                            precio_5 = s.precio_5,
                        };
                    }).ToList();
                }
                rt.Lista = list;
            }

            return rt;
        }
        public OOB.ResultadoLista<OOB.LibInventario.Visor.PrecioAjuste.Ficha> 
            Visor_PrecioAjuste(OOB.LibInventario.Visor.PrecioAjuste.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Visor.PrecioAjuste.Ficha>();

            var filtroDto = new DtoLibInventario.Visor.PrecioAjuste.Filtro()
            {
                autoDepart = filtro.autoDepart,
                autoGrupo = filtro.autoGrupo,
                idEmpresaGrrupo = filtro.idEmpresaGrrupo,
            };
            var r01 = MyData.Visor_PrecioAjuste (filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var _lst = new List<OOB.LibInventario.Visor.PrecioAjuste.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    _lst = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Visor.PrecioAjuste.Ficha()
                        {
                            auto = s.auto,
                            nombre = s.nombre,
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
                            pFDivEmp1_1 = s.pFDivEmp1_1,
                            pFDivEmp1_2 = s.pFDivEmp1_2,
                            pFDivEmp1_3 = s.pFDivEmp1_3,
                            pFDivEmp1_4 = s.pFDivEmp1_4,
                            pFDivEmp1_5 = s.pFDivEmp1_5,
                            pFDivEmp2_1 = s.pFDivEmp2_1,
                            pFDivEmp2_2 = s.pFDivEmp2_2,
                            pFDivEmp2_3 = s.pFDivEmp2_3,
                            pFDivEmp2_4 = s.pFDivEmp2_4,
                            pFDivEmp2_5 = s.pFDivEmp2_5,
                            pFDivEmp3_1 = s.pFDivEmp3_1,
                            pFDivEmp3_2 = s.pFDivEmp3_2,
                            pFDivEmp3_3 = s.pFDivEmp3_3,
                            pFDivEmp3_4 = s.pFDivEmp3_4,
                            pFDivEmp3_5 = s.pFDivEmp3_5,
                        };
                    }).ToList();
                }
                rt.Lista = _lst;
            }

            return rt;
        }
        //
        public OOB.ResultadoLista<OOB.LibInventario.Visor.Precio.SoloReporte.Ficha> 
            Visor_Precio_Modo_SoloReporte(OOB.LibInventario.Visor.Precio.SoloReporte.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Visor.Precio.SoloReporte.Ficha>();
            var filtroDto = new DtoLibInventario.Visor.Precio.SoloReporte.Filtro()
            {
                autoDeposito = filtro.autoDeposito,
                desdeCntDias = filtro.desdeCntDias,
                excluirCambMasivo = filtro.excluirCambiosMasivo,
            };
            var r01 = MyData.Visor_Precio_Modo_SoloReporte(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var _lst = new List<OOB.LibInventario.Visor.Precio.SoloReporte.Ficha>();
            if (r01.Lista != null) 
            {
                if (r01.Lista.Count > 0) 
                {
                    _lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibInventario.Visor.Precio.SoloReporte.Ficha()
                        {
                            codigo = s.codigo,
                            cont_emp_1 = s.cont_emp_1,
                            cont_emp_2 = s.cont_emp_2,
                            cont_emp_3 = s.cont_emp_3,
                            emp_1 = s.emp_1,
                            emp_2 = s.emp_2,
                            emp_3 = s.emp_3,
                            nombre = s.nombre,
                            p1 = s.p1,
                            p1_FD = s.p1_FD,
                            p2 = s.p2,
                            p2_FD = s.p2_FD,
                            p3 = s.p3,
                            p3_FD = s.p3_FD,
                            p4 = s.p4,
                            p4_FD = s.p4_FD,
                            pDSP1 = s.pDSP1,
                            pDSP1_FD = s.pDSP1_FD,
                            pDSP2 = s.pDSP2,
                            pDSP2_FD = s.pDSP2_FD,
                            pDSP3 = s.pDSP3,
                            pDSP3_FD = s.pDSP3_FD,
                            pDSP4 = s.pDSP4,
                            pDSP4_FD = s.pDSP4_FD,
                            pM1 = s.pM1,
                            pM1_FD = s.pM1_FD,
                            pM2 = s.pM2,
                            pM2_FD = s.pM2_FD,
                            pM3 = s.pM3,
                            pM3_FD = s.pM3_FD,
                            pM4 = s.pM4,
                            pM4_FD = s.pM4_FD,
                            tasa = s.tasa,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = _lst;
            return rt;
        }
        public OOB.ResultadoLista<OOB.LibInventario.Visor.EntradaxCompra.Ficha> 
            Visor_EntradaxCompra(OOB.LibInventario.Visor.EntradaxCompra.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Visor.EntradaxCompra.Ficha>();
            var filtroDto = new DtoLibInventario.Visor.EntradaxCompra.Filtro()
            {
                ano = filtro.ano,
                idDeposito = filtro.idDeposito,
                mes = filtro.mes,
            };
            var r01 = MyData.Visor_EntradasxCompra(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var _lst = new List<OOB.LibInventario.Visor.EntradaxCompra.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    _lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibInventario.Visor.EntradaxCompra.Ficha()
                        {
                            cantUnd = s.cantUnd,
                            codConcepto = s.codConcepto,
                            codDeposito = s.codDeposito,
                            codigoPrd = s.codigoPrd,
                            descConcepto = s.descConcepto,
                            descDeposito = s.descDeposito,
                            entidadProv = s.entidadProv,
                            fecha = s.fecha,
                            hora = s.hora,
                            nombrePrd = s.nombrePrd,
                            nroDoc = s.nroDoc,
                            siglasDoc = s.siglasDoc,
                            signoDoc = s.signoDoc,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = _lst;
            return rt;
        }
    }

}