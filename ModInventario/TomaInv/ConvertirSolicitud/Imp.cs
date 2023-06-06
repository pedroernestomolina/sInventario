using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.TomaInv.ConvertirSolicitud
{
    public class Imp
    {

        public Imp()
        {
        }

        public void Convertir() 
        {
            try
            {
                var r01 = Sistema.MyData.TomaInv_ConvertirSolicitud_EnToma("0000000003");
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
    }
}