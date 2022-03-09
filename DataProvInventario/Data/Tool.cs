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

        public OOB.ResultadoLista<OOB.LibInventario.Tool.AjusteNivelMinimoMaximoProducto.Capturar.Ficha> Tools_AjusteNivelMinimoMaximo_GetLista(OOB.LibInventario.Tool.AjusteNivelMinimoMaximoProducto.Capturar.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Tool.AjusteNivelMinimoMaximoProducto.Capturar.Ficha>();

            var filtroDTO = new DtoLibInventario.Tool.AjusteNivelMinimoMaximo.Capturar.Filtro();
            filtroDTO.autoDeposito = filtro.autoDeposito;
            filtroDTO.autoDepartamento = filtro.autoDepartamento;
            filtroDTO.cadena = filtro.cadena;

            var r01 = MyData.Tools_AjusteNivelMinimoMaximo_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Tool.AjusteNivelMinimoMaximoProducto.Capturar.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        var _estatus="Activo" ;
                        if (s.esSuspendido == "1") { _estatus = "Suspendido"; }

                        return new OOB.LibInventario.Tool.AjusteNivelMinimoMaximoProducto.Capturar.Ficha()
                        {
                            autoProducto = s.autoProducto,
                            codigoProducto = s.codigoProducto,
                            decimales = s.decimales,
                            fisica = s.fisica,
                            nivelMinimo = s.nivelMinimo,
                            nivelOptimo = s.nivelOptimo,
                            nombreProducto = s.nombreProducto,
                            referenciaProducto = s.referenciaProducto,
                            esPesado=s.esPesado=="S"?true:false,
                            Estatus=_estatus,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.Resultado Tools_AjusteNivelMinimoMaximo_Ajustar(List<OOB.LibInventario.Tool.AjusteNivelMinimoMaximoProducto.Ajustar.Ficha> lista)
        {
            var rt = new OOB.Resultado();

            var listaDTO = new List<DtoLibInventario.Tool.AjusteNivelMinimoMaximo.Ajustar.Ficha>();
            foreach (var it in lista)
            {
                var nr = new DtoLibInventario.Tool.AjusteNivelMinimoMaximo.Ajustar.Ficha()
                {
                    autoDeposito = it.autoDeposito,
                    autoProducto = it.autoProducto,
                    nivelMinimo = it.nivelMinimo,
                    nivelOptimo = it.nivelOptimo,
                };
                listaDTO.Add(nr);
            }

            var r01 = MyData.Tools_AjusteNivelMinimoMaximo_Ajustar(listaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

    }

}