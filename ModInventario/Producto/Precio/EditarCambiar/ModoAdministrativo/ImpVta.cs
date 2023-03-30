using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Precio.EditarCambiar.ModoAdministrativo
{
    public class ImpVta: IVta
    {
        private dataPrecio _precio;
        private int _idPrecioVenta;


        public string Get_EmpaqueDesc { get { return _precio.EmpaqueDesc; } }
        public int Get_EmpaqueCont { get { return _precio.Contenido; } }
        public decimal Get_UtilidadNueva { get { return _precio.Utilidad; } }
        public decimal Get_Pneto { get { return _precio.Neto; } }
        public decimal Get_PFull { get { return _precio.Full; } }
        public decimal Get_UtilidadActual { get { return _precio.UtilidadActual; } }
        public decimal  Get_Pneto_OtraMoneda { get { return _precio.Neto_OtraMoneda; } }
        public decimal Get_PFULL_OtraMoneda { get { return _precio.Full_OtraMoneda; } }
        public bool Get_ERROR { get { return _precio.IsError; } }


        public ImpVta()
        {
            _precio = new dataPrecio();
            _idPrecioVenta = -1;
        }


        public void Inicializa()
        {
            _precio.Inicializa();
            _idPrecioVenta = -1;
        }


        public void setData(data dat)
        {
            _precio.setContenido(dat.contEmpVenta);
            _precio.setUtilidadActual(dat.utilidad );
            _precio.setCostoEmpCompra(dat.costo);
            _precio.setContEmpCompra(dat.contEmpCompra);
            _precio.setAdmDivisa(dat.esDivisa);
            _precio.setTasaCambio(dat.tasaCambio);
            _precio.setTasaIva(dat.tasaIva);
            _precio.setMetodoCalculoUtilidad((dataPrecio.enumMetCalUtilidad)dat.metodoCalculoUt);
            _precio.setNeto(dat.neto);
            _precio.setEmpDescVenta(dat.descEmpVenta);
            _idPrecioVenta = dat.idPrecio;
        }
        public void setUtilidad(decimal monto)
        {
            _precio.setUtilidadNueva(monto);
        }
        public void setPneto(decimal monto)
        {
            _precio.setNeto(monto);
        }
        public void setPFull(decimal monto)
        {
            _precio.setFull(monto);
        }


        public string msgError { get { return _precio.msgError; } }
        public bool IsOk()
        {
            return _precio.IsOk();
        }


        public decimal FullDivisaGrabar { get { return Math.Round(_precio.Full_Divisa, 2, MidpointRounding.AwayFromZero); } }
        public decimal NetoGrabar { get { return Math.Round(_precio.Neto_MonedaLocal, 2, MidpointRounding.AwayFromZero); } }
        public decimal UtilidadGrabar { get { return Math.Round(_precio.Utilidad, 2, MidpointRounding.AwayFromZero); } }
        public int IdPrecioVentaRef { get { return _idPrecioVenta; } }
    }
}