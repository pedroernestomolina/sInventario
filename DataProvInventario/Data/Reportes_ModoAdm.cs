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
        public OOB.ResultadoLista<OOB.LibInventario.Reportes.MaestroPrecio.ModoAdm.Ficha> 
            Reportes_ModoAdm_MaestroPrecio(OOB.LibInventario.Reportes.MaestroPrecio.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Reportes.MaestroPrecio.ModoAdm.Ficha>();
            var filtroDto = new DtoLibInventario.Reportes.MaestroPrecio.Filtro()
            {
                autoGrupo = filtro.autoGrupo,
                autoMarca = filtro.autoMarca,
                autoTasa = filtro.autoTasa,
                admDivisa = (DtoLibInventario.Reportes.enumerados.EnumAdministradorPorDivisa)filtro.admDivisa,
                autoDepartamento = filtro.autoDepartamento,
                categoria = (DtoLibInventario.Reportes.enumerados.EnumCategoria)filtro.categoria,
                origen = (DtoLibInventario.Reportes.enumerados.EnumOrigen)filtro.origen,
                precio = (DtoLibInventario.Reportes.enumerados.EnumPrecio)filtro.precio,
                pesado = (DtoLibInventario.Reportes.enumerados.EnumPesado)filtro.pesado,
                autoDepositoPrincipal = filtro.autoDepositoPrincipal,
                estatusOferta = filtro.estatusOferta,
            };
            var r01 = MyData.Reportes_ModAdm_MaestroPrecio(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var list = new List<OOB.LibInventario.Reportes.MaestroPrecio.ModoAdm.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Reportes.MaestroPrecio.ModoAdm.Ficha()
                        {
                            departamento = s.departamento,
                            empCont = s.empCont,
                            empDesc = s.empDesc,
                            estatusDivisa = s.estatusDivisa,
                            fullDivisa = s.fullDivisa,
                            grupo = s.grupo,
                            netoMonLocal = s.netoMonLocal,
                            prdCodigo = s.prdCodigo,
                            prdNombre = s.prdNombre,
                            tasaIva = s.tasaIva,
                            tipoEmpVta=s.tipoEmpVta,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;
            return rt;
        }
    }
}