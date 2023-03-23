using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Helpers
{
    public static class GenerarMov
    {
        public static void Traslado(ISeguridadAccesoSistema _seguridad, int IdMovCargar = -1)
        {
            src.MovInventario.Traslado.ITraslado _gMov;
            _gMov = new src.MovInventario.Traslado.ImpTraslado(_seguridad);
            _gMov.ActivarDepDestinoPreDeterminado(false);
            _gMov.Inicializa();
            _gMov.CargarPendiente(IdMovCargar);
            _gMov.Inicia();
        }
        public static void TrasladoPorDevolucion(ISeguridadAccesoSistema _seguridad, int IdMovCargar = -1)
        {
            src.MovInventario.Traslado.ITraslado _gMov;
            _gMov = new src.MovInventario.Traslado.ImpTrasladoPorDev(_seguridad);
            _gMov.Inicializa();
            _gMov.CargarPendiente(IdMovCargar);
            _gMov.ActivarDepDestinoPreDeterminado(true);
            _gMov.Inicia();
        }
        public static void TrasladoPorNivelMinimo(ISeguridadAccesoSistema _seguridad, int IdMovCargar = -1)
        {
            src.MovInventario.Traslado.ITraslado _gMov;
            _gMov = new src.MovInventario.Traslado.PorNIvel.ImpPorNIvel(_seguridad);
            _gMov.Inicializa();
            _gMov.CargarPendiente(IdMovCargar);
            _gMov.ActivarDepDestinoPreDeterminado(false);
            _gMov.Inicia();
        }
        public static void AjusteInv(ISeguridadAccesoSistema _seguridad, int IdMovCargar=-1)
        {
            src.MovInventario.Ajuste.Inv.IAjusteInv _gMov;
            _gMov = new src.MovInventario.Ajuste.Inv.ImpAjusteInv(_seguridad);
            _gMov.Inicializa();
            _gMov.CargarPendiente(IdMovCargar);
            _gMov.Inicia();
        }
        public static void AjustarInvCero(ISeguridadAccesoSistema _seguridad)
        {
            var _modoUsu = new SeguridadSist.Usuario.Gestion();
            var _sec = new SeguridadSist.Gestion();
            _modoUsu.Inicializa();
            _modoUsu.setUsuarioValidar(SeguridadSist.Usuario.enumerados.enumTipo.Administrador);
            _sec.setGestionTipo(_modoUsu);

            src.MovInventario.Ajuste.InvCero.IAjusteInvEnCero _gMov;
            _gMov = new src.MovInventario.Ajuste.InvCero.ImpAjusteInvEnCero(_seguridad);
            _gMov.SeguridadPorUsuario(_sec);
            _gMov.Inicializa();
            _gMov.Inicia();
        }
        public static void Cargo(ISeguridadAccesoSistema _seguridad)
        {
            src.MovInventario.Descargo.IDescargo _gMov;
            _gMov = new src.MovInventario.Descargo.ImpDescargo(_seguridad);
            _gMov.Inicializa();
            _gMov.Inicia();
        }
        public static void DesCargo(ISeguridadAccesoSistema _seguridad)
        {
            src.MovInventario.Cargo.ICargo _gMovCargo;
            _gMovCargo = new src.MovInventario.Cargo.ImpCargo(_seguridad);
            _gMovCargo.Inicializa();
            _gMovCargo.Inicia();
        }
    }
}