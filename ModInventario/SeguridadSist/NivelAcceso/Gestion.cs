using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.SeguridadSist.NivelAcceso
{

    public class Gestion : IModoNivelAcceso
    {

        private string _clave;
        private OOB.LibInventario.Permiso.Ficha _ficha;


        public string Titulo
        {
            get { return "NIVEL DE ACCESO"; }
        }


        public Gestion()
        {
            _clave = "";
            _ficha = null;
        }

        public void setClave(string p)
        {
            _clave = p;
        }

        public void Inicializa()
        {
            _clave = "";
            _ficha = null;
        }

        public bool AceptarVerificar()
        {
            var rt = true;
            var _claveVerificar = "";

            switch (_ficha.NivelSeguridad)
            {
                case OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad.Maxima:
                    var r01 = Sistema.MyData.Permiso_PedirClaveAcceso_NivelMaximo();
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return rt;
                    }
                    _claveVerificar = r01.Entidad;
                    break;
                case OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad.Media:
                    var r02 = Sistema.MyData.Permiso_PedirClaveAcceso_NivelMedio();
                    if (r02.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r02.Mensaje);
                        return rt;
                    }
                    _claveVerificar = r02.Entidad;
                    break;
                case OOB.LibInventario.Permiso.Enumerados.EnumNivelSeguridad.Minima:
                    var r03 = Sistema.MyData.Permiso_PedirClaveAcceso_NivelMinimo();
                    if (r03.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r03.Mensaje);
                        return rt;
                    }
                    _claveVerificar = r03.Entidad;
                    break;
            }
            rt = (_clave == _claveVerificar.Trim());

            if (!rt)
                Helpers.Msg.Error("CLAVE INCORRECTA, VERIFIQUE POR FAVOR");
            return rt;
        }


        public void setTipoAcceso(OOB.LibInventario.Permiso.Ficha ficha)
        {
            _ficha = ficha;
        }

    }

}