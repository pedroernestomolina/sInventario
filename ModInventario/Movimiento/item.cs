using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Movimiento
{

    public class item
    {

        private OOB.LibInventario.Producto.Data.Ficha ficha;
        private decimal _cnt;
        private decimal _costo;
        private enumerados.enumTipoEmpaque _empaque;
        private enumerados.enumTipoMovimientoAjuste _tipoMovimiento; 
        private decimal _tasaCambio;
        private decimal _importe;
        private decimal _importeMonedaLocal;
        private bool _disponible;
        private bool _exDepCero;


        public OOB.LibInventario.Producto.Data.Ficha FichaPrd { get { return ficha; } }
        public string CodigoPrd { get { return ficha.CodigoPrd; } }
        public string DescripcionPrd { get { return ficha.DescripcionPrd; } }
        public bool EsAdmDivisa { get { return ficha.identidad.AdmPorDivisa == OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa.Si ? true : false; } }
        public bool Disponible { get { return _disponible; } }
        public bool ExistenciaDepositoEnCero { get { return _exDepCero; } }
        public int ContenidoEmpCompra 
        { 
            get 
            {
                var rt = 1;
                if (TipoEmpaqueSeleccionado== enumerados.enumTipoEmpaque.PorEmpaqueCompra)
                    rt=ficha.identidad.contenidoCompra;
                return rt;
            } 
        }

        public decimal Cantidad { get { return _cnt; } }
        public string Cnt { get { return _cnt.ToString("n"+ficha.identidad.Decimales); } }
        public decimal Costo { get { return _costo; } }
        public decimal Importe { get { return _importe; } }
        public decimal ImporteMonedaLocal { get { return _importeMonedaLocal; } }
        public enumerados.enumTipoEmpaque TipoEmpaqueSeleccionado { get { return _empaque; } }
        public decimal CostoUnd { get { return _costo / ContenidoEmpCompra; } }
        public decimal TasaCambio { get { return _tasaCambio; } }
        public int Signo { get { return _tipoMovimiento == enumerados.enumTipoMovimientoAjuste.PorEntrada ? 1 : -1; } }
        public string TipoMovimientoDescripcion { get { return Signo==1 ? "CARGO":"DESCARGO"; } }
        public enumerados.enumTipoMovimientoAjuste TipoMovimiento { get { return _tipoMovimiento; } }

        public decimal CostoDivisa 
        { 
            get 
            {
                var ct = 0.0m;
                ct = CostoMonedaLocal / _tasaCambio;
                ct = Math.Round(ct, 2, MidpointRounding.AwayFromZero);
                return ct;
            } 
        }
        public decimal CostoMonedaLocal 
        {
            get 
            {
                var cn = Costo ;
                if (EsAdmDivisa)
                {
                    cn = Costo * _tasaCambio;
                }
                cn = Math.Round(cn, 2, MidpointRounding.AwayFromZero);
                return cn;
            }
        }

        public decimal CostoUndMonedaLocal 
        {
            get 
            {
                var cn = CostoUnd;
                if (EsAdmDivisa)
                {
                    cn = CostoUnd * _tasaCambio;
                }
                cn = Math.Round(cn, 2, MidpointRounding.AwayFromZero);
                return cn;
            }
        }

        public string Empaque 
        { 
            get 
            {
                var _emp = ficha.Empaque; 
                if (TipoEmpaqueSeleccionado == enumerados.enumTipoEmpaque.PorUnidad) 
                {
                    _emp = "UNIDAD (1)";
                }
                return _emp ; 
            } 
        }

        public string EmpaquePrd 
        {
            get 
            {
                var rt = "UNIDAD";
                if (TipoEmpaqueSeleccionado != enumerados.enumTipoEmpaque.PorUnidad)
                    rt = ficha.identidad.empaqueCompra;
                return rt;
            }
        }

        public decimal CantidadUnd 
        { 
            get 
            {
                var ct = 0.0m;
                if (_empaque== enumerados.enumTipoEmpaque.PorEmpaqueCompra)
                    ct = _cnt * ContenidoEmpCompra;
                else
                    ct = _cnt * 1;
                return ct;  
            } 
        }


        public item(OOB.LibInventario.Producto.Data.Ficha ficha, decimal cnt, decimal costo, enumerados.enumTipoEmpaque emp, 
            decimal tasaCambio, decimal importe, decimal importeMonedaLocal, enumerados.enumTipoMovimientoAjuste tipoMov, bool disponible, bool exDepCero)
        {
            this.ficha = ficha;
            _cnt = cnt;
            _costo = costo;
            _empaque = emp;
            _tasaCambio = tasaCambio;
            _importe = importe;
            _importeMonedaLocal = importeMonedaLocal;
            _tipoMovimiento = tipoMov;
            _disponible = disponible;
            _exDepCero = exDepCero;
        }


        public item(OOB.LibInventario.Movimiento.Traslado.Capturar.ProductoPorDebajoNivelMinimo.Ficha ficha,
            OOB.LibInventario.Producto.Data.Existencia fEx,
            OOB.LibInventario.Producto.Data.Costo fCosto,
            decimal cnt, decimal costo, enumerados.enumTipoEmpaque emp,
            decimal tasaCambio, decimal importe, decimal importeMonedaLocal, 
            enumerados.enumTipoMovimientoAjuste tipoMov, bool disponible, bool exDepCero)
        {
            this.ficha = new OOB.LibInventario.Producto.Data.Ficha(ficha, fEx, fCosto);
            _cnt = cnt;
            _costo = costo;
            _empaque = emp;
            _tasaCambio = tasaCambio;
            _importe = importe;
            _importeMonedaLocal = importeMonedaLocal;
            _tipoMovimiento = tipoMov;
            _disponible = disponible;
            _exDepCero = exDepCero;
        }

    }

}