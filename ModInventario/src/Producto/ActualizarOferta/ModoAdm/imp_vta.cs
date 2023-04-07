using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Producto.ActualizarOferta.ModoAdm
{
    public class imp_vta: IVta
    {
        private sVta _vta;


        public string GetEmpDesc { get { return _vta.GetEmpDesc; } }
        public string GetContDesc { get { return _vta.GetEmpCont; } }
        public string GetUtilidadDesc { get { return _vta.GetUtilidadDesc; } }
        public string GetNetoDivisaDesc { get { return _vta.GetNetoDivisaDesc; } }
        public string GetNetoMonLocalDesc { get { return _vta.GetNetoMonLocalDesc; } }
        public string GetFullDivisaDesc { get { return _vta.GetFullDivisaDesc; } }
        public string GetFullMonLocalDesc { get { return _vta.GetFullMonLocalDesc; } }
        //
        public DateTime GetOfertaDesde { get { return _vta.GetOfertaDesde; } }
        public DateTime GetOfertaHasta { get { return _vta.GetOfertaHasta; } }
        public string GetOfertaPorctDesc { get { return _vta.GetOfertaPorct.ToString("n2", CultureInfo.CurrentCulture); } }
        public string GetFullMonLocalConOfertaDesc { get { return _vta.GetFullMonLocalConOfertaDesc; } }
        public string GetFullDivisaConOfertaDesc { get { return _vta.GetFullDivisaConOfertaDesc; } }
        public bool EstatusOfertaOk { get { return _vta.EstatusOfertaOk; } }
        public bool PrecioOfertaIsOK { get { return _vta.PreciOfertaIsOk; } }
        //
        public decimal GetOfertaPorct { get { return _vta.GetOfertaPorct; } }
        public int GetIdPrecioVta { get { return _vta.GetIdPrecioVta; } }


        public imp_vta()
        {
        }


        public void setData(sVta ficha)
        {
            _vta = ficha;
        }
        public void setTasaIva(decimal monto)
        {
            _vta.seTasaIva(monto);
        }
        public void setOfertaDesde(DateTime fecha)
        {
            _vta.setOfertaDesde(fecha);
        }
        public void setOfertaHasta(DateTime fecha)
        {
            _vta.setOfertaHasta(fecha);
        }
        public void setOfertaPorct(decimal monto)
        {
            _vta.setOfertaPorct(monto);
        }


        public void Inicializa()
        {
        }
        public void EliminarOferta()
        {
            _vta.EliminarOferta();
        }
    }
}