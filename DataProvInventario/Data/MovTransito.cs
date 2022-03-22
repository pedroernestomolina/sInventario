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

        public OOB.ResultadoId Transito_Movimiento_Agregar(OOB.LibInventario.Transito.Movimiento.Agregar.Ficha ficha)
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
            var fichaDto = new DtoLibInventario.Transito.Movimiento.Agregar.Ficha()
            {
                mov = movDTO,
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

    }

}