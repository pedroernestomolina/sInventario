using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Tool.AjusteNivelMinimoMaximoProducto
{
    public class data
    {
        private decimal _minimo;
        private decimal _maximo;
        private bool _isEmpaqueCompraMostrar;
        private data it;
        //
        public OOB.LibInventario.Tool.AjusteNivelMinimoMaximoProducto.Capturar.Ficha Ficha { get; set; }
        public string CodigoPrd { get { return Ficha.codigoProducto; } }
        public string NombrePrd { get { return Ficha.nombreProducto; } }
        public bool EsPesado { get { return Ficha.esPesado; } }
        public string Estatus { get { return Ficha.Estatus; } }
        public string Empaque
        { 
            get 
            { 
                var rt ="UNIDAD";
                if (_isEmpaqueCompraMostrar)
                {
                    rt=Ficha.descEmpqCompra.Trim()+"/"+Ficha.contEmpqCompra.ToString();
                }
                return rt;
            } 
        }
        public decimal ExFisica
        {
            get
            {
                var rt = Ficha.fisica;
                if (_isEmpaqueCompraMostrar)
                {
                    rt = 0m;
                    if (Ficha.contEmpqCompra > 0m)
                    {
                        rt = Ficha.fisica / Ficha.contEmpqCompra;
                        rt = Math.Truncate(rt);
                    }
                }
                return rt;
            }
        }
        public decimal Minimo 
        { 
            get 
            {
                var rt = _minimo;
                if (_isEmpaqueCompraMostrar)
                {
                    rt = 0m;
                    if (Ficha.contEmpqCompra > 0m)
                    {
                        rt = _minimo / Ficha.contEmpqCompra;
                        rt = Math.Truncate(rt);
                    }
                }
                return rt;
            } 
        }
        public decimal Maximo 
        { 
            get 
            {
                var rt = _maximo;
                if (_isEmpaqueCompraMostrar)
                {
                    rt = 0m;
                    if (Ficha.contEmpqCompra > 0m)
                    {
                        rt = _maximo / Ficha.contEmpqCompra;
                        rt = Math.Truncate(rt);
                    }
                }
                return rt;
            } 
        }
        public bool IsEditado 
        { 
            get 
            { 
                var rt=false;
                var _contenido = _isEmpaqueCompraMostrar ? Ficha.contEmpqCompra : 1M;
                if (Ficha.nivelMinimo != Minimo*_contenido || Ficha.nivelOptimo != Maximo*_contenido) 
                {
                    rt = true;
                }
                return rt;
            }
        }
        //
        public data(OOB.LibInventario.Tool.AjusteNivelMinimoMaximoProducto.Capturar.Ficha it, bool isEmpaqueCompraMostrar)
        {
            Ficha = it;
            setMinimo(it.nivelMinimo);
            setMaximo(it.nivelOptimo);
            _isEmpaqueCompraMostrar = isEmpaqueCompraMostrar;
        }
        public data(data it, bool isEmpaqueCompraMostrar)
        {
            _isEmpaqueCompraMostrar = isEmpaqueCompraMostrar;
            var _contenido = 1M;
            if (isEmpaqueCompraMostrar) 
            {
                _contenido = it.Ficha.contEmpqCompra;
            }
            Ficha = it.Ficha;
            setMinimo(it.Minimo *_contenido);
            setMaximo(it.Maximo *_contenido);
        }
        //
        public void setMinimo(decimal v) 
        {
            _minimo = v;
        }
        public void setMaximo(decimal v)
        {
            _maximo = v;
        }
        public override string ToString()
        {
            var d = "";
            d = Ficha.codigoProducto;
            d += Environment.NewLine;
            d += Ficha.nombreProducto;
            return d;
        }

        public bool ModoEmpaqueMostrarIsCompra { get { return _isEmpaqueCompraMostrar; } }
        public void setModoEmpaqueMostrarIsCompra(bool modo)
        {
            _isEmpaqueCompraMostrar = modo;
        }
    }
}