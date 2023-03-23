using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.MovInventario.Tools.CapturaMov
{
    public class ImpDataCaptura: IDataCaptura
    {
        protected dataItem _item;
        private decimal _tasaCambio;
        private IDataPrd _fichaPrd;
        protected IEmpaque _empaque;
        protected ITipMov _tipMov;


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
        public string TipoMov { get { return _item.TipoMov; } }
        public int Signo { get { return _item.Signo; } }

        //
        public decimal InfExistenciaActual { get { return _fichaPrd.GetFicha.exFisica; } }
        public decimal InfNivelMinimoDepDestino { get { return _fichaPrd.GetFicha.nivelMinimoDepDestino; } }
        public decimal InfNivelOptimoDepDestino { get { return _fichaPrd.GetFicha.nivelOptimoDepDestino; } }
        public decimal InfExFisicaDepDestino { get { return _fichaPrd.GetFicha.exFisicaDepDestino; } }
        public decimal InfCntReponerDepDestino { get { return _fichaPrd.GetFicha.cntReponerDepDestino; } }
        //
        public decimal TasaCambio { get { return _tasaCambio; } }
        public decimal Mov_GetCantidad { get { return _item.Cantidad; } }
        public decimal Mov_GetCosto { get { return _item.Costo; } }
        public decimal Mov_GetCntUnd { get { return _item.CntUnd; } }
        public decimal Mov_GetCostoUnd { get { return _item.CostoUnd; } }
        public decimal Mov_GetImporte { get { return _item.Importe; } }
        //
        public IDataPrd Ficha { get { return _fichaPrd; } }
        public IEmpaque Empaque { get { return _empaque; } }
        public ITipMov TipMov { get { return _tipMov; } }
        //
        public dataItem GetItem { get { return _item; } }


        public ImpDataCaptura()
        {
            _fichaPrd = new ImpDataPrd();
            _empaque = new ImpEmpaque();
            _tipMov = new ImpTipMov();
            _item = new dataItem();
        }


        public void setTipoMov(string id)
        {
            _tipMov.setTipMov(id);
            _item.setTipMov(_tipMov.GetItem);
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
            _tipMov.Inicializa();
        }
        public virtual bool ValidarParaProcesarIsOk()
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
        public void CargarEmpaques()
        {
            _empaque.CargarData();
        }
        public void CargarTipoMovAjuste()
        {
            _tipMov.CargarData();
        }
    }
}