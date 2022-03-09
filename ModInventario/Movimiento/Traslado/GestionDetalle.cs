using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Movimiento.Traslado
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
                _gestionEntrada.Inicializa();
                _gestionEntrada.Editar(it, idDeposito);
                if (_gestionEntrada.procesarIsOk)
                {
                    detalle.Remover(it);
                    detalle.Agregar(it.FichaPrd, _gestionEntrada.Cantidad, _gestionEntrada.Costo,
                        _gestionEntrada.TipoEmpaqueSeleccionado, tasaCambio, _gestionEntrada.Importe,
                        _gestionEntrada.ImporteMonedaLocal, enumerados.enumTipoMovimientoAjuste.PorEntrada);
                    bs.CurrencyManager.Refresh();
                }
            }
        }

        public void setTasaCambio(decimal tasaCambio)
        {
            this.tasaCambio = tasaCambio;
            _gestionEntrada.setTasaCambio(tasaCambio);
        }

    }

}