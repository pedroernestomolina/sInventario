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
        public OOB.ResultadoId 
            Transito_Movimiento_Agregar(OOB.LibInventario.Transito.Movimiento.Agregar.Ficha ficha)
        {
            var rt = new OOB.ResultadoId();
            var mov = ficha.mov;
            var movDTO = new DtoLibInventario.Transito.Movimiento.Agregar.Mov()
            {
                autoriza = mov.autoriza,
                cntRenglones = mov.cntRenglones,
                codigoMov = mov.codigoMov,
                descConcepto = mov.descConcepto,
                descDepDestino = mov.descDepDestino,
                descDepOrigen = mov.descDepOrigen,
                descMov = mov.descMov,
                descSucDestino = mov.descSucDestino,
                descSucOrigen = mov.descSucOrigen,
                descUsuario = mov.descUsuario,
                estacionEquipo = mov.estacionEquipo,
                factorCambio = mov.factorCambio,
                idConcepto = mov.idConcepto,
                idDeOrigen = mov.idDeOrigen,
                idDepDestino = mov.idDepDestino,
                idSucDestino = mov.idSucDestino,
                idSucOrigen = mov.idSucOrigen,
                monto = mov.monto,
                montoDivisa = mov.montoDivisa,
                motivo = mov.motivo,
                tipoMov = mov.tipoMov,
            };
            var detallesDTO = new List<DtoLibInventario.Transito.Movimiento.Agregar.Detalle>();
            foreach (var det in ficha.detalles) 
            {
                var rg = new DtoLibInventario.Transito.Movimiento.Agregar.Detalle()
                {
                    autoDepart = det.autoDepart,
                    autoGrupo = det.autoGrupo,
                    autoPrd = det.autoPrd,
                    autoTasa = det.autoTasa,
                    catPrd = det.catPrd,
                    codigoPrd = det.codigoPrd,
                    contEmp = det.contEmp,
                    costo = det.costo,
                    costoDivisa = det.costoDivisa,
                    costoDivisaUnd= det.costoDivisaUnd,
                    costoUnd = det.costoUnd,
                    decimales = det.decimales,
                    nombreEmp = det.nombreEmp,
                    descTasa = det.descTasa,
                    estatusDivisa = det.estatusDivisa,
                    exFisica = det.exFisica,
                    fechaUltActCosto = det.fechaUltActCosto,
                    nombrePrd = det.nombrePrd,
                    valorTasa = det.valorTasa,
                    exFisicaDestino = det.exFisicaDestino,
                    nivelMinimo = det.nivelMinimo,
                    nivelOptimo = det.nivelOptimo,
                    //
                    cantidadSolicitada = det.cantidadSolicitada,
                    costoSolicitada = det.costoSolicitada,
                    empaqueIdSolicitada = det.empaqueIdSolicitada,
                    ajusteIdSolicitada = det.ajusteIdSolicitada,
                    //
                    contEmpInv = det.contEmpInv,
                    nombreEmpInv = det.nombreEmpInv,
                };
                detallesDTO.Add(rg);
            }
            var fichaDto = new DtoLibInventario.Transito.Movimiento.Agregar.Ficha()
            {
                mov = movDTO,
                detalles= detallesDTO,
            };
            var r01 = MyData.Transito_Movimiento_Agregar(fichaDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Id = r01.Id;
            return rt;
        }
        public OOB.ResultadoEntidad<int> 
            Transito_Movimiento_GetCnt(OOB.LibInventario.Transito.Movimiento.Lista.Filtro filtro)
        {
            var rt = new OOB.ResultadoEntidad<int>();

            var filtroDTO = new DtoLibInventario.Transito.Movimiento.Lista.Filtro()
            {
                codMov = filtro.codigoMov,
                tipMov = filtro.tipoMov,
            };
            var r01 = MyData.Transito_Movimiento_GetCnt(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Entidad = r01.Entidad;

            return rt;
        }
        public OOB.ResultadoLista<OOB.LibInventario.Transito.Movimiento.Entidad.Mov> 
            Transito_Movimiento_GetLista(OOB.LibInventario.Transito.Movimiento.Lista.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Transito.Movimiento.Entidad.Mov>();

            var filtroDTO = new DtoLibInventario.Transito.Movimiento.Lista.Filtro()
            {
                codMov = filtro.codigoMov,
                tipMov = filtro.tipoMov,
            };
            var r01 = MyData.Transito_Movimiento_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            var lst = new List<OOB.LibInventario.Transito.Movimiento.Entidad.Mov>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0) 
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibInventario.Transito.Movimiento.Entidad.Mov()
                        {
                            autoriza = "",
                            cntRenglones = s.cntRenglones,
                            codigoMov = "",
                            descConcepto = s.descConcepto,
                            descDepDestino = s.descDepDestino,
                            descDepOrigen = s.descDepOrigen,
                            descMov = s.descMov,
                            descSucDestino = s.descSucDestino,
                            descSucOrigen = s.descSucOrigen,
                            descUsuario = s.descUsuario,
                            estacionEquipo = "",
                            factorCambio = s.factorCambio,
                            fecha = s.fecha,
                            id = s.id,
                            idConcepto = "",
                            idDeOrigen = "",
                            idDepDestino = "",
                            idSucDestino = "",
                            idSucOrigen = "",
                            monto = s.monto,
                            montoDivisa = s.montoDivisa,
                            motivo = s.motivo,
                            tipoMov = "",
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = lst;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Transito.Movimiento.Entidad.Ficha> 
            Transito_Movimiento_GetById(int idMov)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Transito.Movimiento.Entidad.Ficha>();

            var r01 = MyData.Transito_Movimiento_GetById(idMov);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            var s = r01.Entidad.mov;
            var mov = new OOB.LibInventario.Transito.Movimiento.Entidad.Mov()
            {
                id=s.id,
                autoriza = s.autoriza,
                cntRenglones = s.cntRenglones,
                codigoMov = s.codigoMov,
                descConcepto = s.desConcepto,
                descDepDestino = s.desDepDestino,
                descDepOrigen = s.desDepOrigen,
                descMov = s.desMov,
                descSucDestino = s.desSucDestino,
                descSucOrigen = s.desSucOrigen,
                descUsuario = s.desUsuario,
                estacionEquipo = s.estacionEquipo,
                factorCambio = s.factorCambio,
                idConcepto = s.idConcepto,
                idDeOrigen = s.idDepOrigen,
                idDepDestino = s.idDepDestino,
                idSucDestino = s.idSucDestino,
                idSucOrigen = s.idSucOrigen,
                monto = s.monto,
                montoDivisa = s.montoDivisa,
                motivo = s.motivo,
                tipoMov = s.tipoMov,
            };
            var ss = r01.Entidad.detalles;
            var detalles = new List<OOB.LibInventario.Transito.Movimiento.Entidad.Detalle>();
            foreach (var det in ss)
            {
                var rg = new OOB.LibInventario.Transito.Movimiento.Entidad.Detalle()
                {
                    autoDepart = det.autoDepart,
                    autoGrupo = det.autoGrupo,
                    autoProd = det.autoProd,
                    autoTasa = det.autoTasa,
                    categoriaProd = det.categoriaProd,
                    codigoProd = det.codigoProd,
                    contEmpaque = det.contEmpaque,
                    costo = det.costo,
                    costoDivisa = det.costoDivisa,
                    costoDivisaUnd = det.costoDivisaUnd,
                    costoUnd = det.costoUnd,
                    decimales = det.decimales,
                    descEmpaque = det.descEmpaque,
                    descTasa = det.descTasa,
                    esAdmDivisa = det.esAdmDivisa,
                    exFisica = det.exFisica,
                    fechaUltActCosto = det.fechaUltActCosto,
                    nombreProd = det.nombreProd,
                    valorTasa = det.valorTasa,
                    exFisicaDestino = det.exFisicaDestino,
                    nivelMinimo = det.nivelMinimo,
                    nivelOptimo = det.nivelOptimo,
                    //
                    cantSolicitada = det.cantSolicitada,
                    costoSolicitado = det.costoSolicitado,
                    empaqueIdSolicitado = det.empaqueIdSolicitado,
                    ajusteIdSolicitado = det.ajusteIdSolicitado,
                    //
                    contEmpaqueInv = det.contEmpaqueInv,
                    descEmpaqueInv = det.descEmpaqueInv,
                };
                detalles.Add(rg);
            }
            rt.Entidad = new OOB.LibInventario.Transito.Movimiento.Entidad.Ficha()
            {
                mov = mov,
                detalles = detalles,
            };

            return rt;
        }
        public OOB.Resultado 
            Transito_Movimiento_AnularById(int idMov)
        {
            var rt = new OOB.Resultado();

            var r01 = MyData.Transito_Movimiento_AnularById(idMov);
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