using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Tool.AjusteNivelMinimoMaximoProducto
{
    
    public class GestionAjuste
    {

        private data _ficha;
        private decimal _minimo;
        private decimal _maximo;
        private bool _abandonarIsOk;
        private bool _procesarIsOk;
        private bool _restaurarValoresOriginalesIsOk;


        public string Producto { get { return _ficha.ToString(); } }
        public decimal Existencia { get { return _ficha.ExFisica; } }
        public bool ProductoEsPesado { get { return _ficha.EsPesado; } }
        public decimal GetMinimo { get { return _minimo; } }
        public decimal GetMaximo { get { return _maximo; } }
        public bool ProcesarIsOk { get { return _procesarIsOk; } }


        public GestionAjuste()
        {
            _ficha = null;            
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _restaurarValoresOriginalesIsOk = false;
            _minimo = 0m;
            _maximo = 0m;
        }


        public void Inicializa() 
        {
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _restaurarValoresOriginalesIsOk = false;
            _minimo = 0m;
            _maximo = 0m;
        }
        AjustarFrm frm ;
        public void Inicia() 
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new AjustarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public void setFicha(data ficha)
        {
            _ficha = ficha;
            _minimo = ficha.Minimo;
            _maximo= ficha.Maximo;
        }

        public void Procesar()
        {
            _procesarIsOk = false;
            if (_minimo > _maximo) 
            {
                Helpers.Msg.Error("Nivel Mínimo Incorrecto");
                return;
            }
            _procesarIsOk = true;
        }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = true;
        }

        public bool RestaurarValoresOriginalesIsOk { get { return _restaurarValoresOriginalesIsOk; } }
        public void RestaurarValoresOriginales()
        {
            _restaurarValoresOriginalesIsOk = false;
            _minimo = _ficha.Ficha.nivelMinimo;
            _maximo= _ficha.Ficha.nivelOptimo;
            _restaurarValoresOriginalesIsOk = true;
        }


        public void setMinimo(decimal xmin)
        {
            _minimo = xmin;
        }
        public void setMaximo(decimal xmax)
        {
            _maximo = xmax;
        }


        private bool CargarData()
        {
            return true;
        }

    }

}