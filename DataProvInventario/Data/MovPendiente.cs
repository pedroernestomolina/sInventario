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

        public OOB.ResultadoLista<OOB.LibInventario.MovPend.Entidad.Ficha>
            MovPendiente_GetLista(OOB.LibInventario.MovPend.Lista.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.MovPend.Entidad.Ficha>();

            var filtroDto = new DtoLibInventario.MovPend.Lista.Filtro()
            {
                codMov = filtro.codMovimiento,
            };
            var r01 = MyData.MovPend_GetLista(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.MovPend.Entidad.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.MovPend.Entidad.Ficha()
                        {
                            autoriza = s.autoriza,
                            cntRenglones = s.cntRenglones,
                            codigoMov = s.codigoMov,
                            concepto = s.concepto,
                            depDestino = s.depDestino,
                            depOrigen = s.depOrigen,
                            descripcionMov = s.descripcionMov,
                            factorCambio = s.factorCambio,
                            fecha = s.fecha,
                            id = s.id,
                            monto = s.monto,
                            montoDivisa = s.montoDivisa,
                            motivo = s.motivo,
                            sucDestino = s.sucDestino,
                            sucOrigen = s.sucOrigen,
                            tipoMov = s.tipoMov,
                            usuario = s.usuario,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }
        public OOB.Resultado 
            MovPendiente_Anular(int idMov)
        {
            var rt = new OOB.Resultado();

            var r01 = MyData.MovPend_Anular(idMov);
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