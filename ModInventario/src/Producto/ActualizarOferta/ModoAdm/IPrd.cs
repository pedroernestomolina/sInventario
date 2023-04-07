using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Producto.ActualizarOferta.ModoAdm
{
    public struct sFicha
    {
        private string _idPrd;
        private string _codigoPrd;
        private string _descPrd;
        private bool _isAdmDivisa;
        private decimal _tasaIva;
        private decimal _tasaCambio;
        private string _metCalcUt;
        private decimal _costoMonLocalUnd;


        public string GetDescripcion { get { return _codigoPrd.Trim() + Environment.NewLine + _descPrd.Trim(); } }
        public string GetAdmDivisaDesc { get { return _isAdmDivisa ? "SI" : "NO"; } }
        public string GetTasaIvaDesc { get { return _tasaIva.ToString("n2") + "%"; } }
        public string GetTasaCambioDesc { get { return _tasaCambio.ToString("n3"); } }
        public string GetMetCalcUtilidadDesc { get { return _metCalcUt; } }


        public sFicha(string idPrd, 
                            string codigo,
                            string desc,
                            bool isAdmDivisa,
                            decimal tasaIva,
                            decimal tasaCambio,
                            string metCalcUt,
                            decimal costoMonLocalUnd) 
        {
            _idPrd = idPrd;
            _codigoPrd = codigo;
            _descPrd = desc;
            _isAdmDivisa = isAdmDivisa;
            _tasaIva = tasaIva;
            _tasaCambio = tasaCambio;
            _metCalcUt = metCalcUt;
            _costoMonLocalUnd = costoMonLocalUnd;
        }
    }
    public struct sVta
    {
        private decimal _tasaIva;
        private decimal _ofPorct;
        private DateTime _ofDesde;
        private DateTime _ofHasta;
        private string _ofertaEstatus;
        private bool _ofEstatus;
        private DateTime _fechaActual;
        private int _idPrecio;
        private decimal _netoMonLocal;
        private decimal _fullDivisa;
        private decimal _utilidad;
        private int _contEmp;
        private string _descEmp;
        private decimal _costoUnd;


        public sVta(int idPrecio,
                        decimal netoMonLocal, decimal fullDivisa, decimal utilidad,
                        int contEmpaque, string descEmp,
                        DateTime desde, DateTime hasta, decimal porct, string estatus,
                        decimal costoUnd)
        {
            _idPrecio = idPrecio;
            _netoMonLocal = netoMonLocal;
            _fullDivisa = fullDivisa;
            _contEmp = contEmpaque;
            _descEmp = descEmp;
            _utilidad = utilidad;
            _tasaIva = 0m;
            _fechaActual = DateTime.Now.Date;
            _ofDesde = desde;
            _ofHasta = hasta;
            _ofPorct = porct;
            _ofertaEstatus = estatus;
            _ofEstatus = false;
            _costoUnd=costoUnd;
        }
        //
        public int GetIdPrecioVta { get { return _idPrecio; } }
        public string GetEmpDesc { get { return _descEmp; } }
        public string GetEmpCont { get { return _contEmp.ToString(); } }
        public string GetUtilidadDesc { get { return _utilidad.ToString("n2") + "%"; } }
        public string GetNetoDivisaDesc { get { return CalculaNeto(_fullDivisa).ToString("n2", CultureInfo.CurrentCulture); } }
        public string GetFullDivisaDesc { get { return _fullDivisa.ToString("n2", CultureInfo.CurrentCulture); } }
        public string GetNetoMonLocalDesc { get { return _netoMonLocal.ToString("n2", CultureInfo.CurrentCulture); } }
        public string GetFullMonLocalDesc { get { return CalculaFull(_netoMonLocal).ToString("n2", CultureInfo.CurrentCulture); } }
        public DateTime GetOfertaDesde { get { return _ofDesde; } }
        public DateTime GetOfertaHasta { get { return _ofHasta; } }
        public decimal GetOfertaPorct { get { return _ofPorct; } }
        public string GetFullMonLocalConOfertaDesc 
        { 
            get 
            {
                var rt = 0m;
                if (_ofEstatus)
                {
                    rt = CalculoOferta(CalculaFull(_netoMonLocal));
                }
                return rt.ToString("n2", CultureInfo.CurrentCulture);
            } 
        }
        public string GetFullDivisaConOfertaDesc 
        {
            get 
            {
                var rt = 0m;
                if (_ofEstatus)
                {
                    rt = CalculoOferta(_fullDivisa);
                }
                return rt.ToString("n2", CultureInfo.CurrentCulture);
            } 
        }
        public bool EstatusOfertaOk { get { return VerificaEstatusOferta(); } }
        public bool PreciOfertaIsOk 
        {
            get
            {
                if (_ofEstatus)
                {
                    var _costo = (_costoUnd * _contEmp);
                    var rt = CalculoOferta(_netoMonLocal);
                    return (rt >= _costo);
                }
                else 
                {
                    return true;
                }
            }
        }


        public void seTasaIva(decimal monto)
        {
            _tasaIva = monto;
        }
        public void setOfertaDesde(DateTime fecha)
        {
            _ofDesde = fecha;
            VerificaEstatusOferta();
        }
        public void setOfertaHasta(DateTime fecha)
        {
            _ofHasta = fecha;
            VerificaEstatusOferta();
        }
        public void setOfertaPorct(decimal monto)
        {
            _ofPorct = monto;
            VerificaEstatusOferta();
        }


        public void EliminarOferta()
        {
            _ofDesde = _fechaActual;
            _ofHasta = _fechaActual;
            _ofPorct = 0m;
            _ofEstatus = false;
        }
        //
        private decimal CalculaNeto(decimal monto)
        {
            var rt = monto;
            if (_tasaIva > 0m)
            {
                rt = rt / (1 + (_tasaIva / 100m));
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            }
            return rt;
        }
        private decimal CalculaFull(decimal monto)
        {
            var rt = monto;
            if (_tasaIva > 0m)
            {
                var iva = (rt * _tasaIva / 100m);
                rt += iva;
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            }
            return rt;
        }
        private decimal CalculoOferta(decimal monto)
        {
            var rt = monto;
            var dsct = (rt * _ofPorct / 100);
            rt -= dsct;
            rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            return rt;
        }
        private bool VerificaEstatusOferta()
        {
            _ofEstatus = false;
            if (_fechaActual >= _ofDesde && _fechaActual <= _ofHasta && _ofPorct > 0m)
            {
                _ofEstatus = true;
            }
            return _ofEstatus;
        }
    }

    public interface IPrd
    {
        string GetDescripcion { get; }
        string GetTasaCambioDesc { get; }
        string GetMetodoCalUtilidadDesc { get; }
        string GetAdmDivisaDesc { get; }
        string GetTasaIvaDesc { get; }
        IVta Vta1 { get; }
        IVta Vta2 { get; }
        IVta Vta3 { get; }

        void Inicializa();
        void setdataPrd(sFicha ficha);
        void setdataVta1(sVta vta, decimal tasaIva);
        void setdataVta2(sVta vta, decimal tasaIva);
        void setdataVta3(sVta vta, decimal tasaIva);
    }
}