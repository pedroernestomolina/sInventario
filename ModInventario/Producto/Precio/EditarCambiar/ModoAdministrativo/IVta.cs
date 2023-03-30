using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Precio.EditarCambiar.ModoAdministrativo
{
    public enum enumMetCalUtilidad { SinDefinir = -1, Financiero = 1, Lineal };

    public struct data
    {
        public int contEmpVenta;
        public decimal utilidad;
        public decimal costo;
        public int contEmpCompra;
        public bool esDivisa;
        public decimal tasaCambio;
        public decimal tasaIva;
        public decimal neto;
        public enumMetCalUtilidad metodoCalculoUt;
        public string descEmpVenta;
        public int idPrecio;
    }

    public interface IVta
    {
        string Get_EmpaqueDesc { get; }
        int Get_EmpaqueCont { get;  }
        decimal Get_UtilidadNueva { get; }
        decimal Get_Pneto { get; }
        decimal Get_PFull { get; }
        decimal Get_UtilidadActual { get; }
        decimal Get_Pneto_OtraMoneda { get; }
        decimal Get_PFULL_OtraMoneda { get; }
        bool Get_ERROR { get; }

        void setData(data reg);
        void setUtilidad(decimal monto);
        void setPneto(decimal monto);
        void setPFull(decimal monto);

        void Inicializa();

        bool IsOk();
        string msgError { get; }

        decimal FullDivisaGrabar { get; }
        decimal NetoGrabar { get; }
        decimal UtilidadGrabar { get; }
        int IdPrecioVentaRef { get; }
    }
}