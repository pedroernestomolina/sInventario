using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Precio.VerVisualizar.ModoAdm
{
    public class ImpVisualAdm: ModoBasico.IVisualBasico
    {
        private string _idPrd;
        private ModoBasico.data _ficha;
        private decimal _tasaCambio;
        private string _metodoCalculoUt;


        public ImpVisualAdm() 
        {
            _idPrd = "";
            _ficha = new ModoBasico.data();
            _tasaCambio = 0m;
            _metodoCalculoUt = "";
        }


        public void Inicializa()
        {
            _ficha.Inicializa();
        }
        ModoBasico.VisualFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new ModoBasico.VisualFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        public void setFichaVisualizar(string idPrd)
        {
            _idPrd = idPrd;
        }


        private bool CargarData()
        {
            try
            {
                if (_idPrd == "")
                {
                    throw new Exception("[ ID ] PRODUCTO NO PUEDE ESTAR VACIO");
                }
                var r01 = Sistema.MyData.Producto_ModoAdm_GetPrecio_By(_idPrd, "1");
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return false;
                }
                var r02 = Sistema.MyData.Configuracion_TasaCambioActual();
                if (r02.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r02.Mensaje);
                }
                var r03 = Sistema.MyData.Configuracion_MetodoCalculoUtilidad();
                if (r03.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r03.Mensaje);
                }

                _metodoCalculoUt = "FINANCIERO";
                if (((OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad)r03.Entidad) == OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad.Lineal)
                {
                    _metodoCalculoUt = "LINEAL";
                }
                _tasaCambio = r02.Entidad;
                var _fichaPrd= r01.Entidad.entidad;
                _ficha.Producto = _fichaPrd.codigo + Environment.NewLine + _fichaPrd.descripcion;
                _ficha.TasaIva = _fichaPrd.tasaIva;
                _ficha.AdmDivisa = _fichaPrd.estatusDivisa;
                foreach (var rg in r01.Entidad.precios) 
                {
                    switch (rg.tipoEmp) 
                    {
                        case "1":
                            _ficha.emp1_1.setData("VENTA/EMP(1)",rg.contEmp, rg.descEmp, rg.pnEmp,rg.pfdEmp,rg.utEmp, _fichaPrd.tasaIva);
                            break;
                        case "2":
                            _ficha.emp1_2.setData("VENTA/EMP(2)", rg.contEmp, rg.descEmp, rg.pnEmp, rg.pfdEmp, rg.utEmp, _fichaPrd.tasaIva);
                            break;
                        case "3":
                            _ficha.emp1_3.setData("VENTA/EMP(3)", rg.contEmp, rg.descEmp, rg.pnEmp, rg.pfdEmp, rg.utEmp, _fichaPrd.tasaIva);
                            break;
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }


        public string GetProductoInfo { get { return _ficha.Producto; } }
        public string GetProductoAdmDivisa { get { return _ficha.ProductoAdmDivisa; } }
        public string GetProductoIva { get { return _ficha.ProductoIva; } }
        public decimal GetTasaCambio { get { return _tasaCambio; } }
        public string GetMetodoCalculoUtilidad { get { return _metodoCalculoUt; } }

        public dataEmp Emp1_1 { get { return _ficha.emp1_1; } }
        public dataEmp Emp1_2 { get { return _ficha.emp1_2; } }
        public dataEmp Emp1_3 { get { return _ficha.emp1_3; } }
    }
}