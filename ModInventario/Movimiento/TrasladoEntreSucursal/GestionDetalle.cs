using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Movimiento.TrasladoEntreSucursal
{
 
    public class GestionDetalle
    {

        private Entrada.Gestion _gestionEntrada;
        private Movimiento.dataDetalle detalle;
        private BindingSource bs;
        private decimal tasaCambio;


        public System.Windows.Forms.BindingSource Souce { get { return bs; } }
        public decimal MontoMovimiento { get { return detalle.MontoMovimiento; } }
        public string ItemsMovimiento { get { return string.Format("Total Items \n {0}", bs.Count); } }
        public int TotalItems { get { return bs.Count; } }
        public Movimiento.dataDetalle Detalle { get { return detalle; } }
        public item ItemActual { get { return (item)bs.Current; } }


        public GestionDetalle()
        {
            _gestionEntrada = new Entrada.Gestion();
            tasaCambio = 0.0m;
            detalle = new dataDetalle();
            bs = new BindingSource();
            bs.DataSource = detalle.ListaItems;
        }


        public void Limpiar()
        {
            detalle.Limpiar();
        }

        public void AgregarItem(OOB.LibInventario.Producto.Data.Ficha ficha, string idDepositoOrigen, string idDepositoDestino)
        {
            var filtro1 = new OOB.LibInventario.Producto.Depositos.Ver.Filtro() { autoProducto = ficha.identidad.auto, autoDeposito = idDepositoOrigen };
            var rt1 = Sistema.MyData.Producto_GetDeposito(filtro1);
            if (rt1.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return;
            }
            var filtro2 = new OOB.LibInventario.Producto.Depositos.Ver.Filtro() { autoProducto = ficha.identidad.auto, autoDeposito = idDepositoDestino };
            var rt2 = Sistema.MyData.Producto_GetDeposito(filtro2);
            if (rt2.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt2.Mensaje);
                return;
            }
            var rt3 = Sistema.MyData.Producto_GetCosto(ficha.identidad.auto);
            if (rt3.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt3.Mensaje);
                return;
            }
            ficha.costo = rt3.Entidad;
            var rt4 = Sistema.MyData.Producto_GetExistencia(ficha.identidad.auto);
            if (rt4.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt4.Mensaje);
                return;
            }
            ficha.existencia = rt4.Entidad;
            var rt5 = Sistema.MyData.Producto_GetIdentificacion (ficha.identidad.auto);
            if (rt5.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt5.Mensaje);
                return;
            }
            ficha.identidad = rt5.Entidad;

            var exFisica = rt4.Entidad.depositos.FirstOrDefault(w => w.autoId == idDepositoOrigen).exFisica;
            if (exFisica <= 0.0m)
            {
                Helpers.Msg.Error("NO HAY DISPONIBILIDAD PARA ESTE PRODUCTO" + Environment.NewLine + "VERIFIQUE POR FAVOR...");
                return;
            }

            _gestionEntrada.Inicializa();
            _gestionEntrada.setFicha(ficha, idDepositoOrigen);
            _gestionEntrada.Inicia();
            if (_gestionEntrada.procesarIsOk)
            {
                detalle.Agregar(ficha, _gestionEntrada.Cantidad, _gestionEntrada.Costo,
                    _gestionEntrada.TipoEmpaqueSeleccionado, tasaCambio, _gestionEntrada.Importe,
                    _gestionEntrada.ImporteMonedaLocal, enumerados.enumTipoMovimientoAjuste.PorEntrada);
                bs.CurrencyManager.Refresh();
            }
        }

        public void EliminarItem()
        {
            var it = (item)bs.Current;
            if (it != null)
            {
                bs.Remove(it);
            }
            bs.CurrencyManager.Refresh();
        }

        public void EditarItem(string idDeposito)
        {
            var it = (item)bs.Current;
            if (it != null)
            {
                var idx= bs.IndexOf(it);
                if (idx == 0)
                    idx = -1;
                _gestionEntrada.Inicializa();
                _gestionEntrada.Editar(it, idDeposito);
                if (_gestionEntrada.procesarIsOk)
                {
                    detalle.Remover(it);
                    detalle.Agregar(it.FichaPrd, _gestionEntrada.Cantidad, _gestionEntrada.Costo,
                        _gestionEntrada.TipoEmpaqueSeleccionado, tasaCambio, _gestionEntrada.Importe,
                        _gestionEntrada.ImporteMonedaLocal, enumerados.enumTipoMovimientoAjuste.PorEntrada,true,false,idx);
                    bs.CurrencyManager.Refresh();
                }
            }
        }

        public void setTasaCambio(decimal tasaCambio)
        {
            this.tasaCambio = tasaCambio;
            _gestionEntrada.setTasaCambio(tasaCambio);
        }


        public void AgregarItem(List<OOB.LibInventario.Movimiento.Traslado.Consultar.ProductoPorDebajoNivelMinimo> list, string idDepositoOrigen)
        {
            foreach (var reg in list.OrderBy(o=>o.nombreProducto).ToList())
            {
                var ficha = new OOB.LibInventario.Producto.Data.Ficha();
                var rt5 = Sistema.MyData.Producto_GetIdentificacion(reg.autoProducto);
                if (rt5.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(rt5.Mensaje);
                    return;
                }
                ficha.identidad = rt5.Entidad;
                var rt3 = Sistema.MyData.Producto_GetCosto(reg.autoProducto);
                if (rt3.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(rt3.Mensaje);
                    return;
                }
                ficha.costo = rt3.Entidad;
                var rt4 = Sistema.MyData.Producto_GetExistencia(reg.autoProducto);
                if (rt4.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(rt4.Mensaje);
                    return;
                }
                ficha.existencia = rt4.Entidad;

                var importe = 0.0m;
                var importeMonedaLocal = 0.0m;
                var costo = rt3.Entidad.costoUnd;
                importe = costo * reg.cntUndReponer;
                importeMonedaLocal = importe ;
                if (rt3.Entidad.admDivisa == OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa.Si) 
                {
                    costo = rt3.Entidad.costoDivisaUnd;
                    importe = costo * reg.cntUndReponer;
                    importeMonedaLocal = importe * tasaCambio;
                }

                var xrt = rt4.Entidad.depositos.FirstOrDefault(w => w.autoId == idDepositoOrigen);
                if (xrt != null)
                {
                    var exFisica = rt4.Entidad.depositos.FirstOrDefault(w => w.autoId == idDepositoOrigen).exFisica;
                    var disponible = (exFisica >= reg.cntUndReponer);
                    var exDepCero = (exFisica <=0);

                    detalle.Agregar(ficha, reg.cntUndReponer, costo,
                             enumerados.enumTipoEmpaque.PorUnidad, tasaCambio, importe,
                             importeMonedaLocal, enumerados.enumTipoMovimientoAjuste.PorEntrada, disponible, exDepCero);
                    bs.CurrencyManager.Refresh();
                }
            }
        }

        public void EliminarItemsNoDisponible()
        {
            detalle.EliminarItemsNoDisponible();
            bs.CurrencyManager.Refresh();
        }

        public void EliminarItemsExistenciaDepositoCero()
        {
            detalle.EliminarItemsExistenciaDepositoCero();
            bs.CurrencyManager.Refresh();
        }

        public void AgregarItem(OOB.LibInventario.Producto.Data.Ficha reg, string idDepositoOrigen)
        {
            Agregar(reg.AutoId, idDepositoOrigen);
            //if (detalle.VerificaItemRegistrado(reg.AutoId)) 
            //{
            //    Helpers.Msg.Alerta("PRODUCTO YA APARECE EN LA LISTA");
            //    return;
            //}

            //var ficha = new OOB.LibInventario.Producto.Data.Ficha();
            //var rt5 = Sistema.MyData.Producto_GetIdentificacion(reg.AutoId);
            //if (rt5.Result == OOB.Enumerados.EnumResult.isError)
            //{
            //    Helpers.Msg.Error(rt5.Mensaje);
            //    return;
            //}
            //ficha.identidad = rt5.Entidad;
            //var rt3 = Sistema.MyData.Producto_GetCosto(reg.AutoId);
            //if (rt3.Result == OOB.Enumerados.EnumResult.isError)
            //{
            //    Helpers.Msg.Error(rt3.Mensaje);
            //    return;
            //}
            //ficha.costo = rt3.Entidad;
            //var rt4 = Sistema.MyData.Producto_GetExistencia(reg.AutoId);
            //if (rt4.Result == OOB.Enumerados.EnumResult.isError)
            //{
            //    Helpers.Msg.Error(rt4.Mensaje);
            //    return;
            //}
            //ficha.existencia = rt4.Entidad;

            //var importe = 0.0m;
            //var importeMonedaLocal = 0.0m;
            //var costo = rt3.Entidad.costoUnd;
            //var cntUndReponer = 0.0m;

            //importe = costo * cntUndReponer ;
            //importeMonedaLocal = importe;
            //if (rt3.Entidad.admDivisa == OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa.Si)
            //{
            //    costo = rt3.Entidad.costoDivisaUnd;
            //    importe = costo * cntUndReponer;
            //    importeMonedaLocal = importe * tasaCambio;
            //}

            //var xrt = rt4.Entidad.depositos.FirstOrDefault(w => w.autoId == idDepositoOrigen);
            //if (xrt != null)
            //{
            //    var exFisica = rt4.Entidad.depositos.FirstOrDefault(w => w.autoId == idDepositoOrigen).exFisica;
            //    var disponible = (exFisica >= cntUndReponer);
            //    var exDepCero = (exFisica <= 0);

            //    detalle.Agregar(ficha, cntUndReponer, costo,
            //             enumerados.enumTipoEmpaque.PorUnidad, tasaCambio, importe,
            //             importeMonedaLocal, enumerados.enumTipoMovimientoAjuste.PorEntrada, disponible, exDepCero);
            //    bs.CurrencyManager.Refresh();
            //}
        }

        public void AgregarItem(Analisis.General.data item, string autoDep)
        {
            Agregar(item.autoId, autoDep);
        }

        private void Agregar(string autoPrd, string autoDep) 
        {
            if (detalle.VerificaItemRegistrado(autoPrd))
            {
                Helpers.Msg.Alerta("PRODUCTO YA APARECE EN LA LISTA");
                return;
            }

            var ficha = new OOB.LibInventario.Producto.Data.Ficha();
            var rt5 = Sistema.MyData.Producto_GetIdentificacion(autoPrd);
            if (rt5.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt5.Mensaje);
                return;
            }
            ficha.identidad = rt5.Entidad;
            var rt3 = Sistema.MyData.Producto_GetCosto(autoPrd);
            if (rt3.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt3.Mensaje);
                return;
            }
            ficha.costo = rt3.Entidad;
            var rt4 = Sistema.MyData.Producto_GetExistencia(autoPrd);
            if (rt4.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt4.Mensaje);
                return;
            }
            ficha.existencia = rt4.Entidad;

            var importe = 0.0m;
            var importeMonedaLocal = 0.0m;
            var costo = rt3.Entidad.costoUnd;
            var cntUndReponer = 0.0m;

            importe = costo * cntUndReponer;
            importeMonedaLocal = importe;
            if (rt3.Entidad.admDivisa == OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa.Si)
            {
                costo = rt3.Entidad.costoDivisaUnd;
                importe = costo * cntUndReponer;
                importeMonedaLocal = importe * tasaCambio;
            }

            var xrt = rt4.Entidad.depositos.FirstOrDefault(w => w.autoId == autoDep);
            if (xrt != null)
            {
                var exFisica = rt4.Entidad.depositos.FirstOrDefault(w => w.autoId == autoDep).exFisica;
                var disponible = (exFisica >= cntUndReponer);
                var exDepCero = (exFisica <= 0);

                detalle.Agregar(ficha, cntUndReponer, costo,
                         enumerados.enumTipoEmpaque.PorUnidad, tasaCambio, importe,
                         importeMonedaLocal, enumerados.enumTipoMovimientoAjuste.PorEntrada, disponible, exDepCero);
                bs.CurrencyManager.Refresh();
            }
        }


        public void AgregarItem(List<OOB.LibInventario.Movimiento.Traslado.Capturar.ProductoPorDebajoNivelMinimo.Ficha> list, string p)
        {
            foreach (var rg in list.OrderBy(o => o.nombrePrd).ToList())
            {
                var importe = 0.0m;
                var importeMonedaLocal = 0.0m;
                var costo = rg.costoUnd;
                importe = costo * rg.cntUndReponer;
                importeMonedaLocal = importe;
                if (rg.AdmDivisa)
                {
                    costo = rg.costoDivisaUnd;
                    importe = costo * rg.cntUndReponer;
                    importeMonedaLocal = importe * tasaCambio;
                }

                var exFisica = rg.exFisicaOrigen;
                var disponible = (exFisica >= rg.cntUndReponer);
                var exDepCero = (exFisica <= 0);

                var ldep = new List<OOB.LibInventario.Producto.Data.Deposito>();
                var dep = new OOB.LibInventario.Producto.Data.Deposito()
                {
                    autoId = rg.autoDepositoOrigen,
                    codigo = rg.codigoDepositoOrigen,
                    nombre = rg.nombreDepositoOrigen,
                    exFisica = rg.exFisicaOrigen,
                    exDisponible = rg.exDisponibleOrigen,
                    exReserva = rg.exReservaOrigen,
                };
                ldep.Add(dep);
                var fEx = new OOB.LibInventario.Producto.Data.Existencia()
                {
                    codigoPrd = rg.codigoPrd,
                    decimales = rg.decimales,
                    empaque = rg.empCompra,
                    empaqueContenido = rg.empCompraCont,
                    nombrePrd = rg.nombrePrd,
                    depositos = ldep,
                };
                var fechaV="";
                if (rg.fechaUltActualizacion!=new DateTime(2000,01,01).Date) 
                { 
                    fechaV = rg.fechaUltActualizacion.ToShortDateString(); 
                }
                var fCosto = new OOB.LibInventario.Producto.Data.Costo()
                {
                    codigo = rg.codigoPrd,
                    nombre = rg.nombrePrd,
                    descripcion = rg.nombrePrd,
                    nombreTasaIva = rg.tasaIvaNombre,
                    tasaIva = rg.tasaIva,
                    empaqueCompra = rg.empCompra,
                    contEmpaqueCompra = rg.empCompraCont,
                    estatus = OOB.LibInventario.Producto.Enumerados.EnumEstatus.Activo,
                    admDivisa = rg.estatusDivisa == "1" ? OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa.Si : OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa.No,
                    fechaUltCambio = fechaV,
                    costoDivisaUnd = rg.costoDivisaUnd,
                    costoImportacionUnd = 0.0m,
                    costoPromedioUnd = 0.0m,
                    costoProveedorUnd = 0.0m,
                    costoUnd = rg.costoUnd,
                    costoVarioUnd = 0.0m,
                    Edad = 0,
                };
                detalle.Agregar(rg,fEx, fCosto, rg.cntUndReponer, costo,
                         enumerados.enumTipoEmpaque.PorUnidad, tasaCambio, importe,
                         importeMonedaLocal, enumerados.enumTipoMovimientoAjuste.PorEntrada, disponible, exDepCero);
                bs.CurrencyManager.Refresh();
            }
        }

    }

}