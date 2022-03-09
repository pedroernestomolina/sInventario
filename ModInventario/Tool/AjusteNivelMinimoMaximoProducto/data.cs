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


        public OOB.LibInventario.Tool.AjusteNivelMinimoMaximoProducto.Capturar.Ficha Ficha { get; set; }
        public string CodigoPrd { get { return Ficha.codigoProducto; } }
        public string NombrePrd { get { return Ficha.nombreProducto; } }
        public decimal ExFisica { get { return Ficha.fisica; } }
        public decimal Minimo { get { return _minimo; } }
        public decimal Maximo { get { return _maximo; } }
        public bool EsPesado { get { return Ficha.esPesado; } }
        public string Estatus { get { return Ficha.Estatus; } }
        public bool IsEditado 
        { 
            get 
            { 
                var rt=false;
                if (Ficha.nivelMinimo != Minimo || Ficha.nivelOptimo != Maximo) 
                {
                    rt = true;
                }
                return rt;
            }
        }


        public data(OOB.LibInventario.Tool.AjusteNivelMinimoMaximoProducto.Capturar.Ficha it)
        {
            Ficha = it;
            setMinimo(it.nivelMinimo);
            setMaximo(it.nivelOptimo);
        }

        public data(data it)
        {
            Ficha = it.Ficha;
            setMinimo(it.Minimo );
            setMaximo(it.Maximo );
        }


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

    }

}