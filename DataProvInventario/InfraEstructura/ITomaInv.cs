using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    public interface ITomaInv
    {
        OOB.ResultadoLista<OOB.LibInventario.TomaInv.ObtenerToma.Ficha>
            TomaInv_GetListaPrd(OOB.LibInventario.TomaInv.ObtenerToma.Filtro filtro);
        OOB.Resultado
            TomaInv_GenerarToma(OOB.LibInventario.TomaInv.GenerarToma.Ficha Ficha);
        OOB.ResultadoEntidad<OOB.LibInventario.TomaInv.Analisis.Ficha>
            TomaInv_Analisis(string idToma);
        OOB.Resultado
            TomaInv_RechazarItemToma(OOB.LibInventario.TomaInv.RechazarItem.Ficha ficha);
        OOB.Resultado
            TomaInv_Procesar(OOB.LibInventario.TomaInv.Procesar.Ficha ficha);
        //
        OOB.Resultado
            TomaInv_GenerarSolcitud(OOB.LibInventario.TomaInv.Solicitud.Generar.Ficha Ficha);
        OOB.ResultadoEntidad<string>
            TomaInv_EncontrarSolicitudActiva(string codigoEmpSuc);
        OOB.Resultado
            TomaInv_ConvertirSolicitud_EnToma(string autoSolicitud, string codigoEmpresaSucursal);
        OOB.ResultadoEntidad<string>
            TomaInv_Analizar_TomaDisponible();
        OOB.ResultadoLista<OOB.LibInventario.TomaInv.Resumen.PorMovAjuste.Ficha>
            TomaInv_GetLista_PorMovAjuste(OOB.LibInventario.TomaInv.Resumen.PorMovAjuste.Filtro filtro);
        OOB.ResultadoLista<OOB.LibInventario.TomaInv.Resumen.Resultado.Ficha>
            TomaInv_GetToma_Resultado(string idToma);


        //OBTIENE/CAMBIA EL MOTIVO POR EL CUAL SURGE LA DIFERENCIA
        OOB.ResultadoEntidad<string>
            TomaInv_AnalizarToma_GetMotivo(OOB.LibInventario.TomaInv.Analisis.Motivo.Obtener.Ficha ficha);
        OOB.Resultado
            TomaInv_AnalizarToma_SetMotivo(OOB.LibInventario.TomaInv.Analisis.Motivo.Cambiar.Ficha ficha);
        OOB.Resultado
            TomaInv_AnalizarToma_NoHayExistencia(OOB.LibInventario.TomaInv.Analisis.NoHayExistencia.Ficha ficha);


        OOB.ResultadoEntidad<int>
            TomaInv_VerificaSiHayUnaTomaActiva();

        OOB.Resultado
            TomaInv_GenerarConteo(OOB.LibInventario.TomaInv.Solicitud.Generar.Ficha ficha);
    }
}