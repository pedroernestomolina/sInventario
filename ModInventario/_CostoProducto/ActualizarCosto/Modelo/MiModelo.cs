using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario._CostoProducto.ActualizarCosto.Modelo
{
    public class MiModelo
    {
        private Producto _producto;
        //
        public string Get_DescProducto { get { return _producto == null ? "" : _producto.Get_DescProducto; } }
        public string Get_TasaCambio { get { return _producto == null ? "" : ""; } }
        public string Get_CostoFinal_Und { get { return _producto == null ? "" : _producto.Get_CostoFinal_Und; } }
        public string Get_AdmDivisa { get { return _producto == null ? "" : _producto.Get_AdmDivisa; } }
        public string Get_DescTasaIva { get { return _producto == null ? "" : _producto.Get_DescTasaIva; } }
        public string Get_FechaUltActCosto { get { return _producto == null ? "" : _producto.Get_FechaUltActCosto; } }
        public string Get_DescEmqCompra { get { return _producto == null ? "" : _producto.Get_DescEmqCompra; } }
        //
        public MiModelo()
        {
        }
        public void Inicializa()
        {
            _producto = null;
        }
        public void setPrdEditarCosto(Producto prd)
        {
            _producto = prd;
        }
    }
}