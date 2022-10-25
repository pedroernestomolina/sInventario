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

        public OOB.ResultadoEntidad<OOB.LibInventario.Auditoria.Entidad.Ficha> 
            Auditoria_Documento_GetFichaBy(OOB.LibInventario.Auditoria.Buscar.Ficha ficha)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Auditoria.Entidad.Ficha>();

            var fichaDTO = new DtoLibInventario.Auditoria.Buscar.Ficha()
            {
                autoDocumento = ficha.autoDocumento,
                autoTipoDocumento = ficha.autoTipoDocumento,
            };
            var r01 = MyData.Auditoria_Documento_GetFichaBy (fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Auditoria.Entidad.Ficha()
            {
                estacionEquipo = s.estacionEquipo,
                fecha = s.fecha,
                hora = s.hora,
                motivo = s.motivo,
                usuAuto = s.usuAuto,
                usuCodigo = s.usuCodigo,
                usuNombre = s.usuNombre,
            };
            rt.Entidad = nr;

            return rt;
        }

    }

}