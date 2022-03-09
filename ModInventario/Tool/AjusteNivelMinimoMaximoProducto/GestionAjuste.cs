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


        public bool AjusteIsOk { get; set; }
        public string Producto { get { return _ficha.ToString(); } }
        public decimal Existencia { get { return _ficha.ExFisica; } }
        public bool ProductoEsPesado { get { return _ficha.EsPesado; } }
        public decimal Minimo 
        {
            get { return _minimo; }
            set {  _minimo= value; }
        }
        public decimal Maximo
        {
            get { return _maximo; }
            set { _maximo = value; }
        }


        public GestionAjuste()
        {
        }


        public void Inicia(data ficha) 
        {
            AjusteIsOk = false;
            setData(ficha);
            var frm = new AjustarFrm();
            frm.setControlador(this);
            frm.ShowDialog();
        }

        public void setData(data ficha)
        {
            _ficha = ficha;
            _minimo = ficha.Minimo;
            _maximo= ficha.Maximo;
        }

        public void Procesar()
        {
            if (_minimo > _maximo) 
            {
                Helpers.Msg.Error("Nivel Mínimo Incorrecto");
                return;
            }

            AjusteIsOk = true;
        }

    }

}