using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Seguridad
{

    public class Gestion
    {

        static public bool SolicitarClave(OOB.LibInventario.Permiso.Ficha ficha) 
        {
            var rt = true;
            if (ficha.IsHabilitado)
            {
                if (ficha.NivelSeguridad != OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad.Niguna)
                {
                    var nivel = Seguridad.Enumerados.Nivel.SinDefinir;
                    switch (ficha.NivelSeguridad)
                    {
                        case OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad.Maxima:
                            nivel = Seguridad.Enumerados.Nivel.Maximo;
                            break;
                        case OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad.Media:
                            nivel = Seguridad.Enumerados.Nivel.Medio;
                            break;
                        case OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad.Minima:
                            nivel = Seguridad.Enumerados.Nivel.Minimo;
                            break;
                    }
                    rt= PedirClave (nivel);
                }
            }
            else
            {
                Helpers.Msg.Error("PERMISO DENEGADO...");
                rt = false;
            }
            return rt;
        }

       static bool PedirClave(Enumerados.Nivel nivel)
        {
            var rt = false;

            var frm = new SeguridadFrm();
            frm.ShowDialog();
            if (frm.IsClaveExitosa)
            {
                var clv = frm.Clave.Trim().ToUpper();
                if (clv != "")
                {
                    var clave = "";
                    switch (nivel) 
                    {
                        case Enumerados.Nivel.Maximo:
                            var r01 = Sistema.MyData.Permiso_PedirClaveAcceso_NivelMaximo();
                            if (r01.Result == OOB.Enumerados.EnumResult.isError)
                            {
                                Helpers.Msg.Error(r01.Mensaje);
                                return rt;
                            }
                            clave = r01.Entidad;
                            break;
                        case Enumerados.Nivel.Medio:
                            var r02 = Sistema.MyData.Permiso_PedirClaveAcceso_NivelMedio();
                            if (r02.Result == OOB.Enumerados.EnumResult.isError)
                            {
                                Helpers.Msg.Error(r02.Mensaje);
                                return rt;
                            }
                            clave = r02.Entidad;
                            break;
                        case Enumerados.Nivel.Minimo:
                            var r03 = Sistema.MyData.Permiso_PedirClaveAcceso_NivelMinimo();
                            if (r03.Result == OOB.Enumerados.EnumResult.isError)
                            {
                                Helpers.Msg.Error(r03.Mensaje);
                                return rt;
                            }
                            clave = r03.Entidad;
                            break;
                    }

                    if (clv == clave)
                    {
                        rt = true;
                    }
                    else
                    {
                        Helpers.Msg.Error("CLAVE INCORRECTA !!!");
                    }
                }
                else
                {
                    Helpers.Msg.Error("CLAVE INCORRECTA !!!");
                }
            }

            return rt;
        }

    }

}