using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.MovInventario.Tools.CapturaMov
{
    public class ImpDataCaptura: IDataCaptura
    {
        private dataItem _item;
        private decimal _tasaCambio;
        private IDataPrd _fichaPrd;
        private IEmpaque _empaque;


        public int Id { get; set; }
        public string AutoPrd { get { return _fichaPrd.PrdAuto; } }
        public string CodigoPrd { get { return _fichaPrd.PrdCodigo; } }
        public string DescripcionPrd { get { return _fichaPrd.PrdDescripcion; } }
        public decimal Cantidad { get { return _item.Cantidad; } }
        public string EmpaqueMov { get { return _item.EmpaqueSel; } }
        public decimal CostoNeto { get { return _item.Costo; } }
        public decimal ImporteNeto { get { return _item.Importe; } }
        public bool EsAdmDivisa { get { return _fichaPrd.InfProductoEsDivisa; } }
        public decimal ImporteNetoMonedaLocal { get { return _item.ImporteMonedaLocal; } }
        public decimal ImporteNetoDivisa { get { return _item.ImporteDivisa;  } }
        //
        public decimal TasaCambio { get { return _tasaCambio; } }
        public decimal Mov_GetCantidad { get { return _item.Cantidad; } }
        public decimal Mov_GetCosto { get { return _item.Costo; } }
        public decimal Mov_GetCntUnd { get { return _item.CntUnd; } }
        public decimal Mov_GetCostoUnd { get { return _item.CostoUnd; } }
        public decimal Mov_GetImporte { get { return _item.Importe; } }
        public IDataPrd Ficha { get { return _fichaPrd; } }
        public IEmpaque Empaque { get { return _empaque; } }
        //
        public dataItem GetItem { get { return _item; } }


        public ImpDataCaptura()
        {
            _fichaPrd = new ImpDataPrd();
            _empaque = new ImpEmpaque();
            _item = new dataItem();
        }


        public void setEmpaque(string id)
        {
            _empaque.setEmpaque(id);
            _item.setEmpaque(_empaque.GetItem);
        }
        public void setCantidad(decimal cnt)
        {
            _item.setCantidad(cnt);
        }
        public void setCosto(decimal mont)
        {
            _item.setCosto(mont);
        }
        public void setTasaCambio(decimal tasa)
        {
            _tasaCambio = tasa;
            _item.setTasaCambio(tasa);
        }
        public void setFicha(data dat)
        {
            _fichaPrd.setFicha(dat);
            _item.setFichaPrd(dat);
        }


        public void Inicializa()
        {
            _fichaPrd.Inicializa();
            _item.Inicializa();
            _empaque.Inicializa();
        }
        public bool ValidarParaProcesarIsOk()
        {
            if (_empaque.GetId == "")
            {
                Helpers.Msg.Alerta("CAMPO [ EMPAQUE ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_item.Importe <= 0)
            {
                Helpers.Msg.Alerta("MONTO MOVIMIENTO INCORRECTO");
                return false;
            }
            return true;
        }
    }
}