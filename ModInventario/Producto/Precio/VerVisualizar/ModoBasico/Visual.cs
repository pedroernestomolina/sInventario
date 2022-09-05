using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Precio.VerVisualizar.ModoBasico
{

    public class Visual: IVisualBasico
    {


        private string _idPrd;
        private data _ficha;
        private decimal _tasaCambio;
        private string _metodoCalculoUt;


        public Visual() 
        {
            _idPrd = "";
            _ficha = new data();
            _tasaCambio = 0m;
            _metodoCalculoUt = "";
        }


        public void Inicializa()
        {
            _ficha.Inicializa();
        }
        VisualFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new VisualFrm();
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
            if (_idPrd == "")
            {
                Helpers.Msg.Error("[ ID ] PRODUCTO NO PUEDE ESTAR VACIO");
                return false;
            }
            var r01 = Sistema.MyData.Producto_Precio_GetById(_idPrd);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            var r02 = Sistema.MyData.Configuracion_TasaCambioActual();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            var r03 = Sistema.MyData.Configuracion_MetodoCalculoUtilidad();
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            _metodoCalculoUt = "FINANCIERO";
            if (((OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad)r03.Entidad) == OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad.Lineal) 
            {
                _metodoCalculoUt = "LINEAL";
            }
            _tasaCambio = r02.Entidad;
            _ficha.Producto = r01.Entidad.codigo + Environment.NewLine + r01.Entidad.descripcion;
            _ficha.TasaIva = r01.Entidad.tasaIva;
            _ficha.AdmDivisa = r01.Entidad.estatusDivisa;


            _ficha.emp1_1.setData("PRECIO 1", 
                                    r01.Entidad.contEmp1_1, 
                                    r01.Entidad.descEmp1_1, 
                                    r01.Entidad.pnEmp1_1, 
                                    r01.Entidad.pfdEmp1_1, 
                                    r01.Entidad.utEmp1_1, 
                                    r01.Entidad.tasaIva);
            _ficha.emp1_2.setData("PRECIO 2",
                                    r01.Entidad.contEmp1_2,
                                    r01.Entidad.descEmp1_2,
                                    r01.Entidad.pnEmp1_2,
                                    r01.Entidad.pfdEmp1_2,
                                    r01.Entidad.utEmp1_2,
                                    r01.Entidad.tasaIva);
            _ficha.emp1_3.setData("PRECIO 3",
                                    r01.Entidad.contEmp1_3,
                                    r01.Entidad.descEmp1_3,
                                    r01.Entidad.pnEmp1_3,
                                    r01.Entidad.pfdEmp1_3,
                                    r01.Entidad.utEmp1_3,
                                    r01.Entidad.tasaIva);
            return true;
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