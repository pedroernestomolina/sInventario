using DataProvInventario.InfraEstructura;
using ServiceInventario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.Data
{
    
    public partial class DataProv: IData
    {

        public static IService MyData;


        public DataProv(string instancia, string bd, string usu="root")
        {
            MyData = new ServiceInventario.MyService.Service(instancia,bd, usu);
        }


        public OOB.ResultadoEntidad<DateTime> 
            FechaServidor()
        {
            var result = new OOB.ResultadoEntidad<DateTime>();

            var r01 = MyData.FechaServidor();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            result.Entidad = (DateTime)r01.Entidad;
            return result;
        }
        public OOB.ResultadoEntidad<OOB.LibInventario.Empresa.Data.Ficha> 
            Empresa_Datos()
        {
            var result = new OOB.ResultadoEntidad<OOB.LibInventario.Empresa.Data.Ficha>();

            var r01 = MyData.Empresa_Datos();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }

            var s=r01.Entidad;
            var nr = new OOB.LibInventario.Empresa.Data.Ficha()
            {
                CiRif = s.CiRif,
                DireccionFiscal = s.DireccionFiscal,
                Nombre = s.Nombre,
                Telefono = s.Telefono,
            };
            result.Entidad = nr;

            return result;
        }

    }

}