using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Helpers
{

    public class Seguridad : ISeguridadAccesoSistema
    {


        private SeguridadSist.NivelAcceso.IModoNivelAcceso _gNivelAcceso;
        private SeguridadSist.ISeguridad _gSeguridad;


        public Seguridad(SeguridadSist.NivelAcceso.IModoNivelAcceso acceso, SeguridadSist.ISeguridad seguridad)
        {
            _gNivelAcceso = acceso;
            _gSeguridad = seguridad;
        }


        public bool Verificar(OOB.LibInventario.Permiso.Ficha ficha)
        {
            if (!ficha.IsHabilitado)
            {
                Helpers.Msg.Error("PERMISO DENEGADO...");
                return false;
            }
            if (ficha.NivelSeguridad == OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad.Niguna)
                return true;

            _gNivelAcceso.Inicializa();
            _gNivelAcceso.setTipoAcceso(ficha);
            _gSeguridad.setGestionTipo(_gNivelAcceso);
            _gSeguridad.Inicializa();
            _gSeguridad.Inicia();
            return _gSeguridad.IsOk;
        }

    }

}