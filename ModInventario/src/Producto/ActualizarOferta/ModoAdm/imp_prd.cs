using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Producto.ActualizarOferta.ModoAdm
{
    public class imp_prd: IPrd
    {
        private sFicha _ficha;
        private IVta _vta1;
        private IVta _vta2;
        private IVta _vta3;

        public string GetDescripcion { get { return _ficha.GetDescripcion; } }
        public string GetTasaCambioDesc { get { return _ficha.GetTasaCambioDesc; } }
        public string GetMetodoCalUtilidadDesc { get { return _ficha.GetMetCalcUtilidadDesc; } }
        public string GetAdmDivisaDesc { get { return _ficha.GetAdmDivisaDesc; } }
        public string GetTasaIvaDesc { get { return _ficha.GetTasaIvaDesc; } }
        public IVta Vta1 { get { return _vta1; } }
        public IVta Vta2 { get { return _vta2; } }
        public IVta Vta3 { get { return _vta3; } }


        public imp_prd()
        {
            _vta1 = new imp_vta();
            _vta2 = new imp_vta();
            _vta3 = new imp_vta();
        }


        public void Inicializa()
        {
            _vta1.Inicializa();
            _vta2.Inicializa();
            _vta3.Inicializa();
        }
        public void setdataPrd(sFicha ficha)
        {
            _ficha = ficha;
        }
        public void setdataVta1(sVta vta, decimal tasaIva)
        {
            _vta1.setData(vta);
            _vta1.setTasaIva(tasaIva);
        }
        public void setdataVta2(sVta vta, decimal tasaIva)
        {
            _vta2.setData(vta);
            _vta2.setTasaIva(tasaIva);
        }
        public void setdataVta3(sVta vta, decimal tasaIva)
        {
            _vta3.setData(vta);
            _vta3.setTasaIva(tasaIva);
        }
    }
}