using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.TomaInv.ConvertirSolicitud
{
    public class Imp
    {
        private bool _convertirIsOk;


        public bool ConvertirIsOk { get { return _convertirIsOk; } }


        public Imp()
        {
            _convertirIsOk = false;
        }

        public void Convertir() 
        {
            try
            {
                var r01 = Sistema.MyData.TomaInv_EncontrarSolicitudActiva(Sistema.Negocio.CodigoEmpresa);
                if (r01.Entidad == "") 
                {
                    Helpers.Msg.Alerta("NO SE ENCONTRARON SOLICITUD DE TOMAS ACTIVAS");
                    return;
                }
                var autoSolicitud = r01.Entidad;
                var r02 = Sistema.MyData.TomaInv_ConvertirSolicitud_EnToma(autoSolicitud, Sistema.Negocio.CodigoEmpresa);
                _convertirIsOk = true;
                Helpers.Msg.Alerta("SOLICITUD ENCONTRADA, VERIFIQUE POR FAVOR");
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
    }
}