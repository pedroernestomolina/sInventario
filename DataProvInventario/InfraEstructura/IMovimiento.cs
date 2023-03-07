using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    public interface IMovimiento
    {
        OOB.ResultadoLista<OOB.LibInventario.Movimiento.Lista.Ficha> Producto_Movimiento_GetLista(OOB.LibInventario.Movimiento.Lista.Filtro filtro);
        OOB.ResultadoLista<OOB.LibInventario.Movimiento.Traslado.Consultar.ProductoPorDebajoNivelMinimo> Producto_Movimiento_Traslado_Consultar_ProductosPorDebajoNivelMinimo(OOB.LibInventario.Movimiento.Traslado.Consultar.Filtro filtro);
        OOB.ResultadoAuto  Producto_Movimiento_Traslado_Insertar(OOB.LibInventario.Movimiento.Traslado.Insertar.Ficha ficha);
        OOB.ResultadoEntidad<OOB.LibInventario.Movimiento.Ver.Ficha> Producto_Movimiento_GetFicha(string autoDoc);
        OOB.ResultadoAuto Producto_Movimiento_Cargo_Insertar(OOB.LibInventario.Movimiento.Cargo.Insertar.Ficha ficha);
        OOB.ResultadoAuto Producto_Movimiento_DesCargo_Insertar(OOB.LibInventario.Movimiento.DesCargo.Insertar.Ficha ficha);
        OOB.ResultadoAuto Producto_Movimiento_Ajuste_Insertar(OOB.LibInventario.Movimiento.Ajuste.Insertar.Ficha ficha);
        OOB.Resultado Producto_Movimiento_Cargo_Anular(OOB.LibInventario.Movimiento.Anular.Cargo.Ficha ficha);
        OOB.Resultado Producto_Movimiento_Descargo_Anular(OOB.LibInventario.Movimiento.Anular.Descargo.Ficha ficha);
        OOB.Resultado Producto_Movimiento_Traslado_Anular(OOB.LibInventario.Movimiento.Anular.Traslado.Ficha ficha);
        OOB.Resultado Producto_Movimiento_Ajuste_Anular(OOB.LibInventario.Movimiento.Anular.Ajuste.Ficha ficha);
        OOB.ResultadoAuto Producto_Movimiento_Traslado_Devolucion_Insertar(OOB.LibInventario.Movimiento.Traslado.Insertar.Ficha ficha);
        OOB.ResultadoEntidad<OOB.LibInventario.Movimiento.AjusteInvCero.Capture.Ficha> Producto_Movimiento_AjusteInventarioCero_Capture(OOB.LibInventario.Movimiento.AjusteInvCero.Capture.Filtro filtro);
        OOB.ResultadoAuto Producto_Movimiento_AjusteInventarioCero_Insertar(OOB.LibInventario.Movimiento.AjusteInvCero.Insertar.Ficha ficha);


        // CAPTURAR DATA RELACIONADO AL PRODUCTO PARA REALIZAR DICHO MOVIMIENTO
        OOB.ResultadoLista<OOB.LibInventario.Movimiento.Traslado.Capturar.ProductoPorDebajoNivelMinimo.Ficha> 
            Capturar_ProductosPorDebajoNivelMinimo(OOB.LibInventario.Movimiento.Traslado.Capturar.ProductoPorDebajoNivelMinimo.Filtro filtro);
        OOB.ResultadoEntidad<OOB.LibInventario.Movimiento.DesCargo.CapturaMov.Ficha> 
            Producto_Movimiento_Descargo_CaptureMov(OOB.LibInventario.Movimiento.DesCargo.CapturaMov.Filtro filtro);
        OOB.ResultadoEntidad<OOB.LibInventario.Movimiento.Cargo.CapturaMov.Ficha>
            Producto_Movimiento_Cargo_CaptureMov(OOB.LibInventario.Movimiento.Cargo.CapturaMov.Filtro filtro);
        OOB.ResultadoEntidad<OOB.LibInventario.Movimiento.Traslado.CapturaMov.Ficha>
            Producto_Movimiento_Traslado_CaptureMov(OOB.LibInventario.Movimiento.Traslado.CapturaMov.Filtro filtro);
    }
}