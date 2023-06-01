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
                IdDepositoTomaInv = ficha.idDepositoTomaInv,
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
            TomaInv_Analisis(int idToma)
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
                                comp = s.comp.HasValue ? s.comp.Value : 0m,
                                conteo = s.conteo,
                                descPrd = s.descPrd,
                                fisico = s.fisico,
                                fisicoDep = s.fisicoDep,
                                idPrd = s.idPrd,
                                inv = s.inv.HasValue ? s.inv.Value : 0m,
                                vtas = s.vtas.HasValue ? s.vtas.Value : 0m,
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
    }
}