using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Helpers
{
    public static class HndReportes
    {
        public static void MaestroPrecio(src.IFabrica fabrica, ModInventario.src.Filtro.FiltroRep.IFiltroRep filtro)
        {
            filtro.Inicializa();
            filtro.setValidarData(false);
            filtro.setGestion(fabrica.CreateInstancia_RepMasterPrecio_Filtros());
            filtro.setDepartamento("");
            filtro.Inicia();
            if (filtro.FiltrosIsOK)
            {
                if (filtro.dataFiltrar.Precio == null)
                {
                    Helpers.Msg.Alerta("Debes Indicar El Tipo De Precio A Listar");
                    return;
                }
                var rp = fabrica.CreateInstancia_RepMasterPrecio();
                rp.setFiltros(filtro.dataFiltrar);
                rp.Generar();
            }
        }
        public static void ResumenCostoInventario(src.IFabrica _fabrica, src.Filtro.FiltroRep.IFiltroRep filtro)
        {
            filtro.Inicializa();
            filtro.setValidarData(false);
            filtro.setDesde(DateTime.Now.Date);
            filtro.setHasta(DateTime.Now.Date);
            filtro.setGestion(new Reportes.Filtros.ResumenCostoInventario.Filtros());
            filtro.Inicia();
            if (filtro.FiltrosIsOK)
            {
                if (filtro.dataFiltrar.Deposito == null)
                {
                    Helpers.Msg.Error("Parametro [ DEPOSITO ] Incorrectos, Verifique Por Favor");
                    return;
                }
                var rp = new Reportes.Filtros.ResumenCostoInventario.GestionRep();
                rp.setFiltros(filtro.dataFiltrar);
                rp.Generar();
            }
        }
        public static void MaestroProductos(src.IFabrica _fabrica, src.Filtro.FiltroRep.IFiltroRep filtro)
        {
            filtro.Inicializa();
            filtro.setValidarData(false);
            filtro.setGestion(new Reportes.Filtros.MaestroProducto.Filtros());
            filtro.Inicia();
            if (filtro.FiltrosIsOK)
            {
                var rp = new Reportes.Filtros.MaestroProducto.GestionRep();
                rp.setFiltros(filtro.dataFiltrar);
                rp.Generar();
            }
        }
        public static void RelacionCompraVenta(src.IFabrica _fabrica, src.Filtro.FiltroRep.IFiltroRep filtro)
        {
            filtro.Inicializa();
            filtro.setValidarData(false);
            filtro.setGestion(new Reportes.Filtros.RelacionCompraVenta.Filtros());
            filtro.Inicia();
            if (filtro.FiltrosIsOK)
            {
                if (filtro.dataFiltrar.Producto == null)
                {
                    Helpers.Msg.Error("Parametros Incorrectos, Verifique Por Favor");
                    return;
                }
                var rp = new Reportes.Filtros.RelacionCompraVenta.GestionRep();
                rp.setFiltros(filtro.dataFiltrar);
                rp.Generar();
            }
        }
        public static void ValorizacionInventario(src.IFabrica _fabrica, src.Filtro.FiltroRep.IFiltroRep filtro)
        {
            filtro.Inicializa();
            filtro.setValidarData(true);
            filtro.setGestion(new Reportes.Filtros.Valorizacion.Filtros());
            filtro.setHasta(DateTime.Now.Date);
            filtro.Inicia();
            if (filtro.FiltrosIsOK)
            {
                if (filtro.dataFiltrar.Deposito == null)
                {
                    Helpers.Msg.Error("Parametro [ DEPOSITO ] Incorrectos, Verifique Por Favor");
                    return;
                }
                var rp = new Reportes.Filtros.Valorizacion.GestionRep();
                rp.setFiltros(filtro.dataFiltrar);
                rp.Generar();
            }
        }
        public static void KardexResumenMov(src.IFabrica _fabrica, src.Filtro.FiltroRep.IFiltroRep filtro)
        {
            filtro.Inicializa();
            filtro.setValidarData(true);
            filtro.setDesde(DateTime.Now.Date);
            filtro.setHasta(DateTime.Now.Date);
            filtro.setGestion(new Reportes.Filtros.Kardex.Filtros());
            filtro.Inicia();
            if (filtro.FiltrosIsOK)
            {
                if (filtro.dataFiltrar.Producto == null)
                {
                    Helpers.Msg.Error("Parametro [ PRODUCTO ] Incorrectos, Verifique Por Favor");
                    return;
                }
                var rp = new Reportes.Filtros.KardexResumen.GestionRep();
                rp.setFiltros(filtro.dataFiltrar);
                rp.Generar();
            }
        }
        public static void Kardex(src.IFabrica _fabrica, src.Filtro.FiltroRep.IFiltroRep filtro)
        {
            filtro.Inicializa();
            filtro.setValidarData(true);
            filtro.setDesde(DateTime.Now.Date);
            filtro.setHasta(DateTime.Now.Date);
            filtro.setGestion(new Reportes.Filtros.Kardex.Filtros());
            filtro.Inicia();
            if (filtro.FiltrosIsOK)
            {
                var rp = new Reportes.Filtros.Kardex.GestionRep();
                rp.setFiltros(filtro.dataFiltrar);
                rp.Generar();
            }
        }
        public static void NivelMinimo(src.IFabrica _fabrica, src.Filtro.FiltroRep.IFiltroRep filtro)
        {
            filtro.Inicializa();
            filtro.setValidarData(false);
            filtro.setGestion(new Reportes.Filtros.NivelMInimo.Filtro());
            filtro.Inicia();
            if (filtro.FiltrosIsOK)
            {
                var rp = new Reportes.Filtros.NivelMInimo.GestionRep();
                rp.setFiltros(filtro.dataFiltrar);
                rp.Generar();
            }
        }
        public static void MaestroInventarioBasico(src.IFabrica _fabrica, src.Filtro.FiltroRep.IFiltroRep filtro)
        {
            filtro.Inicializa();
            filtro.setValidarData(false);
            filtro.setGestion(new Reportes.Filtros.MaestroInventario.Filtros());
            filtro.Inicia();
            if (filtro.FiltrosIsOK)
            {
                var rp = new Reportes.Filtros.MaestroInventarioBasico.GestionRep();
                rp.setFiltros(filtro.dataFiltrar);
                rp.Generar();
            }
        }
        public static void MaestroInventario(src.IFabrica _fabrica, src.Filtro.FiltroRep.IFiltroRep filtro)
        {
            filtro.Inicializa();
            filtro.setValidarData(false);
            filtro.setGestion(new Reportes.Filtros.MaestroInventario.Filtros());
            filtro.Inicia();
            if (filtro.FiltrosIsOK)
            {
                var rp = new Reportes.Filtros.MaestroInventario.GestionRep();
                rp.setFiltros(filtro.dataFiltrar);
                rp.Generar();
            }
        }
        public static void MaestroExistenciaDetalle(src.IFabrica _fabrica, src.Filtro.FiltroRep.IFiltroRep filtro)
        {
            filtro.Inicializa();
            filtro.setValidarData(false);
            filtro.setGestion(new Reportes.Filtros.MaestroExistencia.Filtros());
            filtro.Inicia();
            if (filtro.FiltrosIsOK)
            {
                var rp = new Reportes.Filtros.MaestroExistencia.GestionRep();
                rp.setFiltros(filtro.dataFiltrar);
                rp.Generar();
            }
        }
        public static void MaestroExistenciaInventario(src.IFabrica _fabrica, src.Filtro.FiltroRep.IFiltroRep filtro)
        {
            filtro.Inicializa();
            filtro.setValidarData(false);
            filtro.setGestion(new Reportes.Filtros.MaestroExistenciaInventario.Filtros());
            filtro.Inicia();
            if (filtro.FiltrosIsOK)
            {
                var rp = new Reportes.Filtros.MaestroExistenciaInventario.GestionRep();
                rp.setFiltros(filtro.dataFiltrar);
                rp.Generar();
            }
        }
    }
}