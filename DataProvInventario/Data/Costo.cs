using DataProvInventario.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.Data
{

    public partial class DataProv : IData
    {

        public OOB.ResultadoEntidad<OOB.LibInventario.Costo.Historico.Ficha> HistoricoCosto_GetLista(OOB.LibInventario.Costo.Historico.Filtro filtro)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Costo.Historico.Ficha>();

            var filtroDTO = new DtoLibInventario.Costo.Historico.Filtro()
            {
                autoProducto = filtro.autoProducto,
            };
            var r01 = MyData.HistoricoCosto_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Costo.Historico.Data>();
            if (r01.Entidad.data != null)
            {
                if (r01.Entidad.data.Count > 0)
                {
                    list = r01.Entidad.data.Select(s =>
                    {
                        return new OOB.LibInventario.Costo.Historico.Data()
                        {
                            estacion = s.estacion,
                            fecha = s.fecha,
                            hora = s.hora,
                            nota = s.nota,
                            usuario = s.usuario,
                            costo=s.costo,
                            costoDivisa=s.costoDivisa,
                            tasaDivisa=s.tasaDivisa,
                            serie=s.serie,
                            documento=s.documento,
                            modoCambio= (OOB.LibInventario.Costo.Enumerados.enumModoCambio)s.modoCambio,
                        };
                    }).ToList();
                }
            }
            rt.Entidad = new OOB.LibInventario.Costo.Historico.Ficha()
            {
                codigo = r01.Entidad.codigo,
                descripcion = r01.Entidad.descripcion,
                data = list,
            };

            return rt;
        }

        public OOB.Resultado CostoProducto_Actualizar(OOB.LibInventario.Costo.Editar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibInventario.Costo.Editar.Ficha()
            {
                autoProducto = ficha.autoProducto,
                autoUsuario = ficha.autoUsuario,
                codigoUsuario = ficha.codigoUsuario,
                costoDivisa = ficha.costoDivisa,
                costoFinal = ficha.costoFinal,
                costoFinalUnd = ficha.costoFinalUnd,
                costoImportacion = ficha.costoImportacion,
                costoImportacionUnd = ficha.costoImportacionUnd,
                costoPromedio = ficha.costoPromedio,
                costoPromedioUnd = ficha.costoPromedioUnd,
                costoProveedor = ficha.costoProveedor,
                costoProveedorUnd = ficha.costoProveedorUnd,
                costoVario = ficha.costoVario,
                costoVarioUnd = ficha.costoVarioUnd,
                estacion = ficha.estacion,
                nombreUsuario = ficha.nombreUsuario,
            };

            var historia = new DtoLibInventario.Costo.Editar.FichaHistorica()
            {
                costo = ficha.historia.costo,
                divisa = ficha.historia.divisa,
                documento = ficha.historia.documento,
                nota = ficha.historia.nota,
                serie = ficha.historia.serie,
                tasaCambio = ficha.historia.tasaCambio,
            };
            fichaDTO.historia = historia;

            //var precio = new DtoLibInventario.Costo.Editar.FichaPrecio()
            //{
            //    pn1 = ficha.precio.pn1,
            //    pn2 = ficha.precio.pn2,
            //    pn3 = ficha.precio.pn3,
            //    pn4 = ficha.precio.pn4,
            //    pn5 = ficha.precio.pn5,
            //    ut1 = ficha.precio.ut1,
            //    ut2 = ficha.precio.ut2,
            //    ut3 = ficha.precio.ut3,
            //    ut4 = ficha.precio.ut4,
            //    ut5 = ficha.precio.ut5,
            //};
            //fichaDTO.precio = precio;

            var r01 = MyData.CostoProducto_Actualizar (fichaDTO);
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