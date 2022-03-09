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

        public OOB.ResultadoLista<OOB.LibInventario.Analisis.General.Ficha> Producto_Analisis_General(OOB.LibInventario.Analisis.General.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Analisis.General.Ficha>();

            var filtroDto = new DtoLibInventario.Analisis.General.Filtro()
            {
                modulo = (DtoLibInventario.Analisis.Enumerados.EnumModulo)filtro.modulo,
                autoDeposito = filtro.autoDeposito,
                autoConcepto = filtro.autoConcepto,
                ultimosXDias = filtro.ultimosXDias,
            };
            var r01 = MyData.Producto_Analisis_General(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Analisis.General.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Analisis.General.Ficha()
                        {
                            autoPrd = s.autoPrd,
                            cntUnd = s.cntUnd,
                            cntDoc = s.cntDoc,
                            nombrePrd = s.nombrePrd,
                            codigoPrd = s.codigoPrd,
                            decimales = s.decimales,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibInventario.Analisis.Detallado.Ficha> Producto_Analisis_Detallado(OOB.LibInventario.Analisis.Detallado.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Analisis.Detallado.Ficha>();

            var filtroDto = new DtoLibInventario.Analisis.Detallado.Filtro()
            {
                modulo = (DtoLibInventario.Analisis.Enumerados.EnumModulo)filtro.modulo,
                autoDeposito = filtro.autoDeposito,
                autoConcepto = filtro.autoConcepto,
                autoProducto = filtro.autoProducto,
                ultimosXDias = filtro.ultimosXDias,
            };
            var r01 = MyData.Producto_Analisis_Detallado(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Analisis.Detallado.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Analisis.Detallado.Ficha()
                        {
                            autoPrd = s.autoPrd,
                            cntUnd = s.cntUnd,
                            cntDoc = s.cntDoc,
                            nombrePrd = s.nombrePrd,
                            codigoPrd = s.codigoPrd,
                            decimales = s.decimales,
                            fecha = s.fecha,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibInventario.Analisis.Existencia.Ficha> Producto_Analisis_Existencia(OOB.LibInventario.Analisis.Existencia.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Analisis.Existencia.Ficha>();

            var filtroDto = new DtoLibInventario.Analisis.Existencia.Filtro()
            {
                autoDeposito = filtro.autoDeposito,
            };
            var r01 = MyData.Producto_Analisis_Existencia(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Analisis.Existencia.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Analisis.Existencia.Ficha()
                        {
                            autoPrd = s.autoPrd,
                            nombrePrd = s.nombrePrd,
                            codigoPrd = s.codigoPrd,
                            decimales = s.decimales,
                            cantUnd = s.cantUnd,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

    }

}