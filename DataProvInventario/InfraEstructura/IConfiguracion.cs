using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    
    public interface IConfiguracion
    {

        OOB.ResultadoEntidad<OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda> Configuracion_PreferenciaBusqueda();
        OOB.ResultadoEntidad<OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad> Configuracion_MetodoCalculoUtilidad();
        OOB.ResultadoEntidad<decimal> Configuracion_TasaCambioActual();
        OOB.ResultadoEntidad<OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta> Configuracion_ForzarRedondeoPrecioVenta();
        OOB.ResultadoEntidad<OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio> Configuracion_PreferenciaRegistroPrecio();
        OOB.ResultadoEntidad<int> Configuracion_CostoEdadProducto();
        OOB.ResultadoEntidad<bool> Configuracion_VisualizarProductosInactivos();
        OOB.ResultadoEntidad<int> Configuracion_CantDocVisualizar();

        OOB.Resultado Configuracion_SetCostoEdadProducto(OOB.LibInventario.Configuracion.CostoEdad.Editar.Ficha ficha);
        OOB.Resultado Configuracion_SetRedondeoPrecioVenta(OOB.LibInventario.Configuracion.RedondeoPrecio.Editar.Ficha ficha);
        OOB.Resultado Configuracion_SetPreferenciaRegistroPrecio(OOB.LibInventario.Configuracion.PreferenciaPrecio.Editar.Ficha ficha);
        OOB.Resultado Configuracion_SetMetodoCalculoUtilidad(OOB.LibInventario.Configuracion.MetodoCalculoUtilidad.Editar.Ficha ficha);
        OOB.Resultado Configuracion_SetBusquedaPredeterminada(OOB.LibInventario.Configuracion.BusquedaPredeterminada.Editar.Ficha ficha);
        OOB.Resultado Configuracion_SetDepositosPreDeterminado(OOB.LibInventario.Configuracion.DepositoPreDeterminado.Ficha ficha);

        OOB.ResultadoLista<OOB.LibInventario.Configuracion.MetodoCalculoUtilidad.CapturarData.Ficha> Configuracion_MetodoCalculoUtilidad_CapturarData();
        OOB.ResultadoEntidad<bool> Configuracion_HabilitarPrecio_5_ParaVentaMayorPos();

    }

}