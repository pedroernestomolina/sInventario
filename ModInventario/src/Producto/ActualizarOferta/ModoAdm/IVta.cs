using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Producto.ActualizarOferta.ModoAdm
{
    public interface IVta
    {
        string GetEmpDesc { get; }
        string GetContDesc { get; }
        string GetUtilidadDesc { get; }
        string GetNetoDivisaDesc { get; }
        string GetNetoMonLocalDesc { get; }
        string GetFullDivisaDesc { get; }
        string GetFullMonLocalDesc { get; }
        DateTime GetOfertaDesde { get; }
        DateTime GetOfertaHasta { get; }
        string GetOfertaPorctDesc { get; }
        string GetFullMonLocalConOfertaDesc { get; }
        string GetFullDivisaConOfertaDesc { get; }
        decimal GetOfertaPorct { get; }
        int GetIdPrecioVta { get; }
        bool EstatusOfertaOk { get; }
        bool PrecioOfertaIsOK { get; }


        void setData(sVta ficha);
        void setTasaIva(decimal monto);
        void setOfertaDesde(DateTime fecha);
        void setOfertaHasta(DateTime fecha);
        void setOfertaPorct(decimal monto);

        void Inicializa();
        void EliminarOferta();
    }
}