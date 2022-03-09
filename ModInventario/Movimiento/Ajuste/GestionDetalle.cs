using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Movimiento.Ajuste
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

        public void AgregarItem(OOB.LibInventario.Producto.Data.Ficha ficha, string idDeposito)
        {
            var filtro = new OOB.LibInventario.Producto.Depositos.Ver.Filtro() { autoProducto = ficha.identidad.auto, autoDeposito = idDeposito };
            var rt1 = Sistema.MyData.Producto_GetDeposito(filtro);
            if (rt1.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return;
            }
            var rt2 = Sistema.MyData.Producto_GetCosto(ficha.identidad.auto);
            if (rt2.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt2.Mensaje);
                return;
            }
            ficha.costo = rt2.Entidad;
            var rt3 = Sistema.MyData.Producto_GetExistencia(ficha.identidad.auto);
            if (rt3.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt3.Mensaje);
                return;
            }
            ficha.existencia = rt3.Entidad;
            ficha.costo = rt2.Entidad;
            var rt4 = Sistema.MyData.Producto_GetIdentificacion(ficha.identidad.auto);
            if (rt4.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt4.Mensaje);
                return;
            }
            ficha.identidad = rt4.Entidad;


            _gestionEntrada.Inicializa();
            _gestionEntrada.setFicha(ficha,idDeposito);
            _gestionEntrada.Inicia();
            if (_gestionEntrada.procesarIsOk) 
            {
                detalle.Agregar(ficha, _gestionEntrada.Cantidad, _gestionEntrada.Costo,
                    _gestionEntrada.TipoEmpaqueSeleccionado, tasaCambio, _gestionEntrada.Importe,
                    _gestionEntrada.ImporteMonedaLocal, _gestionEntrada.TipoMovimientoSeleccionado);
                bs.CurrencyManager.Refresh();
            }
        }

        public void EliminarItem()
        {
            var it =(item) bs.Current;
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
                _gestionEntrada.Editar(it,idDeposito);
                if (_gestionEntrada.procesarIsOk)
                {
                    detalle.Remover(it);
                    detalle.Agregar(it.FichaPrd, _gestionEntrada.Cantidad, _gestionEntrada.Costo, 
                        _gestionEntrada.TipoEmpaqueSeleccionado, tasaCambio, _gestionEntrada.Importe,
                        _gestionEntrada.ImporteMonedaLocal, _gestionEntrada.TipoMovimientoSeleccionado);
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