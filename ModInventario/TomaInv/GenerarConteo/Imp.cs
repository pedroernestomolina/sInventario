using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.TomaInv.GenerarConteo
{
    public class Imp: IConteo
    {
        public Imp()
        {
        }

        public void GenerarConteo()
        {
            if (!verificarExistenciaTomaPendiente()) 
            {
                generaConteo();
            }
        }

        private bool verificarExistenciaTomaPendiente()
        {
            try
            {
                var r01 = Sistema.MyData.TomaInv_VerificaSiHayUnaTomaActiva();
                if (r01.Entidad > 0) 
                {
                    throw new Exception("HAY UNA TOMA PENDIENTE POR PROCESAR");
                }
                return false;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return true;
            }
        }
        private void generaConteo()
        {
            try
            {
                var _idDep = Sistema.Negocio.CodigoDepositoPrincipal;
                var r01 = Sistema.MyData.Deposito_GetFicha(_idDep);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                var _dep = r01.Entidad;

                var filtro = new OOB.LibInventario.TomaInv.ObtenerToma.Filtro()
                {
                    idDeposito = _dep.auto,
                    periodoDias = 60,
                    idDepartExcluir = new List<string>(),
                };
                var r02 = Sistema.MyData.TomaInv_GetListaPrd(filtro);
                var _lstPrd = r02.Lista.Where(w => w.cntMov > 0).Select(s =>
                {
                    var nr = new OOB.LibInventario.TomaInv.Solicitud.Generar.PrdToma()
                    {
                        IdPrd = s.idPrd,
                    };
                    return nr;
                }).ToList();


                var ficha = new OOB.LibInventario.TomaInv.Solicitud.Generar.Ficha()
                {
                    idDeposito = _dep.auto,
                    autorizadoPor = "INVENTARIO",
                    cantItems = _lstPrd.Count,
                    codigoDeposito = _dep.codigo ,
                    codigoSucursal = _dep.codigoSucursal ,
                    descDeposito = _dep.nombre,
                    descSucursal = _dep.nombreSucursal ,
                    idSucursal = _dep.autoSucursal ,
                    motivo = "CONTEO GENERAL",
                    ProductosTomaInv = _lstPrd,
                };
                var r03 = Sistema.MyData.TomaInv_GenerarConteo(ficha);
                Helpers.Msg.OK("CONTEO GENERADO EXITOSAMENTE");
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
    }
}