using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.MovInventario
{
    public class dataItem
    {
        private data _fichaPrd;
        private decimal _cntMov;
        private decimal _cntUndMov; 
        private decimal _costMov;
        private decimal _costUndMov;
        private int _contEmpSel;
        private string _descEmpSel;
        private decimal _importe;
        private decimal _tasaCambio;
        private bool _empaqueSelEsPorUnidad;
        private decimal _costoEmpUndMonedaLocal;
        private string _idEmpSel;
        private string _idTipMov;
        private int _signo;


        public decimal Cantidad { get { return _cntMov; } }
        public decimal Costo { get { return _costMov; } }
        public decimal CntUnd { get { return _cntUndMov; } }
        public decimal CostoUnd { get { return _costUndMov; } }
        public decimal Importe { get { return _importe; } }
        public string DescEmpaqueSel { get { return _descEmpSel; } }
        public int ContEmpaqueSel { get { return _contEmpSel; } }
        public string EmpaqueSelGetId { get { return _idEmpSel; } }
        public string EmpaqueSel { get { return _descEmpSel.Trim() + "(" + _contEmpSel.ToString().Trim() + ")"; } }
        public bool EmpaqueSel_EsPorUnidad { get { return _empaqueSelEsPorUnidad; } }
        public decimal ImporteMonedaLocal { get { return CalculaImporteMonedaLocal(); } }
        public decimal ImporteDivisa { get { return CalculaImporteDivisa(); } }
        public data FichaPrd { get { return _fichaPrd; } }
        public decimal CostoEmpUndMonedaLocal  {get {return _costoEmpUndMonedaLocal;}}
        public decimal CostoEmpSelMonedaLocal { get { return _costoEmpUndMonedaLocal * _contEmpSel; } }
        public int Signo { get { return _signo; } }
        public string TipoMov { get { return _idTipMov == "1" ? "CARGO" : "DESCARGO"; } }


        public dataItem()
        {
            _fichaPrd = null;
            _cntMov = 0m;
            _cntUndMov=0m; 
            _costMov = 0m;
            _costUndMov=0m;
            _importe = 0m;
            _idEmpSel = "";
            _contEmpSel = 0;
            _descEmpSel = "";
            _empaqueSelEsPorUnidad = false;
            _tasaCambio = 0m;
            _costoEmpUndMonedaLocal = 0m;
            _idTipMov = "";
            _signo = 1;
        }

        public void Inicializa()
        {
            _fichaPrd = null;
            _cntMov = 0m;
            _cntUndMov = 0m; 
            _costMov = 0m;
            _costUndMov=0m;
            _importe = 0m;
            _idEmpSel = "";
            _contEmpSel = 0;
            _descEmpSel = "";
            _empaqueSelEsPorUnidad = false;
            _tasaCambio = 0m;
            _costoEmpUndMonedaLocal = 0m;
            _idTipMov = "";
            _signo = 1;
        }

        public void setTasaCambio(decimal tasa)
        {
            _tasaCambio = tasa;
        }
        public void setFichaPrd(data fic)
        {
            _fichaPrd = fic;
        }
        public void setCantidad(decimal cnt)
        {
            _cntMov = cnt;
            Actualizar();
        }
        public void setCosto(decimal cost)
        {
            _costMov = cost;
            Actualizar();
        }
        public void setTipMov(ficha ficha)
        {
            _idTipMov = "";
            if (ficha != null)
            {
                _idTipMov = ficha.id;
                _signo = 1;
                if (_idTipMov == "2")
                {
                    _signo = -1;
                }
                Actualizar();
            }
        }
        public  void setEmpaque(ficha ficha)
        {
            if (ficha != null)
            {
                switch (ficha.id)
                {
                    case "1":
                        _idEmpSel = "1";
                        _contEmpSel = _fichaPrd.contEmp;
                        _descEmpSel = _fichaPrd.nombreEmp;
                        _empaqueSelEsPorUnidad = false;
                        _costMov = _fichaPrd.costo;
                        _costUndMov = _fichaPrd.costoUnd;
                        _costoEmpUndMonedaLocal = _fichaPrd.costoUnd;
                        if (_fichaPrd.esAdmDivisa)
                        {
                            _costMov = Math.Round(_fichaPrd.costoDivisa, 2, MidpointRounding.AwayFromZero);
                            _costUndMov = Math.Round(_fichaPrd.costoDivisaUnd, 2, MidpointRounding.AwayFromZero);
                        }
                        break;
                    case "2":
                        _idEmpSel = "2";
                        _contEmpSel = 1;
                        _descEmpSel = "UNIDAD";
                        _empaqueSelEsPorUnidad = true;
                        _costMov = _fichaPrd.costoUnd;
                        _costUndMov = _fichaPrd.costoUnd;
                        _costoEmpUndMonedaLocal = _fichaPrd.costoUnd;
                        if (_fichaPrd.esAdmDivisa)
                        {
                            _costMov = Math.Round(_fichaPrd.costoDivisaUnd, 2, MidpointRounding.AwayFromZero);
                            _costUndMov = Math.Round(_fichaPrd.costoDivisaUnd, 2, MidpointRounding.AwayFromZero);
                        }
                        break;
                    case "3":
                        _idEmpSel = "3";
                        _contEmpSel = _fichaPrd.contEmpInv;
                        _descEmpSel = _fichaPrd.nombreEmpInv;
                        _empaqueSelEsPorUnidad = false;
                        _costMov = _fichaPrd.costoUnd * _fichaPrd.contEmpInv;
                        _costUndMov = _fichaPrd.costoUnd;
                        _costoEmpUndMonedaLocal = _fichaPrd.costoUnd;
                        if (_fichaPrd.esAdmDivisa)
                        {
                            _costMov = Math.Round(_fichaPrd.costoDivisaUnd * _fichaPrd.contEmpInv, 2, MidpointRounding.AwayFromZero);
                            _costUndMov = Math.Round(_fichaPrd.costoDivisaUnd, 2, MidpointRounding.AwayFromZero);
                        }
                        break;
                }
            }
            Actualizar();
        }


        private void Actualizar()
        {
            _costUndMov = 0m;
            if (_contEmpSel > 0) 
            {
                _costUndMov = _costMov / _contEmpSel;
            }
            _importe = _costMov * _cntMov * _signo;
            _cntUndMov = _cntMov * _contEmpSel;
        }
        private decimal CalculaImporteDivisa()
        {
            var rt = 0m;
            if (_fichaPrd.esAdmDivisa)
            {
                rt = _importe;
            }
            else
            {
                if (_tasaCambio > 0)
                {
                    rt = _importe / _tasaCambio;
                }
            }
            return rt;
        }
        private decimal CalculaImporteMonedaLocal()
        {
            var rt = 0m;
            if (_fichaPrd.esAdmDivisa)
            {
                rt = _importe*_tasaCambio;
            }
            else
            {
                rt = _importe ;
            }
            return rt;
        }
    }
}