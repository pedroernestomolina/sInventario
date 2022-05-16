using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Precio.ModoSucursal.Editar
{
    
    public class dataProducto
    {

        private string _codigo;
        private string _desc;
        private string _auto;
        private string _empCompraDesc;
        private int _contEmpCompra;
        private decimal _costoEmpCompra;
        private string _metodoCalculoUT;
        private decimal _tasaCambio;
        private string _admDivisaDesc;
        private decimal _tasaIva;
        private string _fechaUltAct;
        private bool _esAdmDivisa;


        public string InfPrd { get { return _codigo + Environment.NewLine + _desc; } }
        public string InfEmpCompra { get { return _empCompraDesc + "(" + _contEmpCompra.ToString() + ")"; } }
        public decimal InfCostoEmpCompra { get { return _costoEmpCompra; } }
        public string InfMetodoCalculoUt { get { return _metodoCalculoUT; } }
        public decimal InfTasaCambio { get { return _tasaCambio; } }
        public string InfAdmDivisaDesc { get { return _admDivisaDesc; } }
        public decimal InfTasaIva { get { return _tasaIva; } }
        public string InfFechaUltAct { get { return _fechaUltAct; } }
        public bool InfEsAdmDivisa { get { return _esAdmDivisa; } }
        public decimal InfCostoUnd 
        {
            get 
            {
                var rt = 0m;
                if (_contEmpCompra > 0)
                {
                    rt = _costoEmpCompra / _contEmpCompra;
                }
                return rt;
            }
        }


        public dataProducto() 
        {
            limpiar();
        }

        public void Inicializa()
        {
            limpiar();
        }
        public void setCodigo(string p)
        {
            _codigo = p;
        }
        public void setDescripcion(string p)
        {
            _desc = p;
        }
        public void setAuto(string p)
        {
            _auto = p;
        }
        public void setEmpaqueCompraDesc(string p)
        {
            _empCompraDesc = p;
        }
        public void setContEmpaqueCompraDesc(int p)
        {
            _contEmpCompra = p;
        }
        public void setCostoEmpCompra(decimal p)
        {
            _costoEmpCompra = p;
        }
        public void setMetodoCalculoUt(string p)
        {
            _metodoCalculoUT = p;
        }
        public void setTasaCambioPrd(decimal p)
        {
            _tasaCambio = p;
        }
        public void setAdmDivisaDesc(string p)
        {
            _admDivisaDesc = p;
        }
        public void setTasaIvaPrd(decimal p)
        {
            _tasaIva = p;
        }
        public void setFechaUltActPrd(string fecha)
        {
            _fechaUltAct = fecha;
        }
        public void setEsAdmDivisa(bool p)
        {
            _esAdmDivisa = p;
        }


        private void limpiar()
        {
            _auto = "";
            _codigo = "";
            _desc = "";
            _empCompraDesc = "";
            _contEmpCompra = 0;
            _metodoCalculoUT = "";
            _tasaCambio = 0m;
            _admDivisaDesc = "";
            _tasaIva = 0m;
            _fechaUltAct = "";
            _esAdmDivisa = false;
        }

    }

}
