using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.MovimientoInv.AjusteInvCero
{

    public class item
    {

        private int _id;
        private OOB.LibInventario.Movimiento.AjusteInvCero.Capture.Data _data;


        public int Id { get { return _id; } }
        public string AutoPrd { get { return _data.autoPrd; } }
        public string CodigoPrd { get { return _data.codigoPrd; } }
        public string NombrePrd { get { return _data.nombrePrd; } }
        public decimal Cantidad { get { return _data.exFisica; } }
        public decimal Ajuste { get { return Cantidad * (-1); } }
        public string Empaque { get { return "UNIDAD ( 1 )"; } }
        public bool EsDivisa { get { return _data.esAdmDivisa; } }
        public decimal Costo
        {
            get
            {
                var r = _data.costoUnd;
                if (EsDivisa) { r = _data.costoDivisaUnd; }
                return r;
            }
        }
        public decimal Importe
        {
            get
            {
                var rt = Costo * Ajuste;
                return rt;
            }
        }
        public string TipoMovimiento { get { return Importe > 0 ? "CARGO" : "DESCARGO"; } }
        public int Signo { get { return Importe > 0 ? 1 : -1; } }
        public decimal CostoMonedaLocal { get { return _data.costoUnd; } }
        public OOB.LibInventario.Movimiento.AjusteInvCero.Capture.Data Ficha { get { return _data; } }
        public decimal TotalImporteMonedaLocal
        {
            get
            {
                var rt = Importe;
                if (EsDivisa)
                    rt = Math.Round(Importe * 4.8m, 2, MidpointRounding.AwayFromZero);
                return rt;
            }
        }


        public item(int id, OOB.LibInventario.Movimiento.AjusteInvCero.Capture.Data data)
        {
            _id = id;
            _data = data;
        }

    }

}