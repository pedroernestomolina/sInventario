using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.MovInventario
{
    public class ImpDataPrd: IDataPrd
    {
        private data _data;


        public string PrdAuto { get { return _data != null ? _data.autoPrd : ""; } }
        public string PrdCodigo { get { return _data != null ? _data.codigoPrd : ""; } }
        public string PrdDescripcion { get { return _data != null ? _data.nombrePrd : ""; } }
        public string InfProductoDesc 
        { 
            get 
            {
                var rt="";
                if (_data!=null)
                {
                    rt=_data.codigoPrd + Environment.NewLine + _data.nombrePrd;
                }
                return rt;
            } 
        }
        public string InfProductoEmpaCompra 
        {
            get 
            {
                var rt="";
                if (_data!=null)
                {
                    rt=_data.nombreEmp + "(" + _data.contEmp.ToString() + ")";
                }
                return rt;
            }
        }
        public string InfProductoEmpInventario 
        { 
            get 
            { 
                var rt="";
                if (_data!=null)
                {
                 rt=_data.nombreEmpInv + "(" + _data.contEmpInv.ToString() + ")";
                }
                return rt;
            }
        }
        public string InfProductoEmpUnidad 
        { 
            get 
            { 
                var rt="";
                if (_data!=null)
                {
                    rt="Unidad" + "(" + 1.ToString() + ")";
                }
                return rt;
            } 
        }
        public string InfProductoEsAdmDivisa
        {
            get
            {
                var rt="";
                if (_data!=null)
                {
                    rt=_data.esAdmDivisa ? "SI" : "NO";
                }
                return rt;
            }
        }
        public string InfProductoTasaIva 
        {
            get
            {
                var rt="";
                if (_data!=null)
                {
                    rt = "EXENTO";
                    if (_data.valorTasa > 0)
                        rt = _data.descTasa + "( " + _data.valorTasa.ToString("n2") + " )";
                }
                return rt;
            }
        }
        public string InfProductoFechaUltActCosto 
        {
            get 
            { 
                var rt="";
                if (_data != null)
                {
                    rt = _data.fechaUltimaActCosto;
                }
                return rt;
            } 
        }

        public decimal InfExistenciaActual 
        { 
            get 
            {
                var rt = 0m;
                if (_data != null)
                {
                    rt = _data.exFisica;
                }
                return rt;
            } 
        }
        public bool InfProductoEsDivisa
        {
            get 
            {
                var rt = false;
                if (_data != null)
                {
                    rt = _data.esAdmDivisa;
                }
                return rt;
            }
        }


        public ImpDataPrd()
        {
            _data = null;
        }


        public data GetFicha { get { return _data; } }
        public void setFicha(data dat)
        {
            _data = dat;
        }

        public void Inicializa()
        {
            _data = null;
        }
    }
}